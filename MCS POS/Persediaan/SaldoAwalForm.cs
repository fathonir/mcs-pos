using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace MCS_POS.Persediaan
{
    public partial class SaldoAwalForm : MCS_POS.EditorBaseForm
    {
        public new Model.Departemen DepartemenAktif { get; set; }

        private DateTime periodeAwal { get; set; }
        private List<int> deleteList = new List<int>();

        public SaldoAwalForm()
        {
            InitializeComponent();
        }

        private void SaldoAwalForm_Load(object sender, EventArgs e)
        {
            var configs = (MdiParent as MainForm).Configs;
            
            // Load Awal Periode
            periodeAwal = DateTime.Parse(configs.First(c => c.Nama == "periode_awal").Nilai);
            PeriodeAwalDTP.Value = periodeAwal;
        }

        private void SaldoAwalForm_Shown(object sender, EventArgs e)
        {
            // Urutan Kolom DGV :
            // id_saldo_awal
            // id_item
            // kode item
            // nama item
            // jumlah
            // satuan  -> data source
            // harga beli
            // total

            var saldoAwals = Model.SaldoAwal.GetList(DbConnection, DepartemenAktif.ID_Departemen, PeriodeAwalDTP.Value);

            foreach (var sa in saldoAwals)
            {
                // Tambahkan Row
                DGV.Rows.Add(new object[] { 
                    sa.ID_Saldo_Awal,
                    sa.ID_Item,
                    sa.Item.Kode_Item,
                    sa.Item.Nama_Item,
                    sa.Jumlah,
                    null,
                    sa.Harga_Beli,
                    sa.Sub_Total
                });

                // reference last row dan cell satuan
                var lastRow = DGV.Rows[DGV.Rows.GetLastRow(DataGridViewElementStates.None)];
                var cellSatuan = (DataGridViewComboBoxCell)lastRow.Cells[ColumnID_Satuan.Name];

                // Setting data source satuan
                cellSatuan.DataSource = sa.Item.SatuanItemViews;
                cellSatuan.DisplayMember = "nama_satuan";
                cellSatuan.ValueMember = "id_satuan";

                // Set value satuan
                cellSatuan.Value = sa.ID_Satuan;
            }
        }

        private void BrowseItemButton_Click(object sender, EventArgs e)
        {
            var browseItem = new BrowseItemForm()
            {
                DepartemenAktif = this.DepartemenAktif,
                DbConnection = this.DbConnection
            };

            if (browseItem.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                // Cek Item Exist
                var itemExist = DGV.Rows.Cast<DataGridViewRow>()
                    .FirstOrDefault(row => (int)row.Cells[ColumnID_Item.Name].Value == browseItem.SelectedItem.ID_Item);

                if (itemExist == null)
                {
                    TambahItem(browseItem.SelectedItem, browseItem.SelectedSatuanItemView);
                }
                else
                {
                    MessageBox.Show(this, "Item sudah ada", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Move ke DGV
                DGV.Focus();

                // ke cell jumlah
                //if (DGV.Rows.Count > 0)
                //    DGV.CurrentCell = DGV.Rows[DGV.Rows.Count - 1].Cells[ColumnJumlah.Name];
            }
        }

        private void TambahItem(Model.Item item, Model.SatuanItemView satuanItemView)
        {
            // Urutan Kolom DGV :
            // id_saldo_awal
            // id_item
            // kode item
            // nama item
            // jumlah
            // satuan
            // harga beli
            // total

            DGV.Rows.Add(new object[] { 
                -1,
                item.ID_Item,
                item.Kode_Item,
                item.Nama_Item,
                1,
                null,
                satuanItemView.Harga_Pokok,
                0
            });

            // reference last row dan cell satuan
            var lastRow = DGV.Rows[DGV.Rows.GetLastRow(DataGridViewElementStates.None)];
            var cellSatuan = (DataGridViewComboBoxCell)lastRow.Cells[ColumnID_Satuan.Name];

            // Setting data source satuan
            cellSatuan.DataSource = item.SatuanItemViews;
            cellSatuan.DisplayMember = "nama_satuan";
            cellSatuan.ValueMember = "id_satuan";

            // Set id_satuan ke satuan dasar beserta harga beli/pokok
            lastRow.Cells[ColumnID_Satuan.Name].Value = satuanItemView.ID_Satuan;
            lastRow.Cells[ColumnHargaBeli.Name].Value = satuanItemView.Harga_Pokok;
            lastRow.Cells[ColumnSubTotal.Name].Value = 1 * satuanItemView.Harga_Pokok;
        }

        private void DGV_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            var currentCell = DGV.Rows[e.RowIndex].Cells[e.ColumnIndex];

            if (DGV.Columns[e.ColumnIndex] == ColumnHargaBeli)
            {
                if (currentCell.Value != null)
                {
                    currentCell.Value = int.Parse(currentCell.Value.ToString(), NumberStyles.Number).ToString();
                }
            }
        }

        private void DGV_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            // untuk kolom jumlah dan harga beli
            if (DGV.Columns[e.ColumnIndex] == ColumnJumlah || DGV.Columns[e.ColumnIndex] == ColumnHargaBeli)
            {
                int result = 0;
                e.Cancel = !int.TryParse(e.FormattedValue.ToString(), NumberStyles.Number, CultureInfo.CurrentCulture, out result);
            }
        }

        private void DGV_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var currentRow = DGV.Rows[e.RowIndex];
            var value = currentRow.Cells[e.ColumnIndex].Value;

            if (value != null)
            {
                int result = 0;

                // Untuk kolom jumlah dan harga beli
                if (DGV.Columns[e.ColumnIndex] == ColumnJumlah || DGV.Columns[e.ColumnIndex] == ColumnHargaBeli)
                {
                    int.TryParse(value.ToString(), NumberStyles.Number, CultureInfo.CurrentCulture, out result);
                    currentRow.Cells[e.ColumnIndex].Value = result.ToString("N0");

                    // Hitung kolom total = jumlah * harga beli
                    currentRow.Cells[ColumnSubTotal.Name].Value =
                        int.Parse(currentRow.Cells[ColumnJumlah.Name].Value.ToString(), NumberStyles.Number) *
                        int.Parse(currentRow.Cells[ColumnHargaBeli.Name].Value.ToString(), NumberStyles.Number);

                    // Hitung ulang total
                    // RecalculateDGV();
                }
            }
        }

        private void DGV_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            // Pasang handler untuk combo satuan
            if (DGV.CurrentCell.OwningColumn == ColumnID_Satuan)
            {
                var satuanCell = e.Control as ComboBox;
                // remove existing handler
                satuanCell.SelectedValueChanged -= new EventHandler(satuanCell_SelectedValueChanged);
                // add new handler
                satuanCell.SelectedValueChanged += new EventHandler(satuanCell_SelectedValueChanged);
            }
        }

        private void satuanCell_SelectedValueChanged(object sender, EventArgs e)
        {
            var satuanCell = sender as ComboBox;
            var dataSource = (satuanCell.DataSource as List<Model.SatuanItemView>);
            var currentRow = DGV.Rows[DGV.CurrentCell.RowIndex];

            if (satuanCell.SelectedValue != null && satuanCell.SelectedValue is int)
            {
                var satuanTerpilih = dataSource.SingleOrDefault(r => r.ID_Satuan == (int)satuanCell.SelectedValue);

                // Set Harga Beli
                currentRow.Cells[ColumnHargaBeli.Name].Value = satuanTerpilih.Harga_Pokok;

                // Hitung Subtotal
                currentRow.Cells[ColumnSubTotal.Name].Value =
                    int.Parse(currentRow.Cells[ColumnJumlah.Name].Value.ToString(), NumberStyles.Number) *
                    satuanTerpilih.Harga_Pokok;

                // Hitung DGV
                // RecalculateDGV();
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            // Simpan ke database

            var transaction = DbConnection.BeginTransaction();

            foreach (var row in DGV.Rows.Cast<DataGridViewRow>())
            {
                // Item Baru (ID PK = -1)
                if (row.Cells[ColumnID_Saldo_Awal.Name].Value.Equals(-1))
                {
                    // buat object
                    var saldoAwal = new Model.SaldoAwal()
                    {
                        ID_Departemen = DepartemenAktif.ID_Departemen,
                        Tanggal_Saldo_Awal = PeriodeAwalDTP.Value,
                        ID_Item = (int)row.Cells[ColumnID_Item.Name].Value,
                        Jumlah = int.Parse(row.Cells[ColumnJumlah.Name].Value.ToString(), NumberStyles.Number),
                        ID_Satuan = (int)row.Cells[ColumnID_Satuan.Name].Value,
                        Harga_Beli = int.Parse(row.Cells[ColumnHargaBeli.Name].Value.ToString(), NumberStyles.Number),
                        Sub_Total = int.Parse(row.Cells[ColumnSubTotal.Name].Value.ToString(), NumberStyles.Number),
                    };

                    // Ambil satuan
                    saldoAwal.SatuanItem = Model.SatuanItem.GetSingle(DbConnection, saldoAwal.ID_Item, saldoAwal.ID_Satuan);

                    // Insert ke DB
                    Model.SaldoAwal.Add(transaction, saldoAwal);

                    // Update id_saldo_awal
                    row.Cells[ColumnID_Saldo_Awal.Name].Value = saldoAwal.ID_Saldo_Awal;
                }
                else // Item lama
                {
                    // get object
                    var id_saldo_awal = (int)row.Cells[ColumnID_Saldo_Awal.Name].Value;
                    var saldoAwal = Model.SaldoAwal.GetSingle(DbConnection, id_saldo_awal);

                    // Update property
                    saldoAwal.Jumlah = int.Parse(row.Cells[ColumnJumlah.Name].Value.ToString(), NumberStyles.Number);
                    saldoAwal.ID_Satuan = (int)row.Cells[ColumnID_Satuan.Name].Value;
                    saldoAwal.Harga_Beli = int.Parse(row.Cells[ColumnHargaBeli.Name].Value.ToString(), NumberStyles.Number);
                    saldoAwal.Sub_Total = int.Parse(row.Cells[ColumnSubTotal.Name].Value.ToString(), NumberStyles.Number);

                    // Ambil satuan
                    saldoAwal.SatuanItem = Model.SatuanItem.GetSingle(DbConnection, saldoAwal.ID_Item, saldoAwal.ID_Satuan);

                    // Update ke DB
                    Model.SaldoAwal.Update(transaction, saldoAwal);
                }
            }

            // Penghapusan item
            foreach (var id_saldo_awal in deleteList)
            {
                // get object
                var saldoAwal = Model.SaldoAwal.GetSingle(DbConnection, id_saldo_awal);

                // Hapus dari db
                Model.SaldoAwal.Delete(transaction, saldoAwal);
            }

            transaction.Commit();

            MessageBox.Show(this, "Data berhasil disimpan", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DeleteItemButton_Click(object sender, EventArgs e)
        {
            // Pastikan ada yg terselect
            if (DGV.SelectedRows.Count != 1) { return; }

            var dialog = MessageBox.Show(this, "Apakah data ini akan dihapus ?\nPenhapusan data akan mempengaruhi stok", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialog == System.Windows.Forms.DialogResult.Yes)
            {
                // Load object
                var selectedRow = DGV.SelectedRows[0];
                var id_saldo_awal = (int)selectedRow.Cells[ColumnID_Saldo_Awal.Name].Value;

                // tambahkan ke list penghapusan untuk item yg bukan baru
                if (id_saldo_awal != -1)
                {
                    deleteList.Add(id_saldo_awal);
                }

                // Hapus
                DGV.Rows.Remove(selectedRow);
            }
        }

        private void DGV_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            Console.WriteLine("pos:" + e.RowIndex + "," + e.ColumnIndex + ": " + e.Exception.Message);
        }

        

        
    }
}
