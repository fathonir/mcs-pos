using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MCS_POS.Laporan
{
    public partial class PrintPreviewForm : Form
    {
        public string ReportPath { get; set; }
        public DataSet DataSet { get; set; }
        public string TableName { get; set; }
        public IEnumerable<ReportParameter> ReportParams { get; set; }

        public PrintPreviewForm()
        {
            InitializeComponent();
        }

        private void PrintPreviewForm_Load(object sender, EventArgs e)
        {
            // Load report file
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            LocalReport localReport = reportViewer1.LocalReport;
            localReport.ReportPath = this.ReportPath;

            // set parameter
            if (this.ReportParams != null) { localReport.SetParameters(this.ReportParams); }

            // Create report data source utk data yg ditampilkan
            ReportDataSource rds = new ReportDataSource();
            rds.Name = "DataSet1";
            rds.Value = this.DataSet.Tables[0];

            // Tambahkan reportdatasource ke report
            localReport.DataSources.Add(rds);

            this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            this.reportViewer1.RefreshReport();
        }
    }
}
