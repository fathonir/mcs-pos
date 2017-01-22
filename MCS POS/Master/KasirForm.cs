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
    public partial class KasirForm : MCS_POS.ChildBaseForm
    {
        public KasirForm()
        {
            InitializeComponent();
        }

        private void KasirForm_Load(object sender, EventArgs e)
        {
            // Create Data set
            dataSet = new System.Data.DataSet();

            // Departemen
            var departemenAdapter = new MySqlDataAdapter("SELECT id_departemen, nama_departemen FROM departemen", (MySqlConnection)DbConnection);
            departemenAdapter.Fill(dataSet, "departemen");
            ColumnDepartemen.DataSource = dataSet.Tables["departemen"];
            ColumnDepartemen.ValueMember = "id_departemen";
            ColumnDepartemen.DisplayMember = "nama_departemen";

            // User / Kasir
            var sql =
                @"SELECT id_user, tipe_user, username, nama_user, 
                null as password_hash, id_departemen, is_aktif, akses_refund, akses_harga_jual, akses_data_penjualan,
                created, modified FROM `User` WHERE tipe_user = 'kasir'";
            Adapter = new MySqlDataAdapter(sql, (MySqlConnection)DbConnection);
            ((MySqlDataAdapter)Adapter).Fill(dataSet, "User");
            DGV.DataSource = dataSet.Tables["User"];

            // CommandBuilder
            CommandBuilder = new MySqlCommandBuilder((Adapter as MySqlDataAdapter));

            // Replace Update Command
            Adapter.UpdateCommand = ((MySqlConnection)DbConnection).CreateCommand();
            Adapter.UpdateCommand.CommandText = 
                @"UPDATE `User` SET 
                    nama_user = @nama_user,
                    password_hash = sha1(@password_hash),
                    id_departemen = @id_departemen,
                    is_aktif = @is_aktif,
                    akses_refund = @akses_refund,
                    akses_harga_jual = @akses_harga_jual,
                    akses_data_penjualan = @akses_data_penjualan
                WHERE id_user = @id_user";

            (Adapter as MySqlDataAdapter).UpdateCommand.Parameters.AddRange(new object[] {
                new MySqlParameter("@nama_user", MySqlDbType.String, 20, "nama_user"),
                new MySqlParameter("@password_hash", MySqlDbType.String, 40, "password_hash"),
                new MySqlParameter("@id_departemen", MySqlDbType.Int32, 11, "id_departemen"),
                new MySqlParameter("@is_aktif", MySqlDbType.Int32, 1, "is_aktif"),
                new MySqlParameter("@akses_refund", MySqlDbType.Int32, 1, "akses_refund"),
                new MySqlParameter("@akses_harga_jual", MySqlDbType.Int32, 1, "akses_harga_jual"),
                new MySqlParameter("@akses_data_penjualan", MySqlDbType.Int16, 1, "akses_data_penjualan"),
                new MySqlParameter("@id_user", MySqlDbType.Int32, 11, "id_user")
            });

            // Format disable null
            dataSet.Tables["User"].Columns["nama_user"].AllowDBNull = false;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            var i = ((MySqlDataAdapter)Adapter).Update(this.dataSet, "User");

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
