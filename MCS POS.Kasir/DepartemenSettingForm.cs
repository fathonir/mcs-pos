using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MCS_POS.Model;

namespace MCS_POS.Kasir
{
    public partial class DepartemenSettingForm : Form
    {
        public IDbConnection DbConnection { get; set; }

        public DepartemenSettingForm()
        {
            InitializeComponent();
        }

        private void DepartemenSettingForm_Load(object sender, EventArgs e)
        {
            // Populate Departemen
            comboBox1.DataSource = Model.Departemen.GetDepartemenForCombo(DbConnection).ToList();
            comboBox1.ValueMember = "id_departemen";
            comboBox1.DisplayMember = "nama_departemen";

            // Set Select
            if (Properties.Settings.Default.ID_Departemen != -1)
            {
                comboBox1.SelectedValue = Properties.Settings.Default.ID_Departemen;
            }
        }

        private void touchButton1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue != null)
            {
                Properties.Settings.Default.ID_Departemen = (int)comboBox1.SelectedValue;
                Properties.Settings.Default.Save();
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
            }
        }
    }
}
