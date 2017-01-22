using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace MCS_POS.Penjualan
{
    public partial class EditItemPenjualanForm : Form
    {
        public IDbConnection DbConnection { get; set; }
        public Model.PenjualanDetail PenjualanDetail { get; set; }

        public EditItemPenjualanForm()
        {
            InitializeComponent();
        }

        private void EditItemPenjualanForm_Load(object sender, EventArgs e)
        {
            // Load data item
            KodeItemTextBox.Text = PenjualanDetail.Item.Kode_Item;
            NamaItemTextBox.Text = PenjualanDetail.Item.Nama_Item;
            JumlahTextBox.Text = PenjualanDetail.Jumlah.ToString();
            HargaJualTextBox.Text = PenjualanDetail.Harga_Jual.ToString("C2");
            SubTotalTextBox.Text = PenjualanDetail.Sub_Total.ToString("C2");

            // Load pilihan satuan
            SatuanComboBox.DataSource = Model.Item.GetItemSatuans(DbConnection, PenjualanDetail.ID_Item);
            SatuanComboBox.DisplayMember = "Nama_Satuan";
            SatuanComboBox.ValueMember = "ID_Satuan";
            SatuanComboBox.SelectedValue = PenjualanDetail.ID_Satuan;

            // Attach NumbersOnly Listener
            JumlahTextBox.KeyDown += NumbersOnly_KeyDown;
            JumlahTextBox.Validating += NumbersTextBox_Validating;
            JumlahTextBox.Leave += NumbersTextBox_Leave;
            JumlahTextBox.Enter += NumbersTextBox_Enter;

            // Attach global keydown
            JumlahTextBox.KeyDown += Global_KeyDown;
            HargaJualTextBox.KeyDown += Global_KeyDown;
            SubTotalTextBox.KeyDown += Global_KeyDown;
        }

        private void NumbersTextBox_Enter(object sender, EventArgs e)
        {
            (sender as TextBox).Text = float.Parse((sender as TextBox).Text.Trim()).ToString();
        }

        private void NumbersTextBox_Leave(object sender, EventArgs e)
        {
            (sender as TextBox).Text = float.Parse((sender as TextBox).Text.Trim()).ToString("N0");
        }

        private void NumbersTextBox_Validating(object sender, CancelEventArgs e)
        {
            float output = 0;
            e.Cancel = !float.TryParse((sender as TextBox).Text.Trim(), out output);
        }

        private void CurrencyTextBox_Enter(object sender, EventArgs e)
        {
            (sender as TextBox).Text = decimal.Parse((sender as TextBox).Text.Trim(), System.Globalization.NumberStyles.Currency).ToString();
        }

        private void CurrencyTextBox_Leave(object sender, EventArgs e)
        {
            (sender as TextBox).Text = decimal.Parse((sender as TextBox).Text.Trim()).ToString("C2");
        }

        private void CurrencyTextBox_Validating(object sender, CancelEventArgs e)
        {
            decimal output = 0m;
            e.Cancel = !decimal.TryParse((sender as TextBox).Text.Trim(), out output);
        }

        private void NumbersOnly_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                case Keys.Down:
                case Keys.Left:
                case Keys.Right:
                case Keys.PageUp:
                case Keys.PageDown:
                case Keys.Delete:
                    e.SuppressKeyPress = false;
                    return;
            }

            char currentKey = (char)e.KeyCode;
            bool nonNumber = char.IsLetter(currentKey) || 
                char.IsSymbol(currentKey) || 
                char.IsWhiteSpace(currentKey) || 
                char.IsPunctuation(currentKey);

            if (nonNumber)
            {
                e.SuppressKeyPress = true;
            }
        }

        

        private void Global_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SubmitButton_Click(sender, e);
            }

            if (e.KeyCode == Keys.Escape)
            {
                e.Handled = true;
                BackButton_Click(sender, e);
            }
        }

        private void SatuanComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (!SatuanComboBox.DroppedDown)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.Handled = true;
                    SubmitButton_Click(sender, e);
                }

                if (e.KeyCode == Keys.Escape)
                {
                    e.Handled = true;
                    BackButton_Click(sender, e);
                }
            }
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void SatuanComboBox_Enter(object sender, EventArgs e)
        {
            SatuanComboBox.DroppedDown = true;
        }

        

        
    }
}
