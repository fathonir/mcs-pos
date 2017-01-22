using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Dapper;

namespace MCS_POS.Master
{
    public partial class ItemForm : MCS_POS.ChildBaseForm
    {
        public int ID_Departemen_Aktif { get; set; }

        private new MySqlDataAdapter Adapter { get; set; }
        private DataTable DGVTable { get; set; }

        public ItemForm()
        {
            InitializeComponent();
        }

        public void RefreshDGV()
        {
            // Model.Item.FillAllItemsbyDepartemen(DbConnection, this.dataSet.Tables["Item"], this.ID_Departemen_Aktif);
            DGVTable.Clear();

            Adapter.Fill(DGVTable);
        }

        public void RecountDGV()
        {
            // Hitung total rows
            TotalLabel.Text = "Total Data : " + DGV.Rows.GetRowCount(DataGridViewElementStates.Visible);
        }

        private void ItemForm_Load(object sender, EventArgs e)
        {
            const string sql =
                @"SELECT 
                    item.id_item, 
                    kode_item, 
                    nama_item,
                    satuan.nama_satuan, 
                    ifnull(stok_item.stok / satuan_item.konversi_jumlah,0) as stok,
                    item.nama_rak, 
                    jenis_item.nama_jenis_item,
                    merek_item.nama_merek_item,
                    satuan_item.harga_pokok,
                    satuan_item.harga_jual,
                    item.stok_minimum,
                    supplier.nama_supplier,
                    item.keterangan
                FROM item
                JOIN satuan_item on satuan_item.id_item = item.id_item
                JOIN satuan on satuan.id_satuan = satuan_item.id_satuan
                LEFT JOIN stok_item on stok_item.id_item = item.id_item and stok_item.id_departemen = @id_departemen
                JOIN jenis_item on jenis_item.id_jenis_item = item.id_jenis_item
                LEFT JOIN merek_item on merek_item.id_merek_item = item.id_merek_item
                LEFT JOIN supplier on supplier.id_supplier = item.id_supplier
                WHERE 
                    item.kode_item like @search1 OR item.nama_item like @search2
                ORDER BY item.nama_item ASC, satuan.nama_satuan ASC";

            this.Adapter = new MySqlDataAdapter(sql, (MySqlConnection)DbConnection);

            // Setting parameter
            Adapter.SelectCommand.Parameters.AddRange(new object[] { 
                new MySqlParameter("@id_departemen", this.DepartemenAktif.ID_Departemen),
                new MySqlParameter("@search1", MySqlDbType.String),
                new MySqlParameter("@search2", MySqlDbType.String)
            });

            // Data Tabel
            DGVTable = new DataTable();
            DGV.DataSource = DGVTable;

            // Color setting
            DGV.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Silver;
            DGV.RowHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.Color.Silver;
        }

        private void ItemForm_Shown(object sender, EventArgs e)
        {
            // Select ALL
            Adapter.SelectCommand.Parameters["@search1"].Value = "%";
            Adapter.SelectCommand.Parameters["@search2"].Value = "%";

            // Fill ke tabel
            Adapter.Fill(DGVTable);

            // Hitung total rows
            TotalLabel.Text = "Total Data : " + DGV.Rows.GetRowCount(DataGridViewElementStates.Visible);
        }

        private void TambahButton_Click(object sender, EventArgs e)
        {

            var childForm = new Master.ItemEditorForm()
            {
                MdiParent = this.MdiParent,
                DbConnection = this.DbConnection,
                TabControlReference = this.TabControlReference,
                EditorMode = EditorBaseForm.EditMode.Add
            };

            childForm.Show();
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (DGV.SelectedRows.Count == 1)
            {
                // Mendapatkan ID_ITEM 
                var editorForm = new Master.ItemEditorForm() { 
                    MdiParent = this.MdiParent,
                    DbConnection = this.DbConnection,
                    TabControlReference = this.TabControlReference,
                    EditorMode = EditorBaseForm.EditMode.Edit,
                    ID = (int)DGV.SelectedRows[0].Cells[ColumnID_Item.Name].Value
                };

                editorForm.Show();
            }
        }

        

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (DGV.SelectedRows.Count == 1 && MsgBox.Question("Data akan dihapus. Pastikan tidak ada data transaksi yang terkait item ini. Apa akan diteruskan ?") == System.Windows.Forms.DialogResult.OK)
            {
                // Mendapatkan ID yg akan di hapus
                var id = DGV.SelectedRows[0].Cells[ColumnID_Item.Name].Value;
                this.DbConnection.Execute("DELETE FROM item WHERE id_item = @id_item", new { id_item = id });

                // hapus row terpilih
                DGV.Rows.RemoveAt(DGV.SelectedRows[0].Index);

                foreach (DataGridViewRow row in DGV.Rows)
                {
                    // hapus juga row yg ber id_item sama (untuk multi satuan)
                    if ((int)row.Cells[ColumnID_Item.Name].Value == (int)id)
                    {
                        DGV.Rows.RemoveAt(row.Index);
                    }
                }

                // recount jumlah dgv
                RecountDGV();
            }
        }

        private void KeywordTextBox_TextChanged(object sender, EventArgs e)
        {
            if (KeywordTextBox.Text.Trim().Length > 1)
            {
                (DGV.DataSource as DataTable).DefaultView.RowFilter = "kode_item like '" + KeywordTextBox.Text.Trim() + "%' OR nama_item like '%" + KeywordTextBox.Text.Trim() + "%'";
            }
            else
            {
                (DGV.DataSource as DataTable).DefaultView.RowFilter = "";
            }

            RecountDGV();
        }

        private void DGV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                e.Handled = true;
                KeywordTextBox.Focus();
                KeywordTextBox.SelectAll();
            }

            if (e.KeyCode == Keys.F2)
            {
                e.Handled = true;
                EditButton_Click(sender, e);
            }
        }

        private void DGV_Enter(object sender, EventArgs e)
        {
            DGV.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            DGV.RowHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;

            HelpStripStatusLabel.Text = "[F3] Kata kunci [F2] Edit item";
        }

        private void DGV_Leave(object sender, EventArgs e)
        {
            DGV.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Silver;
            DGV.RowHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.Color.Silver;
        }

        private void KeywordTextBox_Enter(object sender, EventArgs e)
        {
            HelpStripStatusLabel.Text = "[F4/Up/Down] Grid";
        }

        private void KeywordTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4 || e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
            {
                e.Handled = true;
                DGV.Focus();
            }
        }

        private void DGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DGV.SelectedRows.Count == 1 && e.RowIndex >= 0)
            {
                EditButton_Click(sender, new EventArgs());
            }
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            RefreshDGV();
        }
    }
}