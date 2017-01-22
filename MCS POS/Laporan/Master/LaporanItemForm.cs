using Microsoft.Reporting.WinForms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MCS_POS.Laporan.Master
{
    public partial class LaporanItemForm : MCS_POS.EditorBaseForm
    {
        public LaporanItemForm()
        {
            InitializeComponent();
        }

        private void CetakButton_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            var adapter = new app_posDataSetTableAdapters.DaftarItemTableAdapter();
            adapter.Connection = (this.DbConnection as MySqlConnection);
            var ds = new DataSet();

            ds.Tables.Add(adapter.GetData(DepartemenAktif.ID_Departemen));

            // Masukkan parameter
            var reportParams = new List<ReportParameter>();
            reportParams.AddRange(new ReportParameter[] { 
                new ReportParameter("NamaDepartemen", DepartemenAktif.Nama_Departemen),
                new ReportParameter("AlamatDepartemen", DepartemenAktif.Alamat_Departemen),
                new ReportParameter("KotaDepartemen", DepartemenAktif.Kota_Departemen),
                new ReportParameter("TelpDepartemen", DepartemenAktif.Telp_Departemen),
                new ReportParameter("User", UserLogin.Nama_User),
            });

            var dialog = new Laporan.PrintPreviewForm();
            dialog.Owner = this.MdiParent;
            dialog.DataSet = ds;
            dialog.ReportPath = "Report\\DaftarStokItem.rdlc";
            dialog.ReportParams = reportParams;
            dialog.Show();

            Cursor = Cursors.Default;
        }
    }
}
