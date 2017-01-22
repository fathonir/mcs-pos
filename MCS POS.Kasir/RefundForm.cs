using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MCS_POS.Kasir
{
    public partial class RefundForm : Form
    {
        public IDbConnection DbConnection { get; set; }
        public int ID_Penjualan { get; set; }
        public Model.User UserLogin { get; set; }

        private Model.Penjualan penjualan { get; set; }
        private Timer waktuRefundTimer = new Timer();
        private IEnumerable<Model.Config> configs;

        public RefundForm()
        {
            InitializeComponent();
        }

        private void RefundForm_Load(object sender, EventArgs e)
        {
            // Load config from database
            configs = Model.Config.GetAll(DbConnection);

            // Load data penjualan
            penjualan = Model.Penjualan.GetSingle(DbConnection, this.ID_Penjualan);
            penjualan.Departemen = Model.Departemen.GetSingle(DbConnection, penjualan.ID_Departemen);
            penjualan.User = Model.User.GetSingle(DbConnection, penjualan.ID_User);
            penjualan.PenjualanDetails = Model.PenjualanDetail.GetListOfPenjualan(DbConnection, penjualan);
            penjualan.ID_User_Refund = this.UserLogin.ID_User;
            penjualan.UserRefund = this.UserLogin;

            // Tampilan
            NamaPegawaiTextBox.Text = penjualan.User.Nama_User;
            NamaPegawaiReturTextBox.Text = penjualan.UserRefund.Nama_User;
            WaktuTransaksiDTP.Value = penjualan.Waktu_Transaksi;
            TotalBiayaTextBox.Text = penjualan.Total_Biaya.ToString("N0");
            BiayaLainTextBox.Text = penjualan.Biaya_Lain.ToString("N0");
            BiayaPotonganTextBox.Text = penjualan.Biaya_Potongan.ToString("N0");
            TotalBiayaAkhirTextBox.Text = penjualan.Total_Biaya_Akhir.ToString("N0");
            TotalBiayaRefundTextBox.Text = penjualan.Total_Biaya_Refund.ToString("N0");
            BiayaPotonganRefundTextBox.Text = penjualan.Biaya_Potongan_Refund.ToString("N0");

            // Load ke datagrid
            foreach (var pd in penjualan.PenjualanDetails)
            {
                // Kolom DGV : 
                // id_penjualan_detail
                //retur
                //kode item
                //nama item
                //jumlah
                //harga
                //jmlah retur
                //harga retur
                //sub total => (jml * harga) - (jml * harga ret)

                DGV.Rows.Add(new object[] { 
                    pd.ID_Penjualan_Detail,
                    pd.Is_Refund ? "True" : "False",
                    pd.Kode_Item,
                    pd.Nama_Item,
                    Convert.ToInt32(pd.Jumlah), // dikonversi ke int untuk mempermudah hitungan
                    pd.Harga_Jual,
                    pd.Jumlah_Refund,   
                    pd.Harga_Refund,  
                    pd.Sub_Total  
                });
            }

            waktuRefundTimer.Interval = 1000;
            waktuRefundTimer.Tick += waktuRefundTimer_Tick;
            waktuRefundTimer.Start();
        }

        private void waktuRefundTimer_Tick(object sender, EventArgs e)
        {
            WaktuRefundDTP.Value = DateTime.Now;
        }

        private void ScrollUpButton_Click(object sender, EventArgs e)
        {
            DGV.Focus(); SendKeys.Send("{UP}");
        }

        private void ScrollDownButton_Click(object sender, EventArgs e)
        {
            DGV.Focus(); SendKeys.Send("{DOWN}");
        }

        private void DGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ref cell
            var isRefundCell = DGV.Rows[e.RowIndex].Cells[ColumnIsRefund.Name];
            var jumlahCell = DGV.Rows[e.RowIndex].Cells[ColumnJumlah.Name];
            var jumlahRefundCell = DGV.Rows[e.RowIndex].Cells[ColumnJumlahRefund.Name];
            var hargaCell = DGV.Rows[e.RowIndex].Cells[ColumnHarga.Name];
            var hargaRefundCell = DGV.Rows[e.RowIndex].Cells[ColumnHargaRefund.Name];
            var subTotalCell = DGV.Rows[e.RowIndex].Cells[ColumnSubTotal.Name];

            // Jumlah Refund & refund tercentang
            if (DGV.Columns[e.ColumnIndex] == ColumnJumlahRefund && isRefundCell.Value.Equals("True"))
            {    
                var numpad = new VirtualKeyboard.NumpadForm() { Value = (int)jumlahRefundCell.Value };
            
                if (numpad.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    // Cek batas atas refund
                    if (numpad.Value > (int)jumlahCell.Value)
                    {
                        MessageBox.Show(this, "Jumlah retur melebihi jumlah barang yang dijual", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        // Update display
                        jumlahRefundCell.Value = numpad.Value;
                        subTotalCell.Value = ((int)jumlahCell.Value * (int)hargaCell.Value) - ((int)jumlahRefundCell.Value * (int)hargaRefundCell.Value);

                        // Update Object
                        penjualan.PenjualanDetails[e.RowIndex].Jumlah_Refund = Convert.ToInt32(numpad.Value);
                        penjualan.PenjualanDetails[e.RowIndex].Sub_Total = Convert.ToInt32(subTotalCell.Value);

                        // Hitung total
                        RecountDGV();
                    }
                }

                // clear resource
                numpad.Dispose();
            }

            // Harga Refund & refund tercentang
            if (DGV.Columns[e.ColumnIndex] == ColumnHargaRefund && isRefundCell.Value.Equals("True"))
            {
                var numpad = new VirtualKeyboard.NumpadForm() { Value = (int)hargaRefundCell.Value };

                if (numpad.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    if (numpad.Value > (int)hargaCell.Value)
                    {
                        MessageBox.Show(this, "Harga retur melebihi harga barang yang dijual", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        // Update display
                        hargaRefundCell.Value = numpad.Value;
                        subTotalCell.Value = ((int)jumlahCell.Value * (int)hargaCell.Value) - ((int)jumlahRefundCell.Value * (int)hargaRefundCell.Value);

                        // Update Object
                        penjualan.PenjualanDetails[e.RowIndex].Harga_Refund = Convert.ToInt32(numpad.Value);
                        penjualan.PenjualanDetails[e.RowIndex].Sub_Total = Convert.ToInt32(subTotalCell.Value);

                        // Hitung total
                        RecountDGV();
                    }
                }

                // clear resource
                numpad.Dispose();
            }
        }

        private void RecountDGV()
        {
            // Total Item Refund
            penjualan.Jumlah_Item_Refund =
                DGV.Rows.Cast<DataGridViewRow>()
                .Where(row => row.Cells[ColumnIsRefund.Name].Value.Equals("True"))
                .Count();

            // Total Biaya
            penjualan.Total_Biaya =
                DGV.Rows.Cast<DataGridViewRow>()
                .Sum(row => (int)row.Cells[ColumnSubTotal.Name].Value);
            TotalBiayaTextBox.Text = penjualan.Total_Biaya.ToString("N0");

            // Menghitung potongan retur
            // Potongan Retur = (Harga Jual - Harga Retur) * Jumlah Item Retur 
            penjualan.Biaya_Potongan_Refund =
                DGV.Rows.Cast<DataGridViewRow>()
                .Where(row => row.Cells[ColumnIsRefund.Name].Value.ToString() == "True")
                .Sum(row => ((int)row.Cells[ColumnHarga.Name].Value - (int)row.Cells[ColumnHargaRefund.Name].Value) * (int)row.Cells[ColumnJumlahRefund.Name].Value);
            BiayaPotonganRefundTextBox.Text = penjualan.Biaya_Potongan_Refund.ToString("N0");

            // Menghitung total biaya yang direfund kan
            // Total biaya refund = harga retur * jumlah item retur
            penjualan.Total_Biaya_Refund =
                DGV.Rows.Cast<DataGridViewRow>()
                .Where(row => row.Cells[ColumnIsRefund.Name].Value.ToString() == "True")
                .Sum(row => (int)row.Cells[ColumnHargaRefund.Name].Value * (int)row.Cells[ColumnJumlahRefund.Name].Value);
            TotalBiayaRefundTextBox.Text = penjualan.Total_Biaya_Refund.ToString("N0");

            // Total Biaya Akhir = (jml * harga) - (jml ret * harga ret)
            penjualan.Total_Biaya_Akhir = (penjualan.Total_Biaya + penjualan.Biaya_Lain) - penjualan.Biaya_Potongan;
            TotalBiayaAkhirTextBox.Text = penjualan.Total_Biaya_Akhir.ToString("N0");
        }

        private void DGV_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DGV.Columns[e.ColumnIndex] == ColumnIsRefund && e.RowIndex >= 0)
            {
                DGV.EndEdit();
            }
        }

        private void DGV_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (DGV.Columns[e.ColumnIndex] == ColumnIsRefund && e.RowIndex >= 0)
            {
                var currentRow = DGV.Rows[e.RowIndex];
                var jumlahRefundCell = currentRow.Cells[ColumnJumlahRefund.Name];
                var hargaRefundCell = currentRow.Cells[ColumnHargaRefund.Name];
                var jumlahCell = currentRow.Cells[ColumnJumlah.Name];
                var hargaCell = currentRow.Cells[ColumnHarga.Name];
                var subTotalCell = currentRow.Cells[ColumnSubTotal.Name];

                if (currentRow.Cells[e.ColumnIndex].Value.Equals("True"))
                {
                    // Jika sebelumnya masih kosong
                    if (jumlahRefundCell.Value.Equals(0) && hargaRefundCell.Value.Equals(0))
                    {
                        // Set jumlah dan harga retur dr jumlah dan harga jual
                        jumlahRefundCell.Value = jumlahCell.Value;
                        hargaRefundCell.Value = hargaCell.Value;
                        
                        // subtotal = (jumlah * harga jual) - (jumlah ret * harga ret)
                        subTotalCell.Value = ((int)jumlahCell.Value * (int)hargaCell.Value) - ((int)jumlahRefundCell.Value * (int)hargaRefundCell.Value);
                        
                        // Update object
                        penjualan.PenjualanDetails[e.RowIndex].Jumlah_Refund = Convert.ToInt32(jumlahRefundCell.Value);
                        penjualan.PenjualanDetails[e.RowIndex].Harga_Refund = Convert.ToInt32(hargaRefundCell.Value);
                        penjualan.PenjualanDetails[e.RowIndex].Sub_Total = Convert.ToInt32(subTotalCell.Value);
                        penjualan.PenjualanDetails[e.RowIndex].Is_Refund = true;
                    }
                }
                else
                {
                    jumlahRefundCell.Value = 0;
                    hargaRefundCell.Value = 0;
                    subTotalCell.Value = ((int)jumlahCell.Value * (int)hargaCell.Value);

                    // Update object
                    penjualan.PenjualanDetails[e.RowIndex].Jumlah_Refund = 0;
                    penjualan.PenjualanDetails[e.RowIndex].Harga_Refund = 0;
                    penjualan.PenjualanDetails[e.RowIndex].Sub_Total = Convert.ToInt32(subTotalCell.Value);
                    penjualan.PenjualanDetails[e.RowIndex].Is_Refund = false;
                }

                // Hitung total
                RecountDGV();
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ReturButton_Click(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show(this, "Apakah transaksi ini akan di refund ?", "Konfirmasi", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (dialogResult == System.Windows.Forms.DialogResult.OK)
            {
                // prepare transaksi
                var transaction = DbConnection.BeginTransaction();

                // Update waktu refund
                penjualan.Waktu_Refund = WaktuRefundDTP.Value;
                penjualan.Is_Refund = true;

                // Update ke database
                var result = Model.Penjualan.UpdateForRefund(transaction, this.penjualan);

                // Update kartu stok
                result = Model.KartuStok.UpdatePenjualanRefund(transaction, this.penjualan);

                // Commit transaksi
                transaction.Commit();

                if (result)
                {

                    // Load struk Refund
                    var strukRefund = this.configs.First(c => c.Nama == "template_struk_refund").Nilai;

                    // Cetak Struk
                    RefundForm.PrintRefundStruk(this.penjualan, strukRefund, Properties.Settings.Default.PrinterName, Properties.Settings.Default.PrinterSpace);

                    // Pesan ke user
                    MessageBox.Show(this, "Retur telah berhasil disimpan", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //
                    this.Close();
                }
            }
            
        }

        public static void PrintRefundStruk(Model.Penjualan penjualan, string templateStruk, string printerName, int printerSpace)
        {
            var struk = new StringBuilder(templateStruk);
            struk
                .Replace("[DEPARTEMEN]", penjualan.Departemen.Nama_Departemen)
                .Replace("[DEPARTEMEN_ALAMAT]", penjualan.Departemen.Alamat_Departemen)
                .Replace("[DEPARTEMEN_KOTA]", penjualan.Departemen.Kota_Departemen)
                .Replace("[DEPARTEMEN_TELP]", penjualan.Departemen.Telp_Departemen)
                .Replace("[KODE_TRX]", penjualan.Kode_Transaksi)
                .Replace("[KASIR]", penjualan.UserRefund.Nama_User)
                .Replace("[WAKTU_TRX]", penjualan.Waktu_Refund.ToString("dd/MM/yyyy hh:mm:ss"));

            // Populate item terjual
            var itemsSB = new StringBuilder();

            for (int i = 0; i < penjualan.PenjualanDetails.Count; i++)
            {
                var detail = penjualan.PenjualanDetails[i];

                /* *
                 * Format Item (40) :    AAAAAAAAAAAAAAA_000_AAA_999.999_9.999.999
                 * Refund           :    ---_RETUR_-000_____999.999_
                 * Nama Item : 14 >>  AAAAAAAAAAAAAAA
                 * Jumlah    : (1) + 3  >> _000
                 * Satuan    : (1) + 3  >> _AAA
                 * Harga     : (1) + 7  >> _999.999
                 * Sub Total : (1) + 9  >> _9.999.999
                 * 
                 * Contoh : 
                 * -----------------------------------
                 * OBH COMB      50 BTL 2.000  100.000
                 *     RETUR     -5 BTL 2.000  -10.000
                 * OSKADON       10 PCS 1.000   10.000
                 *     RETUR     -1 PCS 1.000   -1.000
                 * PROMAG       100 PCS 1.000  100.000
                 *     RETUR    -10 PCS   500   -5.000
                 * -----------------------------------
                 *              Subtotal       210.000
                 *              Potongan        -5.000
                 *              Biaya Lain       5.000
                 *              ----------------------
                 *              Total          199.000
                 *              ======================
                 *              RETUR          -16.000
                 * */

                // Building line String
                var formatLine = (
                    detail.Nama_Item.PadRight(14).Substring(0, 14) +
                    " " + detail.Jumlah.ToString().PadLeft(3) +
                    " " + detail.Nama_Satuan.PadRight(3).Substring(0, 3) +
                    " " + detail.Harga_Jual.ToString("N0").PadLeft(7) +
                    " " + detail.Sub_Total.ToString("N0").PadLeft(9));

                if (detail.Is_Refund)
                {
                    formatLine += Environment.NewLine +
                        "----> RETUR".PadRight(14) +
                        " " + detail.Jumlah_Refund.ToString().PadLeft(3) +
                        " " + detail.Nama_Satuan.PadRight(3).Substring(0, 3) +
                        (0 - detail.Harga_Refund).ToString("N0").PadLeft(8);
                }

                // Ditambahkan NewLine jika belum baris terakhir
                if (i < penjualan.PenjualanDetails.Count - 1)
                    itemsSB.AppendLine(formatLine);
                else
                    itemsSB.Append(formatLine);
            }

            // Replace to template
            struk.Replace("[[ITEM]]", itemsSB.ToString());

            var totalSB = new StringBuilder();

            totalSB.AppendLine("Sub Total = ".PadLeft(25) + penjualan.Total_Biaya.ToString("N0").PadLeft(15));
                
            if (penjualan.Biaya_Potongan > 0)
                totalSB.AppendLine("Potongan = ".PadLeft(25) + (0 - penjualan.Biaya_Potongan).ToString("N0").PadLeft(15));

            if (penjualan.Biaya_Lain > 0)
                totalSB.AppendLine((penjualan.Biaya_Lain == 0) ? "" : "Biaya Lain = ".PadLeft(25) + penjualan.Biaya_Lain.ToString("N0").PadLeft(15));

            totalSB.AppendLine("----------------------------".PadLeft(40));
            totalSB.AppendLine("Total = ".PadLeft(25) + penjualan.Total_Biaya_Akhir.ToString("N0").PadLeft(15));

            totalSB.AppendLine("============================".PadLeft(40));
            totalSB.AppendLine("Retur = ".PadLeft(25) + (0 - penjualan.Total_Biaya_Refund).ToString("N0").PadLeft(15));

            struk.Replace("[[TOTAL]]", totalSB.ToString());

            // System.Diagnostics.Debug.WriteLine(struk.ToString());

            // Space
            struk.Append('\n', printerSpace);

            // Print POS
            var printer = new PrintDirect();
            printer.Print(printerName, struk.ToString(), "STRUK");
        }
    }
}
