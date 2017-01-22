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
using System.Reflection;

namespace MCS_POS.Konsinyasi
{
    public partial class KonsinyasiMasukForm : MCS_POS.ChildBaseForm
    {
        private new MySqlDataAdapter Adapter { get; set; }
        private DataTable DGVTable { get; set; }

        public KonsinyasiMasukForm()
        {
            InitializeComponent();
        }

        private void KonsinyasiMasukForm_Load(object sender, EventArgs e)
        {
            var sql =
                @"SELECT id_konsinyasi, kode_transaksi, waktu_transaksi, nama_supplier, nama_user, jumlah_item, total_biaya_akhir
                FROM konsinyasi k
                JOIN user u on u.id_user = k.id_user
                LEFT JOIN supplier s on s.id_supplier = k.id_supplier
                WHERE 
                    k.id_departemen = @id_departemen AND
                    (waktu_transaksi BETWEEN @awal AND @akhir)
                ORDER BY waktu_transaksi DESC";

            // Create Object
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

        private void KonsinyasiMasukForm_Shown(object sender, EventArgs e)
        {
            DayFilterComboBox.SelectedText = "Hari Ini";

            var today = DateTime.Now;
            Adapter.SelectCommand.Parameters["@awal"].Value = new DateTime(today.Year, today.Month, today.Day, 0, 0, 0);
            Adapter.SelectCommand.Parameters["@akhir"].Value = new DateTime(today.Year, today.Month, today.Day, 23, 59, 59);

            // Fill data
            Adapter.Fill(DGVTable);
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

        private void TambahButton_Click(object sender, EventArgs e)
        {
            var mdiParent = (MdiParent as MainForm);

            if (!mdiParent.IsChildExist(typeof(Konsinyasi.KonsinyasiMasukEditorForm)))
            {
                var childForm = new Konsinyasi.KonsinyasiMasukEditorForm()
                {
                    MdiParent = mdiParent,
                    DbConnection = this.DbConnection,
                    TabControlReference = this.TabControlReference,
                    CloseButtonReference = this.CloseButtonReference,
                    Text = "Tambah Konsinyasi Masuk",
                    EditorMode = EditorBaseForm.EditMode.Add,
                    DepartemenAktif = this.DepartemenAktif,
                    UserLogin = this.UserLogin,
                    Configs = this.Configs
                };

                childForm.Show();
            }
            else
            {
                mdiParent.MdiChildren.First(f => f is Konsinyasi.KonsinyasiMasukEditorForm).Activate();
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            // Memastikan harus ada yg di select
            if (DGV.SelectedRows.Count != 1) { return; }

            var id_konsinyasi = (int)DGV.SelectedRows[0].Cells[ColumnID_Konsinyasi.Name].Value;

            // Child form bisa banyak, tanpa harus melakukan close sebelumnya
            var childForm = new Konsinyasi.KonsinyasiMasukEditorForm()
            {
                MdiParent = this.MdiParent,
                DbConnection = this.DbConnection,
                TabControlReference = this.TabControlReference,
                CloseButtonReference = this.CloseButtonReference,
                EditorMode = EditorBaseForm.EditMode.Edit,
                ID = id_konsinyasi,
                DepartemenAktif = this.DepartemenAktif,
                UserLogin = this.UserLogin
            };

            childForm.Show();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            // Memastikan harus ada yg di select
            if (DGV.SelectedRows.Count != 1) { return; }

            var selectedRow = DGV.SelectedRows[0];
            var id_konsinyasi = (int)selectedRow.Cells[ColumnID_Konsinyasi.Name].Value;

            var dialog = MessageBox.Show(this, "Apakah data ini akan dihapus ?\nPenghapusan data konsinyasi akan mempengaruhi stok", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialog == System.Windows.Forms.DialogResult.Yes)
            {
                // Start transaksi
                var transaction = DbConnection.BeginTransaction();

                // Load konsinyasi yg akan dihapus
                var konsinyasi = Model.Konsinyasi.GetSingle(transaction.Connection, id_konsinyasi, true);

                // Hapus konsinyasi
                Model.Konsinyasi.Delete(transaction, konsinyasi);

                // Commit DB
                transaction.Commit();

                // Remove DGV Rows
                DGV.Rows.Remove(selectedRow);
            }
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
