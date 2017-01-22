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
        public MySqlConnection MySqlConnection { get; set; }
        public Model.User UserLogin { get; set; }

        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            if (UsernameTextBox.Text.Trim().Length == 0)
            {
                MessageBox.Show("Username kosong");
                return;
            }

            if (PasswordTextBox.Text.Trim().Length == 0)
            {
                MessageBox.Show("Password kosong");
                return;
            }

            var sql = "select * from user where username = @username and password_hash = sha1(@password)";
            var users = this.MySqlConnection.Query<Model.User>(sql, new { 
                username = UsernameTextBox.Text.Trim(),
                password = PasswordTextBox.Text.Trim()
            });

            if (users.Count() == 0)
            {
                MessageBox.Show("Login salah");
            }
            else
            {
                this.UserLogin = users.First();
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
    }
}
