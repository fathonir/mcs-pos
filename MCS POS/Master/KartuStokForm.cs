using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Dapper;

namespace MCS_POS.Master
{
    public partial class KartuStokForm : MCS_POS.EditorBaseForm
    {
        public new List<Model.Config> Configs { get; set; }
        public new Model.Departemen DepartemenAktif { get; set; }

        private Model.Item SelectedItem { get; set; }

        public KartuStokForm()
        {
            InitializeComponent();
        }

        private void KartuStokForm_Load(object sender, EventArgs e)
        {
            DepartemenComboBox.DataSource = Model.Departemen.GetDepartemenForCombo(DbConnection, true);
            DepartemenComboBox.DisplayMember = "nama_departemen";
            DepartemenComboBox.ValueMember = "id_departemen";

            // set selected departemen aktif
            DepartemenComboBox.SelectedValue = DepartemenAktif.ID_Departemen;

            // Mendapatkan tahun terendah tertinggi
            var minYear = DbConnection.ExecuteScalar<int>("SELECT MIN(YEAR(waktu_transaksi)) FROM kartu_stok");
            for (var year = minYear; year <= DateTime.Today.Year; year++)
                TahunComboBox.Items.Add(year);
        }

        private void KartuStokForm_Shown(object sender, EventArgs e)
        {
            BulanComboBox.Text = DateTime.Now.ToString("MMMM");
        } 

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            var browseDialog = new BrowseItemForm()
            {
                DbConnection = this.DbConnection,
                DepartemenAktif = this.DepartemenAktif
            };

            if (browseDialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                SelectedItem = browseDialog.SelectedItem;
                ItemLabel.Text = SelectedItem.Nama_Item;
            }
        }

        private void ProsesButton_Click(object sender, EventArgs e)
        {
            if (SelectedItem == null)
            {
                MessageBox.Show(this, "Pilih item terlebih dahulu", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Ambil Periode Awal aplikasi
            var periodeAwal = Convert.ToDateTime(Configs.Find(c => c.Nama == Model.Config.PERIODE_AWAL).Nilai);

            // Kosongkan tabel
            DGV.Rows.Clear();

            // Informasi Kolom
            // Kode transaksi,
            // waktu transaksi
            // tipe
            // keterangan
            // masuk
            // keluar
            // saldo
            // pelanggan / supplier

            // Ambil data kartu_stok
            // var kartuStokList = Model.KartuStok.GetList(DbConnection, DepartemenAktif, SelectedItem, BulanComboBox.Text, (int)TahunUpDown.Value);

            var x = BulanComboBox.SelectedIndex;

            // var tanggalSatu = Convert.ToDateTime("01 " + BulanComboBox.Text + " " + (int)TahunUpDown.Value);
            var tanggalSatu = new DateTime(int.Parse(TahunComboBox.Text), BulanComboBox.SelectedIndex + 1, 1);
            var akhirBulan = tanggalSatu.AddMonths(1).AddSeconds(-1d);
            var sql = "";

            // Saat pilihan departemen aktif
            if ((int)DepartemenComboBox.SelectedValue > 0)
            {
                sql = @"
                    SELECT * FROM kartu_stok 
                    WHERE 
                        id_departemen = @id_departemen AND
                        id_item = @id_item AND 
                        (waktu_transaksi BETWEEN @awal AND @akhir) 
                    ORDER BY waktu_transaksi ASC";
            }
            else
            {
                sql = @"
                    SELECT * FROM kartu_stok 
                    WHERE 
                        id_item = @id_item AND 
                        (waktu_transaksi BETWEEN @awal AND @akhir) 
                    ORDER BY waktu_transaksi ASC";
            }

            var kartuStokList = DbConnection.Query<Model.KartuStok>(sql, new {
                id_item = SelectedItem.ID_Item,
                id_departemen = DepartemenComboBox.SelectedValue,
                awal = tanggalSatu,
                akhir = akhirBulan
            }).ToList();

            if (kartuStokList.Count == 0)
            {
                MessageBox.Show("Tidak ada data kartu stok, silahkan lakukan Proses Bulanan pada periode ini");
                return;
            }

            foreach (var kartuStok in kartuStokList)
            {
                // Format tampilan keterangan
                if (kartuStok.Tipe == "SA") kartuStok.Keterangan = "Saldo Awal";

                if (kartuStok.Tipe == "JL")
                {
                    if (kartuStok.Masuk > 0) kartuStok.Keterangan = "Penjualan (+ Retur)";
                    else kartuStok.Keterangan = "Penjualan";
                }

                // Konversi ke keterangan
                if (kartuStok.Tipe == "BL") kartuStok.Keterangan = "Pembelian";
                if (kartuStok.Tipe == "OP") kartuStok.Keterangan = "Stok Opname";
                if (kartuStok.Tipe == "TR") kartuStok.Keterangan = "Transfer";
                if (kartuStok.Tipe == "KIN") kartuStok.Keterangan = "Konsinyasi Masuk";
                if (kartuStok.Tipe == "RKI") kartuStok.Keterangan = "Konsinyasi Retur";

                // Tambahkan ke tabel
                DGV.Rows.Add(new object[] {
                    kartuStok.Kode_Transaksi,
                    kartuStok.Waktu_Transaksi,
                    kartuStok.Tipe,
                    kartuStok.Keterangan,
                    kartuStok.Masuk,
                    kartuStok.Keluar,
                    kartuStok.Saldo
                });
            }

            // Total Masuk : 
            TotalMasukTextBox.Text = kartuStokList.Sum(ks => ks.Masuk).ToString("N0");
            TotalKeluarTextBox.Text = kartuStokList.Sum(ks => ks.Keluar).ToString("N0");

            if (kartuStokList.FirstOrDefault() != null)
                SaldoAwalTextBox.Text = kartuStokList.First().Saldo.ToString("N0");
            else
                SaldoAwalTextBox.Text = "0";

            if (kartuStokList.LastOrDefault() != null)
                SaldoAkhirTextBox.Text = kartuStokList.Last().Saldo.ToString("N0");
            else
                SaldoAkhirTextBox.Text = "0";
        }

        
    }
}
