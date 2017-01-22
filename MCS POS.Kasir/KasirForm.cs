using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using Dapper;
using System.Globalization;

namespace MCS_POS.Kasir 
{
    public partial class KasirForm : Form
    {
        public IDbConnection DbConnection { get; set; }
        public Model.User KasirUser { get; set; }
        public RibbonButton RibbonButtonReference { get; set; }
        public Model.Departemen DepartemenAktif { get; set; }

        private DataSet dataSet = new DataSet();
        private DataTable penjualanDetailDT = new DataTable("PenjualanDetail");
        private Model.Penjualan penjualan;
        private Model.ItemPenjualan itemPenjualan;
        private IEnumerable<Model.Config> configs;

        public KasirForm()
        {
            InitializeComponent();
        }

        private void KasirForm_Load(object sender, EventArgs e)
        {
            // this.WindowState = FormWindowState.Maximized;
            this.Text = "PENJUALAN KASIR - " + this.KasirUser.Nama_User;

            // Create table cache PenjualanDetail
            dataSet.Tables.Add(penjualanDetailDT);

            // Load config from main form
            configs = Model.Config.GetAll(DbConnection);

            // Load penjualan terakhir
            penjualan = Model.Penjualan.GetActive(DbConnection, DepartemenAktif, KasirUser);

            // Jika ada penjualan
            if (penjualan != null)
            {
                // Populate DGV
                foreach (var penjualanDetail in penjualan.PenjualanDetails)
                {
                    // Urutan harus sesuai dengan DGV Columns
                    DGV.Rows.Add(new object[] { 
                        penjualanDetail.ID_Penjualan_Detail,
                        penjualanDetail.ID_Item,
                        penjualanDetail.Kode_Item,
                        penjualanDetail.Nama_Item,
                        penjualanDetail.Jumlah,
                        penjualanDetail.ID_Satuan,
                        penjualanDetail.Nama_Satuan,
                        penjualanDetail.Harga_Jual,
                        penjualanDetail.Sub_Total
                    });
                }
            }
            else // jika belum ada
            {
                AddNewTransaksi();
            }

            RefreshDisplayTransaksi();

            // start timer
            timer1.Start();
        }

        private void AddNewTransaksi()
        {
            // Set Nama Kasir
            NamaPegawaiTextBox.Text = this.KasirUser.Nama_User;

            // Create penjualan baru
            penjualan = new Model.Penjualan()
            {
                ID_Departemen = DepartemenAktif.ID_Departemen,
                ID_Customer = 1,  // Customer UMUM
                ID_User = KasirUser.ID_User,
                Total_Biaya = 0,
                Total_Biaya_Akhir = 0,
                Biaya_Lain = 0,
                Biaya_Potongan = 0,

                // Reference
                User = this.KasirUser,
                Departemen = this.DepartemenAktif
            };

            // Create List Penjualan detail baru
            penjualan.PenjualanDetails = new List<Model.PenjualanDetail>();

            // Tambah ke DB
            Model.Penjualan.Add(DbConnection, penjualan);

            // Reset tampilan jumlah
            JumlahItemLabel.Text = "Jumlah Item : 0";
        }

        private void RefreshDisplayTransaksi()
        {
            // Display Info
            NamaPegawaiTextBox.Text = penjualan.User.Nama_User;
            TotalBiayaAkhirTextBox.Text = penjualan.Total_Biaya_Akhir.ToString("N0");
            TotalBiayaTextBox.Text = penjualan.Total_Biaya.ToString("N0");
            BiayaLainTextBox.Text = penjualan.Biaya_Lain.ToString("N0");
            BiayaPotonganTextBox.Text = penjualan.Biaya_Potongan.ToString("N0");
            JumlahTextBox.Text = "1";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            WaktuTransaksiDTP.Value = DateTime.Now;
        }

