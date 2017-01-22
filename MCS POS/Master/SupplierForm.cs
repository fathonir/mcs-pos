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
    public partial class SupplierForm : MCS_POS.ChildBaseForm
    {
        public SupplierForm() : this(null, null, null) { }

        public SupplierForm(Form parent, IDbConnection dbConnection, TabControl tabControl)
        {
            InitializeComponent();

            MdiParent = parent;
            DbConnection = dbConnection;
            TabControlReference = tabControl;
        }

        private void SupplierForm_Load(object sender, EventArgs e)
        {
            Adapter = new MySqlDataAdapter("select * from supplier", (MySqlConnection)DbConnection);
            CommandBuilder = new MySqlCommandBuilder((MySqlDataAdapter)Adapter);
            dataSet = new System.Data.DataSet();

            ((MySqlDataAdapter)Adapter).Fill(dataSet, "Supplier");
            DGV.DataSource = dataSet.Tables["Supplier"];

            // Format disable null
            dataSet.Tables[0].Columns["kode_supplier"].AllowDBNull = false;
            dataSet.Tables[0].Columns["nama_supplier"].AllowDBNull = false;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            var i = ((MySqlDataAdapter)Adapter).Update(this.dataSet, "Supplier");

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
                    // Modified Column = 6
                    DGV.Rows[e.RowIndex].Cells[6].Value = DateTime.Now;
                }
            }
        }
    }
}
