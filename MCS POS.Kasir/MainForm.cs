using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace MCS_POS.Kasir
{
    public partial class MainForm : Form
    {
        public IDbConnection DbConnection { get; set; }
        public Model.Departemen DepartemenAktif { get; set; }
        public List<Model.User> KasirUsers { get; set; }

        /// <summary>Config.ini</summary>
        public IniFile ConfigINI { get; set; }

        public MainForm()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.Manual;

            if (Properties.Settings.Default.MainFormLocation.X >= 0 && Properties.Settings.Default.MainFormLocation.Y >= 0)
                this.Location = Properties.Settings.Default.MainFormLocation;

            if (Properties.Settings.Default.MainFormSize.Height > 0 && Properties.Settings.Default.MainFormSize.Width > 0)
                this.Size = Properties.Settings.Default.MainFormSize;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            // Load config.ini
            ConfigINI = new IniFile("config.ini");

            // Mendapatkan versi binary
            ribbonLabelVersi.Text = "App v" + System.Reflection.Assembly
                .GetExecutingAssembly()
                .GetName()
                .Version.ToString();

            ribbonLabelVersi2.Text = "Model v" + System.Reflection.Assembly
                .GetAssembly(typeof(Model.Item))
                .GetName()
                .Version.ToString();

            // build connection string
            var csBuilder = new MySqlConnectionStringBuilder();
            csBuilder.Server = ConfigINI.GetString("db", "server", "localhost");
            csBuilder.Port = Convert.ToUInt32(ConfigINI.GetString("db", "port", "3306"));
            csBuilder.UserID = ConfigINI.GetString("db", "user_id", "root");
            csBuilder.Password = ConfigINI.GetString("db", "password", "");
            csBuilder.Database = ConfigINI.GetString("db", "database", "app_pos");

            DbConnection = new MySqlConnection(csBuilder.GetConnectionString(true));

            try
            {
                // try connect database
                this.DbConnection.Open();

                // Cek Departemen Aktif
                CekDepartemenAktif();

                if (this.DepartemenAktif != null)
                {
                    // Load Kasir
                    LoadKasir();
                }

                // Tampilkan ribbon setelah di Kasir diload
                ribbon1.Visible = true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(this, "Terjadi kesalahan DB : " + ex.Message + "\r\n\r\nCek setting di file config.ini", "Kesalahan Sistem", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Automatis exit
                this.Close();
            }
        }

        private void CekDepartemenAktif()
        {
            var setting = Properties.Settings.Default;

            if (setting.ID_Departemen == -1)
            {
                MessageBox.Show(this, "Departemen belum di set. Setting departemen terlebih dahulu.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                using (var form = new DepartemenSettingForm())
                {
                    form.DbConnection = this.DbConnection;

                    if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                    {
                        setting.Reload();

                        // Load Departemen Item
                        this.DepartemenAktif = Model.Departemen.GetSingle(DbConnection, setting.ID_Departemen);
                    }
                }
            }
            else
            {
                // Load Departemen Item
                this.DepartemenAktif = Model.Departemen.GetSingle(DbConnection, setting.ID_Departemen);
            }
        }

        private void LoadKasir()
        {
            // get kasir aktif di departemen terpilih
            this.KasirUsers = Model.User.GetListKasirAktif(DbConnection, DepartemenAktif.ID_Departemen);

            // Jika sudah ada kasir yg aktif
            if (KasirUsers.Count() > 0)
            {
                // tambah tombol dynamic sesuai jumlah kasir
                foreach (var kasir in KasirUsers)
                {
                    // create button + default image
                    var ribbonButtonKasir = new RibbonButton()
                    {
                        Text = kasir.Nama_User,
                        Image = Properties.Resources.business_people32,
                        CheckOnClick = true,
                        CheckedGroup = "KasirButton",
                        Tag = kasir
                    };

                    // set handler klik
                    ribbonButtonKasir.Click += ribbonButtonKasir_Click;

                    // Add ke panel
                    ribbonPanelKasir.Items.Add(ribbonButtonKasir);
                }
            }
        }

        private void ribbonButtonKasir_Click(object sender, EventArgs e)
        {
            var ribbonButtonKasir = (RibbonButton)sender;
            var findForm = this.MdiChildren.FirstOrDefault(f => f.GetType() == typeof(KasirForm));

            // Jika belum ada yg aktif
            if (findForm == null)
            {
                // Create Object
                var childForm = new KasirForm()
                {
                    MdiParent = this,
                    DbConnection = this.DbConnection,
                    DepartemenAktif = this.DepartemenAktif,
                    RibbonButtonReference = ribbonButtonKasir,
                    KasirUser = (Model.User)ribbonButtonKasir.Tag
                };

                // Tampilkan
                childForm.Show();
            }
            else // jika sudah ada yg aktif
            {
                // Jika referensi tombol sama -> aktifkan
                if ((findForm as KasirForm).RibbonButtonReference == ribbonButtonKasir)
                {
                    // aktifkan form kasir
                    findForm.Activate();
                }
                else // jika referensi tombol beda -> tutup, buka baru
                {
                    // tutup form kasir aktif
                    findForm.Close();
                    
                    // Create form kasir baru
                    var childForm = new KasirForm()
                    {
                        MdiParent = this,
                        DbConnection = this.DbConnection,
                        DepartemenAktif = this.DepartemenAktif,
                        RibbonButtonReference = ribbonButtonKasir,
                        KasirUser = (Model.User)ribbonButtonKasir.Tag
                    };

                    // Tampilkan
                    childForm.Show();
                }
            }

            ribbonButtonKasir.Checked = true;
        }

        private void ribbonButtonPenjualan_Click(object sender, EventArgs e)
        {
            var authForm = new LoginForm() { DbConnection = this.DbConnection, AksesDataPenjualan = true };

            if (authForm.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                var findForm = this.MdiChildren.FirstOrDefault(f => f.GetType() == typeof(PenjualanForm));

                if (findForm == null)
                {
                    var childForm = new PenjualanForm()
                    {
                        MdiParent = this,
                        DbConnection = this.DbConnection,
                        DepartemenAktif = this.DepartemenAktif
                    };

                    childForm.Show();
                }
                else
                {
                    findForm.Activate();
                }
            }
        }

        private void ribbonButtonPenjualanRefund_Click(object sender, EventArgs e)
        {
            var findForm = this.MdiChildren.FirstOrDefault(f => f.GetType() == typeof(PenjualanRefundForm));

            if (findForm == null)
            {
                var childForm = new PenjualanRefundForm()
                {
                    MdiParent = this,
                    DbConnection = this.DbConnection,
                    DepartemenAktif = this.DepartemenAktif
                };

                childForm.Show();
            }
            else
            {
                findForm.Activate();
            }
        }

        private void ribbonButtonDepartemen_Click(object sender, EventArgs e)
        {
            using (var form = new DepartemenSettingForm())
            {
                form.DbConnection = this.DbConnection;

                if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    // Tampilkan informasi perubahan
                    MessageBox.Show(this, "Ada perubahan setting cabang. Aplikasi perlu direstart", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Application.Exit();
                }
            }
        }

        private void ribbonButtonPrinterSetting_Click(object sender, EventArgs e)
        {
            using (var form = new PrinterSettingForm())
            {
                form.ShowDialog(this);
            }
        }

        private bool IsChildExist(Type formType)
        {
            return (this.MdiChildren.FirstOrDefault(f => f.GetType() == formType) != null);
        }

        private void ribbonPanelPengaturan_ButtonMoreClick(object sender, EventArgs e)
        {
            using (var dbSetting = new DbSettingForm())
            {
                if (dbSetting.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    MessageBox.Show(this, "Aplikasi perlu restart setelah setting database.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Application.Exit();
                }
            }
        }

        private void MainForm_Move(object sender, EventArgs e)
        {
            Properties.Settings.Default.MainFormLocation = this.Location;
            Properties.Settings.Default.Save();
        }

        private void MainForm_ResizeEnd(object sender, EventArgs e)
        {
            Properties.Settings.Default.MainFormSize = this.Size;
            Properties.Settings.Default.Save();
        }
    }
}
