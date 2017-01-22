using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Dapper;

namespace MCS_POS
{
    public partial class MainForm : System.Windows.Forms.RibbonForm
    {
        /// <summary>Koneksi aktif </summary>
        public IDbConnection DbConnection { get; set; }

        /// <summary>Config.ini</summary>
        public IniFile ConfigINI { get; set; }

        public List<Model.Config> Configs { get; set; }

        /// <summary>Departemen aktif</summary>
        public Model.Departemen DepartemenAktif { get; set; }

        /// <summary>User Login aktif</summary>
        public Model.User UserLogin { get; set; }

        /// <summary>Daftar tombol ribbon kasir</summary>
        private List<RibbonButton> ribbonButtonKasirs = new List<RibbonButton>();

        public MainForm()
        {
            // Check Maxmized before initialize
            if (Properties.Settings.Default.MainFormMaximized)
                this.WindowState = FormWindowState.Maximized;
            
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Load Default Location & Size
            if (Properties.Settings.Default.MainFormLocation != new Point(0, 0))
            {
                // Pastikan tidak negatif
                if (Properties.Settings.Default.MainFormLocation.X > 0 && Properties.Settings.Default.MainFormLocation.X > 0)
                {
                    this.Location = Properties.Settings.Default.MainFormLocation;
                }
            }

            if (Properties.Settings.Default.MainFormSize != new Size(0, 0))
            {
                // Pastikan tidak negatif
                if (Properties.Settings.Default.MainFormSize.Width > 0 && Properties.Settings.Default.MainFormSize.Height > 0)
                {
                    this.Size = Properties.Settings.Default.MainFormSize;
                }
            }
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            // Hidden close child form
            buttonCloseChild.Visible = false;
            tabControl1.Visible = false;

            // Mendapatkan versi binary
            ribbonLabelVersi.Text = "App v" + System.Reflection.Assembly
                .GetExecutingAssembly()
                .GetName()
                .Version.ToString();

            ribbonLabelVersi2.Text = "Model v" + System.Reflection.Assembly
                .GetAssembly(typeof(Model.Item))
                .GetName()
                .Version.ToString();

            // Load config.ini
            ConfigINI = new IniFile("config.ini");

            // build connection string
            var csBuilder = new MySqlConnectionStringBuilder();
            csBuilder.Server = ConfigINI.GetString("db", "server", "localhost");
            csBuilder.Port = Convert.ToUInt32(ConfigINI.GetString("db", "port", "3306"));
            csBuilder.UserID = ConfigINI.GetString("db", "user_id", "root");
            csBuilder.Password = ConfigINI.GetString("db", "password", "");
            csBuilder.Database = ConfigINI.GetString("db", "database", "app_pos");

            // load default connection
            this.DbConnection = new MySqlConnection(csBuilder.GetConnectionString(true));

            try
            {
                // start connect
                this.DbConnection.Open();

                // load default departemen
                this.DepartemenAktif = Model.Departemen.GetSingle(this.DbConnection, ConfigINI.GetString("app", "default_departemen", ""));

                // Load All Config dari database
                this.Configs = Model.Config.GetAll(this.DbConnection).ToList();

                // start transaksi
                var transaction = DbConnection.BeginTransaction();

                // Menghapus Konfigurasi lama yg tidak terpakai
                transaction.Connection.Execute("DELETE FROM config WHERE nama LIKE 'cabang_%'");
                transaction.Connection.Execute("DELETE FROM config WHERE nama LIKE 'program_start'");


                // ==============================
                // Default konfigurasi
                // ==============================
                // Periode Awal Transaksi
                Model.Config.InitConfig(transaction, this.Configs, Model.Config.PERIODE_AWAL, "2015-06-01");
                // Format Kode Pembelian
                Model.Config.InitConfig(transaction, this.Configs, Model.Config.FORMAT_KODE_PEMBELIAN, "[COUNTER].BL.[DEPARTEMEN].[TGL][BLN][THN]");
                Model.Config.InitConfig(transaction, this.Configs, Model.Config.DIGIT_COUNTER_PEMBELIAN, "3");
                Model.Config.InitConfig(transaction, this.Configs, Model.Config.RESET_COUNTER_PEMBELIAN, "HARI");
                // Format Kode Penjualan
                Model.Config.InitConfig(transaction, this.Configs, Model.Config.FORMAT_KODE_PENJUALAN, "[COUNTER].JL.[DEPARTEMEN].[TGL][BLN][THN]");
                Model.Config.InitConfig(transaction, this.Configs, Model.Config.DIGIT_COUNTER_PENJUALAN, "3");
                Model.Config.InitConfig(transaction, this.Configs, Model.Config.RESET_COUNTER_PENJUALAN, "HARI");
                // Format Kode Transfer
                Model.Config.InitConfig(transaction, this.Configs, Model.Config.FORMAT_KODE_TRANSFER, "[COUNTER].TRF.[DEPARTEMEN].[TGL][BLN][THN]");
                Model.Config.InitConfig(transaction, this.Configs, Model.Config.DIGIT_COUNTER_TRANSFER, "3");
                Model.Config.InitConfig(transaction, this.Configs, Model.Config.RESET_COUNTER_TRANSFER, "HARI");
                // Format Kode Konsinyasi
                Model.Config.InitConfig(transaction, this.Configs, Model.Config.FORMAT_KODE_KONSINYASI, "[COUNTER].KIN.[DEPARTEMEN].[TGL][BLN][THN]"); 
                Model.Config.InitConfig(transaction, this.Configs, Model.Config.DIGIT_COUNTER_KONSINYASI, "3");
                Model.Config.InitConfig(transaction, this.Configs, Model.Config.RESET_COUNTER_KONSINYASI, "HARI");
                // Format Kode Retur Konsinyasi
                Model.Config.InitConfig(transaction, this.Configs, Model.Config.FORMAT_KODE_KONSINYASI_RETUR, "[COUNTER].RKI.[DEPARTEMEN].[TGL][BLN][THN]");
                Model.Config.InitConfig(transaction, this.Configs, Model.Config.DIGIT_COUNTER_KONSINYASI_RETUR, "3");
                Model.Config.InitConfig(transaction, this.Configs, Model.Config.RESET_COUNTER_KONSINYASI_RETUR, "HARI");
                // Format Kode Pembayaran Konsinyasi
                Model.Config.InitConfig(transaction, this.Configs, Model.Config.FORMAT_KODE_KONSINYASI_PEMBAYARAN, "[COUNTER].HKI.[DEPARTEMEN].[TGL][BLN][THN]");
                Model.Config.InitConfig(transaction, this.Configs, Model.Config.DIGIT_COUNTER_KONSINYASI_PEMBAYARAN, "3");
                Model.Config.InitConfig(transaction, this.Configs, Model.Config.RESET_COUNTER_KONSINYASI_PEMBAYARAN, "BULAN");
                // Informasi Cabang (untuk cetak struk)
                Model.Config.InitConfig(transaction, this.Configs, Model.Config.CABANG_KODE, "CBG");
                Model.Config.InitConfig(transaction, this.Configs, Model.Config.CABANG_NAMA, "Toko Apotek");
                Model.Config.InitConfig(transaction, this.Configs, Model.Config.CABANG_ALAMAT, "Alamat Apotek");
                Model.Config.InitConfig(transaction, this.Configs, Model.Config.CABANG_KOTA, "Kota Apotek");
                Model.Config.InitConfig(transaction, this.Configs, Model.Config.CABANG_TELP, "021-0000000");

                // ======================
                // Inisialisasi Sequence
                // ======================
                Model.Config.InitSequence(transaction, "pembelian");
                Model.Config.InitSequence(transaction, "penjualan");
                Model.Config.InitSequence(transaction, "transfer");
                Model.Config.InitSequence(transaction, "konsinyasi");
                Model.Config.InitSequence(transaction, "konsinyasi_retur");
                Model.Config.InitSequence(transaction, "konsinyasi_pembayaran");


                // Commit semua transaksi inisialisasi
                transaction.Commit();

                // Enable Admin autologin
                EnableAdmin();
                this.UserLogin = Model.User.GetSingle(this.DbConnection, 1);
            }
            catch (MySql.Data.MySqlClient.MySqlException exc)
            {
                MessageBox.Show(this, "Terjadi kesalahan DB : " + exc.Message + "\r\nCek setting di file config.ini", "Kesalahan Sistem", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Automatis exit
                this.Close();
            }
        }

        private void DisableAmin() 
        {
            // disable admin
            ribbonTabMaster.Visible = false;
            ribbonTabPembelian.Visible = false;
            ribbonTabPenjualan.Visible = false;
            ribbonTabKonsinyasi.Visible = false;
            ribbonTabPersediaan.Visible = false;
            ribbonTabLaporan.Visible = false;
            ribbonOrbMenuLogin.Text = "Login Admin";
        }

        private void EnableAdmin()
        {
            // disable admin
            ribbonTabMaster.Visible = true;
            ribbonTabPembelian.Visible = true;
            ribbonTabPenjualan.Visible = true;
            ribbonTabKonsinyasi.Visible = true;
            ribbonTabPersediaan.Visible = true;
            ribbonTabLaporan.Visible = true;
            
            // Disable fitur tidak dibutuhkan
            // TAB: Master

            // TAB: Pembelian
            rPanelPembelianPesanan.Visible = false;
            rPanelPembelianHutang.Visible = false;
            rPanelPembelianRetur.Visible = false;
            // TAB: Penjualan
            rPanelPenjualanPesanan.Visible = false;
            rPanelPenjualanPiutang.Visible = false;
            // TAB: Persediaan
            ribbonButtonDataItemMasuk.Visible = false;
            ribbonButtonDataItemKeluar.Visible = false;
            //rPanelPersediaanTransfer.Visible = true;
            ribbonButtonMutasiItem.Visible = false;


            // Tab aktif
            ribbon1.ActiveTab = ribbonTabMaster;
            ribbonOrbMenuLogin.Text = "Logout";
        }

        #region FUNGSI BANTUAN
        
        public bool IsChildExist(Type formType)
        {
            foreach (var item in this.MdiChildren)
            {
                if (item.GetType() == formType)
                {
                    return true;
                }
            }

            return false;
        }

        #endregion

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Form form in MdiChildren)
            {
                if (form.GetType().IsSubclassOf(typeof(ChildBaseForm)))
                {
                    if (tabControl1.SelectedTab != null)
                    {
                        if (((ChildBaseForm)form).TabPageReference.Equals(tabControl1.SelectedTab))
                        {
                            form.Activate();
                        }
                    }
                }
                else if (form.GetType().IsSubclassOf(typeof(EditorBaseForm)))
                {
                    // Memastikan reference sudah benar
                    if (tabControl1.SelectedTab != null && ((EditorBaseForm)form).TabPageReference != null)
                    {
                        if (((EditorBaseForm)form).TabPageReference.Equals(tabControl1.SelectedTab))
                        {
                            form.Activate();
                        }
                    }
                }
            }
        }

