using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Dapper;
using System.Globalization;

namespace MCS_POS.Konsinyasi
{
    public partial class KonsinyasiMasukEditorForm : MCS_POS.EditorBaseForm
    {
        public new Model.Departemen DepartemenAktif { get; set; }
        public new Model.User UserLogin { get; set; }
        public new List<Model.Config> Configs { get; set; }

        // Handle object konsinyasi
        private Model.Konsinyasi konsinyasi { get; set; }

        // Untuk transaksional
        private Model.Item selectedItem { get; set; }
        private DataTable DGVDataTable { get; set; }

        public KonsinyasiMasukEditorForm()
        {
            InitializeComponent();
        }

        private void KonsinyasiMasukEditorForm_Load(object sender, EventArgs e)
        {
            // Fill Supplier ComboBox
            SupplierComboBox.DataSource = Model.Supplier.GetEnumerable(DbConnection);
            SupplierComboBox.DisplayMember = "nama_supplier";
            SupplierComboBox.ValueMember = "id_supplier";

            if (this.EditorMode == EditMode.Add)
            {
                this.konsinyasi = new Model.Konsinyasi();
                konsinyasi.ID_Konsinyasi = -1;      // PK = -1
                konsinyasi.KonsinyasiDetails = new List<Model.KonsinyasiDetail>();
                konsinyasi.ID_User = UserLogin.ID_User;
                konsinyasi.User = UserLogin;
                konsinyasi.ID_Departemen = DepartemenAktif.ID_Departemen;
                konsinyasi.Departemen = DepartemenAktif;
                konsinyasi.Kode_Transaksi = Model.Konsinyasi.GenerateKodeTransaksi(DbConnection, DepartemenAktif, Configs);

                // Tampilkan ke form
                UserTextBox.Text = UserLogin.Nama_User;
                KodeTransaksiTextBox.Text = konsinyasi.Kode_Transaksi;

                // Jatuh tempo default : today + 10 hari
                JatuhTempoDTP.Value = DateTime.Today.AddDays(10D);

                // Debug
                System.Diagnostics.Debug.WriteLine("MDIParent: " + this.MdiParent.Text);
            }
            else if (this.EditorMode == EditMode.Edit)
            {
                konsinyasi = Model.Konsinyasi.GetSingle(DbConnection, this.ID, true, true, true, true);

                // Load ke tampilan
                UserTextBox.Text = konsinyasi.User.Nama_User;
                KodeTransaksiTextBox.Text = konsinyasi.Kode_Transaksi;
                TanggalDTP.Value = konsinyasi.Waktu_Transaksi;
                JumlahItemLabel.Text = "Jumlah Item : " + konsinyasi.Jumlah_Item;
                JatuhTempoDTP.Value = konsinyasi.Jatuh_Tempo;

                SubTotalTextBox.Text = konsinyasi.Total_Biaya.ToString("N0");
                BiayaLainTextBox.Text = konsinyasi.Biaya_Lain.ToString("N0");
                TotalBiayaAkhirTextBox.Text = konsinyasi.Total_Biaya_Akhir.ToString("N0");

                foreach (var kd in konsinyasi.KonsinyasiDetails)
                {
                    DGV.Rows.Add(new object[] { 
                        kd.ID_Konsinyasi_Detail,
                        kd.ID_Konsinyasi,
                        kd.ID_Item,
                        kd.Item.Kode_Item,
                        kd.Item.Nama_Item,
                        kd.Jumlah,
                        null,           // --> Satuan diset setelah datasource diset
                        kd.Harga_Beli,
                        kd.Sub_Total
                    });

                    // Setting satuan datasource
                    var satuanCell = (DataGridViewComboBoxCell)DGV.Rows[DGV.Rows.Count - 1].Cells[ColumnID_Satuan.Name];
                    satuanCell.DataSource = kd.Item.SatuanItemViews.ToList();
                    satuanCell.ValueMember = "id_satuan";
                    satuanCell.DisplayMember = "nama_satuan";

                    // Update value id_satuan
                    satuanCell.Value = kd.ID_Satuan;
                }
            }
        }

