using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Diagnostics;

namespace MCS_POS
{
    public partial class TesterForm : Form
    {
        public TesterForm()
        {
            InitializeComponent();
        }

        DataTable DGVDataTable;
        BindingSource DGVBindingSource;

        private void TesterForm_Load(object sender, EventArgs e)
        {
            DGVDataTable = new DataTable();
            DGVDataTable.Columns.AddRange(new DataColumn[] { 
                new DataColumn("No", typeof(int)),
                new DataColumn("Kode", typeof(string)),
                new DataColumn("Item", typeof(string)),
                new DataColumn("Jumlah", typeof(int)),
                new DataColumn("ID_Satuan", typeof(int)),
                new DataColumn("Harga", typeof(float)),
                new DataColumn("Total", typeof(float))
            });

            DGVDataTable.Columns[0].AllowDBNull = false;

            // Set Datasource
            DGVBindingSource = new BindingSource();
            DGVBindingSource.DataSource = DGVDataTable;
            DGV1.DataSource = DGVBindingSource;
        }

        private void DGV_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            // Jika Kolom Kode
            if (DGV1.Columns[e.ColumnIndex] == DGV1.Columns[ColumnKode.Name])
            {
                DGV1.BeginEdit(true);
            }
        }

        private void DGV_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Set Nomer Urut
            for (int i = 0; i < DGV1.Rows.Count; i++)
            {
                DGV1.Rows[i].Cells[ColumnNo.Name].Value = (i + 1);
            }

            listBox2.Items.Clear();
            listBox2.Items.Add("DGV : " + DGV1.Rows.Count);
            listBox2.Items.Add("Table : " + DGVDataTable.Rows.Count);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            for (int i = 0; i < DGVDataTable.Rows.Count; i++)
            {
                listBox1.Items.Add(DGVDataTable.Rows[i].RowState.ToString());
            }
        }

        private void DGV_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyDown += DGVCell_KeyDown;
            e.Control.KeyPress += DGVCell_KeyPress;
        }

        private void DGVCell_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void DGVCell_KeyDown(object sender, KeyEventArgs e)
        {
            // Jika Enter pada Kode, muncul pencarian
            if (e.KeyCode == Keys.Enter && DGV1.CurrentCell.OwningColumn == ColumnKode)
            {
                e.Handled = true;

                MessageBox.Show("Browse Item");
            }
            
        }
    }
}