        public void buttonCloseChild_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
            {
                ActiveMdiChild.Close();
            }

            if (MdiChildren.Length == 0)
            {
                buttonCloseChild.Visible = false;
            }
        }

        private void tabControl1_ControlAdded(object sender, ControlEventArgs e)
        {
            buttonCloseChild.Visible = true;
        }

        #region TAB : MASTER DATA

        private void ribbonButtonSatuan_Click(object sender, EventArgs e)
        {
            if (!IsChildExist(typeof(Master.SatuanForm)))
            {
                var childForm = new Master.SatuanForm(this, DbConnection, tabControl1);
                childForm.Show();
            }
            else
            {
                foreach (Form form in MdiChildren)
                {
                    if (form is Master.SatuanForm)
                    {
                        form.Activate(); break;
                    }
                }
            }
        }

        private void ribbonButtonJenis_Click(object sender, EventArgs e)
        {
            if (!IsChildExist(typeof(Master.JenisForm)))
            {
                var childForm = new Master.JenisForm(this, DbConnection, tabControl1);
                childForm.Show();
            }
            else
            {
                foreach (Form form in MdiChildren)
                {
                    if (form is Master.JenisForm)
                    {
                        form.Activate(); break;
                    }
                }
            }
        }

        

        private void ribbonButtonCabang_Click(object sender, EventArgs e)
        {
            if (!IsChildExist(typeof(Master.CabangForm)))
            {
                var childForm = new Master.CabangForm(this, DbConnection, tabControl1);
                childForm.Show();
            }
            else
            {
                foreach (Form form in MdiChildren)
                {
                    if (form is Master.CabangForm)
                    {
                        form.Activate(); break;
                    }
                }
            }
        }

        private void ribbonButtonMerek_Click(object sender, EventArgs e)
        {
            if (!IsChildExist(typeof(Master.MerekForm)))
            {
                var childForm = new Master.MerekForm(this, DbConnection, tabControl1);
                childForm.Show();
            }
            else
            {
                foreach (Form form in MdiChildren)
                {
                    if (form is Master.MerekForm)
                    {
                        form.Activate(); break;
                    }
                }
            }
        }

        private void ribbonButtonBank_Click(object sender, EventArgs e)
        {
            if (!IsChildExist(typeof(Master.BankForm)))
            {
                var childForm = new Master.BankForm(this, DbConnection, tabControl1);
                childForm.Show();
            }
            else
            {
                foreach (Form form in MdiChildren)
                {
                    if (form is Master.BankForm)
                    {
                        form.Activate(); break;
                    }
                }
            }
        }

        private void ribbonButtonSupplier_Click(object sender, EventArgs e)
        {
            if (!IsChildExist(typeof(Master.SupplierForm)))
            {
                var childForm = new Master.SupplierForm(this, DbConnection, tabControl1);
                childForm.Show();
            }
            else
            {
                foreach (Form form in MdiChildren)
                {
                    if (form is Master.SupplierForm)
                    {
                        form.Activate(); break;
                    }
                }
            }
        }

        private void ribbonButtonPelanggan_Click(object sender, EventArgs e)
        {
            if (!IsChildExist(typeof(Master.CustomerForm)))
            {
                var childForm = new Master.CustomerForm()
                {
                    MdiParent = this,
                    DbConnection = this.DbConnection,
                    TabControlReference = this.tabControl1
                };

                childForm.Show();
            }
            else
            {
                foreach (Form form in MdiChildren)
                {
                    if (form is Master.CustomerForm)
                    {
                        form.Activate(); break;
                    }
                }
            }
        }

        private void ribbonButtonKasir_Click(object sender, EventArgs e)
        {
            if (!IsChildExist(typeof(Master.KasirForm)))
            {
                var childForm = new Master.KasirForm()
                {
                    MdiParent = this,
                    DbConnection = this.DbConnection,
                    DepartemenAktif = this.DepartemenAktif,
                    TabControlReference = this.tabControl1
                };

                childForm.Show();
            }
            else
            {
                foreach (Form form in MdiChildren)
                {
                    if (form is Master.KasirForm)
                    {
                        form.Activate(); break;
                    }
                }
            }
        }

        private void ribbonButtonDataItem_Click(object sender, EventArgs e)
        {
            if (!IsChildExist(typeof(Master.ItemForm)))
            {
                var childForm = new Master.ItemForm() { 
                    MdiParent = this,
                    DbConnection = this.DbConnection,
                    TabControlReference = this.tabControl1,
                    DepartemenAktif = this.DepartemenAktif
                };

                childForm.Show();
            }
            else
            {
                foreach (Form form in MdiChildren)
                {
                    if (form is Master.ItemForm)
                    {
                        form.Activate(); break;
                    }
                }
            }
        }

        private void ribbonButtonItemBaru_Click(object sender, EventArgs e)
        {
            var childForm = new Master.ItemEditorForm()
            {
                MdiParent = this,
                DbConnection = this.DbConnection,
                TabControlReference = this.tabControl1,
                EditorMode = EditorBaseForm.EditMode.Add
            };

            childForm.Show();
        }

        private void ribbonButtonKartuStok_Click(object sender, EventArgs e)
        {
            var childForm = new Master.KartuStokForm()
            {
                MdiParent = this,
                DbConnection = this.DbConnection,
                TabControlReference = this.tabControl1,
                DepartemenAktif = this.DepartemenAktif,
                Configs = this.Configs
            };

            childForm.Show();
        }

        private void ribbonButtonPengaturan_Click(object sender, EventArgs e)
        {
            if (!IsChildExist(typeof(Pengaturan.PengaturanForm)))
            {
                var childForm = new Pengaturan.PengaturanForm()
                {
                    MdiParent = this,
                    DbConnection = this.DbConnection,
                    TabControlReference = this.tabControl1
                };

                childForm.Show();
            }
            else
            {
                MdiChildren.First(f => f is Pengaturan.PengaturanForm).Activate();
            }
        }

        #endregion

        #region TAB : KONSINYASI
        private void ribbonButtonKonsPenerimaanBarang_Click(object sender, EventArgs e)
        {
            var child = MdiChildren.SingleOrDefault(f => f is Konsinyasi.KonsinyasiMasukForm);

            if (child == null)
            {
                var childForm = new Konsinyasi.KonsinyasiMasukForm()
                {
                    MdiParent = this,
                    DbConnection = this.DbConnection,
                    TabControlReference = this.tabControl1,
                    CloseButtonReference = this.buttonCloseChild,
                    DepartemenAktif = this.DepartemenAktif,
                    UserLogin = this.UserLogin,
                    Configs = this.Configs
                };

                childForm.Show();
            }
            else
            {
                // Aktifkan konsinyasi masuk form
                child.Activate();
            }
        }

        private void ribbonButtonKonsReturMasuk_Click(object sender, EventArgs e)
        {
            var child = MdiChildren.SingleOrDefault(f => f is Konsinyasi.KonsinyasiReturForm);

            if (child == null)
            {
                var childForm = new Konsinyasi.KonsinyasiReturForm()
                {
                    MdiParent = this,
                    DbConnection = this.DbConnection,
                    TabControlReference = this.tabControl1,
                    CloseButtonReference = this.buttonCloseChild,
                    DepartemenAktif = this.DepartemenAktif,
                    UserLogin = this.UserLogin,
                    Configs = this.Configs
                };

                childForm.Show();
            }
            else
            {
                // Aktifkan retur konsinyasi form
                child.Activate();
            }
        }

        private void ribbonButtonDataKonsinyasi_Click(object sender, EventArgs e)
        {
            var child = MdiChildren.SingleOrDefault(f => f is Konsinyasi.KonsinyasiForm);

            if (child == null)
            {
                var childForm = new Konsinyasi.KonsinyasiForm() {
                    MdiParent = this,
                    DbConnection = this.DbConnection,
                    TabControlReference = this.tabControl1,
                    CloseButtonReference = this.buttonCloseChild,
                    DepartemenAktif = this.DepartemenAktif,
                    UserLogin = this.UserLogin,
                    Configs = this.Configs
                };

                childForm.Show();
            }
            else
            {
                // Aktifkan konsinyasi form
                child.Activate();
            }
        }
        #endregion

        #region TAB : PERSEDIAAN

        private void ribbonButtonSaldoAwal_Click(object sender, EventArgs e)
        {
            if (!IsChildExist(typeof(Persediaan.SaldoAwalForm)))
            {
                // Format baru
                var childForm = new Persediaan.SaldoAwalForm()
                {
                    MdiParent = this,
                    DbConnection = this.DbConnection,
                    TabControlReference = this.tabControl1,
                    DepartemenAktif = this.DepartemenAktif
                };

                childForm.Show();
            }
            else
            {
                foreach (Form form in MdiChildren)
                {
                    if (form is Persediaan.SaldoAwalForm)
                    {
                        form.Activate(); break;
                    }
                }
            }
        }

        private void ribbonButtonStokOpname_Click(object sender, EventArgs e)
        {
            if (!IsChildExist(typeof(Persediaan.StokOpnameForm)))
            {
                // Format baru
                var childForm = new Persediaan.StokOpnameForm()
                {
                    MdiParent = this,
                    DbConnection = this.DbConnection,
                    TabControlReference = this.tabControl1,
                    DepartemenAktif = this.DepartemenAktif
                };

                childForm.Show();
            }
            else
            {
                foreach (Form form in MdiChildren)
                {
                    if (form is Persediaan.StokOpnameForm)
                    {
                        form.Activate(); break;
                    }
                }
            }
        }

        private void ribbonButtonTransferItem_Click(object sender, EventArgs e)
        {
            var child = MdiChildren.SingleOrDefault(f => f is Persediaan.TransferForm);

            if (child == null)
            {
                var childForm = new Persediaan.TransferForm()
                {
                    MdiParent = this,
                    DbConnection = this.DbConnection,
                    TabControlReference = this.tabControl1,
                    CloseButtonReference = this.buttonCloseChild,
                    DepartemenAktif = this.DepartemenAktif,
                    UserLogin = this.UserLogin,
                    Configs = this.Configs
                };

                childForm.Show();
            }
            else
            {
                // Aktifkan transaksi Transfer form
                child.Activate();
            }
        }

        private void ribbonButtonProsesBulanan_Click(object sender, EventArgs e)
        {
            var dialog = new Persediaan.ProsesBulananForm()
            {
                Configs = this.Configs,
                DbConnection = this.DbConnection,
                DepartemenAktif = this.DepartemenAktif
            };

            dialog.ShowDialog(this);
        }

        #endregion
        
        #region RIBBON ORB

        private void ribbonOrbMenuLogin_Click(object sender, EventArgs e)
        {
            if (ribbonOrbMenuLogin.Text == "Login Admin")
            {
                var loginForm = new LoginForm();
                loginForm.MySqlConnection = (MySqlConnection)this.DbConnection;
                loginForm.ShowDialog(this);

                if (loginForm.UserLogin != null)
                {
                    // Set User aktif
                    this.UserLogin = loginForm.UserLogin;

                    // Enable control
                    EnableAdmin();
                }
            }
            else // Logout
            {
                // Unset
                this.UserLogin = null;

                // Disable Control
                DisableAmin();
            }
        }

        private void ribbonOrbMenuQuit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Anda akan keluar dari program. Ingin melanjutkan ?", "Question", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
            {
                this.DbConnection.Close();
                Application.Exit();
            }
        }

        #endregion

        private void ribbonButtonPrinterKasir_Click(object sender, EventArgs e)
        {
            using (var dialog = new Kasir.PrinterSettingForm())
            {
                dialog.ShowDialog(this);
            }
        }

        #region TAB : PEMBELIAN

        private void ribbonButtonDataPembelian_Click(object sender, EventArgs e)
        {
            var child = MdiChildren.SingleOrDefault(f => f is Pembelian.PembelianForm);

            if (child == null)
            {
                var childForm = new Pembelian.PembelianForm()
                {
                    MdiParent = this,
                    DbConnection = this.DbConnection,
                    TabControlReference = this.tabControl1,
                    CloseButtonReference = this.buttonCloseChild,
                    DepartemenAktif = this.DepartemenAktif,
                    UserLogin = this.UserLogin,
                    Configs = this.Configs
                };

                childForm.Show();
            }
            else
            {
                // Aktifkan pembelian form
                child.Activate();
            }
        }

        private void ribbonButtonHistoryHargaBeli_Click(object sender, EventArgs e)
        {
            var child = MdiChildren.SingleOrDefault(f => f is Pembelian.HistoryHargaForm);

            if (child == null)
            {
                var childForm = new Pembelian.HistoryHargaForm()
                {
                    MdiParent = this,
                    DbConnection = this.DbConnection,
                    TabControlReference = this.tabControl1,
                    CloseButtonReference = this.buttonCloseChild,
                    DepartemenAktif = this.DepartemenAktif,
                    UserLogin = this.UserLogin,
                    Configs = this.Configs
                };

                childForm.Show();
            }
            else
            {
                // Aktifkan pembelian form
                child.Activate();
            }
        }

        #endregion

        #region TAB : PENJUALAN

        private void ribbonButtonDataPenjualan_Click(object sender, EventArgs e)
        {
            var child = MdiChildren.SingleOrDefault(f => f is Penjualan.PenjualanForm);

            if (child == null)
            {
                var childForm = new Penjualan.PenjualanForm()
                {
                    MdiParent = this,
                    DbConnection = this.DbConnection,
                    TabControlReference = this.tabControl1,
                    CloseButtonReference = this.buttonCloseChild,
                    DepartemenAktif = this.DepartemenAktif,
                    UserLogin = this.UserLogin,
                    Configs = this.Configs
                };

                childForm.Show();
            }
            else
            {
                // Aktifkan pembelian form
                child.Activate();
            }
        }

        #endregion

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.MainFormLocation = this.Location;

            if (this.WindowState == FormWindowState.Normal)
            {
                Properties.Settings.Default.MainFormSize = this.Size;
            }
            else
            {
                Properties.Settings.Default.MainFormSize = this.RestoreBounds.Size;
            }
            
            Properties.Settings.Default.MainFormMaximized = (this.WindowState == FormWindowState.Maximized);

            Properties.Settings.Default.Save();
        }

        #region LAPORAN - LAPORAN

        private void ribbonButtonLapPembelian_Click(object sender, EventArgs e)
        {
            var child = MdiChildren.SingleOrDefault(f => f is Laporan.Penjualan.LaporanPembelianForm);

            if (child == null)
            {
                var childForm = new Laporan.Penjualan.LaporanPembelianForm()
                {
                    MdiParent = this,
                    DbConnection = this.DbConnection,
                    TabControlReference = this.tabControl1,
                    CloseButtonReference = this.buttonCloseChild,
                    DepartemenAktif = this.DepartemenAktif,
                    UserLogin = this.UserLogin,
                    Configs = this.Configs
                };

                childForm.Show();
            }
            else
            {
                // Aktifkan laporan pembelian form
                child.Activate();
            }
        }

        private void ribbonButtonLapPenjualan_Click(object sender, EventArgs e)
        {
            var child = MdiChildren.SingleOrDefault(f => f is Laporan.Penjualan.LaporanPenjualanForm);

            if (child == null)
            {
                var childForm = new Laporan.Penjualan.LaporanPenjualanForm()
                {
                    MdiParent = this,
                    DbConnection = this.DbConnection,
                    TabControlReference = this.tabControl1,
                    CloseButtonReference = this.buttonCloseChild,
                    DepartemenAktif = this.DepartemenAktif,
                    UserLogin = this.UserLogin,
                    Configs = this.Configs
                };

                childForm.Show();
            }
            else
            {
                // Aktifkan laporan penjualan
                child.Activate();
            }
        }

        private void ribbonButtonLapRetur_Click(object sender, EventArgs e)
        {
            var child = MdiChildren.SingleOrDefault(f => f is Laporan.Penjualan.LaporanReturForm);

            if (child == null)
            {
                var childForm = new Laporan.Penjualan.LaporanReturForm()
                {
                    MdiParent = this,
                    DbConnection = this.DbConnection,
                    TabControlReference = this.tabControl1,
                    CloseButtonReference = this.buttonCloseChild,
                    DepartemenAktif = this.DepartemenAktif,
                    UserLogin = this.UserLogin,
                    Configs = this.Configs
                };

                childForm.Show();
            }
            else
            {
                // Aktifkan pembelian form
                child.Activate();
            }
        }

        /// <summary>
        /// Laporan Master data item
        /// </summary>
        private void ribbonButtonLapMaster1_Click(object sender, EventArgs e)
        {
            var child = MdiChildren.SingleOrDefault(f => f is Laporan.Master.LaporanItemForm);

            if (child == null)
            {
                var childForm = new Laporan.Master.LaporanItemForm()
                {
                    MdiParent = this,
                    DbConnection = this.DbConnection,
                    TabControlReference = this.tabControl1,
                    CloseButtonReference = this.buttonCloseChild,
                    DepartemenAktif = this.DepartemenAktif,
                    UserLogin = this.UserLogin,
                    Configs = this.Configs
                };

                childForm.Show();
            }
            else
            {
                // Aktifkan pembelian form
                child.Activate();
            }
        }

        #endregion
    }
}
