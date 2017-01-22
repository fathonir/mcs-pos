using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using Dapper;
using MySql.Data.MySqlClient;

namespace MCS_POS.Kasir
{
    public partial class BrowseItemForm : Form
    {
        public IDbConnection DbConnection { get; set; }

        public int IdDepartemenAktif { get; set; }
        public int SelectedID_Item { get; set; }
        public int SelectedID_Satuan { get; set; }

        private DataTable dataTableDGV = new DataTable();
        private MySql.Data.MySqlClient.MySqlDataAdapter dataAdapter;
        private System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();

        public BrowseItemForm()
        {
            InitializeComponent();
        }

        private void BrowseItemForm_Load(object sender, EventArgs e)
        {
            DGV.RowTemplate.Height = 30;

            PrepareDataSource();
            FindItem();
        }

        private void PrepareDataSource()
        {
            var sql = @"
                SELECT
	                item.id_item,
	                item.kode_item,
                    satuan_item.barcode,
                    item.nama_item,
                    satuan.id_satuan,
                    satuan.nama_satuan,
                    ifnull(stok_item.stok / satuan_item.konversi_jumlah,0) as stok,
                    satuan_item.harga_jual
                FROM
	                item
                JOIN satuan_item ON satuan_item.id_item = item.id_item
                JOIN satuan ON satuan.id_satuan = satuan_item.id_satuan
                LEFT JOIN stok_item ON stok_item.id_item = item.id_item AND stok_item.id_departemen = @id_departemen
                WHERE item.kode_item LIKE @search1 OR item.nama_item LIKE @search2
                ORDER BY item.nama_item ASC, satuan.nama_satuan ASC";

            var command = ((MySqlConnection)DbConnection).CreateCommand();
            command.CommandText = sql;
            command.Parameters.Add("@id_departemen", MySql.Data.MySqlClient.MySqlDbType.Int32);
            command.Parameters.Add("@search1", MySql.Data.MySqlClient.MySqlDbType.String);
            command.Parameters.Add("@search2", MySql.Data.MySqlClient.MySqlDbType.String);
            dataAdapter = new MySqlDataAdapter(command);
            DGV.DataSource = dataTableDGV;
        }

        private void FindItem()
        {
            if (KeywordTextBox.Text.Trim().Length > 1)
            {
                this.Cursor = Cursors.WaitCursor;

                // Clear
                dataTableDGV.Clear();

                // Update parameters
                dataAdapter.SelectCommand.Parameters["@id_departemen"].Value = this.IdDepartemenAktif;
                dataAdapter.SelectCommand.Parameters["@search1"].Value = KeywordTextBox.Text + "%";
                dataAdapter.SelectCommand.Parameters["@search2"].Value = "%" + KeywordTextBox.Text + "%";
                dataAdapter.Fill(dataTableDGV);

                // Show total
                TotalItemLabel.Text = "Total Item : " + dataTableDGV.Rows.Count;

                this.Cursor = Cursors.Default;
            }
        }

        private void KeywordTextBox_TextChanged(object sender, EventArgs e)
        {
            // Sudah di inialisasi & keyword minimal 2 karakter
            if (dataAdapter != null && KeywordTextBox.Text.Trim().Length > 1)
            {
                stopwatch.Start();

                FindItem();

                stopwatch.Stop();

                if (Debugger.IsAttached) Debug.WriteLine("Fill time : " + stopwatch.Elapsed.ToString());

                stopwatch.Reset();
            }
        }

        private void BrowseItemForm_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void DGV_DataSourceChanged(object sender, EventArgs e)
        {
            if (Debugger.IsAttached) Debug.WriteLine("DGV_DataSourceChanged("+sender.ToString()+")");
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {

            this.SelectedID_Item = (int)DGV.SelectedRows[0].Cells[ColumnID_Item.Name].Value;
            this.SelectedID_Satuan = (int)DGV.SelectedRows[0].Cells[ColumnID_Satuan.Name].Value;

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void KeywordTextBox_Click(object sender, EventArgs e)
        {
            // Show virtual Keyboard

            using (var vKeyboard = new VirtualKeyboard.VirtualKeyboardForm())
            {
                vKeyboard.StringValue = KeywordTextBox.Text;
                
                if (vKeyboard.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    KeywordTextBox.Text = vKeyboard.StringValue;
                }
            }
        }

        private void KeywordTextBox_MouseDown(object sender, MouseEventArgs e)
        {
            (sender as TextBox).BackColor = Color.LightGoldenrodYellow;
        }

        private void KeywordTextBox_MouseUp(object sender, MouseEventArgs e)
        {
            (sender as TextBox).BackColor = SystemColors.Window;
        }
    }
}
