using Microsoft.Reporting.WinForms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MCS_POS.Laporan.Penjualan
{
    public partial class LaporanReturForm : MCS_POS.EditorBaseForm
    {
        public LaporanReturForm()
        {
            InitializeComponent();
        }

        private void LaporanReturForm_Load(object sender, EventArgs e)
        {
            // Tanggal Awal = 1
            // Tanggal Akhir = tgl akhir bulan
            TglAwalDTP.Value = new DateTime(DateTime.Now.Date.Year, DateTime.Now.Date.Month, 1);
            TglAkhirDTP.Value = new DateTime(DateTime.Now.Date.Year, DateTime.Now.Date.Month, DateTime.DaysInMonth(DateTime.Now.Date.Year, DateTime.Now.Date.Month));
        }

        private void CetakButton_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            var adapter = new app_posDataSetTableAdapters.ReturPenjualanRekapTableAdapter();
            adapter.Connection = (this.DbConnection as MySqlConnection);
            var ds = new DataSet();

            // Prepare Jam
            TglAwalDTP.Value = new DateTime(TglAwalDTP.Value.Year, TglAwalDTP.Value.Month, TglAwalDTP.Value.Day, 0, 0, 0);
            TglAkhirDTP.Value = new DateTime(TglAkhirDTP.Value.Year, TglAkhirDTP.Value.Month, TglAkhirDTP.Value.Day, 23, 59, 59);

            ds.Tables.Add(adapter.GetData(DepartemenAktif.ID_Departemen, TglAwalDTP.Value, TglAkhirDTP.Value));

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
            dialog.ReportPath = "Report\\ReturPenjualanRekap.rdlc";
            dialog.ReportParams = reportParams;
            dialog.Show();

            Cursor = Cursors.Default;
        }
    }
}
