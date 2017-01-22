using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MCS_POS.Model;

namespace MCS_POS.Kasir
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var penjualans = new List<Model.Penjualan>(10);
            var query =
                from p in penjualans
                select new Model.Penjualan
                    {
                        ID_Penjualan = p.ID_Penjualan,
                        ID_User = p.ID_User
                    };

            textBox1.Text = query.ToString();
        }
    }
}
