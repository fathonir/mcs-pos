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
    public partial class VirtualKeyboardForm : Form
    {
        public string StringValue { get; set; }
        public float FloatValue { get; set; }

        public VirtualKeyboardForm()
        {
            InitializeComponent();
        }

        private void VirtualKeyboardForm_Load(object sender, EventArgs e)
        {
            var defaultSetting = Properties.Settings.Default;

            // Startup location
            if (defaultSetting.VKeyboardTop == 0 && defaultSetting.VKeyboardLeft == 0)
            {
                this.CenterToParent();
            }
            else
            {
                this.Location = new Point(defaultSetting.VKeyboardLeft, defaultSetting.VKeyboardTop);
            }

            if (StringValue != string.Empty)
            {
                ValueTextBox.Text = StringValue;
            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.StringValue = ValueTextBox.Text;
            this.Close();
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

        private void buttonK1_Click(object sender, EventArgs e)
        {
            ValueTextBox.Text = ValueTextBox.Text + "1";
            ValueTextBox.Focus(); ValueTextBox.SelectionStart = ValueTextBox.Text.Length;
        }

        private void buttonK2_Click(object sender, EventArgs e)
        {
            ValueTextBox.Text = ValueTextBox.Text + "2";
            ValueTextBox.Focus(); ValueTextBox.SelectionStart = ValueTextBox.Text.Length;
        }

        private void buttonK3_Click(object sender, EventArgs e)
        {
            ValueTextBox.Text = ValueTextBox.Text + "3";
            ValueTextBox.Focus(); ValueTextBox.SelectionStart = ValueTextBox.Text.Length;
        }

        private void buttonK4_Click(object sender, EventArgs e)
        {
            ValueTextBox.Text = ValueTextBox.Text + "4";
            ValueTextBox.Focus(); ValueTextBox.SelectionStart = ValueTextBox.Text.Length;
        }

        private void buttonK5_Click(object sender, EventArgs e)
        {
            ValueTextBox.Text = ValueTextBox.Text + "5";
            ValueTextBox.Focus(); ValueTextBox.SelectionStart = ValueTextBox.Text.Length;
        }

        private void buttonK6_Click(object sender, EventArgs e)
        {
            ValueTextBox.Text = ValueTextBox.Text + "6";
            ValueTextBox.Focus(); ValueTextBox.SelectionStart = ValueTextBox.Text.Length;
        }

        private void buttonK7_Click(object sender, EventArgs e)
        {
            ValueTextBox.Text = ValueTextBox.Text + "7";
            ValueTextBox.Focus(); ValueTextBox.SelectionStart = ValueTextBox.Text.Length;
        }

        private void buttonK8_Click(object sender, EventArgs e)
        {
            ValueTextBox.Text = ValueTextBox.Text + "8";
            ValueTextBox.Focus(); ValueTextBox.SelectionStart = ValueTextBox.Text.Length;
        }

        private void buttonK9_Click(object sender, EventArgs e)
        {
            ValueTextBox.Text = ValueTextBox.Text + "9";
            ValueTextBox.Focus(); ValueTextBox.SelectionStart = ValueTextBox.Text.Length;
        }

        private void buttonK0_Click(object sender, EventArgs e)
        {
            ValueTextBox.Text = ValueTextBox.Text + "0";
            ValueTextBox.Focus(); ValueTextBox.SelectionStart = ValueTextBox.Text.Length;
        }

        private void buttonBackspace_Click(object sender, EventArgs e)
        {
            if (ValueTextBox.Text.Length > 0)
            {
                ValueTextBox.Text = ValueTextBox.Text.Substring(0, ValueTextBox.Text.Length - 1);
                ValueTextBox.Focus(); ValueTextBox.SelectionStart = ValueTextBox.Text.Length;
            }
        }

        private void buttonKeyQ_Click(object sender, EventArgs e)
        {
            ValueTextBox.Text = ValueTextBox.Text + "Q";
            ValueTextBox.Focus(); ValueTextBox.SelectionStart = ValueTextBox.Text.Length;
        }

        private void buttonKeyW_Click(object sender, EventArgs e)
        {
            ValueTextBox.Text = ValueTextBox.Text + "W";
            ValueTextBox.Focus(); ValueTextBox.SelectionStart = ValueTextBox.Text.Length;
        }

        private void buttonKeyE_Click(object sender, EventArgs e)
        {
            ValueTextBox.Text = ValueTextBox.Text + "E";
            ValueTextBox.Focus(); ValueTextBox.SelectionStart = ValueTextBox.Text.Length;
        }

        private void buttonKeyR_Click(object sender, EventArgs e)
        {
            ValueTextBox.Text = ValueTextBox.Text + "R";
            ValueTextBox.Focus(); ValueTextBox.SelectionStart = ValueTextBox.Text.Length;
        }

        private void buttonKeyT_Click(object sender, EventArgs e)
        {
            ValueTextBox.Text = ValueTextBox.Text + "T";
            ValueTextBox.Focus(); ValueTextBox.SelectionStart = ValueTextBox.Text.Length;
        }

        private void buttonKeyY_Click(object sender, EventArgs e)
        {
            ValueTextBox.Text = ValueTextBox.Text + "Y";
            ValueTextBox.Focus(); ValueTextBox.SelectionStart = ValueTextBox.Text.Length;
        }

        private void buttonKeyU_Click(object sender, EventArgs e)
        {
            ValueTextBox.Text = ValueTextBox.Text + "U";
            ValueTextBox.Focus(); ValueTextBox.SelectionStart = ValueTextBox.Text.Length;
        }

        private void buttonKeyI_Click(object sender, EventArgs e)
        {
            ValueTextBox.Text = ValueTextBox.Text + "I";
            ValueTextBox.Focus(); ValueTextBox.SelectionStart = ValueTextBox.Text.Length;
        }

        private void buttonKeyO_Click(object sender, EventArgs e)
        {
            ValueTextBox.Text = ValueTextBox.Text + "O";
            ValueTextBox.Focus(); ValueTextBox.SelectionStart = ValueTextBox.Text.Length;
        }

        private void buttonKeyP_Click(object sender, EventArgs e)
        {
            ValueTextBox.Text = ValueTextBox.Text + "P";
            ValueTextBox.Focus(); ValueTextBox.SelectionStart = ValueTextBox.Text.Length;
        }

        private void buttonKeyA_Click(object sender, EventArgs e)
        {
            ValueTextBox.Text = ValueTextBox.Text + "A";
            ValueTextBox.Focus(); ValueTextBox.SelectionStart = ValueTextBox.Text.Length;
        }

        private void buttonKeyS_Click(object sender, EventArgs e)
        {
            ValueTextBox.Text = ValueTextBox.Text + "S";
            ValueTextBox.Focus(); ValueTextBox.SelectionStart = ValueTextBox.Text.Length;
        }

        private void buttonKeyD_Click(object sender, EventArgs e)
        {
            ValueTextBox.Text = ValueTextBox.Text + "D";
            ValueTextBox.Focus(); ValueTextBox.SelectionStart = ValueTextBox.Text.Length;
        }

        private void buttonKeyF_Click(object sender, EventArgs e)
        {
            ValueTextBox.Text = ValueTextBox.Text + "F";
            ValueTextBox.Focus(); ValueTextBox.SelectionStart = ValueTextBox.Text.Length;
        }

        private void buttonKeyG_Click(object sender, EventArgs e)
        {
            ValueTextBox.Text = ValueTextBox.Text + "G";
            ValueTextBox.Focus(); ValueTextBox.SelectionStart = ValueTextBox.Text.Length;
        }

        private void buttonKeyH_Click(object sender, EventArgs e)
        {
            ValueTextBox.Text = ValueTextBox.Text + "H";
            ValueTextBox.Focus(); ValueTextBox.SelectionStart = ValueTextBox.Text.Length;
        }

        private void buttonKeyJ_Click(object sender, EventArgs e)
        {
            ValueTextBox.Text = ValueTextBox.Text + "J";
            ValueTextBox.Focus(); ValueTextBox.SelectionStart = ValueTextBox.Text.Length;
        }

        private void buttonKeyK_Click(object sender, EventArgs e)
        {
            ValueTextBox.Text = ValueTextBox.Text + "K";
            ValueTextBox.Focus(); ValueTextBox.SelectionStart = ValueTextBox.Text.Length;
        }

        private void buttonKeyL_Click(object sender, EventArgs e)
        {
            ValueTextBox.Text = ValueTextBox.Text + "L";
            ValueTextBox.Focus(); ValueTextBox.SelectionStart = ValueTextBox.Text.Length;
        }

        private void buttonKeyZ_Click(object sender, EventArgs e)
        {
            ValueTextBox.Text = ValueTextBox.Text + "Z";
            ValueTextBox.Focus(); ValueTextBox.SelectionStart = ValueTextBox.Text.Length;
        }

        private void buttonKeyX_Click(object sender, EventArgs e)
        {
            ValueTextBox.Text = ValueTextBox.Text + "X";
            ValueTextBox.Focus(); ValueTextBox.SelectionStart = ValueTextBox.Text.Length;
        }

        private void buttonKeyC_Click(object sender, EventArgs e)
        {
            ValueTextBox.Text = ValueTextBox.Text + "C";
            ValueTextBox.Focus(); ValueTextBox.SelectionStart = ValueTextBox.Text.Length;
        }

        private void buttonKeyV_Click(object sender, EventArgs e)
        {
            ValueTextBox.Text = ValueTextBox.Text + "V";
            ValueTextBox.Focus(); ValueTextBox.SelectionStart = ValueTextBox.Text.Length;
        }

        private void buttonKeyB_Click(object sender, EventArgs e)
        {
            ValueTextBox.Text = ValueTextBox.Text + "B";
            ValueTextBox.Focus(); ValueTextBox.SelectionStart = ValueTextBox.Text.Length;
        }

        private void buttonKeyN_Click(object sender, EventArgs e)
        {
            ValueTextBox.Text = ValueTextBox.Text + "N";
            ValueTextBox.Focus(); ValueTextBox.SelectionStart = ValueTextBox.Text.Length;
        }

        private void buttonKeyM_Click(object sender, EventArgs e)
        {
            ValueTextBox.Text = ValueTextBox.Text + "M";
            ValueTextBox.Focus(); ValueTextBox.SelectionStart = ValueTextBox.Text.Length;
        }

        private void buttonSpace_Click(object sender, EventArgs e)
        {
            ValueTextBox.Text = ValueTextBox.Text + " ";
            ValueTextBox.Focus(); ValueTextBox.SelectionStart = ValueTextBox.Text.Length;
        }

        private void VirtualKeyboardForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Save Window Location
            var defaultSetting = Properties.Settings.Default;
            defaultSetting.VKeyboardLeft = this.Location.X;
            defaultSetting.VKeyboardTop = this.Location.Y;
            defaultSetting.Save();
        }

        private void buttonKeyComa_Click(object sender, EventArgs e)
        {
            ValueTextBox.Text = ValueTextBox.Text + ",";
            ValueTextBox.Focus(); ValueTextBox.SelectionStart = ValueTextBox.Text.Length;
        }

        private void buttonKeyPeriod_Click(object sender, EventArgs e)
        {
            ValueTextBox.Text = ValueTextBox.Text + ".";
            ValueTextBox.Focus(); ValueTextBox.SelectionStart = ValueTextBox.Text.Length;
        }

        private void buttonKeySlash_Click(object sender, EventArgs e)
        {
            ValueTextBox.Text = ValueTextBox.Text + "/";
            ValueTextBox.Focus(); ValueTextBox.SelectionStart = ValueTextBox.Text.Length;
        }

        private void buttonKeyDoublePeriod_Click(object sender, EventArgs e)
        {
            ValueTextBox.Text = ValueTextBox.Text + ":";
            ValueTextBox.Focus(); ValueTextBox.SelectionStart = ValueTextBox.Text.Length;
        }

        private void buttonKeyQuote_Click(object sender, EventArgs e)
        {
            ValueTextBox.Text = ValueTextBox.Text + "\"";
            ValueTextBox.Focus(); ValueTextBox.SelectionStart = ValueTextBox.Text.Length;
        }

        private void buttonKeyMinus_Click(object sender, EventArgs e)
        {
            ValueTextBox.Text = ValueTextBox.Text + "-";
            ValueTextBox.Focus(); ValueTextBox.SelectionStart = ValueTextBox.Text.Length;
        }

        private void buttonKeyPlus_Click(object sender, EventArgs e)
        {
            ValueTextBox.Text = ValueTextBox.Text + "+";
            ValueTextBox.Focus(); ValueTextBox.SelectionStart = ValueTextBox.Text.Length;
        }

    }
}
