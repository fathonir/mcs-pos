using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace MCS_POS.Konsinyasi
{
    public partial class PembayaranKonsinyasiForm : System.Windows.Forms.Form
    {
        public IDbConnection DbConnection { get; set; }
        public int ID { get; set; }
        public Model.User UserLogin { get; set; }
        public Model.Departemen DepartemenAktif { get; set; }
        public List<Model.Config> Configs { get; set; }

        private MySqlDataAdapter Adapter { get; set; }
        private DataTable DGVTable;
        private Model.Konsinyasi konsinyasi;
        private Model.KonsinyasiPembayaran konsinyasiPembayaran;

        public PembayaranKonsinyasiForm()
        {
            InitializeComponent();
        }

        private void PembayaranKonsinyasiForm_Load(object sender, EventArgs e)
        {
            // Ambil data konsinyasi
            konsinyasi = Model.Konsinyasi.GetSingle(DbConnection, this.ID, true, true, true);
            
            // Buat object pembayaran konsinyasi
            konsinyasiPembayaran = new Model.KonsinyasiPembayaran();
            konsinyasiPembayaran.KonsinyasiPembayaranDetails = new List<Model.KonsinyasiPembayaranDetail>();
            konsinyasiPembayaran.Konsinyasi = konsinyasi;
            konsinyasiPembayaran.ID_Konsinyasi = konsinyasi.ID_Konsinyasi;
            konsinyasiPembayaran.Konsinyasi = konsinyasi;konsinyasiPembayaran.Kode_Transaksi = Model.KonsinyasiPembayaran.GenerateKodeTransaksi(DbConnection, DepartemenAktif, Configs);
            konsinyasiPembayaran.User = UserLogin;
            konsinyasiPembayaran.ID_User = UserLogin.ID_User;
            konsinyasiPembayaran.Departemen = DepartemenAktif;
            konsinyasiPembayaran.ID_Departemen = DepartemenAktif.ID_Departemen;

            // Tampilkan ke user
            UserTextBox.Text = konsinyasiPembayaran.User.Nama_User;
            KodeKonsinyasiTextBox.Text = konsinyasi.Kode_Transaksi;
            KodeTransaksiTextBox.Text = konsinyasiPembayaran.Kode_Transaksi;

            // Fill Supplier ComboBox
            BankComboBox.DataSource = Model.Bank.GetList(DbConnection);
            BankComboBox.DisplayMember = "nama_bank";
            BankComboBox.ValueMember = "id_bank";

            DGVTable = new DataTable();
            DGV.DataSource = DGVTable;

            // disable bank combo sebelum dipilih
            BankComboBox.Enabled = false;
        }

        private void PembayaranKonsinyasiForm_Shown(object sender, EventArgs e)
        {
            // Load data detail konsinyasi
            var sql =
                @"SELECT 
	                id_konsinyasi_detail, i.kode_item, i.nama_item,
                    kd.jumlah, kd.jumlah_bayar, kd.jumlah_retur, (kd.jumlah_keluar - kd.jumlah_bayar) as jumlah_belum_bayar,
                    s.nama_satuan, harga_beli, (kd.jumlah_keluar - kd.jumlah_bayar) * harga_beli as sub_total
                FROM konsinyasi_detail kd
                JOIN item i ON i.id_item = kd.id_item
                JOIN satuan s ON s.id_satuan = kd.id_satuan
                WHERE kd.id_konsinyasi = " + this.ID;

            Adapter = new MySqlDataAdapter(sql, (MySqlConnection)this.DbConnection);
            Adapter.Fill(DGVTable);

            konsinyasiPembayaran.Jumlah_Bayar = DGVTable.Rows.Cast<DataRow>()
                .Sum(row => Convert.ToSingle(row["sub_total"]));
            TotalBiayaAkhirTextBox.Text = konsinyasiPembayaran.Jumlah_Bayar.ToString("N0");
        }

        private void TunaiRadioButton_Click(object sender, EventArgs e)
        {
            if (NonTunaiRadioButton.Checked)
                BankComboBox.Enabled = true;
            else
                BankComboBox.Enabled = false;
        }

        private void NonTunaiRadioButton_Click(object sender, EventArgs e)
        {
            if (NonTunaiRadioButton.Checked)
                BankComboBox.Enabled = true;
            else
                BankComboBox.Enabled = false;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            // Jumlah Item = Jumlah item yg belum dibayarkan
            konsinyasiPembayaran.Jumlah_Item = DGVTable.Rows.Cast<DataRow>()
                .Sum(row => Convert.ToSingle(row["jumlah_belum_bayar"]));

            // Jika tidak ada, batalkan
            if (konsinyasiPembayaran.Jumlah_Item == 0.0f) { MsgBox.Warning("Tidak ada barang yang harus dibayar.", MessageBoxButtons.OK); return; }

            // Set waktu transaksi
            konsinyasiPembayaran.Waktu_Transaksi = TanggalDTP.Value;
            konsinyasiPembayaran.Created = DateTime.Now;
            konsinyasiPembayaran.GUID = new Guid();

            // Status pembayaran (tunai non tunai)
            konsinyasiPembayaran.Is_Tunai = TunaiRadioButton.Checked;
            if (konsinyasiPembayaran.Is_Tunai == false)
                konsinyasiPembayaran.ID_Bank = Convert.ToInt32(BankComboBox.SelectedValue);

            // Ambil detail item
            foreach (var dataRow in DGVTable.Rows.Cast<DataRow>())
            {
                konsinyasiPembayaran.KonsinyasiPembayaranDetails.Add(
                    new Model.KonsinyasiPembayaranDetail() {
                        ID_Konsinyasi_Detail = Convert.ToInt32(dataRow["id_konsinyasi_detail"]),
                        Jumlah_Item = Convert.ToSingle(dataRow["jumlah_belum_bayar"]),
                        Jumlah_Sub_Total = Convert.ToSingle(dataRow["sub_total"])
                    });
            }

            // ------------------------------------
            // Mulai Proses transaksi pembayaran
            // ------------------------------------
            var transaction = this.DbConnection.BeginTransaction();

            try
            {
                // Tambah konsinyasi pembayaran
                Model.KonsinyasiPembayaran.Add(transaction, konsinyasiPembayaran);

                // Tambahkan pembayaran ke konsinyasi
                Model.Konsinyasi.AddPembayaran(transaction, konsinyasiPembayaran);

                transaction.Commit();

                MsgBox.Info("Pembayaran konsinyasi berhasil dilakukan");

                this.Close();
            }
            catch (Exception ex)
            {
                transaction.Rollback();

                throw ex;
            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
