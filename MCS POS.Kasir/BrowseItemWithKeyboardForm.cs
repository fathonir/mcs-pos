using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using MySql.Data.MySqlClient;

namespace MCS_POS.Kasir
{
    public partial class BrowseItemWithKeyboardForm : Form
    {
        public IDbConnection DbConnection { get; set; }
        public Model.Departemen DepartemenAktif { get; set; }

        // Output process
        public int SelectedID_Item { get; set; }
        public int SelectedID_Satuan { get; set; }

        private MySqlDataAdapter dgvDataAdapter;
        private DataTable dgvDataTable;
        private BindingSource dgvBindingSource;

        public BrowseItemWithKeyboardForm()
        {
            InitializeComponent();

            // Load position & size
            this.StartPosition = FormStartPosition.Manual;

            if (Properties.Settings.Default.BrowseItemFormLocation.X >= 0 && Properties.Settings.Default.BrowseItemFormLocation.Y >= 0)
                this.Location = Properties.Settings.Default.BrowseItemFormLocation;

            if (Properties.Settings.Default.BrowseItemFormSize.Width > 0 && Properties.Settings.Default.BrowseItemFormSize.Height > 0)
                this.Size = Properties.Settings.Default.BrowseItemFormSize;
        }

        private void KeywordTextBox_TextChanged(object sender, EventArgs e)
        {
            // Clear
            dgvDataTable.Clear();

            // Minimal 2 karakter
            if ((sender as TextBox).Text.Trim().Length > 1)
            {
                this.Cursor = Cursors.WaitCursor;

                // Update parameters
                dgvDataAdapter.SelectCommand.Parameters["@id_departemen"].Value = this.DepartemenAktif.ID_Departemen;
                dgvDataAdapter.SelectCommand.Parameters["@search1"].Value = KeywordTextBox.Text + "%";
                dgvDataAdapter.SelectCommand.Parameters["@search2"].Value = "%"+ KeywordTextBox.Text + "%";
                dgvDataAdapter.Fill(dgvDataTable);

                // Show total
                // TotalItemLabel.Text = "Total Item : " + dataTableDGV.Rows.Count;

                this.Cursor = Cursors.Default;
            }
        }

        private void BrowseItemWithKeyboardForm_Load(object sender, EventArgs e)
        {
            // Create Table Cache
            dgvDataTable = new DataTable();
            dgvDataTable.Columns.AddRange(new DataColumn[] {
                new DataColumn("ID_Item", typeof(int)),
                new DataColumn("Kode_Item", typeof(string)),
                new DataColumn("Nama_Item", typeof(string)),
                new DataColumn("ID_Satuan", typeof(int)),
                new DataColumn("Nama_Satuan", typeof(string)),
                new DataColumn("Stok", typeof(float)),
                new DataColumn("Harga_Jual", typeof(int)),
                new DataColumn("Aksi", typeof(string))
            });

            // Default button aksi
            dgvDataTable.Columns[7].DefaultValue = "PILIH";

            // Set to DGV
            dgvBindingSource = new BindingSource();
            dgvBindingSource.DataSource = dgvDataTable;
            DGV.DataSource = dgvBindingSource;

            // Define SQL browse
            const string sql = @"
                SELECT
	                item.id_item,
	                item.kode_item,
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
                WHERE item.is_dijual = 1 AND (item.kode_item LIKE @search1 OR item.nama_item LIKE @search2)
                ORDER BY item.nama_item ASC, satuan.nama_satuan ASC";

            // Create adapter connection
            dgvDataAdapter = new MySqlDataAdapter(sql, (DbConnection as MySqlConnection));
            dgvDataAdapter.SelectCommand.Parameters.Add("@id_departemen", MySql.Data.MySqlClient.MySqlDbType.Int32);
            dgvDataAdapter.SelectCommand.Parameters.Add("@search1", MySql.Data.MySqlClient.MySqlDbType.String);
            dgvDataAdapter.SelectCommand.Parameters.Add("@search2", MySql.Data.MySqlClient.MySqlDbType.String);
        }

