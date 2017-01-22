using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCS_POS.Kasir.VirtualKeyboard
{
    public partial class NumpadForm : Form
    {
        public int Value { get; set; }

        public NumpadForm()
        {
            InitializeComponent();
        }

        private void NumpadForm_Load(object sender, EventArgs e)
        {
            var defaultSetting = Properties.Settings.Default;

            // Startup location
            if (defaultSetting.VNumpadLeft == 0 && defaultSetting.VNumpadTop == 0)
            {
                this.CenterToParent();
            }
            else
            {
                this.Location = new Point(defaultSetting.VNumpadLeft, defaultSetting.VNumpadTop);
            }

            ValueTextBox.AppendText(Value.ToString());
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            int result = 0;

            if (int.TryParse(ValueTextBox.Text,  out result))
            {
                this.Value = result;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(this, "Angka Salah");
            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void buttonBackspace_Click(object sender, EventArgs e)
        {
            if (ValueTextBox.Text.Length > 0)
            {
                ValueTextBox.Text = ValueTextBox.Text.Substring(0, ValueTextBox.Text.Length - 1);
                ValueTextBox.Focus(); ValueTextBox.SelectionStart = ValueTextBox.Text.Length;
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            ValueTextBox.ResetText();
        }

        private void buttonK7_Click(object sender, EventArgs e)
        {
            ValueTextBox.AppendText("7");
        }

        private void buttonK8_Click(object sender, EventArgs e)
        {
            ValueTextBox.AppendText("8");
        }

        private void buttonK9_Click(object sender, EventArgs e)
        {
            ValueTextBox.AppendText("9");
        }

        private void buttonK4_Click(object sender, EventArgs e)
        {
            ValueTextBox.AppendText("4");
        }

        private void buttonK5_Click(object sender, EventArgs e)
        {
            ValueTextBox.AppendText("5");
        }

        private void buttonK6_Click(object sender, EventArgs e)
        {
            ValueTextBox.AppendText("6");
        }

        private void buttonK1_Click(object sender, EventArgs e)
        {
            ValueTextBox.AppendText("1");
        }

        private void buttonK2_Click(object sender, EventArgs e)
        {
            ValueTextBox.AppendText("2");
        }

        private void buttonK3_Click(object sender, EventArgs e)
        {
            ValueTextBox.AppendText("3");
        }

        private void buttonK0_Click(object sender, EventArgs e)
        {
            ValueTextBox.AppendText("0");
        }

        private void buttonKDecimal_Click(object sender, EventArgs e)
        {
            ValueTextBox.AppendText(",");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ValueTextBox.AppendText("00");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ValueTextBox.AppendText("000");
        }

        private void button_MouseDown(object sender, MouseEventArgs e)
        {
            (sender as Button).UseVisualStyleBackColor = false;
            (sender as Button).BackColor = Color.LightSkyBlue;
        }

        private void button_MouseUp(object sender, MouseEventArgs e)
        {
            (sender as Button).BackColor = SystemColors.Control;
            (sender as Button).UseVisualStyleBackColor = true;
        }

        private void NumpadForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Save Window Location
            var defaultSetting = Properties.Settings.Default;
            defaultSetting.VNumpadLeft = this.Location.X;
            defaultSetting.VNumpadTop = this.Location.Y;
            defaultSetting.Save();
        }
    }
}
