using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Dapper;

namespace MCS_POS.Master
{
    public partial class ItemEditorForm : MCS_POS.EditorBaseForm
    {
        private MySqlDataAdapter satuanItemAdapter = new MySqlDataAdapter();
        private DataSet dataSet = new DataSet();

        // Item yg sedang di edit / ditambahkan
        private Model.Item item;

        public ItemEditorForm()
        {
            InitializeComponent();
        }

        private void ItemEditorForm_Load(object sender, EventArgs e)
        {
            // Load Master Jenis
            JenisItemComboBox.DataSource = Model.JenisItem.GetList(this.DbConnection);
            JenisItemComboBox.DisplayMember = "nama_jenis_item";
            JenisItemComboBox.ValueMember = "id_jenis_item";

            // Load Master Merek
            MerekItemComboBox.DataSource = Model.MerekItem.GetList(this.DbConnection);
            MerekItemComboBox.DisplayMember = "nama_merek_item";
            MerekItemComboBox.ValueMember = "id_merek_item";

            // Load Master Supplier --> Satuan Dasar
            SupplierComboBox.DataSource = Model.Supplier.GetEnumerable(this.DbConnection);
            SupplierComboBox.DisplayMember = "nama_supplier";
            SupplierComboBox.ValueMember = "id_supplier";

            // Load Master Satuan
            SatuanDasarComboBox.DataSource = Model.Satuan.GetList(this.DbConnection);
            SatuanDasarComboBox.DisplayMember = "nama_satuan";
            SatuanDasarComboBox.ValueMember = "id_satuan";

            // Load Master Satuan untuk Konversi
            ColumnID_Satuan.DataSource = Model.Satuan.GetListForSatuanEditor(this.DbConnection);
            ColumnID_Satuan.DisplayMember = "nama_satuan";
            ColumnID_Satuan.ValueMember = "id_satuan";

            if (this.EditorMode == EditMode.Add)
            {
                // Informasi judul form
                this.Text = "Tambah Data Item";
                this.TabPageReference.Text = this.Text;

                // Dijual Auto
                DijualRadioButton.Checked = true;
            }
            else if (this.EditorMode == EditMode.Edit)
            {
                // Ambil data Item
                this.item = Model.Item.GetSingle(this.DbConnection, this.ID);
                // Ambil satuan dasar
                this.item.SatuanDasar = Model.Item.GetSatuanDasar(this.DbConnection, this.item);
                // Ambil satuan item
                this.item.SatuanItems = Model.SatuanItem.GetList(this.DbConnection, this.item);
                
                // Informasi judul form
                this.Text = "Edit Item : " + item.Nama_Item;
                this.TabPageReference.Text = this.Text;

                // ==================================
                // Load data ke display
                // ==================================
                KodeItemTextBox.Text = item.Kode_Item;
                NamaItemTextBox.Text = item.Nama_Item;
                JenisItemComboBox.SelectedValue = item.ID_Jenis_Item;
                if (item.ID_Merek_Item != null) MerekItemComboBox.SelectedValue = item.ID_Merek_Item;
                RakTextBox.Text = item.Nama_Rak;
                KeteranganTextBox.Text = item.Keterangan;

                if (item.Is_Dijual)
                    DijualRadioButton.Checked = true;
                else
                    TidakDijualRadioButton.Checked = true;

                if (item.ID_Supplier != null) SupplierComboBox.SelectedValue = item.ID_Supplier;

                SatuanDasarComboBox.SelectedValue = item.SatuanDasar.ID_Satuan;
                HargaPokokTextBox.Text = item.SatuanDasar.Harga_Pokok.ToString("N0");
                BarcodeTextBox.Text = item.SatuanDasar.Barcode;
                HargaJualTextBox.Text = item.SatuanDasar.Harga_Jual.ToString("N0");
                KonsinyasiCheckBox.Checked = item.Is_Konsinyasi;

                // Konsinyasi tidak bisa dirubah jika mode edit
                KonsinyasiCheckBox.Enabled = false;

                // Jika item sudah digunakan dalam transaksi,
                // tidak boleh ada perubahan satuan dasar
                if (Model.Item.HasTransaction(DbConnection, item.ID_Item, item.SatuanDasar.ID_Satuan))
                {
                    SatuanDasarComboBox.Enabled = false;
                    label16.Visible = true;
                }


                // ==================================
                // Load satuan konversi
                // ==================================
                foreach (var satuanItem in item.SatuanItems)
                {
                    var rowIndex = SatuanDGV.Rows.Add(new object[] { 
                        satuanItem.ID_Satuan_Item,
                        satuanItem.ID_Item,
                        satuanItem.ID_Satuan,
                        null, // sama dengan
                        satuanItem.Konversi_Jumlah,
                        satuanItem.Barcode,
                        satuanItem.Is_Satuan_Dasar,
                        SatuanDasarComboBox.Text,
                        satuanItem.Harga_Pokok,
                        satuanItem.Harga_Jual
                    });

                    // Deteksi satuan yg sudah ada transaksi
                    if (Model.Item.HasTransaction(DbConnection, satuanItem.ID_Item, satuanItem.ID_Satuan))
                    {
                        SatuanDGV.Rows[rowIndex].Cells[ColumnID_Satuan.Name].ReadOnly = true;
                        ((DataGridViewComboBoxCell)SatuanDGV.Rows[rowIndex].Cells[ColumnID_Satuan.Name]).DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                        SatuanDGV.Rows[rowIndex].Cells[ColumnKonversiJumlah.Name].ReadOnly = true;
                    }
                }
            }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            ((MainForm)MdiParent).buttonCloseChild_Click(sender, e);
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {

            // Prepare input
            var kodeItem = KodeItemTextBox.Text.Trim();
            var namaItem = NamaItemTextBox.Text.Trim();

            // Validasi kode item
            if (kodeItem == "")
            {
                MsgBox.Info("Masukkan Kode Item");
                KodeItemTextBox.Focus();
                return;
            }

            // Validasi nama item
            if (namaItem == "")
            {
                MsgBox.Info("Masukkan Nama Item");
                NamaItemTextBox.Focus();
                return;
            }

            // Dipaksa open
            if (this.DbConnection.State == ConnectionState.Closed) { this.DbConnection.Open(); }

            // Mulai isolasi transaksi
            var transaction = this.DbConnection.BeginTransaction();

            //try
            //{
                if (this.EditorMode == EditMode.Add)
                {
                    int affectedRows = -1;

                    // Create Object Item
                    var newItem = new Model.Item()
                    {
                        Kode_Item = KodeItemTextBox.Text.Trim(),
                        Nama_Item = NamaItemTextBox.Text.Trim(),
                        ID_Jenis_Item = (int)JenisItemComboBox.SelectedValue,
                        ID_Merek_Item = (int)MerekItemComboBox.SelectedValue,
                        Nama_Rak = RakTextBox.Text.Trim(),
                        Keterangan = KeteranganTextBox.Text.Trim(),
                        Is_Dijual = DijualRadioButton.Checked,
                        Jenis_Harga_Jual = 1,   // Satu jenis harga jual dulu
                        Persen_Harga_Jual = 0f,  // persentase harga jual di nol-kan dulu
                        ID_Supplier = (int)SupplierComboBox.SelectedValue,
                        Stok_Minimium = int.Parse(StokMinTextBox.Text, NumberStyles.Number),
                        Is_Konsinyasi = KonsinyasiCheckBox.Checked,
                        Guid = Guid.NewGuid()
                    };

                    // Insert Item
                    Model.Item.Add(transaction, newItem);

                    // Create Object SatuanItem
                    var newSatuanDasarItem = new Model.SatuanItem
                    {
                        ID_Item = newItem.ID_Item,
                        ID_Satuan = (int)SatuanDasarComboBox.SelectedValue,
                        Konversi_Jumlah = 1f,
                        Barcode = BarcodeTextBox.Text,
                        Is_Satuan_Dasar = true,
                        Harga_Pokok = int.Parse(HargaPokokTextBox.Text, NumberStyles.Number),
                        Harga_Jual = int.Parse(HargaJualTextBox.Text, NumberStyles.Number)
                    };

                    // Insert Satuan
                    Model.SatuanItem.Add(transaction, newSatuanDasarItem);

                    // Proses Satuan Item. Syarat : Konversi > 0, harga pokok > 0, harga jual > 0
                    foreach (DataGridViewRow row in SatuanDGV.Rows)
                    {
                        // pastikan id_satuan tidak kosong
                        if (SatuanDGV.Rows[row.Index].Cells[ColumnID_Satuan.Index].Value != null)
                        {
                            // prepare value
                            int satuanId = (int)SatuanDGV.Rows[row.Index].Cells[ColumnID_Satuan.Index].Value;
                            float konversiJumlah = float.Parse(SatuanDGV.Rows[row.Index].Cells[ColumnKonversiJumlah.Index].FormattedValue.ToString(), NumberStyles.Number);

                            // Syarat terpenuhi
                            if (satuanId >= 0 && konversiJumlah > 0)
                            {
                                // Create Object SatuanItem
                                var newSatuanTambahan = new Model.SatuanItem
                                {
                                    ID_Item = newItem.ID_Item,
                                    ID_Satuan = (int)SatuanDGV.Rows[row.Index].Cells[ColumnID_Satuan.Index].Value,
                                    Konversi_Jumlah = konversiJumlah,
                                    Is_Satuan_Dasar = false,
                                    Harga_Pokok = int.Parse(SatuanDGV.Rows[row.Index].Cells[ColumnHargaPokok.Index].FormattedValue.ToString(), NumberStyles.Number),
                                    Harga_Jual = int.Parse(SatuanDGV.Rows[row.Index].Cells[ColumnHargaJual.Index].FormattedValue.ToString(), NumberStyles.Number)
                                };

                                // Insert ke DB
                                affectedRows = Model.SatuanItem.Add(transaction, newSatuanTambahan);
                            }
                        }
                    }

                    // Commit penambahan ke database
                    transaction.Commit();

                    MsgBox.Info("Data berhasil ditambahkan.");

                    // Cek Form Master item aktif / tidak
                    if (((MainForm)this.MdiParent).IsChildExist(typeof(Master.ItemForm)))
                    {
                        foreach (var child in this.MdiParent.MdiChildren)
                        {
                            if (child.GetType() == typeof(Master.ItemForm))
                            {
                                // Refresh DataGridVew
                                ((Master.ItemForm)child).RefreshDGV();
                                break;
                            }
                        }
                    }

                    this.Close();
                }

                if (this.EditorMode == EditMode.Edit)
                {
                    int affectedRows = 0;

                    // update Item object
                    item.Kode_Item = KodeItemTextBox.Text;
                    item.Nama_Item = NamaItemTextBox.Text;
                    item.ID_Jenis_Item = (int)JenisItemComboBox.SelectedValue;
                    item.ID_Merek_Item = (int)MerekItemComboBox.SelectedValue;
                    item.Nama_Rak = RakTextBox.Text.Trim();
                    item.Keterangan = KeteranganTextBox.Text.Trim();
                    item.Is_Dijual = (DijualRadioButton.Checked == true) ? true : false;
                    item.ID_Supplier = (int)SupplierComboBox.SelectedValue;

                    // Update Item ke database
                    affectedRows = Model.Item.Update(transaction, item);

                    // Update Satuan Dasar object
                    item.SatuanDasar.ID_Satuan = (int)SatuanDasarComboBox.SelectedValue;
                    item.SatuanDasar.Harga_Pokok = int.Parse(HargaPokokTextBox.Text, NumberStyles.Number);
                    item.SatuanDasar.Harga_Jual = int.Parse(HargaJualTextBox.Text, NumberStyles.Number);

                    // Update ke database
                    Model.SatuanItem.Update(transaction, item.SatuanDasar);


                    foreach (DataGridViewRow row in SatuanDGV.Rows)
                    {
                        // Jika tidak ada ID_Satuan, maka di skip
                        if (row.Cells[ColumnID_Satuan.Name].Value == null) { continue; }

                        // Jika sudah di set delete
                        if (row.Visible == false)
                        {
                            // Permanently delete
                            Model.SatuanItem.Delete(transaction, (int)row.Cells[ColumnID_Satuan_Item.Name].Value);

                            // Skip langsung
                            continue;
                        }

                        // Uji variabel
                        //var v1 = (int)row.Cells[ColumnID_Satuan.Name].Value;
                        //var v2 = float.Parse(row.Cells[ColumnKonversiJumlah.Name].Value.ToString(), NumberStyles.Number, CultureInfo.CurrentCulture);
                        //var v3 = int.Parse(row.Cells[ColumnHargaPokok.Name].Value.ToString(), NumberStyles.Number, CultureInfo.CurrentCulture);
                        //var v4 = int.Parse(row.Cells[ColumnHargaJual.Name].Value.ToString(), NumberStyles.Number, CultureInfo.CurrentCulture);

                        // Sampai SINI

                        // Create Object Reference SatuanItem
                        var satuanItem = new Model.SatuanItem
                        {
                            ID_Item = this.item.ID_Item,
                            ID_Satuan = (int)row.Cells[ColumnID_Satuan.Name].Value,
                            Konversi_Jumlah = float.Parse(row.Cells[ColumnKonversiJumlah.Name].Value.ToString(), NumberStyles.Number, CultureInfo.CurrentCulture),
                            Is_Satuan_Dasar = false,
                            Harga_Pokok = int.Parse(row.Cells[ColumnHargaPokok.Name].Value.ToString(), NumberStyles.Number, CultureInfo.CurrentCulture),
                            Harga_Jual = int.Parse(row.Cells[ColumnHargaJual.Name].Value.ToString(), NumberStyles.Number, CultureInfo.CurrentCulture)
                        };

                        // Jika belum punya PK
                        if (row.Cells[ColumnID_Satuan_Item.Name].Value == null)
                        {
                            // Tambah Baru
                            Model.SatuanItem.Add(transaction, satuanItem);

                            // Update PK dari yg sudah ditambahkan
                            row.Cells[ColumnID_Satuan_Item.Name].Value = satuanItem.ID_Satuan_Item;
                        }
                        else  // Jika sudah ada PK
                        {
                            // Set Primary key
                            satuanItem.ID_Satuan_Item = (int)row.Cells[ColumnID_Satuan_Item.Name].Value;

                            // Update ke database
                            Model.SatuanItem.Update(transaction, satuanItem);
                        }
                    }

                    /**
                    // Proses tiap row tabel satuan
                    foreach (DataRow row in this.dataSet.Tables["satuan_item"].Rows)
                    {
                        if (row.RowState == DataRowState.Deleted)
                        {
                            // Hapus dari database
                            affectedRows = Model.SatuanItem.Delete(transaction, row.Field<int>("id_satuan_item", DataRowVersion.Original));

                            // langsung next row
                            continue;
                        }

                        // Create Object Reference SatuanItem
                        var satuanItem = new Model.SatuanItem
                        {
                            ID_Item = this.item.ID_Item,
                            ID_Satuan = (int)row["id_satuan"],
                            Konversi_Jumlah = (float)row["konversi_jumlah"],
                            Is_Satuan_Dasar = false,
                            Harga_Pokok = (int)row["harga_pokok"],
                            Harga_Jual = (int)row["harga_jual"]
                        };

                        if (row.RowState == DataRowState.Added)
                        {
                            // Insert ke database
                            affectedRows = Model.SatuanItem.Add(transaction, satuanItem);
                        }

                        if (row.RowState == DataRowState.Modified)
                        {
                            // Primary key
                            satuanItem.ID_Satuan_Item = (int)row["id_satuan_item"];

                            // Update ke database
                            affectedRows = Model.SatuanItem.Update(transaction, satuanItem);
                        }
                    } */

                    // Commit transaksi
                    transaction.Commit();

                    // Info ke user
                    MsgBox.Info("Data berhasil diupdate.");

                    // Cek Form Master item aktif / tidak
                    var masterItemForm = (this.MdiParent as MainForm).MdiChildren.SingleOrDefault(c => c is Master.ItemForm);

                    // Jika ada
                    if (masterItemForm != null)
                    {
                        // Update datagrid
                        (masterItemForm as Master.ItemForm).RefreshDGV();
                    }
                }
            //}
            //catch (Exception ex)
            //{
            //    transaction.Rollback();

            //    ExceptionBox(ex);
            //    return;
            //}
        }

        private void NumbersOnly_KeyDown(object sender, KeyEventArgs e)
        {
            var ascii = (int)e.KeyCode;

            var rules1 = (37 <= ascii && ascii <= 40);  // Arrow Keys
            var rules2 = (48 <= ascii && ascii <= 57);  // D-Pad
            var rules3 = (ascii == 8 || ascii == 188);   // backspace, comma

            if (!(rules1 || rules2 || rules3))
            {
                e.SuppressKeyPress = true;
            }
        }

        private void SelectAllTextBox_OnEnter(object sender, EventArgs e)
        {
            var thisTextBox = (TextBox)sender;
            thisTextBox.SelectAll();
        }

        private void SatuanDGV_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            ExceptionBox(e.Exception);
        }