        private void BrowseItem()
        {
            using (var browseItemForm = new BrowseItemForm())
            {
                browseItemForm.DbConnection = this.DbConnection;
                var browseResult = browseItemForm.ShowDialog(this);

                if (browseResult == System.Windows.Forms.DialogResult.OK)
                {
                    if (Debugger.IsAttached) Debug.WriteLine("KodeItem_KeyPress\r\n\tItem Selected : " + browseItemForm.SelectedID_Item + " " + browseItemForm.SelectedID_Satuan);

                    var penjualanDetail = new Model.PenjualanDetail();
                }
            }
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            var browseItem = new BrowseItemWithKeyboardForm()
            {
                DbConnection = this.DbConnection,
                DepartemenAktif = this.DepartemenAktif
            };
            
            if (browseItem.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                itemPenjualan = Model.ItemPenjualan.GetSingle(DbConnection, browseItem.SelectedID_Item, browseItem.SelectedID_Satuan, DepartemenAktif.ID_Departemen);

                if (itemPenjualan == null)
                {
                    MessageBox.Show("Kesalahan program. Object tidak ditemukan", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    // Preview
                    InfoItemLabel.Text = string.Format("Item: {0} {1}, {2}  Stok: {3}  Harga Jual : {4:N0}",
                        itemPenjualan.Kode_item,
                        itemPenjualan.Nama_Item,
                        itemPenjualan.Nama_Satuan,
                        itemPenjualan.Stok,
                        itemPenjualan.Harga_Jual);
                }
                
            }

            browseItem.Dispose();
        }

        private void JumlahTextBox_Click(object sender, EventArgs e)
        {
            using (var numpad = new VirtualKeyboard.NumpadForm())
            {
                int parsedValue = 0;
                int.TryParse(JumlahTextBox.Text, out parsedValue);
                numpad.Value = parsedValue;

                if (numpad.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    JumlahTextBox.Text = numpad.Value.ToString();
                }
            }
        }

        private void TambahButton_Click(object sender, EventArgs e)
        {
            if (itemPenjualan != null)
            {
                bool isExistInDGV = false;

                // Cek kesamaaan item sebelumnya
                foreach (DataGridViewRow row in DGV.Rows)
                {
                    if ((int)row.Cells[ColumnID_Item.Name].Value == itemPenjualan.ID_Item && (int)row.Cells[ColumnID_Satuan.Name].Value == itemPenjualan.ID_Satuan)
                    {
                        isExistInDGV = true;
                        break;
                    }
                }

                // Jika belum ada, tambahkan
                if (!isExistInDGV)
                {
                    // Tambahkan ke Grid
                    DGV.Rows.Add(new object[] { 
                        -1, // ID_Penjualan_Item
                        itemPenjualan.ID_Item,
                        itemPenjualan.Kode_item,
                        itemPenjualan.Nama_Item,
                        int.Parse(JumlahTextBox.Text), // Jumlah
                        itemPenjualan.ID_Satuan,
                        itemPenjualan.Nama_Satuan,
                        itemPenjualan.Harga_Jual,
                        int.Parse(JumlahTextBox.Text) * itemPenjualan.Harga_Jual // harga jual
                    });

                    // buat object penjualan detail
                    var newPenjualanDetail = new Model.PenjualanDetail()
                    {
                        ID_Penjualan = penjualan.ID_Penjualan,
                        ID_Item = itemPenjualan.ID_Item,
                        ID_Satuan = itemPenjualan.ID_Satuan,
                        Kode_Item = itemPenjualan.Kode_item,
                        Nama_Item = itemPenjualan.Nama_Item,
                        Jumlah = int.Parse(JumlahTextBox.Text),
                        Nama_Satuan = itemPenjualan.Nama_Satuan,
                        Harga_Jual = itemPenjualan.Harga_Jual,
                        Sub_Total = int.Parse(JumlahTextBox.Text) * itemPenjualan.Harga_Jual
                    };

                    // tambahkan ke list PenjualanDetails
                    penjualan.PenjualanDetails.Add(newPenjualanDetail);

                    // Begin Transaction
                    var transaction = DbConnection.BeginTransaction();

                    // Insert ke DB
                    if (!Model.PenjualanDetail.Insert(transaction, newPenjualanDetail))
                    {
                        MessageBox.Show(this, "Gagal Insert");
                    }

                    // Update ID_Penjualan_Detail
                    DGV.Rows[DGV.Rows.Count - 1].Cells[ColumnID_Penjualan_Detail.Name].Value = newPenjualanDetail.ID_Penjualan_Detail;

                    // Update penjualan
                    UpdatePenjualan(transaction);

                    // Commit
                    transaction.Commit();

                    // Clear itemPenjualan & Preview
                    itemPenjualan = null;
                    InfoItemLabel.Text = "[ITEM BELUM DIPILIH]";

                    // Update tampilan jumlah item
                    JumlahItemLabel.Text = "Jumlah Item : " + DGV.Rows.Cast<DataGridViewRow>()
                        .Sum(r => (int)r.Cells[ColumnJumlah.Name].Value).ToString();
                }
                else  // Jika sudah ada, tampilkan pesan
                {
                    MessageBox.Show(this, "Item sudah ada, hapus terlebih dahulu");
                }
            }
        }

        private void DGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            var transaction = DbConnection.BeginTransaction();

            // Edit Harga
            if (e.ColumnIndex == ColumnHarga.Index)
            {
                // Cek otorisasi
                if (KasirUser.Akses_Harga_Jual == false) { transaction.Rollback(); return; }

                var numpad = new VirtualKeyboard.NumpadForm();
                numpad.Value = int.Parse(DGV.Rows[e.RowIndex].Cells[ColumnHarga.Name].Value.ToString());

                if (numpad.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    // Update display
                    DGV.Rows[e.RowIndex].Cells[ColumnHarga.Name].Value = numpad.Value;

                    // Update Object
                    penjualan.PenjualanDetails[e.RowIndex].Harga_Jual = Convert.ToInt32(numpad.Value);

                    // Update Master Item
                    if (MessageBox.Show(this, "Apakah perubahan harga ini permanaen ?\n\r\r\nNB: Perubahan harga akan disimpan ke master.", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        // Ambil ID-ID Terkait
                        var id_item = (int)DGV.Rows[e.RowIndex].Cells[ColumnID_Item.Name].Value;
                        var id_satuan = (int)DGV.Rows[e.RowIndex].Cells[ColumnID_Satuan.Name].Value;

                        // Update
                        Model.Item.UpdateHargaJual(transaction, id_item, id_satuan, Convert.ToInt32(numpad.Value));
                    }
                }

                // clear resource
                numpad.Dispose();
            }

            // Edit Jumlah
            if (e.ColumnIndex == ColumnJumlah.Index)
            {
                var numpad = new VirtualKeyboard.NumpadForm();
                numpad.Value = int.Parse(DGV.Rows[e.RowIndex].Cells[ColumnJumlah.Name].Value.ToString());

                if (numpad.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    // update display
                    DGV.Rows[e.RowIndex].Cells[ColumnJumlah.Name].Value = numpad.Value;

                    // update object
                    penjualan.PenjualanDetails[e.RowIndex].Jumlah = Convert.ToInt32(numpad.Value);
                }

                // clear resource
                numpad.Dispose();

                // Update tampilan jumlah item
                JumlahItemLabel.Text = "Jumlah Item : " + DGV.Rows.Cast<DataGridViewRow>()
                    .Sum(r => (int)r.Cells[ColumnJumlah.Name].Value).ToString();
            }

            // Re-calculate subtotal
            var jumlahItem = int.Parse(DGV.Rows[e.RowIndex].Cells[ColumnJumlah.Name].Value.ToString());
            var hargaItem = int.Parse(DGV.Rows[e.RowIndex].Cells[ColumnHarga.Name].Value.ToString());
            DGV.Rows[e.RowIndex].Cells[ColumnSubTotal.Name].Value = (jumlahItem * hargaItem);
            
            // update object
            penjualan.PenjualanDetails[e.RowIndex].Sub_Total = (jumlahItem * hargaItem);

            // Update ke DB
            Model.PenjualanDetail.Update(transaction, penjualan.PenjualanDetails[e.RowIndex]);

            // Update Penjualan
            UpdatePenjualan(transaction);

            // Commit
            transaction.Commit();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            // Skip jika belum ada yg terselect
            if (DGV.SelectedRows.Count == 0) { return; }

            var id_penjualan_detail = (int)DGV.SelectedRows[0].Cells[ColumnID_Penjualan_Detail.Name].Value;

            var transaction = DbConnection.BeginTransaction();

            // Remove from DB
            if (Model.PenjualanDetail.Delete(transaction, id_penjualan_detail))
            {
                // Remove dari Object Penjualan
                var penjualanDetail = penjualan.PenjualanDetails.Find(f => f.ID_Penjualan_Detail == id_penjualan_detail);
                penjualan.PenjualanDetails.Remove(penjualanDetail);

                // Remove dari display
                DGV.Rows.Remove(DGV.SelectedRows[0]);

                // Update DB Penjualan
                UpdatePenjualan(transaction);

                // Commit
                transaction.Commit();

                // Update tampilan jumlah item
                JumlahItemLabel.Text = "Jumlah Item : " + DGV.Rows.Cast<DataGridViewRow>()
                    .Sum(r => (int)r.Cells[ColumnJumlah.Name].Value).ToString();
            }
        }

        private void PotonganTextBox_Click(object sender, EventArgs e)
        {
            using (var numpad = new VirtualKeyboard.NumpadForm())
            {
                numpad.Value = int.Parse((sender as TextBox).Text, NumberStyles.Number);

                if (numpad.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    (sender as TextBox).Text = numpad.Value.ToString("N0");

                    UpdatePenjualan();
                }
            }
        }

        private void BiayaLainTextBox_Click(object sender, EventArgs e)
        {
            using (var numpad = new VirtualKeyboard.NumpadForm())
            {
                numpad.Value = int.Parse((sender as TextBox).Text, NumberStyles.Number);

                if (numpad.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    (sender as TextBox).Text = numpad.Value.ToString("N0");

                    UpdatePenjualan();
                }
            }
        }

        private void UpdatePenjualan(IDbTransaction transaction = null)
        {
            // Hitung semua harga dulu
            penjualan.Total_Biaya = DGV.Rows
                .Cast<DataGridViewRow>()
                .Sum(r => int.Parse(r.Cells[ColumnSubTotal.Name].Value.ToString(), System.Globalization.NumberStyles.Number));

            // Ambil Potongan + Biaya Tambahan
            penjualan.Biaya_Potongan = int.Parse(BiayaPotonganTextBox.Text, System.Globalization.NumberStyles.Number);
            penjualan.Biaya_Lain = int.Parse(BiayaLainTextBox.Text, System.Globalization.NumberStyles.Number);

            // Hitung ulang total biaya Akhir
            penjualan.Total_Biaya_Akhir = penjualan.Total_Biaya - penjualan.Biaya_Potongan + penjualan.Biaya_Lain;

            // Update waktu transaksi
            penjualan.Waktu_Transaksi = DateTime.Now;

            // Update ke DB, jika belum ada transaksi create dulu
            if (transaction == null)
            {
                transaction = DbConnection.BeginTransaction();
                Model.Penjualan.Update(transaction, penjualan);
                transaction.Commit();
            }
            else
            {
                Model.Penjualan.Update(transaction, penjualan);
            }

            // Tampilkan ke user
            TotalBiayaTextBox.Text = penjualan.Total_Biaya.ToString("N0");
            TotalBiayaAkhirTextBox.Text = penjualan.Total_Biaya_Akhir.ToString("N0");
        }

        private void BayarButton_Click(object sender, EventArgs e)
        {
            // Skip jika belum ada item
            if (DGV.Rows.Count == 0) { return; }

            // Buat object form pembayaran
            var pembayaran = new PembayaranForm();
            pembayaran.TotalTextBox.Text = TotalBiayaAkhirTextBox.Text;
            var result = pembayaran.ShowDialog(this);

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                // update object
                penjualan.Kode_Transaksi = Model.Penjualan.GenerateKodeTransaksi(DbConnection, this.DepartemenAktif, this.configs);
                penjualan.Waktu_Transaksi = DateTime.Now;

                // Hitung jumlah semua item
                penjualan.Jumlah_Item = DGV.Rows.Cast<DataGridViewRow>()
                    .Sum(r => (int)r.Cells[ColumnJumlah.Name].Value);

                // Update status
                penjualan.Is_Dibayar = true;
                penjualan.Is_Saved = false;
                penjualan.Keterangan_Save = string.Empty;

                // Info Pembayaran
                penjualan.Bayar_Tunai = int.Parse(pembayaran.BayarTextBox.Text, System.Globalization.NumberStyles.Number);
                penjualan.Bayar_Kembali = int.Parse(pembayaran.KembaliTextBox.Text, System.Globalization.NumberStyles.Number);

                // update db
                var transaction = DbConnection.BeginTransaction();
                Model.Penjualan.Update(transaction, penjualan);
                Model.KartuStok.AddPenjualan(transaction, penjualan);
                transaction.Commit();

                // reload setting & config
                Properties.Settings.Default.Reload();
                // configs = Model.Config.GetAll(DbConnection);

                // template struk
                var templateStruk = configs.First(c => c.Nama == "template_struk_kasir").Nilai;

                // Cetak struk
                KasirForm.PrintStruk(penjualan, templateStruk, Properties.Settings.Default.PrinterName, Properties.Settings.Default.PrinterSpace);

                // Clear tampilan
                penjualan = null;
                DGV.Rows.Clear();

                // Add Transaksi Baru
                AddNewTransaksi();
                RefreshDisplayTransaksi();
            }
        }

