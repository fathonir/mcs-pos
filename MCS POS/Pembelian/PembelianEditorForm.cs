using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MCS_POS.Pembelian
{
    public partial class PembelianEditorForm : MCS_POS.EditorBaseForm
    {
        public new Model.Departemen DepartemenAktif { get; set; }
        public new Model.User UserLogin { get; set; }
        public new List<Model.Config> Configs { get; set; }

        // Handle object pembelian
        private Model.Pembelian pembelian { get; set; }

        // Untuk transaksional
        private Model.Item selectedItem { get; set; }
        private DataTable DGVDataTable { get; set; }

        public PembelianEditorForm()
        {
            InitializeComponent();
        }

        private void PembelianEditorForm_Load(object sender, EventArgs e)
        {
            // Fill Supplier ComboBox
            SupplierComboBox.DataSource = Model.Supplier.GetEnumerable(DbConnection);
            SupplierComboBox.DisplayMember = "nama_supplier";
            SupplierComboBox.ValueMember = "id_supplier";

            if (this.EditorMode == EditMode.Add)
            {
                // Create Object Pembelian;
                pembelian = new Model.Pembelian();
                pembelian.ID_Pembelian = -1; // pembelian baru
                pembelian.PembelianDetails = new List<Model.PembelianDetail>();
                pembelian.ID_User = this.UserLogin.ID_User;
                pembelian.User = this.UserLogin;
                pembelian.ID_Departemen = this.DepartemenAktif.ID_Departemen;
                pembelian.Departemen = this.DepartemenAktif;
                pembelian.Kode_Transaksi = Model.Pembelian.GenerateKodeTransaksi(DbConnection, DepartemenAktif, Configs);

                // Tampilkan ke form
                UserTextBox.Text = this.UserLogin.Nama_User;
                KodeTransaksiTextBox.Text = pembelian.Kode_Transaksi;

                // Recursively Update Timer
                timer1.Start();
            }
            else if (this.EditorMode == EditMode.Edit)
            {
                pembelian = Model.Pembelian.GetSingle(DbConnection, this.ID);

                // Load ke tampilan
                UserTextBox.Text = pembelian.User.Nama_User;
                KodeTransaksiTextBox.Text = pembelian.Kode_Transaksi;
                TanggalDTP.Value = pembelian.Waktu_Transaksi;
                SupplierComboBox.SelectedValue = pembelian.ID_Supplier;
                SubTotalTextBox.Text = pembelian.Total_Biaya.ToString("N0");
                BiayaPotonganTextBox.Text = pembelian.Biaya_Potongan.ToString("N0");
                BiayaLainTextBox.Text = pembelian.Biaya_Lain.ToString("N0");
                TotalBiayaAkhirTextBox.Text = pembelian.Total_Biaya_Akhir.ToString("N0");
                JumlahItemLabel.Text = "Jumlah Item : " + pembelian.Jumlah_Item;

                // Load ke Grid
                // urutan kolom DGV :
                // id_pembelian_detail,
                // id_pembelian
                // id_item
                // kode_item
                // nama_item
                // jumlah
                // id_satuan
                // Harga
                // Sub Total

                foreach (var pd in pembelian.PembelianDetails)
                {
                    DGV.Rows.Add(
                        pd.ID_Pembelian_Detail,
                        pd.ID_Pembelian,
                        pd.ID_Item,
                        pd.Item.Kode_Item,
                        pd.Item.Nama_Item,
                        pd.Jumlah,
                        null,  // di set setelah ditambahkan
                        pd.Harga_Beli,
                        pd.Sub_Total
                    );

                    // Setting satuan datasource
                    var satuanCell = (DataGridViewComboBoxCell)DGV.Rows[DGV.Rows.Count - 1].Cells[ColumnID_Satuan.Name];
                    satuanCell.DataSource = pd.Item.SatuanItemViews.ToList();
                    satuanCell.ValueMember = "id_satuan";
                    satuanCell.DisplayMember = "nama_satuan";

                    // Update value
                    satuanCell.Value = pd.ID_Satuan;
                }
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            // Pada saat transaksi baru
            if (EditorMode == EditMode.Add)
            {
                // Update informasi pembelian
                pembelian.Waktu_Transaksi = TanggalDTP.Value;
                pembelian.ID_Supplier = Convert.ToInt32(SupplierComboBox.SelectedValue);

                // Identifikasi row
                pembelian.Created = DateTime.Now;
                pembelian.GUID = Guid.NewGuid();

                // Konversi DGV ke Detail Pembelian
                foreach (var row in DGV.Rows.Cast<DataGridViewRow>())
                {
                    pembelian.PembelianDetails.Add(new Model.PembelianDetail() { 
                        ID_Item = Convert.ToInt32(row.Cells[ColumnID_Item.Name].Value),
                        ID_Satuan = Convert.ToInt32(row.Cells[ColumnID_Satuan.Name].Value),
                        Jumlah = int.Parse(row.Cells[ColumnJumlah.Name].Value.ToString(), NumberStyles.Number),
                        Harga_Beli = int.Parse(row.Cells[ColumnHargaBeli.Name].Value.ToString(), NumberStyles.Number),
                        Sub_Total = int.Parse(row.Cells[ColumnSubTotal.Name].Value.ToString(), NumberStyles.Number)
                    });
                }

                var transaction = this.DbConnection.BeginTransaction();

                try
                {
                    // Tambahkan ke database
                    Model.Pembelian.Add(transaction, this.pembelian);

                    // Tambahkan ke kartu stok
                    Model.KartuStok.AddPembelian(transaction, this.pembelian);

                    // Simpan transaksi
                    transaction.Commit();

                    // Tampilkan info
                    MsgBox.Info("Data pembelian berhasil ditambahkan");
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    ExceptionBox(ex);
                }
            }
            else if (this.EditorMode == EditMode.Edit)
            {
                // Update informasi pembelian
                pembelian.Waktu_Transaksi = TanggalDTP.Value;
                pembelian.ID_Supplier = Convert.ToInt32(SupplierComboBox.SelectedValue);

                // Identifikasi perubahan row
                pembelian.Modified = DateTime.Now;

                // Ambil row data yang akan insert (ID = -1)
                var newRows =
                    from row in DGV.Rows.Cast<DataGridViewRow>()
                    where row.Visible && (int)row.Cells[ColumnID_Pembelian_Detail.Name].Value == -1
                    select row;

                // Ambil row data yang akan update (ID <> -1)
                var updatedRows =
                    from row in DGV.Rows.Cast<DataGridViewRow>()
                    where row.Visible && (int)row.Cells[ColumnID_Pembelian_Detail.Name].Value != -1
                    select row;

                // Ambil row data yang akan delete (ID <> -1 && visible false)
                var deletedRows =
                    from row in DGV.Rows.Cast<DataGridViewRow>()
                    where row.Visible == false && (int)row.Cells[ColumnID_Pembelian_Detail.Name].Value != -1
                    select row;


                // =================================================
                // Urutan proses data row : DELETE > UPDATE > INSERT
                // =================================================
                // ----- DELETE -----
                foreach (var row in deletedRows)
                {
                    // Set untuk persiapan hapus
                    pembelian.PembelianDetails
                        .Single(pd => pd.ID_Pembelian_Detail == (int)row.Cells[ColumnID_Pembelian_Detail.Name].Value)
                        .ForDelete = true;
                }

                // ----- UPDATE -----
                foreach (var row in updatedRows)
                {
                    // Ambil data model pembelian detail
                    var pembelianDetail =
                        pembelian.PembelianDetails
                        .Single(pd => pd.ID_Pembelian_Detail == (int)row.Cells[ColumnID_Pembelian_Detail.Name].Value);

                    // Simpan info data lama
                    pembelianDetail.Old_Jumlah = pembelianDetail.Jumlah;
                    pembelianDetail.Old_ID_Satuan = pembelianDetail.ID_Satuan;

                    // update informasi data
                    pembelianDetail.Jumlah = Convert.ToSingle(row.Cells[ColumnJumlah.Name].Value);
                    pembelianDetail.ID_Satuan = Convert.ToInt32(row.Cells[ColumnID_Satuan.Name].Value);
                    pembelianDetail.Harga_Beli = Convert.ToInt32(row.Cells[ColumnHargaBeli.Name].Value);
                    pembelianDetail.Sub_Total = Convert.ToInt32(row.Cells[ColumnSubTotal.Name].Value);
                }

                // ----- INSERT -----
                foreach (var row in newRows)
                {
                    // tambah data row
                    pembelian.PembelianDetails.Add(new Model.PembelianDetail() {
                        ID_Pembelian_Detail = -1,
                        ID_Pembelian = this.ID,
                        ID_Item = Convert.ToInt32(row.Cells[ColumnID_Item.Name].Value),
                        ID_Satuan = Convert.ToInt32(row.Cells[ColumnID_Satuan.Name].Value),
                        Jumlah = float.Parse(row.Cells[ColumnJumlah.Name].Value.ToString(), NumberStyles.Number),
                        Harga_Beli = int.Parse(row.Cells[ColumnHargaBeli.Name].Value.ToString(), NumberStyles.Number),
                        Sub_Total = int.Parse(row.Cells[ColumnSubTotal.Name].Value.ToString(), NumberStyles.Number)
                    });
                }


                // Proses tiap row DGV
                /**
                foreach (var row in DGV.Rows.Cast<DataGridViewRow>())
                {
                    // Jika belum punya PK  --> tambahkan
                    if (row.Cells[ColumnID_Pembelian_Detail.Name].Value.Equals(-1))
                    {
                        pembelian.PembelianDetails.Add(new Model.PembelianDetail()
                        {
                            ID_Pembelian_Detail = -1,
                            ID_Pembelian = this.ID,
                            ID_Item = Convert.ToInt32(row.Cells[ColumnID_Item.Name].Value),
                            ID_Satuan = Convert.ToInt32(row.Cells[ColumnID_Satuan.Name].Value),
                            Jumlah = int.Parse(row.Cells[ColumnJumlah.Name].Value.ToString(), NumberStyles.Number),
                            Harga_Beli = int.Parse(row.Cells[ColumnHargaBeli.Name].Value.ToString(), NumberStyles.Number),
                            Sub_Total = int.Parse(row.Cells[ColumnSubTotal.Name].Value.ToString(), NumberStyles.Number)
                        });
                    }
                    else
                    {
                        var pd = pembelian.PembelianDetails[row.Index];
                        pd.ID_Pembelian_Detail = (int)row.Cells[ColumnID_Pembelian_Detail.Name].Value;
                        pd.ID_Satuan = Convert.ToInt32(row.Cells[ColumnID_Satuan.Name].Value);
                        pd.Jumlah = int.Parse(row.Cells[ColumnJumlah.Name].Value.ToString(), NumberStyles.Number);
                        pd.Harga_Beli = int.Parse(row.Cells[ColumnHargaBeli.Name].Value.ToString(), NumberStyles.Number);
                        pd.Sub_Total = int.Parse(row.Cells[ColumnSubTotal.Name].Value.ToString(), NumberStyles.Number);
                    }
                }
                 **/

                var transaction = this.DbConnection.BeginTransaction();

                try
                {
                    // Update pembelian
                    Model.Pembelian.Update(transaction, this.pembelian);

                    // Update kartu stok
                    Model.KartuStok.UpdatePembelian(transaction, this.pembelian);

                    // Simpan transaksi
                    transaction.Commit();

                    // Tampilkan info
                    MsgBox.Info("Data pembelian berhasil diupdate");
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    ExceptionBox(ex);
                }
            }

            // refresh Pembelian form jika form exist
            var pembelianForm = MdiParent.MdiChildren.FirstOrDefault(c => c.GetType() == typeof(PembelianForm));
            if (pembelianForm != null){ (pembelianForm as PembelianForm).RefreshDGV(); }

            // refresh master item jika form exist
            var masterItemForm = MdiParent.MdiChildren.FirstOrDefault(c => c.GetType() == typeof(Master.ItemForm));
            if (masterItemForm != null) { (masterItemForm as Master.ItemForm).RefreshDGV(); }

            // Close form
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TanggalDTP.Value = DateTime.Now;
        }

        private void TanggalDTP_ValueChanged(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void KodeItemTextBox_TextChanged(object sender, EventArgs e)
        {
            var kodeItem = KodeItemTextBox.Text.Trim();

            selectedItem = Model.Item.FindItemByKode(this.DbConnection, kodeItem);

            // Jika ditemukan
            if (selectedItem != null)
            {
                NamaItemLabel.Text = selectedItem.Nama_Item;

                // Ambil Satuan List
                selectedItem.SatuanItemViews = Model.Item.GetSatuanItemViews(this.DbConnection, selectedItem.ID_Item);
            }
            else if (kodeItem.Length > 0)
            {
                NamaItemLabel.Text = "Tidak ditemukan";
            }
            else if (kodeItem.Length == 0)
            {
                NamaItemLabel.Text = "Masukkan kata kunci / kode item";
            }
        }

        private void KodeItemTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.selectedItem != null)
                {
                    e.Handled = true;

                    // Dapatkan satuan dasar
                    var satuanDasar = selectedItem.SatuanItemViews.First(si => si.Is_Satuan_Dasar == true);

                    // Tambahkan ke grid
                    TambahItem(selectedItem, satuanDasar);

                    // hilangkan select
                    this.selectedItem = null;
                    this.KodeItemTextBox.Clear();
                    this.NamaItemLabel.Text = "[ITEM]";

                    // Hitung All
                    RecalculateDGV();

                    // Move ke DGV
                    DGV.Focus();

                    // ke cell jumlah
                    DGV.CurrentCell = DGV.Rows[DGV.Rows.Count - 1].Cells[ColumnJumlah.Name];
                }
            }

            if (e.KeyCode == Keys.PageDown || e.KeyCode == Keys.Down)
            {
                e.Handled = true;

                // Move ke DGV
                DGV.Focus();

                // ke cell jumlah
                if (DGV.Rows.Count > 0)
                    DGV.CurrentCell = DGV.Rows[DGV.Rows.Count - 1].Cells[ColumnJumlah.Name];
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
                TambahItem(browseItem.SelectedItem, browseItem.SelectedSatuanItemView);

                // Hitung All
                RecalculateDGV();

                // Move ke DGV
                DGV.Focus();

                // ke cell jumlah
                if (DGV.Rows.Count > 0)
                    DGV.CurrentCell = DGV.Rows[DGV.Rows.Count - 1].Cells[ColumnJumlah.Name];
            }
        }

        private void TambahItem(Model.Item item, Model.SatuanItemView satuanItemView)
        {
            // urutan kolom DGV :
            // id_pembelian_detail,
            // id_pembelian
            // id_item
            // kode_item
            // nama_item
            // jumlah
            // id_satuan
            // Harga
            // Sub Total

            // Tambah Row
            DGV.Rows.Add(new object[]  {
                -1,  // id_pembelian_detail (PK)
                pembelian.ID_Pembelian,  // id_pembelian (FK)
                item.ID_Item,  // id_item
                item.Kode_Item, // kode_item
                item.Nama_Item,  // nama_item
                1, // jumlah item 
                null,  // id_satuan  --> ditambahkan setelah data source satuan diset
                null,    // harga jual
                null     // 1 * harga jual
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

        private void NumberTextBox_Leave(object sender, EventArgs e)
        {
            float result = 0; float.TryParse((sender as TextBox).Text, out result);
            (sender as TextBox).Text = result.ToString("N0");

            if (sender == BiayaLainTextBox || sender == BiayaPotonganTextBox)
            {
                RecalculateDGV();
            }
        }

        private void NumberTextBox_Enter(object sender, EventArgs e)
        {
            float result = 0; float.TryParse((sender as TextBox).Text, NumberStyles.Number, CultureInfo.CurrentCulture, out result);
            (sender as TextBox).Text = result.ToString();
            (sender as TextBox).SelectAll();
        }

        private void NumberTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            (sender as TextBox).SelectAll();
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
                RecalculateDGV();
            }
        }

        private void DGV_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            // ambil nilai saat ini
            var currentCell = DGV.Rows[e.RowIndex].Cells[e.ColumnIndex];

            // Pastikan nilai tidak null
            if (currentCell.Value != null)
            {
                // Kolom Jumlah dan harga beli
                if (DGV.Columns[e.ColumnIndex] == ColumnJumlah || DGV.Columns[e.ColumnIndex] == ColumnHargaBeli)
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
                    RecalculateDGV();
                }
            }
        }

        private void RecalculateDGV()
        {
            // Jumlah Item
            pembelian.Jumlah_Item = DGV.Rows.Cast<DataGridViewRow>()
                .Where(row => row.Visible == true)  // Hitung yg tampil saja, yg hidden proses hapus
                .Sum(row => int.Parse(row.Cells[ColumnJumlah.Name].Value.ToString(), NumberStyles.Number));
            JumlahItemLabel.Text = "Jumlah Item : " + pembelian.Jumlah_Item;

            // Sum Total Biaya
            pembelian.Total_Biaya = DGV.Rows.Cast<DataGridViewRow>()
                .Where(row => row.Visible == true)  // Hitung yg tampil saja, yg hidden proses hapus
                .Sum(row => int.Parse(row.Cells[ColumnSubTotal.Name].Value.ToString(), NumberStyles.Number));

            // Biaya Lain
            pembelian.Biaya_Lain = int.Parse(BiayaLainTextBox.Text, NumberStyles.Number);

            // Biaya Potongan
            pembelian.Biaya_Potongan = int.Parse(BiayaPotonganTextBox.Text, NumberStyles.Number);

            // Kalkulasi biaya akhir
            pembelian.Total_Biaya_Akhir = pembelian.Total_Biaya + pembelian.Biaya_Lain - pembelian.Biaya_Potongan;
            TotalBiayaAkhirTextBox.Text = pembelian.Total_Biaya_Akhir.ToString("N0");

            // Tampilkan
            SubTotalTextBox.Text = pembelian.Total_Biaya.ToString("N0");
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
                    // Set hidden dulu
                    DGV.CurrentRow.Visible = false;
                }

                RecalculateDGV();
            }
        }

        private void DGV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.PageUp)
            {
                e.Handled = true;

                // Pindah ke kode item
                KodeItemTextBox.Focus();
            }
        }

        
    }
}