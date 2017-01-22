using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace MCS_POS.Kasir
{
    public partial class DbSettingForm : Form
    {
        public DbSettingForm()
        {
            InitializeComponent();
        }

        private void DbSettingForm_Load(object sender, EventArgs e)
        {
            var setting = Properties.Settings.Default;
            //HostTextBox.Text = setting.DbHost;
            //PortTextBox.Text = setting.DbPort.ToString();
            //UsernameTextBox.Text = setting.DbUsername;
            //PasswordTextBox.Text = setting.DbPassword;
            //DatabaseTextBox.Text = setting.DbName;

            Program.StartOnScreenKeyboard();
        }

        private void touchButton3_Click(object sender, EventArgs e)
        {
            using (var connection = new MySqlConnection())
            {
                var csBuilder = new MySqlConnectionStringBuilder();
                csBuilder.Server = HostTextBox.Text;
                csBuilder.Port = uint.Parse(PortTextBox.Text);
                csBuilder.UserID = UsernameTextBox.Text;
                csBuilder.Password = PasswordTextBox.Text;
                csBuilder.Database = DatabaseTextBox.Text;

                connection.ConnectionString = csBuilder.ToString();

                try
                {
                    connection.Open();
                    connection.Close();

                    MessageBox.Show(this, "Koneksi berhasil", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "Koneksi gagal: " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void touchButton1_Click(object sender, EventArgs e)
        {
            var setting = Properties.Settings.Default;
            //setting.DbHost = HostTextBox.Text;
            //setting.DbPort = uint.Parse(PortTextBox.Text);
            //setting.DbUsername = UsernameTextBox.Text;
            //setting.DbPassword = PasswordTextBox.Text;
            //setting.DbName = DatabaseTextBox.Text;
            //setting.DbConfigured = true;
            setting.Save();

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void HostTextBox_Click(object sender, EventArgs e)
        {
            // Program.StartOnScreenKeyboard();

            /**
            using (var vkeyboard = new VirtualKeyboard.VirtualKeyboardForm())
            {
                vkeyboard.StringValue = (sender as TextBox).Text;

                if (vkeyboard.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    (sender as TextBox).Text = vkeyboard.StringValue;
                }
            }
             */
        }

        private void PortTextBox_Click(object sender, EventArgs e)
        {
            //using (var vnumpad = new VirtualKeyboard.NumpadForm())
            //{
            //    vnumpad.Value = int.Parse((sender as TextBox).Text);

            //    if (vnumpad.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            //    {
            //        (sender as TextBox).Text = vnumpad.Value.ToString();
            //    }
            //}
        }

        private void UsernameTextBox_Click(object sender, EventArgs e)
        {
            //using (var vkeyboard = new VirtualKeyboard.VirtualKeyboardForm())
            //{
            //    vkeyboard.StringValue = (sender as TextBox).Text;

            //    if (vkeyboard.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            //    {
            //        (sender as TextBox).Text = vkeyboard.StringValue;
            //    }
            //}
        }

        private void PasswordTextBox_Click(object sender, EventArgs e)
        {
            //using (var vkeyboard = new VirtualKeyboard.VirtualKeyboardForm())
            //{
            //    vkeyboard.StringValue = (sender as TextBox).Text;

            //    if (vkeyboard.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            //    {
            //        (sender as TextBox).Text = vkeyboard.StringValue;
            //    }
            //}
        }

        private void DatabaseTextBox_Click(object sender, EventArgs e)
        {
            //using (var vkeyboard = new VirtualKeyboard.VirtualKeyboardForm())
            //{
            //    vkeyboard.StringValue = (sender as TextBox).Text;

            //    if (vkeyboard.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            //    {
            //        (sender as TextBox).Text = vkeyboard.StringValue;
            //    }
            //}
        }

    }
}