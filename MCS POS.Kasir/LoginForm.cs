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
using Dapper;

namespace MCS_POS
{
    public partial class LoginForm : Form
    {
        public IDbConnection DbConnection { get; set; }
        public Model.User UserLogin { get; set; }

        public bool AksesRefund { get; set; }
        public bool AksesHargaJual { get; set; }
        public bool AksesDataPenjualan { get; set; }

        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            var sql = "SELECT id_user, nama_user FROM user where tipe_user = 'kasir' ";

            if (AksesRefund == true) { sql += "AND akses_refund = 1"; }
            if (AksesHargaJual == true) { sql += "AND akses_harga_jual = 1"; }
            if (AksesDataPenjualan == true) { sql += "AND akses_data_penjualan = 1"; }

            var adapter = new MySqlDataAdapter(sql, this.DbConnection as MySqlConnection);
            var dt = new DataTable();

            adapter.Fill(dt);

            UserComboBox.DataSource = dt;
            UserComboBox.DisplayMember = "nama_user";
            UserComboBox.ValueMember = "id_user";
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            if (PasswordTextBox.Text.Trim().Length == 0)
            {
                MessageBox.Show("Password kosong");
                return;
            }

            var sql = "select * from user where id_user = @id_user and password_hash = sha1(@password)";
            var users = this.DbConnection.Query<Model.User>(sql, new { 
                id_user = UserComboBox.SelectedValue,
                password = PasswordTextBox.Text.Trim()
            });

            if (users.Count() == 0)
            {
                MessageBox.Show("Login salah");
            }
            else
            {
                this.UserLogin = users.First();
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UsernameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                LoginButton_Click(sender, e);
            }
        }

        private void PasswordTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                LoginButton_Click(sender, e);
            }
        }

        

        private void PasswordTextBox_MouseClick(object sender, MouseEventArgs e)
        {

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

        private void buttonK7_Click(object sender, EventArgs e)
        {
            PasswordTextBox.Focus();
            SendKeys.Send("7");
        }

        private void buttonK8_Click(object sender, EventArgs e)
        {
            PasswordTextBox.Focus();
            SendKeys.Send("8");
        }

        private void buttonK9_Click(object sender, EventArgs e)
        {
            PasswordTextBox.Focus();
            SendKeys.Send("9");
        }

        private void buttonBackspace_Click(object sender, EventArgs e)
        {
            PasswordTextBox.Focus();
            SendKeys.Send("{BACKSPACE}");
        }

        private void buttonK4_Click(object sender, EventArgs e)
        {
            PasswordTextBox.Focus();
            SendKeys.Send("4");
        }

        private void buttonK5_Click(object sender, EventArgs e)
        {
            PasswordTextBox.Focus();
            SendKeys.Send("5");
        }

        private void buttonK6_Click(object sender, EventArgs e)
        {
            PasswordTextBox.Focus();
            SendKeys.Send("6");
        }

        private void buttonK1_Click(object sender, EventArgs e)
        {
            PasswordTextBox.Focus();
            SendKeys.Send("1");
        }

        private void buttonK2_Click(object sender, EventArgs e)
        {
            PasswordTextBox.Focus();
            SendKeys.Send("2");
        }

        private void buttonK3_Click(object sender, EventArgs e)
        {
            PasswordTextBox.Focus();
            SendKeys.Send("3");
        }

        private void buttonK0_Click(object sender, EventArgs e)
        {
            PasswordTextBox.Focus();
            SendKeys.Send("0");
        }

        private void buttonKDecimal_Click(object sender, EventArgs e)
        {

        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            PasswordTextBox.Clear();
        }
    }
}
