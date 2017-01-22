using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Microsoft.Reporting.WinForms;

namespace MCS_POS.Laporan.Penjualan
{
    public partial class LaporanPembelianForm : MCS_POS.EditorBaseForm
    {
        public LaporanPembelianForm()
        {
            InitializeComponent();
        }

        private void LaporanPembelianForm_Load(object sender, EventArgs e)
        {
            // Tanggal Awal = 1
            // Tanggal Akhir = tgl akhir bulan
            TglAwalDTP.Value = new DateTime(DateTime.Now.Date.Year, DateTime.Now.Date.Month, 1);
            TglAkhirDTP.Value = new DateTime(DateTime.Now.Date.Year, DateTime.Now.Date.Month, DateTime.DaysInMonth(DateTime.Now.Date.Year, DateTime.Now.Date.Month));

            // Load data supplier
            var supplierList = Model.Supplier.GetEnumerable(DbConnection).ToList();
            supplierList.Insert(0, new Model.Supplier() { ID_Supplier = -1, Nama_Supplier = "SEMUA SUPPLIER" });
            SupplierComboBox.DataSource = supplierList;
            SupplierComboBox.DisplayMember = "nama_supplier";
            SupplierComboBox.ValueMember = "id_supplier";
        }

        private void CetakButton_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            var adapter = new app_posDataSetTableAdapters.PembelianRekapDTTableAdapter();
            adapter.Connection = (this.DbConnection as MySqlConnection);
            var ds = new DataSet();

            if ((int)SupplierComboBox.SelectedValue == -1)
            {
                ds.Tables.Add(adapter.GetData(this.DepartemenAktif.ID_Departemen, TglAwalDTP.Value, TglAkhirDTP.Value));
            }
            else
            {
                ds.Tables.Add(adapter.GetDataBySupplier(DepartemenAktif.ID_Departemen, TglAwalDTP.Value, TglAkhirDTP.Value, (int)SupplierComboBox.SelectedValue));
            }

            // Masukkan parameter
            var reportParams = new List<ReportParameter>();
            reportParams.AddRange(new ReportParameter[] { 
                new ReportParameter("NamaDepartemen", DepartemenAktif.Nama_Departemen),
                new ReportParameter("AlamatDepartemen", DepartemenAktif.Alamat_Departemen),
                new ReportParameter("KotaDepartemen", DepartemenAktif.Kota_Departemen),
                new ReportParameter("TelpDepartemen", DepartemenAktif.Telp_Departemen),
                new ReportParameter("User", UserLogin.Nama_User),
                new ReportParameter("TglAwal", TglAwalDTP.Value.ToShortDateString()),
                new ReportParameter("TglAkhir", TglAkhirDTP.Value.ToShortDateString())
            });

            var dialog = new Laporan.PrintPreviewForm();
            dialog.Owner = this.MdiParent;
            dialog.DataSet = ds;
            dialog.ReportPath = "Report\\PembelianRekap.rdlc";
            dialog.ReportParams = reportParams;
            dialog.Show();

            Cursor = Cursors.Default;
        }
    }
}
