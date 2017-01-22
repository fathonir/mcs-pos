using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Dapper;

namespace MCS_POS.Pengaturan
{
    public partial class PengaturanForm : MCS_POS.EditorBaseForm
    {
        private IEnumerable<Model.Config> configs { get; set; }

        public PengaturanForm()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void PengaturanForm_Load(object sender, EventArgs e)
        {
            // Load all settings
            configs = Model.Config.GetAll(DbConnection);

            // Cabang Setting
            KodeCabangTextBox.Text = configs.First(c => c.Nama == "cabang_kode").Nilai;
            NamaCabangTextBox.Text = configs.First(c => c.Nama == "cabang_nama").Nilai;
            AlamatCabangTextBox.Text = configs.First(c => c.Nama == "cabang_alamat").Nilai;
            KotaCabangTextBox.Text = configs.First(c => c.Nama == "cabang_kota").Nilai;
            TelpCabangTextBox.Text = configs.First(c => c.Nama == "cabang_telp").Nilai;

            // Penjualan
            KodePenjualanTextBox.Text = configs.First(c => c.Nama == "format_kode_penjualan").Nilai;
            DigitPenjualanTextBox.Text = configs.First(c => c.Nama == "digit_counter_penjualan").Nilai;

            // Pembelian
            KodePembelianTextBox.Text = configs.First(c => c.Nama == "format_kode_pembelian").Nilai;
            DigitPembelianTextBox.Text = configs.First(c => c.Nama == "digit_counter_pembelian").Nilai;

            // Struk template
            StrukTemplateTextBox.Text = configs.First(c => c.Nama == "template_struk_kasir").Nilai;
            StrukRefundTextBox.Text = configs.First(c => c.Nama == "template_struk_refund").Nilai;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            // reset error
            errorProvider1.Clear();

            // Prepare transaction
            var transaction = DbConnection.BeginTransaction();

            // VALIDATION Password Change
            if (PasswordAdminTextBox.Text.Trim().Length > 0)
            {
                if (PasswordAdminTextBox2.Text.Trim().Length == 0)
                {
                    // Set error
                    errorProvider1.SetError(PasswordAdminTextBox2, "Ulangi password baru disini");

                    // Activate
                    tabControl1.SelectedTab = tabPage2;

                    // Play Windows sound
                    System.Media.SystemSounds.Asterisk.Play();

                    return;
                }
                else if (PasswordAdminTextBox.Text.Trim().Equals(PasswordAdminTextBox2.Text.Trim()) == false)
                {
                    // Set error
                    errorProvider1.SetError(PasswordAdminTextBox2, "Harus sama dengan password baru");

                    // Activate
                    tabControl1.SelectedTab = tabPage2;

                    // Play windows sound
                    System.Media.SystemSounds.Asterisk.Play();

                    return;
                }
                else
                {
                    // Set Object
                    (MdiParent as MainForm).UserLogin.New_Password = PasswordAdminTextBox.Text.Trim();

                    // Update password
                    Model.User.UpdatePassword(transaction, (MdiParent as MainForm).UserLogin);
                }
            }


            // ----------------------
            // Assign to object
            // ----------------------

            // Cabang
            configs.First(c => c.Nama == "cabang_kode").Nilai = KodeCabangTextBox.Text;
            configs.First(c => c.Nama == "cabang_nama").Nilai = NamaCabangTextBox.Text;
            configs.First(c => c.Nama == "cabang_alamat").Nilai = AlamatCabangTextBox.Text;
            configs.First(c => c.Nama == "cabang_kota").Nilai = KotaCabangTextBox.Text;
            configs.First(c => c.Nama == "cabang_telp").Nilai = TelpCabangTextBox.Text;


            // Penjualan
            configs.First(c => c.Nama == "format_kode_penjualan").Nilai = KodePenjualanTextBox.Text;
            configs.First(c => c.Nama == "digit_counter_penjualan").Nilai = DigitPenjualanTextBox.Text;

            // Pembelian
            configs.First(c => c.Nama == "format_kode_pembelian").Nilai = KodePembelianTextBox.Text;
            configs.First(c => c.Nama == "digit_counter_pembelian").Nilai = DigitPembelianTextBox.Text;

            // Struk template
            configs.First(c => c.Nama == "template_struk_kasir").Nilai = StrukTemplateTextBox.Text;
            configs.First(c => c.Nama == "template_struk_refund").Nilai = StrukRefundTextBox.Text;

            // Update config
            Model.Config.UpdateMulti(transaction, configs);

            // Apply transaction
            transaction.Commit();

            MessageBox.Show(this, "Pengaturan berhasil disimpan", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        
    }
}
