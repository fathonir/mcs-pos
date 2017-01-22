using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Microsoft.Reporting.WinForms;

namespace MCS_POS.Laporan.Penjualan
{
    public partial class LaporanPenjualanForm : MCS_POS.EditorBaseForm
    {
        public LaporanPenjualanForm()
        {
            InitializeComponent();
        }

        private void LaporanPenjualanForm_Load(object sender, EventArgs e)
        {
            // Tanggal Awal = 1
            // Tanggal Akhir = tgl akhir bulan
            TglAwalDTP.Value = new DateTime(DateTime.Now.Date.Year, DateTime.Now.Date.Month, 1);
            TglAkhirDTP.Value = new DateTime(DateTime.Now.Date.Year, DateTime.Now.Date.Month, DateTime.DaysInMonth(DateTime.Now.Date.Year, DateTime.Now.Date.Month));

            // Load data kasir
            var kasirList = Model.User.GetListKasir(DbConnection, DepartemenAktif.ID_Departemen);
            kasirList.Insert(0, new Model.User() { ID_User = -1, Nama_User = "SEMUA KASIR"});
            KasirComboBox.DataSource = kasirList;
            KasirComboBox.DisplayMember = "nama_user";
            KasirComboBox.ValueMember = "id_user";
        }

        private void CetakButton_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            var adapter = new app_posDataSetTableAdapters.PenjualanRekapDTTableAdapter();
            adapter.Connection = (this.DbConnection as MySqlConnection);
            var ds = new DataSet();

            // Prepare Jam
            TglAwalDTP.Value = new DateTime(TglAwalDTP.Value.Year, TglAwalDTP.Value.Month, TglAwalDTP.Value.Day, 0, 0, 0);
            TglAkhirDTP.Value = new DateTime(TglAkhirDTP.Value.Year, TglAkhirDTP.Value.Month, TglAkhirDTP.Value.Day, 23, 59, 59);

            if ((int)KasirComboBox.SelectedValue == -1)
            {
                ds.Tables.Add(adapter.GetData(this.DepartemenAktif.ID_Departemen, TglAwalDTP.Value, TglAkhirDTP.Value));
            }
            else
            {
                ds.Tables.Add(adapter.GetDataByKasir(DepartemenAktif.ID_Departemen, TglAwalDTP.Value, TglAkhirDTP.Value, (int)KasirComboBox.SelectedValue));
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
            dialog.ReportPath = "Report\\PenjualanRekap.rdlc";
            dialog.ReportParams = reportParams;
            dialog.Show();

            Cursor = Cursors.Default;
        }
    }
}
