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
    public partial class SatuanForm : MCS_POS.ChildBaseForm
    {
        public SatuanForm() : this(null, null, null) { }

        public SatuanForm(Form parent, IDbConnection dbConnection, TabControl tabControl)
        {
            InitializeComponent();

            MdiParent = parent;
            DbConnection = dbConnection;
            TabControlReference = tabControl;
        }

        private void SatuanForm_Load(object sender, EventArgs e)
        {
            Adapter = new MySqlDataAdapter("select * from satuan", (MySqlConnection)DbConnection);
            CommandBuilder = new MySqlCommandBuilder((MySqlDataAdapter)Adapter);
            dataSet = new DataSet();

            ((MySqlDataAdapter)Adapter).Fill(dataSet, "satuan");
            DGV.DataSource = dataSet.Tables["Satuan"];

            // Format disable null
            dataSet.Tables[0].Columns["nama_satuan"].AllowDBNull = false;
        }

        private void SatuanForm_Shown(object sender, EventArgs e)
        {
            DGV.DataSource = dataSet.Tables["Satuan"];
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            var i = ((MySqlDataAdapter)Adapter).Update(this.dataSet, "Satuan");

            if (i > 0)
            {
                MsgBox.Info("Data berhasil disimpan");
            }
        }

        private void DGV_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                if (!(DGV.Rows[e.RowIndex].Cells[0].Value is DBNull))
                {
                    // Modified Column = 4
                    DGV.Rows[e.RowIndex].Cells[4].Value = DateTime.Now;
                }
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