        private void button_MouseDown(object sender, MouseEventArgs e)
        {
            (sender as Button).UseVisualStyleBackColor = false;
            (sender as Button).BackColor = Color.LightSkyBlue;
        }

        private void button_MouseUp(object sender, MouseEventArgs e)
        {
            (sender as Button).BackColor = SystemColors.Control;
            (sender as Button).UseVisualStyleBackColor = true;
        }

        private void KasirForm_Shown(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void DGV_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void ScrollUpButton_Click(object sender, EventArgs e)
        {
            DGV.Focus();
            SendKeys.Send("{UP}");
        }

        private void ScrollDownButton_Click(object sender, EventArgs e)
        {
            DGV.Focus();
            SendKeys.Send("{DOWN}");
        }

        public static void PrintStruk(Model.Penjualan penjualan, string templateStruk, string printerName, int printerSpace)
        {
            // Assign Departemen Info
            var struk = new StringBuilder(templateStruk);
            struk
                .Replace("[DEPARTEMEN]", penjualan.Departemen.Nama_Departemen)
                .Replace("[DEPARTEMEN_ALAMAT]", penjualan.Departemen.Alamat_Departemen)
                .Replace("[DEPARTEMEN_KOTA]", penjualan.Departemen.Kota_Departemen)
                .Replace("[DEPARTEMEN_TELP]", penjualan.Departemen.Telp_Departemen)
                .Replace("[KODE_TRX]", penjualan.Kode_Transaksi)
                .Replace("[KASIR]", penjualan.User.Nama_User)
                .Replace("[WAKTU_TRX]", penjualan.Waktu_Transaksi.ToString("dd/MM/yyyy hh:mm:ss"));

            // Populate item terjual
            var itemsSB = new StringBuilder();

            for (int i = 0; i < penjualan.PenjualanDetails.Count; i++)
            {
                var detail = penjualan.PenjualanDetails[i];

                /* *
                 * Format Item List
                 * Nama Item : 14 >>  AAAAAAAAAAAAAAA
                 * Jumlah    : (1) + 3  >> _000
                 * Satuan    : (1) + 3  >> _AAA
                 * Harga     : (1) + 7  >> _999.999
                 * Sub Total : (1) + 9  >> _9.999.999
                 * */

                // Building line String
                var formatLine = (
                    detail.Nama_Item.PadRight(14).Substring(0, 14) +
                    " " + detail.Jumlah.ToString().PadLeft(3) +
                    " " + detail.Nama_Satuan.PadRight(3).Substring(0, 3) +
                    " " + detail.Harga_Jual.ToString("N0").PadLeft(7) +
                    " " + detail.Sub_Total.ToString("N0").PadLeft(9));

                // Ditambahkan NewLine jika belum baris terakhir
                if (i < penjualan.PenjualanDetails.Count - 1)
                    itemsSB.AppendLine(formatLine);
                else
                    itemsSB.Append(formatLine);
            }

            // Replace to template
            struk.Replace("[[ITEM]]", itemsSB.ToString());

            var totalSB = new StringBuilder();

            // Jika ada biaya Potongan / Biaya lain, tampilkan subtotal dulu
            if (penjualan.Biaya_Lain > 0 || penjualan.Biaya_Potongan > 0)
            {
                // Biaya-Total Line
                totalSB.AppendLine(
                    "Sub Total = ".PadLeft(25) + penjualan.Total_Biaya.ToString("N0").PadLeft(15) +
                    ((penjualan.Biaya_Potongan == 0) ? "" : "Potongan = ".PadLeft(25) + (0 - penjualan.Biaya_Potongan).ToString("N0").PadLeft(15)) +
                    ((penjualan.Biaya_Lain == 0) ? "" : "Biaya Lain = ".PadLeft(25) + penjualan.Biaya_Lain.ToString("N0").PadLeft(15)) +
                    "---------------".PadLeft(40) +
                    "Total = ".PadLeft(25) + penjualan.Total_Biaya_Akhir.ToString("N0").PadLeft(15) +
                    "Tunai = ".PadLeft(25) + penjualan.Bayar_Tunai.ToString("N0").PadLeft(15) +
                    "---------------".PadLeft(40) +
                    "Kembali = ".PadLeft(25) + penjualan.Bayar_Kembali.ToString("N0").PadLeft(15)
                );
            }
            else // Jika tidak, langsung total akhir
            {
                // Biaya-Total Line
                totalSB.AppendLine(
                    "Total = ".PadLeft(25) + penjualan.Total_Biaya_Akhir.ToString("N0").PadLeft(15) +
                    "Tunai = ".PadLeft(25) + penjualan.Bayar_Tunai.ToString("N0").PadLeft(15) +
                    "---------------".PadLeft(40) +
                    "Kembali = ".PadLeft(25) + penjualan.Bayar_Kembali.ToString("N0").PadLeft(15)
                );
            }

            struk.Replace("[[TOTAL]]", totalSB.ToString());
            
            // Space
            struk.Append('\n', printerSpace);

            // Print POS
            var printer = new PrintDirect();
            printer.Print(printerName, struk.ToString(), "STRUK");
        }
    }
}
