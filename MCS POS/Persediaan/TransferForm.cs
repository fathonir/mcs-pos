using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MCS_POS.Persediaan
{
    public partial class TransferForm : MCS_POS.ChildBaseForm
    {
        private new MySqlDataAdapter Adapter { get; set; }
        private DataTable DGVTable { get; set; }

        public TransferForm()
        {
            InitializeComponent();
        }

        private void TransferItemForm_Load(object sender, EventArgs e)
        {
            const string sql =
                @"SELECT t.id_transfer, t.kode_transaksi, t.waktu_transaksi, 
                    d1.nama_departemen AS departemen_asal, d2.nama_departemen AS departemen_tujuan,
                    t.jumlah_item
                FROM transfer t
                JOIN departemen d1 ON d1.id_departemen = t.id_departemen_asal
                JOIN departemen d2 ON d2.id_departemen = t.id_departemen_tujuan
                WHERE 
                    (d1.id_departemen = @id_dept1 OR d2.id_departemen = @id_dept2) AND
                    (t.waktu_transaksi BETWEEN @awal AND @akhir)
                ORDER BY t.waktu_transaksi ASC";

            this.Adapter = new MySqlDataAdapter(sql, (MySqlConnection)DbConnection);

            // Setting parameter
            Adapter.SelectCommand.Parameters.AddRange(new object[] { 
                new MySqlParameter("@id_dept1", this.DepartemenAktif.ID_Departemen),
                new MySqlParameter("@id_dept2", this.DepartemenAktif.ID_Departemen),
                new MySqlParameter("@awal", MySqlDbType.DateTime),
                new MySqlParameter("@akhir", MySqlDbType.DateTime)
            });

            // Data Tabel
            DGVTable = new DataTable();
            DGV.DataSource = DGVTable;
        }

        private void TransferForm_Shown(object sender, EventArgs e)
        {
            DayFilterComboBox.SelectedText = "Hari Ini";

            var today = DateTime.Now;
            Adapter.SelectCommand.Parameters["@awal"].Value = new DateTime(today.Year, today.Month, today.Day, 0, 0, 0);
            Adapter.SelectCommand.Parameters["@akhir"].Value = new DateTime(today.Year, today.Month, today.Day, 23, 59, 59);

            Adapter.Fill(this.DGVTable);
        }

        private void TambahButton_Click(object sender, EventArgs e)
        {
            var childForm = new Persediaan.TransferEditorForm()
            {
                MdiParent = this.MdiParent,
                DbConnection = this.DbConnection,
                TabControlReference = this.TabControlReference,
                EditorMode = EditorBaseForm.EditMode.Add,
                DepartemenAktif = this.DepartemenAktif,
                UserLogin = this.UserLogin,
                Configs = this.Configs,
                Text = "Tambah Transfer Item"
            };

            childForm.Show();
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            // Memastikan harus ada yg di select
            if (DGV.SelectedRows.Count != 1) { return; }

            var id_transfer = (int)DGV.SelectedRows[0].Cells[ColumnID_Transfer.Name].Value;

            // Child form bisa banyak, tanpa melakukan close sebelumnya
            var childForm = new TransferEditorForm()
            {
                MdiParent = this.MdiParent,
                DbConnection = this.DbConnection,
                TabControlReference = this.TabControlReference,
                CloseButtonReference = this.CloseButtonReference,
                EditorMode = EditorBaseForm.EditMode.Edit,
                ID = id_transfer,
                DepartemenAktif = this.DepartemenAktif
            };

            childForm.Show();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            // Memastikan harus ada yg di select
            if (DGV.SelectedRows.Count != 1) { return; }

            var selectedRow = DGV.SelectedRows[0];
            var id_transfer = (int)selectedRow.Cells[ColumnID_Transfer.Name].Value;

            var dialog = MessageBox.Show(this, "Apakah data ini akan dihapus ?\nPenghapusan data transfer item akan mempengaruhi stok", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialog == System.Windows.Forms.DialogResult.Yes)
            {
                // Start transaksi
                var transaction = DbConnection.BeginTransaction();

                // Load transfer yg akan dihapus
                var transfer = Model.Transfer.GetSingle(transaction.Connection, id_transfer, true);

                // Hapus konsinyasi
                Model.Transfer.Delete(transaction, transfer);

                // Commit DB
                transaction.Commit();

                // Remove DGV Rows
                DGV.Rows.Remove(selectedRow);
            }
        }

        private void RefreshDGV()
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
                commandParameters["@awal"].Value = new DateTime(TanggalDTP1.Value.Year, TanggalDTP1.Value.Month, TanggalDTP1.Value.Day, 0, 0, 0);
                commandParameters["@akhir"].Value = new DateTime(TanggalDTP2.Value.Year, TanggalDTP2.Value.Month, TanggalDTP2.Value.Day, 23, 59, 59);
            }

            System.Diagnostics.Debug.WriteLine(TanggalDTP1.Value.ToString());

            // Refill
            DGVTable.Clear();
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
    }
}
