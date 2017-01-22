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
    public partial class MerekForm : MCS_POS.ChildBaseForm
    {
        public MerekForm() : this(null, null, null) { }

        public MerekForm(Form parent, IDbConnection dbConnection, TabControl tabControl)
        {
            InitializeComponent();

            MdiParent = parent;
            DbConnection = dbConnection;
            TabControlReference = tabControl;
        }

        private void MerekForm_Load(object sender, EventArgs e)
        {
            Adapter = new MySqlDataAdapter("select * from merek_item", (MySqlConnection)DbConnection);
            CommandBuilder = new MySqlCommandBuilder((MySqlDataAdapter)Adapter);
            dataSet = new System.Data.DataSet();

            ((MySqlDataAdapter)Adapter).Fill(dataSet, "Merek Item");
            DGV.DataSource = dataSet.Tables["Merek Item"];

            // Format disable null
            dataSet.Tables[0].Columns["nama_merek_item"].AllowDBNull = false;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            var i = ((MySqlDataAdapter)Adapter).Update(this.dataSet, "Merek Item");

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

        private void DGV_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                if (!(DGV.Rows[e.RowIndex].Cells[0].Value is DBNull))
                {
                    // Modified Column = 3
                    DGV.Rows[e.RowIndex].Cells[3].Value = DateTime.Now;
                }
            }
        }
    }
}
