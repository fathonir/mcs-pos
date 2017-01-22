using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MCS_POS.Kasir
{
    public partial class PenjualanDetailForm : Form
    {
        public IDbConnection DbConnection { get; set; }
        public int ID_Penjualan { get; set; }

        public PenjualanDetailForm()
        {
            InitializeComponent();
        }

        private void PenjualanDetailForm_Load(object sender, EventArgs e)
        {
            // ambil data db
            var penjualan = Model.Penjualan.GetSingle(DbConnection, this.ID_Penjualan);
            penjualan.PenjualanDetails = Model.PenjualanDetail.GetListOfPenjualan(DbConnection, penjualan);

            // custom query linq
            var query = from pd in penjualan.PenjualanDetails
                        select new
                        {
                            pd.Kode_Item,
                            pd.Nama_Item,
                            pd.Jumlah,
                            pd.Nama_Satuan,
                            pd.Harga_Jual,
                            pd.Sub_Total
                        };

            DGV.DataSource = query.ToList();
        }

        private void touchButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
