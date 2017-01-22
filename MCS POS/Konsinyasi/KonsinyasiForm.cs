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
    public partial class KonsinyasiForm : MCS_POS.ChildBaseForm
    {
        private new MySqlDataAdapter Adapter { get; set; }
        private DataTable DGVTable { get; set; }
        private DataTable DGV2Table { get; set; }

        private bool isLoadingSupplier = false;

        public KonsinyasiForm()
        {
            InitializeComponent();
        }

        private void KonsinyasiForm_Load(object sender, EventArgs e)
        {

            // Fill Supplier ComboBox
            isLoadingSupplier = true;
            var supplierList = Model.Supplier.GetEnumerable(DbConnection).ToList();
            supplierList.Insert(0, new Model.Supplier() { ID_Supplier = -1, Nama_Supplier = "Semua Supplier" });
            SupplierComboBox.DataSource = supplierList;
            SupplierComboBox.DisplayMember = "nama_supplier";
            SupplierComboBox.ValueMember = "id_supplier";
            isLoadingSupplier = false;

            Adapter = new MySqlDataAdapter("", (MySqlConnection)DbConnection);

            // Setting Data source
            DGVTable = new DataTable();
            DGV.DataSource = DGVTable;
            DGV2Table = new DataTable();
            DGV2.DataSource = DGV2Table;

            // Setting double buffered
            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty, null, DGV, new object[] { true });
        }

        private void KonsinyasiForm_Shown(object sender, EventArgs e)
        {
            // StatusFilterComboBox.Text = "Belum Lunas";
            RefreshDGV();

            // Jika ada data, bangkitkan event RowEnter
            if (DGVTable.Rows.Count > 0) DGV_RowEnter(sender, null);
        }

        public void RefreshDGV()
        {
            // -----------------------------------------
            // Building Query Konsinyasi
            // -----------------------------------------

            var sql =
                @"SELECT id_konsinyasi, kode_transaksi, waktu_transaksi, s.nama_supplier, k.total_biaya_akhir, k.total_biaya_retur, k.total_pembayaran
                FROM konsinyasi k
                JOIN supplier s ON s.id_supplier = k.id_supplier ";

            var where = "";

            if (BelumLunasRadioButton.Checked)
            {
                where = "WHERE k.is_lunas = 0 ";
            }

            if (LunasRadioButton.Checked)
            {
                where = "WHERE k.is_lunas = 1 ";
            }

            if (SupplierComboBox.SelectedIndex > 0)
            {
                where =
                    (where == "" ? "WHERE " : "AND ") +
                    "k.id_supplier = " + SupplierComboBox.SelectedValue.ToString();
            }

            sql = sql + where + " ORDER BY waktu_transaksi DESC";

            Adapter.SelectCommand.CommandText = sql;

            // Clear detail item
            DGV2Table.Clear();

            // Clear daftar konsinyasi
            DGVTable.Clear();
            Adapter.Fill(DGVTable);
        }

        private void SupplierComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Memastikan tidak sedang dalam mode loading
            if (isLoadingSupplier == false)
                RefreshDGV();
        }

        private void BelumLunasRadioButton_Click(object sender, EventArgs e)
        {
            RefreshDGV();
        }

        private void LunasRadioButton_Click(object sender, EventArgs e)
        {
            RefreshDGV();
        }

        private void SemuaRadioButton_Click(object sender, EventArgs e)
        {
            RefreshDGV();
        }

        private void DGV_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            // Memastikan Rownya terselect penuh
            if (DGV.SelectedRows.Count == 1)
            {
                var id_konsinyasi = DGV.SelectedRows[0].Cells[ColumnID_Konsinyasi.Name].Value;

                var sql =
                    @"SELECT 
	                    id_konsinyasi_detail, i.kode_item, i.nama_item,
                        kd.jumlah, s.nama_satuan, kd.jumlah_retur, kd.jumlah_keluar, kd.jumlah_bayar,
                        (kd.jumlah - kd.jumlah_retur - kd.jumlah_keluar) as jumlah_sisa
                    FROM konsinyasi_detail kd
                    JOIN item i ON i.id_item = kd.id_item
                    JOIN satuan s ON s.id_satuan = kd.id_satuan
                    WHERE kd.id_konsinyasi = " + id_konsinyasi;

                Adapter.SelectCommand.CommandText = sql;

                // Refresh Fill
                DGV2Table.Clear();
                Adapter.Fill(DGV2Table);
            }
        }

        private void BayarButton_Click(object sender, EventArgs e)
        {
            if (DGV.SelectedRows.Count == 0)
            {
                MessageBox.Show(this, "Pilih data item yang akan dibayarkan", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var id_konsinyasi = DGV.SelectedRows[0].Cells[ColumnID_Konsinyasi.Name].Value;

                var dialog = new Konsinyasi.PembayaranKonsinyasiForm();
                dialog.Configs = this.Configs;
                dialog.DbConnection = this.DbConnection;
                dialog.DepartemenAktif = this.DepartemenAktif;
                dialog.UserLogin = this.UserLogin;
                dialog.ID = (int)id_konsinyasi;
                dialog.ShowDialog(this);
            }
        }
    }
}
