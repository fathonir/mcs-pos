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
    public partial class TransferEditorForm : MCS_POS.EditorBaseForm
    {
        public new Model.Departemen DepartemenAktif { get; set; }
        public new Model.User UserLogin { get; set; }
        public new List<Model.Config> Configs { get; set; }

        // Handle transfer
        private Model.Transfer transfer { get; set; } 

        // Untuk transaksional
        private Model.Item selectedItem { get; set; }
        private DataTable dgvDataTable { get; set; }

        public TransferEditorForm()
        {
            InitializeComponent();
        }

        private void TransferEditorForm_Load(object sender, EventArgs e)
        {
            // Departemen Asal
            DepartemenAsalComboBox.DataSource = Model.Departemen.GetDepartemenForCombo(this.DbConnection);
            DepartemenAsalComboBox.DisplayMember = "nama_departemen";
            DepartemenAsalComboBox.ValueMember = "id_departemen";

            // Departemen Tujuan
            DepartemenTujuanComboBox.DataSource = Model.Departemen.GetDepartemenForCombo(this.DbConnection);
            DepartemenTujuanComboBox.DisplayMember = "nama_departemen";
            DepartemenTujuanComboBox.ValueMember = "id_departemen";
            
            if (this.EditorMode == EditMode.Add)
            {
                // Create object transfer item
                transfer = new Model.Transfer();
                transfer.ID_Transfer = -1;  // id primary key baru
                transfer.TransferDetails = new List<Model.TransferDetail>();
                transfer.ID_User = this.UserLogin.ID_User;
                transfer.User = this.UserLogin;
                transfer.Kode_Transaksi = Model.Transfer.GenerateKode(this.DbConnection, this.DepartemenAktif, this.Configs);

                // Tampilkan ke form
                UserTextBox.Text = this.UserLogin.Nama_User;
                KodeTransaksiTextBox.Text = this.transfer.Kode_Transaksi;
            }
            else if (this.EditorMode == EditMode.Edit)
            {
                transfer = Model.Transfer.GetSingle(DbConnection, this.ID, true, true);

                // Load ke tampilan
                UserTextBox.Text = transfer.User.Nama_User;
                KodeTransaksiTextBox.Text = transfer.Kode_Transaksi;
                TanggalDTP.Value = transfer.Waktu_Transaksi;
                DepartemenAsalComboBox.SelectedValue = transfer.ID_Departemen_Asal;
                DepartemenTujuanComboBox.SelectedValue = transfer.ID_Departemen_Tujuan;
                JumlahItemLabel.Text = "Jumlah Item : " + transfer.Jumlah_Item;

                // Kunci pilihan departemen asal-tujuan
                DepartemenAsalComboBox.Enabled = false;
                DepartemenTujuanComboBox.Enabled = false;

                /// Load ke Grid
                /// id_transfer_detail
                /// id_transfer
                /// id_item
                /// kode_item
                /// nama_item
                /// jumlah
                /// id_satuan
                /// harga

                foreach (var td in transfer.TransferDetails)
                {
                    DGV.Rows.Add(new object[] { 
                        td.ID_Transfer_Detail,
                        td.ID_Transfer,
                        td.ID_Item,
                        td.Item.Kode_Item,
                        td.Item.Nama_Item,
                        td.Jumlah,
                        null,           // --> Satuan diset setelah datasource diset
                        td.Harga        
                    });

                    // Setting satuan datasource
                    var satuanCell = (DataGridViewComboBoxCell)DGV.Rows[DGV.Rows.Count - 1].Cells[ColumnID_Satuan.Name];
                    satuanCell.DataSource = td.Item.SatuanItemViews.ToList();
                    satuanCell.ValueMember = "id_satuan";
                    satuanCell.DisplayMember = "nama_satuan";

                    // Update value id_satuan
                    satuanCell.Value = td.ID_Satuan;
                }
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
            /// Urutan kolom DGV :
            /// id_transfer_detail
            /// id_transfer
            /// id_item
            /// kode_item
            /// nama_item
            /// jumlah
            /// id_satuan
            /// harga_beli
            /// sub_total

            // Tambah Row
            DGV.Rows.Add(new object[] { 
                -1,                         // New Primary-Key (PK)
                this.transfer.ID_Transfer,  // (FK)
                item.ID_Item,
                item.Kode_Item,
                item.Nama_Item,
                1,                          // Jumlah default = 1
                null,                       // --> ditambahkan, setelah data source satuan diset
                null,
                null
            });

            // reference last row dan cell satuan
            var lastRow = DGV.Rows[DGV.Rows.GetLastRow(DataGridViewElementStates.None)];
            var cellSatuan = (DataGridViewComboBoxCell)lastRow.Cells[ColumnID_Satuan.Name];

            // Setting data source satuan
            cellSatuan.DataSource = item.SatuanItemViews;
            cellSatuan.DisplayMember = "nama_satuan";
            cellSatuan.ValueMember = "id_satuan";

            // Set id_satuan ke satuan dasar beserta harga beli/pokok yg terpilih
            lastRow.Cells[ColumnID_Satuan.Name].Value = satuanItemView.ID_Satuan;
            lastRow.Cells[ColumnHarga.Name].Value = satuanItemView.Harga_Pokok;
        }

        private void RecalculateDGV()
        {
            // Jumlah Item
            transfer.Jumlah_Item = DGV.Rows.Cast<DataGridViewRow>()
                .Where(row => row.Visible)  // Hitung yg tampil saja, yg hidden proses hapus
                .Sum(row => int.Parse(row.Cells[ColumnJumlah.Name].Value.ToString(), NumberStyles.Number));
            JumlahItemLabel.Text = "Jumlah Item : " + transfer.Jumlah_Item;
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
            // Memastikan asal-tujuan departemen tidak sama
            if ((int)DepartemenAsalComboBox.SelectedValue == (int)DepartemenTujuanComboBox.SelectedValue)
            {
                MsgBox.Warning("Departemen asal dan tujuan tidak boleh sama");
                return;
            }

            if (this.EditorMode == EditMode.Add)
            {
                // Update informasi waktu transfer
                transfer.Waktu_Transaksi = TanggalDTP.Value;
                transfer.ID_Departemen = this.DepartemenAktif.ID_Departemen;
                transfer.ID_Departemen_Asal = (int)DepartemenAsalComboBox.SelectedValue;
                transfer.ID_Departemen_Tujuan = (int)DepartemenTujuanComboBox.SelectedValue;

                // Identifikasi row
                transfer.Created = DateTime.Now;
                transfer.GUID = Guid.NewGuid();

                // Konversi DGV ke Detail Transfer
                foreach (var row in DGV.Rows.Cast<DataGridViewRow>())
                {
                    transfer.TransferDetails.Add(new Model.TransferDetail() {
                        ID_Item = Convert.ToInt32(row.Cells[ColumnID_Item.Name].Value),
                        ID_Satuan = Convert.ToInt32(row.Cells[ColumnID_Satuan.Name].Value),
                        Jumlah = int.Parse(row.Cells[ColumnJumlah.Name].Value.ToString(), NumberStyles.Number),
                        Harga = int.Parse(row.Cells[ColumnHarga.Name].Value.ToString(), NumberStyles.Number),
                    });
                }

                var transaction = this.DbConnection.BeginTransaction();

                try
                {
                    // Tambahkan ke database
                    Model.Transfer.Add(transaction, this.transfer);

                    // Tambahkan ke kartu stok
                    Model.KartuStok.AddTransfer(transaction, this.transfer);

                    // Simpan transaksi
                    transaction.Commit();

                    // Tampilkan info
                    MsgBox.Info("Data transfer berhasil ditambahkan");

                    // Keluar dari form
                    this.Close();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    ExceptionBox(ex);
                }
            }
            else if (this.EditorMode == EditMode.Edit)
            {
                // Update informasi waktu transfer
                transfer.Waktu_Transaksi = TanggalDTP.Value;

                // Identifikasi waktu perubahan
                transfer.Modified = DateTime.Now;

                // Ambil row data yang akan insert (ID = -1)
                var newRows =
                    from row in DGV.Rows.Cast<DataGridViewRow>()
                    where row.Visible && (int)row.Cells[ColumnID_Transfer_Detail.Name].Value == -1
                    select row;

                // Ambil row data yang akan update (ID <> -1)
                var updatedRows =
                    from row in DGV.Rows.Cast<DataGridViewRow>()
                    where row.Visible && (int)row.Cells[ColumnID_Transfer_Detail.Name].Value != -1
                    select row;

                // Ambil row data yang akan delete (ID <> -1 && visible false)
                var deletedRows =
                    from row in DGV.Rows.Cast<DataGridViewRow>()
                    where row.Visible == false && (int)row.Cells[ColumnID_Transfer_Detail.Name].Value != -1
                    select row;

                // =================================================
                // Urutan proses data row : DELETE > UPDATE > INSERT
                // =================================================
                // ----- DELETE -----
                foreach (var row in deletedRows)
                {
                    // Ambil data model transfer detail
                    var transferDetail =
                        transfer.TransferDetails
                        .Single(td => td.ID_Transfer_Detail == (int)row.Cells[ColumnID_Transfer_Detail.Name].Value);

                    // set untuk persiapan hapus
                    transferDetail.ForDelete = true;
                }

                // ----- UPDATE -----
                foreach (var row in updatedRows)
                {
                    // Ambil data model transfer detail
                    var transferDetail =
                        transfer.TransferDetails
                        .Single(td => td.ID_Transfer_Detail == (int)row.Cells[ColumnID_Transfer_Detail.Name].Value);

                    // Simpan info data lama
                    transferDetail.Old_Jumlah = transferDetail.Jumlah;
                    transferDetail.Old_ID_Satuan = transferDetail.ID_Satuan;

                    // update informasi data
                    transferDetail.Jumlah = (int)row.Cells[ColumnJumlah.Name].Value;
                    transferDetail.ID_Satuan = (int)row.Cells[ColumnID_Satuan.Name].Value;
                    transferDetail.Harga = (int)row.Cells[ColumnHarga.Name].Value;
                }

                // ----- INSERT -----
                foreach (var row in newRows)
                {
                    // tambah data row
                    transfer.TransferDetails.Add(new Model.TransferDetail() {
                        ID_Transfer_Detail = -1,    // new PK
                        ID_Transfer = transfer.ID_Transfer, // FK
                        ID_Item = Convert.ToInt32(row.Cells[ColumnID_Item.Name].Value),
                        ID_Satuan = Convert.ToInt32(row.Cells[ColumnID_Satuan.Name].Value),
                        Jumlah = int.Parse(row.Cells[ColumnJumlah.Name].Value.ToString(), NumberStyles.Number),
                        Harga = int.Parse(row.Cells[ColumnHarga.Name].Value.ToString(), NumberStyles.Number),
                    });
                }


                var transaction = this.DbConnection.BeginTransaction();

                try
                {
                    // Update ke database
                    Model.Transfer.Update(transaction, this.transfer);

                    // Update ke kartu stok
                    Model.KartuStok.UpdateTransfer(transaction, this.transfer);

                    // Simpan transaksi
                    transaction.Commit();

                    // Tampilkan info
                    MsgBox.Info("Data transfer berhasil diupdate");
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    ExceptionBox(ex);
                }
            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Close();
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
                currentRow.Cells[ColumnHarga.Name].Value = satuanTerpilih.Harga_Pokok;

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
                if (DGV.Columns[e.ColumnIndex] == ColumnJumlah)
                {
                    currentCell.Value = int.Parse(currentCell.Value.ToString(), NumberStyles.Number).ToString();
                }
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

        private void DGV_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            // untuk kolom jumlah dan harga beli
            if (DGV.Columns[e.ColumnIndex] == ColumnJumlah)
            {
                int result = 0;
                e.Cancel = !int.TryParse(e.FormattedValue.ToString(), NumberStyles.Number, CultureInfo.CurrentCulture, out result);
            }
        }
    }
}
