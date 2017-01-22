using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MCS_POS.Konsinyasi
{
    public partial class KonsinyasiReturEditorForm : MCS_POS.EditorBaseForm
    {
        public new Model.Departemen DepartemenAktif { get; set; }
        public new Model.User UserLogin { get; set; }
        public new List<Model.Config> Configs { get; set; }

        // Handle object konsinyasi
        private Model.KonsinyasiRetur konsinyasiRetur { get; set; }

        // Untuk transaksional
        private Model.Item selectedItem { get; set; }
        private DataTable DGVDataTable { get; set; }

        public KonsinyasiReturEditorForm()
        {
            InitializeComponent();
        }

        private void KonsinyasiReturEditorForm_Load(object sender, EventArgs e)
        {
            // Fill Supplier ComboBox
            SupplierComboBox.DataSource = Model.Supplier.GetEnumerable(DbConnection);
            SupplierComboBox.DisplayMember = "nama_supplier";
            SupplierComboBox.ValueMember = "id_supplier";

            if (EditorMode == EditMode.Add)
            {
                this.konsinyasiRetur = new Model.KonsinyasiRetur() {
                    ID_Konsinyasi_Retur = -1,
                    KonsinyasiReturDetails = new List<Model.KonsinyasiReturDetail>(),
                    ID_User = this.UserLogin.ID_User,
                    User = this.UserLogin,
                    ID_Departemen = this.DepartemenAktif.ID_Departemen,
                    Departemen = this.DepartemenAktif,
                    Kode_Transaksi = Model.KonsinyasiRetur.GenerateKode(DbConnection, DepartemenAktif, this.Configs)
                };

                // Tampilkan ke form
                UserTextBox.Text = UserLogin.Nama_User;
                KodeTransaksiTextBox.Text = konsinyasiRetur.Kode_Transaksi;
            }
            else if (EditorMode == EditMode.Edit)
            {
                // --------------------------------------------------------------------
                // Tidak ada edit untuk konsinyasi retur, ada kekeliruan harus dihapus
                // --------------------------------------------------------------------
            }
        }

        private void BrowseItemButton_Click(object sender, EventArgs e)
        {
            var browseItem = new BrowseItemForm() {
                DepartemenAktif = this.DepartemenAktif,
                DbConnection = this.DbConnection,
                IsKonsinyasiOnly = true
            };

            if (browseItem.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                // Sebelum dimasukkan pastikan item yg terpilih mempunyai
                // konsinyasi yg bisa di retur.
                if (Model.Item.CanRetur(this.DbConnection, browseItem.SelectedItem, this.DepartemenAktif) == true)
                {
                    TambahItem(browseItem.SelectedItem, browseItem.SelectedSatuanItemView);

                    // Hitung All
                    RecalculateDGV();

                    // Move ke DGV
                    DGV.Focus();

                    // ke cell jumlah
                    if (DGV.Rows.Count > 0)
                        DGV.CurrentCell = DGV.Rows[DGV.Rows.Count - 1].Cells[ColumnJumlah.Name];
                }
                else
                {
                    MsgBox.Warning("Item yang dipilih tidak ada data konsinyasi yg bisa diretur");
                }
            }
        }

        private void RecalculateDGV()
        {
            // Jumlah Item
            konsinyasiRetur.Jumlah_Item = DGV.Rows.Cast<DataGridViewRow>()
                .Where(row => row.Visible == true)  // Hitung yg tampil saja, yg hidden proses hapus
                .Sum(row => int.Parse(row.Cells[ColumnJumlah.Name].Value.ToString(), NumberStyles.Number));
            JumlahItemLabel.Text = "Jumlah Item : " + konsinyasiRetur.Jumlah_Item;
        }

        private void TambahItem(Model.Item item, Model.SatuanItemView satuanItemView)
        {
            // urutan kolom DGV :
            // id_konsinyasi_retur_detail,
            // id_konsinyasi_retur
            // id_item
            // kode_item
            // nama_item
            // jumlah
            // id_satuan

            // Tambah Row
            DGV.Rows.Add(new object[]  {
                -1,  // id_konsinyasi_retur_detail (PK)
                konsinyasiRetur.ID_Konsinyasi_Retur,  // id_konsinyasi_retur (FK)
                item.ID_Item,  // id_item
                item.Kode_Item, // kode_item
                item.Nama_Item,  // nama_item
                1, // jumlah item 
                null  // id_satuan  --> ditambahkan setelah data source satuan diset
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
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (EditorMode == EditMode.Add)
            {
                // Update informasi konsinyasi retur
                konsinyasiRetur.Waktu_Transaksi = TanggalDTP.Value;
                konsinyasiRetur.ID_Supplier = Convert.ToInt32(SupplierComboBox.SelectedValue);

                // Identifikasi row
                konsinyasiRetur.Created = DateTime.Now;
                konsinyasiRetur.GUID = Guid.NewGuid();

                // Konversi DGV ke Detail konsinyasi retur
                foreach (var row in DGV.Rows.Cast<DataGridViewRow>())
                {
                    konsinyasiRetur.KonsinyasiReturDetails.Add(new Model.KonsinyasiReturDetail() {
                        ID_Item = Convert.ToInt32(row.Cells[ColumnID_Item.Name].Value),
                        ID_Satuan = Convert.ToInt32(row.Cells[ColumnID_Satuan.Name].Value),
                        Jumlah = int.Parse(row.Cells[ColumnJumlah.Name].Value.ToString(), NumberStyles.Number)
                    });
                }

                var transaction = this.DbConnection.BeginTransaction();

                try
                {
                    // Tambahkan ke database
                    Model.KonsinyasiRetur.Add(transaction, konsinyasiRetur);

                    // Tambahkan ke kartu stok
                    Model.KartuStok.AddKonsinyasiRetur(transaction, konsinyasiRetur);

                    // Simpan transaksi
                    transaction.Commit();

                    // Tampilkan info
                    MsgBox.Info("Data konsinyasi retur berhasil ditambahkan");

                    this.Close();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    ExceptionBox(ex);
                }
            }
            else if (EditorMode == EditMode.Edit)
            {
                // --------------------------------------------------------------------
                // Tidak ada edit untuk konsinyasi retur, ada kekeliruan harus dihapus
                // --------------------------------------------------------------------
            }
        }

        private void DeleteItemButton_Click(object sender, EventArgs e)
        {
            if (DGV.CurrentRow != null)
            {
                // Jika dalam mode Tambah Baru
                if (this.EditorMode == EditMode.Add)
                {
                    // Langsung hapus
                    DGV.Rows.Remove(DGV.CurrentRow);
                }
                else  // Jika dalam mode Edit
                {
                    // --------------------------------------------------------------------
                    // Tidak ada edit untuk konsinyasi retur, ada kekeliruan harus dihapus
                    // --------------------------------------------------------------------
                }

                RecalculateDGV();
            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DGV_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            // ambil nilai saat ini
            var currentCell = DGV.Rows[e.RowIndex].Cells[e.ColumnIndex];

            // Pastikan nilai tidak null
            if (currentCell.Value != null)
            {
                // Kolom Jumlah dan harga beli
                if (DGV.Columns[e.ColumnIndex] == ColumnJumlah)
                {
                    currentCell.Value = int.Parse(currentCell.Value.ToString(), NumberStyles.Number).ToString();
                }
            }
        }

        private void DGV_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            // untuk kolom jumlah dan harga beli
            if (DGV.Columns[e.ColumnIndex] == ColumnJumlah)
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
                if (DGV.Columns[e.ColumnIndex] == ColumnJumlah)
                {
                    int.TryParse(value.ToString(), NumberStyles.Number, CultureInfo.CurrentCulture, out result);
                    currentRow.Cells[e.ColumnIndex].Value = result.ToString("N0");

                    // Hitung ulang total
                    RecalculateDGV();
                }
            }
        }

        
    }
}
