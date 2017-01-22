using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace MCS_POS.Master
{
    public partial class CabangForm : MCS_POS.ChildBaseForm
    {
        public CabangForm() : this(null, null, null) { }

        public CabangForm(Form parent, IDbConnection dbConnection, TabControl tabControl)
        {
            InitializeComponent();

            MdiParent = parent;
            DbConnection = dbConnection;
            TabControlReference = tabControl;
        }

        private void CabangForm_Load(object sender, EventArgs e)
        {
            Adapter = new MySqlDataAdapter("select id_departemen, kode_departemen, nama_departemen, alamat_departemen, kota_departemen, telp_departemen from departemen", (MySqlConnection)DbConnection);
            CommandBuilder = new MySqlCommandBuilder((MySqlDataAdapter)Adapter);
            dataSet = new System.Data.DataSet();

            ((MySqlDataAdapter)Adapter).Fill(dataSet, "Departemen");
            DGV.DataSource = dataSet.Tables["Departemen"];

            // Format disable null
            dataSet.Tables[0].Columns["kode_departemen"].AllowDBNull = false;
            dataSet.Tables[0].Columns["nama_departemen"].AllowDBNull = false;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            var i = ((MySqlDataAdapter)Adapter).Update(this.dataSet, "Departemen");

            if (i > 0)
            {
                MsgBox.Info("Data berhasil disimpan");
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (DGV.SelectedRows.Count == 1)
            {
                if (MsgBox.Question("Data akan dihapus. Anda yakin ingin melanjutkan ?") == System.Windows.Forms.DialogResult.OK)
                {
                    DGV.Rows.RemoveAt(DGV.SelectedRows[0].Index);
                }
            }
        }
    }
}
