using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Dapper;

namespace MCS_POS.Master
{
    public partial class CustomerForm : MCS_POS.ChildBaseForm
    {
        public CustomerForm()
        {
            InitializeComponent();
        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {
            // SELECT Customer
            const string sqlSelect = "select id_customer, nama_customer, alamat_customer, telp_customer from customer";
            Adapter = new MySqlDataAdapter(sqlSelect, (MySqlConnection)DbConnection);
            CommandBuilder = new MySqlCommandBuilder((MySqlDataAdapter)Adapter);
            Adapter.InsertCommand = CommandBuilder.GetInsertCommand();
            Adapter.UpdateCommand = CommandBuilder.GetUpdateCommand();
            Adapter.DeleteCommand = CommandBuilder.GetDeleteCommand();
            dataSet = new System.Data.DataSet();

            ((MySqlDataAdapter)Adapter).Fill(dataSet, "Customer");
            DGV.DataSource = dataSet.Tables["Customer"];

            // Format disable null
            dataSet.Tables[0].Columns["nama_customer"].AllowDBNull = false;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                var i = ((MySqlDataAdapter)Adapter).Update(this.dataSet, "Customer");

                if (i > 0)
                {
                    MsgBox.Info("Data berhasil disimpan");
                }
            }
            catch (Exception ex)
            {
                ExceptionBox(ex);
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
