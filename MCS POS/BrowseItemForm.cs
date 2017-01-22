using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Reflection;

namespace MCS_POS
{
    public partial class BrowseItemForm : Form
    {
        public IDbConnection DbConnection { get; set; }
        public Model.Item SelectedItem { get; set; }
        public Model.SatuanItemView SelectedSatuanItemView { get; set; }
        public Model.Departemen DepartemenAktif { get; set; }

        public bool IsKonsinyasiOnly { get; set; }

        private MySqlDataAdapter Adapter { get; set; }
        private DataTable DGVTable { get; set; }

        public BrowseItemForm()
        {
            InitializeComponent();
        }

        private void BrowseItemForm_Load(object sender, EventArgs e)
        {
            var defaultSetting = Properties.Settings.Default;

            // Load Default Location & Size
            if (defaultSetting.BrowseItemLocation != new Point(0, 0))
                this.Location = defaultSetting.BrowseItemLocation;
            if (defaultSetting.BrowseItemSize != new Size(0, 0))
                this.Size = defaultSetting.BrowseItemSize;

            var filterKonsinyasi = "";
            if (IsKonsinyasiOnly)
                filterKonsinyasi = "AND i.is_konsinyasi = 1";

            var sql =
                @"SELECT 
	                i.id_item, i.kode_item, i.nama_item, 
	                ifnull(stok.stok / si.konversi_jumlah,0) as stok,
                    s.id_satuan, s.nama_satuan, si.harga_pokok, si.harga_jual, nama_rak, mi.nama_merek_item
                FROM item i
                JOIN satuan_item si on si.id_item = i.id_item
                JOIN satuan s on s.id_satuan = si.id_satuan
                LEFT JOIN merek_item mi on mi.id_merek_item = i.id_merek_item
                LEFT JOIN stok_item stok ON stok.id_item = i.id_item AND stok.id_departemen = @id_departemen
                WHERE 
                    (kode_item like @search1 OR nama_item like @search2)
                    "+filterKonsinyasi+@"
                ORDER BY nama_item ASC, nama_satuan ASC";
            Adapter = new MySqlDataAdapter(sql, (MySqlConnection)DbConnection);

            // Setting parameter
            Adapter.SelectCommand.Parameters.AddRange(new object[] { 
                new MySqlParameter("@id_departemen", this.DepartemenAktif.ID_Departemen),
                new MySqlParameter("@search1", MySqlDbType.String),
                new MySqlParameter("@search2", MySqlDbType.String)
            });

            DGVTable = new DataTable();
            DGV.DataSource = DGVTable;

            // Setting double buffered
            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty, null, DGV, new object[] { true });

            // Gray non focus
            DGV.DefaultCellStyle.SelectionBackColor = SystemColors.ControlLight;
            DGV.DefaultCellStyle.SelectionForeColor = SystemColors.ControlText;
            DGV.RowHeadersDefaultCellStyle.SelectionBackColor = SystemColors.ControlLight;
            DGV.RowHeadersDefaultCellStyle.SelectionForeColor = SystemColors.ControlText;
        }

        private void BrowseItemForm_Shown(object sender, EventArgs e)
        {
            Adapter.SelectCommand.Parameters["@search1"].Value = "%";
            Adapter.SelectCommand.Parameters["@search2"].Value = "%";
            Adapter.Fill(DGVTable);
        }

        private void KeywordTextBox_TextChanged(object sender, EventArgs e)
        {
            DGVTable.Clear();
            Adapter.SelectCommand.Parameters["@search1"].Value = (sender as TextBox).Text.Trim() + "%";
            Adapter.SelectCommand.Parameters["@search2"].Value = "%" + (sender as TextBox).Text.Trim() + "%";
            Adapter.Fill(DGVTable);

            JumlahItemLabel.Text = "Jumlah Item : " + DGV.Rows.Count;
        }

        private void KeywordTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.PageDown)
            {
                DGV.Focus();
                e.Handled = true;
            }
        }

        private void DGV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3 || e.KeyCode == Keys.PageUp)
            {
                KeywordTextBox.Focus();
                e.Handled = true;
            }

            if (e.KeyCode == Keys.Enter)
            {
                SubmitButton_Click(sender, e);
                e.Handled = true;
            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            if (DGV.SelectedRows.Count == 1)
            {
                var id_item = int.Parse(DGV.SelectedRows[0].Cells[ColumnID_Item.Name].Value.ToString());
                var id_satuan = int.Parse(DGV.SelectedRows[0].Cells[ColumnID_Satuan.Name].Value.ToString());

                // Ambil data Item
                SelectedItem = Model.Item.GetSingle(this.DbConnection, id_item);

                // Ambil data Satuan Item
                SelectedItem.SatuanItemViews = Model.Item.GetSatuanItemViews(this.DbConnection, id_item);

                // Set satuan terselect
                SelectedSatuanItemView = SelectedItem.SatuanItemViews.Single(si => si.ID_Satuan == id_satuan);
            }

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void BrowseItemForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var defaultSetting = Properties.Settings.Default;
            defaultSetting.BrowseItemLocation = this.Location;
            defaultSetting.BrowseItemSize = this.Size;
            defaultSetting.Save();
        }

        private void DGV_Leave(object sender, EventArgs e)
        {
            DGV.DefaultCellStyle.SelectionBackColor = SystemColors.ControlLight;
            DGV.DefaultCellStyle.SelectionForeColor = SystemColors.ControlText;
            DGV.RowHeadersDefaultCellStyle.SelectionBackColor = SystemColors.ControlLight;
            DGV.RowHeadersDefaultCellStyle.SelectionForeColor = SystemColors.ControlText;
        }

        private void DGV_Enter(object sender, EventArgs e)
        {
            DGV.DefaultCellStyle.SelectionBackColor = SystemColors.Highlight;
            DGV.DefaultCellStyle.SelectionForeColor = SystemColors.HighlightText;
            DGV.RowHeadersDefaultCellStyle.SelectionBackColor = SystemColors.Highlight;
            DGV.RowHeadersDefaultCellStyle.SelectionForeColor = SystemColors.HighlightText;
        }

        private void DGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                SubmitButton_Click(sender, e);
            }
        }
    }
}