        private void NumberTextBox_Leave(object sender, EventArgs e)
        {
            float result = 0; float.TryParse((sender as TextBox).Text, out result);
            (sender as TextBox).Text = result.ToString("N0");
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

        private void SatuanDasarComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            ColumnSatuanDasar.DefaultCellStyle.NullValue = SatuanDasarComboBox.Text;
        }

        // Format normal cell
        private void SatuanDGV_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            var value = SatuanDGV.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

            if ((SatuanDGV.Columns[e.ColumnIndex] == ColumnKonversiJumlah) ||
                (SatuanDGV.Columns[e.ColumnIndex] == ColumnHargaPokok) ||
                (SatuanDGV.Columns[e.ColumnIndex] == ColumnHargaJual))
            {
                if (value != null)
                {

                    SatuanDGV.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = float.Parse(value.ToString(), NumberStyles.Number, CultureInfo.CurrentCulture).ToString();
                }
            }
        }

        // Validasi cell DGV
        private void SatuanDGV_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (SatuanDGV.Columns[e.ColumnIndex] == ColumnKonversiJumlah || SatuanDGV.Columns[e.ColumnIndex] == ColumnHargaPokok || SatuanDGV.Columns[e.ColumnIndex] == ColumnHargaJual)
            {
                float result = 0f;

                if (e.FormattedValue != null)
                {
                    e.Cancel = (!float.TryParse(e.FormattedValue.ToString(), NumberStyles.Number, CultureInfo.CurrentCulture, out result));
                }
            }
        }

        private void SatuanDGV_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var value = SatuanDGV.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            
            if (value != null)
            {
                float result = 0f;

                // Konversi bisa koma
                if (SatuanDGV.Columns[e.ColumnIndex] == ColumnKonversiJumlah)
                {
                    float.TryParse(value.ToString(), NumberStyles.Any, CultureInfo.CurrentCulture, out result);
                    SatuanDGV.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = result.ToString("#,##0.####");
                }

                // Harga tidak bisa koma
                if (SatuanDGV.Columns[e.ColumnIndex] == ColumnHargaPokok || SatuanDGV.Columns[e.ColumnIndex] == ColumnHargaJual)
                {
                    float.TryParse(value.ToString(), NumberStyles.Any, CultureInfo.CurrentCulture, out result);
                    SatuanDGV.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = result.ToString("N0");
                }
            }
        }

        private void DeleteSatuanButton_Click(object sender, EventArgs e)
        {
            if (SatuanDGV.SelectedRows.Count == 1)
            {
                try
                {
                    // Remove -> set visible false
                    SatuanDGV.SelectedRows[0].Visible = false;
                }
                catch
                {

                }
            }
        }

        private void NamaItemTextBox_TextChanged(object sender, EventArgs e)
        {
            if (this.EditorMode == EditMode.Add)
            {
                this.TabPageReference.Text = "Tambah Data Item : " + (sender as TextBox).Text.Trim();
                this.Text = "Tambah Data Item : " + (sender as TextBox).Text.Trim();
            }
            else if (this.EditorMode == EditMode.Edit)
            {
                this.TabPageReference.Text = "Edit Item : " + (sender as TextBox).Text.Trim();
                this.Text = "Edit Item : " + (sender as TextBox).Text.Trim();
            }
        }
    }
}
