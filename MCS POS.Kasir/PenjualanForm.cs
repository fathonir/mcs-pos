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
    public partial class PenjualanForm : Form
    {
        public IDbConnection DbConnection { get; set; }
        public Model.Departemen DepartemenAktif { get; set; }
        private IEnumerable<Model.Config> Configs { get; set; }

        public PenjualanForm()
        {
            InitializeComponent();
        }

        private void PenjualanForm_Shown(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            // Load semua, untuk hari ini
            DGV.DataSource = Model.Penjualan.GetListPenjualanKasir(DbConnection, DepartemenAktif);
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

            DGV.DataSource = Model.Penjualan.GetListPenjualanKasir(DbConnection, DepartemenAktif, filterHari, (int)KasirComboBox.SelectedValue, false);
        }

        private void PrintButton_Click(object sender, EventArgs e)
        {
            // Prepare variabel
            var id_penjualan = DGV.SelectedRows[0].Cells[ColumnID_Penjualan.Name].Value;
            var penjualan = Model.Penjualan.GetSingle(DbConnection, (int)id_penjualan);
            var template_struk = Configs.First(c => c.Nama == "template_struk_kasir").Nilai;

            penjualan.PenjualanDetails = Model.PenjualanDetail.GetListOfPenjualan(DbConnection, penjualan);
            penjualan.Departemen = this.DepartemenAktif;
            penjualan.User = Model.User.GetSingle(DbConnection, penjualan.ID_User);
            
            // Lets Print
            KasirForm.PrintStruk(penjualan, template_struk, Properties.Settings.Default.PrinterName, Properties.Settings.Default.PrinterSpace);
        }

        private void RefundButton_Click(object sender, EventArgs e) 
        {
            // Pastikan ada yg terpilih
            if (DGV.SelectedRows.Count == 0) { return; }

            var authForm = new LoginForm() { DbConnection = this.DbConnection, AksesRefund = true };

            if (authForm.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                // Cek hak akses
                if (!authForm.UserLogin.Akses_Refund)
                {
                    MessageBox.Show("Anda tidak mempunyai akses utk refund");
                    return;
                }

                // Mendapatkan id penjualan
                var id_penjualan = (int)DGV.SelectedRows[0].Cells[ColumnID_Penjualan.Name].Value;

                var refundForm = new RefundForm()
                {
                    DbConnection = this.DbConnection,
                    MdiParent = this.MdiParent,
                    ID_Penjualan = id_penjualan,    // id penjualan
                    UserLogin = authForm.UserLogin  // user yg melakukan retur
                };

                refundForm.Show();

                // Refill datagrid
                RefillDGV();
            }
        }

        private void DetailButton_Click(object sender, EventArgs e)
        {
            // Pastikan ada yg terpilih
            if (DGV.SelectedRows.Count == 0) { return; }

            var detailForm = new PenjualanDetailForm()
            {
                DbConnection = this.DbConnection,
                ID_Penjualan = (int)DGV.SelectedRows[0].Cells[ColumnID_Penjualan.Name].Value
            };

            detailForm.ShowDialog(this);
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
    }
}