        private void DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                this.SelectedID_Item = (int)senderGrid.Rows[e.RowIndex].Cells[ColumnID_Item.Name].Value;
                this.SelectedID_Satuan = (int)senderGrid.Rows[e.RowIndex].Cells[ColumnID_Satuan.Name].Value;

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private void TouchButton_MouseDown(object sender, System.Windows.Forms.MouseEventArgs mevent)
        {
            // Highlight touch
            (sender as Button).UseVisualStyleBackColor = false;
            (sender as Button).BackColor = Color.LightSkyBlue;
        }

        private void TouchButton_MouseUp(object sender, System.Windows.Forms.MouseEventArgs mevent)
        {
            // Return
            (sender as Button).BackColor = SystemColors.Control;
            (sender as Button).UseVisualStyleBackColor = true;
        }

        private void BrowseItemWithKeyboardForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Save current position
            Properties.Settings.Default.BrowseItemFormLocation = this.Location;
            Properties.Settings.Default.BrowseItemFormSize = this.Size;
            Properties.Settings.Default.Save();
        }

        private void buttonKey1_Click(object sender, EventArgs e)
        {
            KeywordTextBox.Focus(); SendKeys.Send("1");
        }

        private void buttonKey2_Click(object sender, EventArgs e)
        {
            KeywordTextBox.Focus(); SendKeys.Send("2");
        }

        private void buttonKey3_Click(object sender, EventArgs e)
        {
            KeywordTextBox.Focus(); SendKeys.Send("3");
        }

        private void buttonKey4_Click(object sender, EventArgs e)
        {
            KeywordTextBox.Focus(); SendKeys.Send("4");
        }

        private void buttonKey5_Click(object sender, EventArgs e)
        {
            KeywordTextBox.Focus(); SendKeys.Send("5");
        }

        private void buttonKey6_Click(object sender, EventArgs e)
        {
            KeywordTextBox.Focus(); SendKeys.Send("6");
        }

        private void buttonKey7_Click(object sender, EventArgs e)
        {
            KeywordTextBox.Focus(); SendKeys.Send("7"); 
        }

        private void buttonKey8_Click(object sender, EventArgs e)
        {
            KeywordTextBox.Focus(); SendKeys.Send("8");
        }

        private void buttonKey9_Click(object sender, EventArgs e)
        {
            KeywordTextBox.Focus(); SendKeys.Send("9");
        }

        private void buttonKey0_Click(object sender, EventArgs e)
        {
            KeywordTextBox.Focus(); SendKeys.Send("0");
        }

        private void buttonKeyBack_Click(object sender, EventArgs e)
        {
            KeywordTextBox.Focus(); SendKeys.Send("{BACKSPACE}");
        }

        private void buttonKeyQ_Click(object sender, EventArgs e)
        {
            KeywordTextBox.Focus(); SendKeys.Send("Q");
        }

        private void buttonKeyW_Click(object sender, EventArgs e)
        {
            KeywordTextBox.Focus(); SendKeys.Send("W");
        }

        private void buttonKeyE_Click(object sender, EventArgs e)
        {
            KeywordTextBox.Focus(); SendKeys.Send("E");
        }

        private void buttonKeyR_Click(object sender, EventArgs e)
        {
            KeywordTextBox.Focus(); SendKeys.Send("R");
        }

        private void buttonKeyT_Click(object sender, EventArgs e)
        {
            KeywordTextBox.Focus(); SendKeys.Send("T");
        }

        private void buttonKeyY_Click(object sender, EventArgs e)
        {
            KeywordTextBox.Focus(); SendKeys.Send("Y");
        }

        private void buttonKeyU_Click(object sender, EventArgs e)
        {
            KeywordTextBox.Focus(); SendKeys.Send("U");
        }

        private void buttonKeyI_Click(object sender, EventArgs e)
        {
            KeywordTextBox.Focus(); SendKeys.Send("I");
        }

        private void buttonKeyO_Click(object sender, EventArgs e)
        {
            KeywordTextBox.Focus(); SendKeys.Send("O");
        }

        private void buttonKeyP_Click(object sender, EventArgs e)
        {
            KeywordTextBox.Focus(); SendKeys.Send("P");
        }

        private void buttonKeyMinus_Click(object sender, EventArgs e)
        {
            KeywordTextBox.Focus(); SendKeys.Send("-");
        }

