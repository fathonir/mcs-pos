using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MCS_POS.Pembelian
{
    public partial class HistoryHargaForm : MCS_POS.ChildBaseForm
    {
        private new MySqlDataAdapter Adapter { get; set; }
        private DataTable DGVTable { get; set; }

        private Model.Item SelectedItem { get; set; }

        public HistoryHargaForm()
        {
            InitializeComponent();
        }

        private void HistoryHargaForm_Load(object sender, EventArgs e)
        {
            const string sql =
                @"SELECT p.id_pembelian,
                       s.nama_supplier,
                       p.kode_transaksi,
                       p.waktu_transaksi,
                       i.kode_item,
                       i.nama_item,
                       stn.nama_satuan,
                       pd.harga_beli
                FROM   pembelian_detail pd
                       JOIN pembelian p
                         ON p.id_pembelian = pd.id_pembelian
                       JOIN item i
                         ON i.id_item = pd.id_item
                       JOIN supplier s
                         ON s.id_supplier = p.id_supplier
                       JOIN satuan stn
                         ON stn.id_satuan = pd.id_satuan
                WHERE  p.id_departemen = @id_departemen AND 
                       pd.id_item = @id_item AND
                       p.waktu_transaksi BETWEEN @awal AND @akhir
                ORDER  BY waktu_transaksi ASC";

            Adapter = new MySqlDataAdapter(sql, (MySqlConnection)DbConnection);

            // Setting Parameter
            Adapter.SelectCommand.Parameters.AddRange(new object[] { 
                new MySqlParameter("@id_departemen", this.DepartemenAktif.ID_Departemen),
                new MySqlParameter("@id_item", MySqlDbType.Int32),
                new MySqlParameter("@awal", MySqlDbType.DateTime),
                new MySqlParameter("@akhir", MySqlDbType.DateTime)
            });

            // Setting Data source
            DGVTable = new DataTable();
            DGV.DataSource = DGVTable;

            // Setting tanggal 1 dan akhir bulan
            TanggalDTP1.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            TanggalDTP2.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            var browseItem = new BrowseItemForm()
            {
                DepartemenAktif = this.DepartemenAktif,
                DbConnection = this.DbConnection
            };

            if (browseItem.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                SelectedItem = browseItem.SelectedItem;
                ItemTextBox.Text = SelectedItem.Nama_Item;

                // Set parameter
                Adapter.SelectCommand.Parameters["@id_item"].Value = SelectedItem.ID_Item;
                Adapter.SelectCommand.Parameters["@awal"].Value = TanggalDTP1.Value;
                Adapter.SelectCommand.Parameters["@akhir"].Value = new DateTime(TanggalDTP2.Value.Year, TanggalDTP2.Value.Month, TanggalDTP2.Value.Day, 23, 59, 59);

                // Fill tabel
                DGVTable.Clear();
                Adapter.Fill(DGVTable);
            }
        }

        private void TanggalDTP1_ValueChanged(object sender, EventArgs e)
        {
            if (SelectedItem != null)
            {
                Adapter.SelectCommand.Parameters["@awal"].Value = TanggalDTP1.Value;
                Adapter.SelectCommand.Parameters["@akhir"].Value = new DateTime(TanggalDTP2.Value.Year, TanggalDTP2.Value.Month, TanggalDTP2.Value.Day, 23, 59, 59);

                // Fill tabel
                DGVTable.Clear();
                Adapter.Fill(DGVTable);
            }
        }

        private void TanggalDTP2_ValueChanged(object sender, EventArgs e)
        {
            if (SelectedItem != null)
            {
                Adapter.SelectCommand.Parameters["@awal"].Value = TanggalDTP1.Value;
                Adapter.SelectCommand.Parameters["@akhir"].Value = new DateTime(TanggalDTP2.Value.Year, TanggalDTP2.Value.Month, TanggalDTP2.Value.Day, 23, 59, 59);

                // Fill tabel
                DGVTable.Clear();
                Adapter.Fill(DGVTable);
            }
        }
    }
}