        private void BrowseItemButton_Click(object sender, EventArgs e)
        {
            var browseItem = new BrowseItemForm()
            {
                DepartemenAktif = this.DepartemenAktif,
                DbConnection = this.DbConnection,
                IsKonsinyasiOnly = true
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
            // id_konsinyasi_detail,
            // id_konsinyasi
            // id_item
            // kode_item
            // nama_item
            // jumlah
            // id_satuan
            // Harga
            // Sub Total

            // Tambah Row
            DGV.Rows.Add(new object[]  {
                -1,  // id_konsinyasi_detail (PK)
                konsinyasi.ID_Konsinyasi,  // id_konsinyasi (FK)
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
            konsinyasi.Jumlah_Item = DGV.Rows.Cast<DataGridViewRow>()
                .Where(row => row.Visible == true)  // Hitung yg tampil saja, yg hidden proses hapus
                .Sum(row => int.Parse(row.Cells[ColumnJumlah.Name].Value.ToString(), NumberStyles.Number));
            JumlahItemLabel.Text = "Jumlah Item : " + konsinyasi.Jumlah_Item;

            // Sum Total Biaya
            konsinyasi.Total_Biaya = DGV.Rows.Cast<DataGridViewRow>()
                .Where(row => row.Visible == true)  // Hitung yg tampil saja, yg hidden proses hapus
                .Sum(row => int.Parse(row.Cells[ColumnSubTotal.Name].Value.ToString(), NumberStyles.Number));

            // Biaya Lain
            konsinyasi.Biaya_Lain = int.Parse(BiayaLainTextBox.Text, NumberStyles.Number);

            // Kalkulasi biaya akhir
            konsinyasi.Total_Biaya_Akhir = konsinyasi.Total_Biaya + konsinyasi.Biaya_Lain;
            TotalBiayaAkhirTextBox.Text = konsinyasi.Total_Biaya_Akhir.ToString("N0");

            // Tampilkan
            SubTotalTextBox.Text = konsinyasi.Total_Biaya.ToString("N0");
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

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (EditorMode == EditMode.Add)
            {
                // Update informasi konsinyasi
                konsinyasi.Waktu_Transaksi = TanggalDTP.Value;
                konsinyasi.Jatuh_Tempo = JatuhTempoDTP.Value;
                konsinyasi.ID_Supplier = Convert.ToInt32(SupplierComboBox.SelectedValue);

                // Identifikasi row
                konsinyasi.Created = DateTime.Now;
                konsinyasi.GUID = Guid.NewGuid();

                // Konversi DGV ke Detail konsinyasi
                foreach (var row in DGV.Rows.Cast<DataGridViewRow>())
                {
                    konsinyasi.KonsinyasiDetails.Add(new Model.KonsinyasiDetail()
                    {
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
                    Model.Konsinyasi.Add(transaction, konsinyasi);

                    // Tambahkan ke kartu stok
                    Model.KartuStok.AddKonsinyasi(transaction, konsinyasi);

                    // Simpan transaksi
                    transaction.Commit();

                    // Tampilkan info
                    MsgBox.Info("Data konsinyasi berhasil ditambahkan");
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    ExceptionBox(ex);
                }
            }
            else if (EditorMode == EditMode.Edit)
            {
                // Update informasi waktu transfer
                konsinyasi.Waktu_Transaksi = TanggalDTP.Value;

                // Identifikasi user & waktu perubahan
                konsinyasi.ID_User = UserLogin.ID_User;
                konsinyasi.Modified = DateTime.Now;

                // Ambil row data yang akan insert
                var newRows =
                    from row in DGV.Rows.Cast<DataGridViewRow>()
                    where row.Visible && (int)row.Cells[ColumnID_Konsinyasi_Detail.Name].Value == -1
                    select row;

                // Ambil row data yang akan update
                var updatedRows =
                    from row in DGV.Rows.Cast<DataGridViewRow>()
                    where row.Visible && (int)row.Cells[ColumnID_Konsinyasi_Detail.Name].Value != -1
                    select row;

                // Ambil row data yang akan delete
                var deletedRows =
                    from row in DGV.Rows.Cast<DataGridViewRow>()
                    where row.Visible == false && (int)row.Cells[ColumnID_Konsinyasi_Detail.Name].Value != -1
                    select row;

                // =================================================
                // Urutan proses data row : DELETE > UPDATE > INSERT
                // =================================================
                // ----- DELETE -----
                foreach (var row in deletedRows)
                {
                    // Ambil data model konsinyasi detail
                    var konsinyasiDetail =
                        konsinyasi.KonsinyasiDetails
                        .Single(kd => kd.ID_Konsinyasi_Detail == (int)row.Cells[ColumnID_Konsinyasi_Detail.Name].Value);

                    // set untuk persiapan hapus
                    konsinyasiDetail.ForDelete = true;
                }

                // ----- UPDATE -----
                foreach (var row in updatedRows)
                {
                    // Ambil data model konsinyasi detail
                    var konsinyasiDetail =
                        konsinyasi.KonsinyasiDetails
                        .Single(kd => kd.ID_Konsinyasi_Detail == (int)row.Cells[ColumnID_Konsinyasi_Detail.Name].Value);

                    // Simpan info data lama
                    konsinyasiDetail.Old_Jumlah = konsinyasiDetail.Jumlah;
                    konsinyasiDetail.Old_ID_Satuan = konsinyasiDetail.ID_Satuan;

                    // update informasi data
                    konsinyasiDetail.Jumlah = int.Parse(row.Cells[ColumnJumlah.Name].Value.ToString());
                    konsinyasiDetail.ID_Satuan = (int)row.Cells[ColumnID_Satuan.Name].Value;
                    konsinyasiDetail.Harga_Beli = int.Parse(row.Cells[ColumnHargaBeli.Name].Value.ToString());
                    konsinyasiDetail.Sub_Total = (int)row.Cells[ColumnSubTotal.Name].Value;
                }

                // ----- INSERT -----
                foreach (var row in newRows)
                {
                    // tambah data row
                    konsinyasi.KonsinyasiDetails.Add(new Model.KonsinyasiDetail() {
                        ID_Konsinyasi_Detail = -1,    // new PK
                        ID_Konsinyasi = konsinyasi.ID_Konsinyasi, // FK
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
                    // Update ke database
                    Model.Konsinyasi.Update(transaction, konsinyasi);

                    // Update ke kartu stok
                    Model.KartuStok.UpdateKonsinyasi(transaction, konsinyasi);

                    // Simpan transaksi
                    transaction.Commit();

                    // Tampilkan info
                    MsgBox.Info("Data konsinyasi masuk berhasil diupdate");
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    ExceptionBox(ex);
                }
            }

            // refresh Konsinyasi masuk form jika form exist
            var konsinyasiMasukForm = MdiParent.MdiChildren.FirstOrDefault(c => c.GetType() == typeof(Konsinyasi.KonsinyasiMasukForm));
            if (konsinyasiMasukForm != null) { (konsinyasiMasukForm as KonsinyasiMasukForm).RefreshDGV(); }

            // Kembalikan hasil OK
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void NumberTextBox_Leave(object sender, EventArgs e)
        {
            float result = 0; float.TryParse((sender as TextBox).Text, out result);
            (sender as TextBox).Text = result.ToString("N0");

            if (sender == BiayaLainTextBox)
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

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