        private void buttonKeyPlus_Click(object sender, EventArgs e)
        {
            KeywordTextBox.Focus(); SendKeys.Send("+");
        }

        private void buttonKeyA_Click(object sender, EventArgs e)
        {
            KeywordTextBox.Focus(); SendKeys.Send("A");
        }

        private void buttonKeyS_Click(object sender, EventArgs e)
        {
            KeywordTextBox.Focus(); SendKeys.Send("S");
        }

        private void buttonKeyD_Click(object sender, EventArgs e)
        {
            KeywordTextBox.Focus(); SendKeys.Send("D");
        }

        private void buttonKeyF_Click(object sender, EventArgs e)
        {
            KeywordTextBox.Focus(); SendKeys.Send("F");
        }

        private void buttonKeyG_Click(object sender, EventArgs e)
        {
            KeywordTextBox.Focus(); SendKeys.Send("G");
        }

        private void buttonKeyH_Click(object sender, EventArgs e)
        {
            KeywordTextBox.Focus(); SendKeys.Send("H");
        }

        private void buttonKeyJ_Click(object sender, EventArgs e)
        {
            KeywordTextBox.Focus(); SendKeys.Send("J");
        }

        private void buttonKeyK_Click(object sender, EventArgs e)
        {
            KeywordTextBox.Focus(); SendKeys.Send("K");
        }

        private void buttonKeyL_Click(object sender, EventArgs e)
        {
            KeywordTextBox.Focus(); SendKeys.Send("L");
        }

        private void buttonKeyDoublePeriod_Click(object sender, EventArgs e)
        {
            KeywordTextBox.Focus(); SendKeys.Send(":");
        }

        private void buttonKeyQuote_Click(object sender, EventArgs e)
        {
            KeywordTextBox.Focus(); SendKeys.Send("\"");
        }

        private void buttonKeyZ_Click(object sender, EventArgs e)
        {
            KeywordTextBox.Focus(); SendKeys.Send("Z");
        }

        private void buttonKeyX_Click(object sender, EventArgs e)
        {
            KeywordTextBox.Focus(); SendKeys.Send("X");
        }

        private void buttonKeyC_Click(object sender, EventArgs e)
        {
            KeywordTextBox.Focus(); SendKeys.Send("C");
        }

        private void buttonKeyV_Click(object sender, EventArgs e)
        {
            KeywordTextBox.Focus(); SendKeys.Send("V");
        }

        private void buttonKeyB_Click(object sender, EventArgs e)
        {
            KeywordTextBox.Focus(); SendKeys.Send("B");
        }

        private void buttonKeyN_Click(object sender, EventArgs e)
        {
            KeywordTextBox.Focus(); SendKeys.Send("N");
        }

        private void buttonKeyM_Click(object sender, EventArgs e)
        {
            KeywordTextBox.Focus(); SendKeys.Send("M");
        }

        private void buttonKeyComa_Click(object sender, EventArgs e)
        {
            KeywordTextBox.Focus(); SendKeys.Send(",");
        }

        private void buttonKeyPeriod_Click(object sender, EventArgs e)
        {
            KeywordTextBox.Focus(); SendKeys.Send(".");
        }

        private void buttonKeySlash_Click(object sender, EventArgs e)
        {
            KeywordTextBox.Focus(); SendKeys.Send("/");
        }

        private void buttonKeySpace_Click(object sender, EventArgs e)
        {
            KeywordTextBox.Focus(); SendKeys.Send(" ");
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (DGV.SelectedRows.Count == 1)
            {
                this.SelectedID_Item = (int)DGV.SelectedRows[0].Cells[ColumnID_Item.Name].Value;
                this.SelectedID_Satuan = (int)DGV.SelectedRows[0].Cells[ColumnID_Satuan.Name].Value;

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private void buttonScrollUp_Click(object sender, EventArgs e)
        {
            DGV.Focus();
            SendKeys.Send("{UP}");
        }

        private void buttonScrollDown_Click(object sender, EventArgs e)
        {
            DGV.Focus();
            SendKeys.Send("{DOWN}");
        }

        

        
    }
}
