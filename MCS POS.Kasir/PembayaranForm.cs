using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCS_POS.Kasir
{
    public partial class PembayaranForm : Form
    {
        public PembayaranForm()
        {
            InitializeComponent();
        }

        private void touchButton1_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void touchButton2_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }

        private void BayarTextBox_Click(object sender, EventArgs e)
        {
            using (var numpad = new VirtualKeyboard.NumpadForm())
            {
                int result = 0;
                int.TryParse((sender as TextBox).Text, out result);
                numpad.Value = result;

                if (numpad.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    (sender as TextBox).Text = numpad.Value.ToString("N0");
                }
            }
        }

        private void BayarTextBox_TextChanged(object sender, EventArgs e)
        {
            var totalBiaya = int.Parse(TotalTextBox.Text, System.Globalization.NumberStyles.Number);
            int bayar = 0; int.TryParse(BayarTextBox.Text, System.Globalization.NumberStyles.Number, Application.CurrentCulture, out bayar);

            KembaliTextBox.Text = (bayar - totalBiaya).ToString("N0");

            if (bayar - totalBiaya > 0) // Kembali
            {
                KembaliTextBox.ForeColor = Color.Blue;
                touchButton1.Enabled = true;
            }
            else if (bayar - totalBiaya == 0)  // PAS
            {
                KembaliTextBox.ForeColor = SystemColors.WindowText;
                touchButton1.Enabled = true;
            }
            else // Kurang
            {
                KembaliTextBox.ForeColor = Color.Red;
                touchButton1.Enabled = false;
            }
        }

        private void PembayaranForm_Load(object sender, EventArgs e)
        {
            BayarTextBox_TextChanged(sender, e);
        }
    }
}
