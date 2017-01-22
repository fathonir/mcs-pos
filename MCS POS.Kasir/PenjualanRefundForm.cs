using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCS_POS.Kasir
{
    public partial class PenjualanRefundForm : Form
    {
        public IDbConnection DbConnection { get; set; }
        public Model.Departemen DepartemenAktif { get; set; }
        private IEnumerable<Model.Config> Configs { get; set; }

        public PenjualanRefundForm()
        {
            InitializeComponent();
        }

        private void PenjualanForm_Shown(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            // Load semua, untuk hari ini
            DGV.DataSource = Model.Penjualan.GetListPenjualanKasir(DbConnection, DepartemenAktif, 0, 0, true);
        }

        private void PenjualanForm_Load(object sender, EventArgs e)
        {
            // Load configs from database
            Configs = Model.Config.GetAll(DbConnection);

            // List Kasir
            var kasirList = Model.User.GetListKasirAktif(DbConnection, DepartemenAktif.ID_Departemen);
            kasirList.Insert(0, new Model.User() { ID_User = 0, Nama_User = "-- SEMUA --" });
            KasirComboBox.DataSource = kasirList;
            KasirComboBox.DisplayMember = "nama_user";
            KasirComboBox.ValueMember = "id_user";

            // select hari ini
            FilterComboBox.SelectedIndex = 0;
        }

        private void FilterComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DGV.DataSource != null)
            {
                RefillDGV();
            }
            
        }

        private void KasirComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DGV.DataSource != null)
            {
                RefillDGV();
            }
        }

        private void RefillDGV()
        {
            int filterHari = 0;

            if (FilterComboBox.Text == "Kemarin")
            {
                filterHari = 1;
            }
            else if (FilterComboBox.Text == "1 Minggu")
            {
                filterHari = 7;
            }
            else if (FilterComboBox.Text == "2 Minggu")
            {
                filterHari = 14;
            }
            else if (FilterComboBox.Text == "3 Minggu")
            {
                filterHari = 21;
            }
            else if (FilterComboBox.Text == "1 Bulan")
            {
                filterHari = 30;
            }

            DGV.DataSource = Model.Penjualan.GetListPenjualanKasir(DbConnection, DepartemenAktif, filterHari, (int)KasirComboBox.SelectedValue, true);
        }
    }
}
