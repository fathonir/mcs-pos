using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace MCS_POS.Penjualan
{
    public partial class PenjualanForm : MCS_POS.ChildBaseForm
    {
        private new MySqlDataAdapter Adapter { get; set; }
        private DataTable DGVTable { get; set; }

        public PenjualanForm()
        {
            InitializeComponent();
        }

        private void PenjualanForm_Load(object sender, EventArgs e)
        {
            const string sql = @"
                SELECT id_penjualan, kode_transaksi, waktu_transaksi, nama_user, jumlah_item, total_biaya_akhir
                FROM penjualan p
                JOIN user u ON u.id_user = p.id_user
                WHERE p.id_departemen = @id_departemen AND p.is_dibayar = 1 AND
                    p.waktu_transaksi BETWEEN @awal AND @akhir
                ORDER BY waktu_transaksi DESC";

            Adapter = new MySqlDataAdapter(sql, (MySqlConnection)DbConnection);

            // Setting Parameter
            Adapter.SelectCommand.Parameters.AddRange(new object[] { 
                new MySqlParameter("@id_departemen", this.DepartemenAktif.ID_Departemen),
                new MySqlParameter("@awal", MySqlDbType.DateTime),
                new MySqlParameter("@akhir", MySqlDbType.DateTime)
            });

            // Setting Data source
            DGVTable = new DataTable();
            DGV.DataSource = DGVTable;

            // Setting double buffered
            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty, null, DGV, new object[] { true });
        }

        private void PenjualanForm_Shown(object sender, EventArgs e)
        {
            DayFilterComboBox.SelectedText = "Hari Ini";

            var today = DateTime.Now;
            Adapter.SelectCommand.Parameters["@awal"].Value = new DateTime(today.Year, today.Month, today.Day, 0, 0, 0);
            Adapter.SelectCommand.Parameters["@akhir"].Value = new DateTime(today.Year, today.Month, today.Day, 23, 59, 59);

            // Fill data
            Adapter.Fill(DGVTable);
        }

        private void DayFilterComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DayFilterComboBox.Text == "Custom")
            {
                tanggalLabel.Visible = true;
                TanggalDTP1.Visible = true;
                TanggalDTP2.Visible = true;
            }
            else
            {
                tanggalLabel.Visible = false;
                TanggalDTP1.Visible = false;
                TanggalDTP2.Visible = false;
            }

            RefreshDGV();
        }

        public void RefreshDGV()
        {
            var commandParameters = Adapter.SelectCommand.Parameters;
            var today = DateTime.Today;
            var kemarin = today.AddDays(-1d);

            if (DayFilterComboBox.Text == "Hari Ini")
            {
                commandParameters["@awal"].Value = DateTime.Today;
                commandParameters["@akhir"].Value = DateTime.Today.AddDays(1d);
            }
            else if (DayFilterComboBox.Text == "Kemarin")
            {
                commandParameters["@awal"].Value = DateTime.Today.AddDays(-1d);
                commandParameters["@akhir"].Value = DateTime.Today.AddDays(1d);
            }
            else if (DayFilterComboBox.Text == "3 Hari")
            {
                commandParameters["@awal"].Value = DateTime.Today.AddDays(-3d);
                commandParameters["@akhir"].Value = DateTime.Today.AddDays(1d);
            }
            else if (DayFilterComboBox.Text == "1 Minggu")
            {
                commandParameters["@awal"].Value = DateTime.Today.AddDays(-7d);
                commandParameters["@akhir"].Value = DateTime.Today.AddDays(1d);
            }
            else if (DayFilterComboBox.Text == "2 Minggu")
            {
                commandParameters["@awal"].Value = DateTime.Today.AddDays(-14d);
                commandParameters["@akhir"].Value = DateTime.Today.AddDays(1d);
            }
            else if (DayFilterComboBox.Text == "1 Bulan")
            {
                commandParameters["@awal"].Value = DateTime.Today.AddDays(-30d);
                commandParameters["@akhir"].Value = DateTime.Today.AddDays(1d);
            }
            else if (DayFilterComboBox.Text == "2 Bulan")
            {
                commandParameters["@awal"].Value = DateTime.Today.AddDays(-60d);
                commandParameters["@akhir"].Value = DateTime.Today.AddDays(1d);
            }
            else if (DayFilterComboBox.Text == "Custom")
            {
                commandParameters["@awal"].Value = TanggalDTP1.Value;
                commandParameters["@akhir"].Value = new DateTime(TanggalDTP2.Value.Year, TanggalDTP2.Value.Month, TanggalDTP2.Value.Day, 23, 59, 59);
            }

            // Refill
            DGVTable.Clear();
            Adapter.Fill(DGVTable);
        }

        private void TanggalDTP1_ValueChanged(object sender, EventArgs e)
        {
            if (DayFilterComboBox.Text == "Custom")
            {
                RefreshDGV();
            }
        }

        private void TanggalDTP2_ValueChanged(object sender, EventArgs e)
        {
            if (DayFilterComboBox.Text == "Custom")
            {
                RefreshDGV();
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            // Memastikan harus ada yg di select
            if (DGV.SelectedRows.Count != 1) { return; }

            var selectedRow = DGV.SelectedRows[0];
            var id_penjualan = (int)selectedRow.Cells[ColumnID_Penjualan.Name].Value;

            var dialog = MessageBox.Show(this, "Apakah data ini akan dihapus ?\nPenghapusan data penjualan akan mempengaruhi stok", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialog == System.Windows.Forms.DialogResult.Yes)
            {
                // Start transaksi
                var transaction = DbConnection.BeginTransaction();

                // Load penjualan yg akan dihapus
                var penjualan = Model.Penjualan.GetSingle(transaction.Connection, id_penjualan);

                // Hapus pembelian
                Model.Penjualan.Delete(transaction, penjualan);

                // Commit DB
                transaction.Commit();

                // Remove DGV Rows
                DGV.Rows.Remove(selectedRow);
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {

        }

        private void TambahButton_Click(object sender, EventArgs e)
        {

        }
    }
}
