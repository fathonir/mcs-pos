using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MCS_POS.Persediaan
{
    public partial class ProsesBulananForm : Form
    {
        public List<Model.Config> Configs { get; set; }
        public IDbConnection DbConnection { get; set; }
        public Model.Departemen DepartemenAktif { get; set; }

        private DateTime PeriodeAwal { get; set; }

        public ProsesBulananForm()
        {
            InitializeComponent();
        }

        private void ProsesBulananForm_Load(object sender, EventArgs e)
        {
            PeriodeAwal = Convert.ToDateTime(Configs.Single(c => c.Nama == Model.Config.PERIODE_AWAL).Nilai);
            label3.Text = "Periode Awal Aplikasi : " + PeriodeAwal.ToString("MMMM yyyy");

            // Mulai 2015 hingga tahun sekarang
            TahunUpDown.Minimum = 2015M;
            TahunUpDown.Maximum = Convert.ToDecimal(DateTime.Now.ToString("yyyy"));

            // Dapatkan bulan kemarin
            var bulanLalu = DateTime.Now.AddMonths(-1);
            BulanComboBox.Text = bulanLalu.ToString("MMMM");
            TahunUpDown.Value = bulanLalu.Year;
        }

        private void ProsesButton_Click(object sender, EventArgs e)
        {
            // Cursor Loading
            this.Cursor = Cursors.WaitCursor;

            // Cek dari batas periode awal
            var bulanProses = Convert.ToDateTime("01 " + BulanComboBox.Text + " " + TahunUpDown.Value);

            if (bulanProses < PeriodeAwal)
            {
                MessageBox.Show(this, "Periode ini belum ada transaksi", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Cursor = Cursors.Default;
                return;
            }

            var transaction = DbConnection.BeginTransaction();

            var departemenList = Model.Departemen.GetDepartemenForCombo(DbConnection);

            foreach (var departemen in departemenList)
            {
                // Proses Bulanan
                Model.KartuStok.ProsesBulanan(transaction, departemen, BulanComboBox.Text, (int)TahunUpDown.Value, PeriodeAwal, PerbaikiStokCheckBox.Checked);
            }

            transaction.Commit();

            // Kembalikan cursor
            this.Cursor = Cursors.Default;

            MessageBox.Show(this, "Proses penghitungan bulanan berhasil", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
