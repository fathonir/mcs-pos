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

namespace MCS_POS.Konsinyasi
{
    public partial class KonsinyasiReturForm : MCS_POS.ChildBaseForm
    {
        private new MySqlDataAdapter Adapter { get; set; }
        private DataTable DGVTable { get; set; }

        public KonsinyasiReturForm()
        {
            InitializeComponent();
        }

        private void KonsinyasiReturForm_Load(object sender, EventArgs e)
        {
            var sql =
                @"SELECT id_konsinyasi_retur, kode_transaksi, waktu_transaksi, nama_supplier, nama_user, jumlah_item
                FROM konsinyasi_retur kr
                JOIN user u on u.id_user = kr.id_user
                LEFT JOIN supplier s on s.id_supplier = kr.id_supplier
                WHERE 
                    kr.id_departemen = @id_departemen AND
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

        private void KonsinyasiReturForm_Shown(object sender, EventArgs e)
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

        private void TambahButton_Click(object sender, EventArgs e)
        {
            var mdiParent = (MdiParent as MainForm);

            if (!mdiParent.IsChildExist(typeof(Konsinyasi.KonsinyasiReturEditorForm)))
            {
                var childForm = new Konsinyasi.KonsinyasiReturEditorForm() {
                    MdiParent = mdiParent,
                    DbConnection = this.DbConnection,
                    TabControlReference = this.TabControlReference,
                    CloseButtonReference = this.CloseButtonReference,
                    Text = "Tambah Konsinyasi Retur",
                    EditorMode = EditorBaseForm.EditMode.Add,
                    DepartemenAktif = this.DepartemenAktif,
                    UserLogin = this.UserLogin,
                    Configs = this.Configs
                };

                childForm.Show();
            }
            else
            {
                mdiParent.MdiChildren.First(f => f is Konsinyasi.KonsinyasiReturEditorForm).Activate();
            }
        }

        /**
        private void EditButton_Click(object sender, EventArgs e)
        {
            // Memastikan harus ada yg di select
            if (DGV.SelectedRows.Count != 1) { return; }

            var id_konsinyasi_retur = (int)DGV.SelectedRows[0].Cells[ColumnID_Konsinyasi_Retur.Name].Value;

            // Child form bisa banyak, tanpa harus melakukan close sebelumnya
            var childForm = new Konsinyasi.KonsinyasiReturEditorForm() {
                MdiParent = this.MdiParent,
                DbConnection = this.DbConnection,
                TabControlReference = this.TabControlReference,
                CloseButtonReference = this.CloseButtonReference,
                Text = "Edit Konsinyasi Retur",
                EditorMode = EditorBaseForm.EditMode.Edit,
                ID = id_konsinyasi_retur,
                DepartemenAktif = this.DepartemenAktif,
                UserLogin = this.UserLogin
            };

            childForm.Show();
        }
         **/

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            // Memastikan harus ada yg di select
            if (DGV.SelectedRows.Count != 1) { return; }

            var selectedRow = DGV.SelectedRows[0];
            var id_konsinyasi = (int)selectedRow.Cells[ColumnID_Konsinyasi_Retur.Name].Value;

            var dialog = MessageBox.Show(this, "Apakah data ini akan dihapus ?\nPenghapusan data konsinyasi retur akan mempengaruhi stok", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialog == System.Windows.Forms.DialogResult.Yes)
            {
                // Start transaksi
                var transaction = DbConnection.BeginTransaction();

                // Load konsinyasi retur yg akan dihapus
                var konsinyasiRetur = Model.KonsinyasiRetur.GetSingle(transaction.Connection, id_konsinyasi, true);

                // Hapus konsinyasi
                Model.KonsinyasiRetur.Delete(transaction, konsinyasiRetur);

                // Commit DB
                transaction.Commit();

                // Remove DGV Rows
                DGV.Rows.Remove(selectedRow);
            }
        }

        
    }
}
