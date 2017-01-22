namespace MCS_POS.Kasir
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.ribbon1 = new System.Windows.Forms.Ribbon();
            this.ribbonTab1 = new System.Windows.Forms.RibbonTab();
            this.ribbonPanelKasir = new System.Windows.Forms.RibbonPanel();
            this.ribbonPanelPenjualan = new System.Windows.Forms.RibbonPanel();
            this.ribbonButtonPenjualan = new System.Windows.Forms.RibbonButton();
            this.ribbonButtonPenjualanRefund = new System.Windows.Forms.RibbonButton();
            this.ribbonPanelPengaturan = new System.Windows.Forms.RibbonPanel();
            this.ribbonButtonPrinterSetting = new System.Windows.Forms.RibbonButton();
            this.ribbonButtonDepartemen = new System.Windows.Forms.RibbonButton();
            this.ribbonLabelInfoVersi = new System.Windows.Forms.RibbonLabel();
            this.ribbonLabelVersi = new System.Windows.Forms.RibbonLabel();
            this.ribbonLabelVersi2 = new System.Windows.Forms.RibbonLabel();
            this.SuspendLayout();
            // 
            // ribbon1
            // 
            this.ribbon1.CaptionBarVisible = false;
            this.ribbon1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ribbon1.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.Minimized = false;
            this.ribbon1.Name = "ribbon1";
            // 
            // 
            // 
            this.ribbon1.OrbDropDown.BorderRoundness = 8;
            this.ribbon1.OrbDropDown.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.OrbDropDown.Name = "";
            this.ribbon1.OrbDropDown.Size = new System.Drawing.Size(527, 447);
            this.ribbon1.OrbDropDown.TabIndex = 0;
            this.ribbon1.OrbImage = null;
            this.ribbon1.OrbStyle = System.Windows.Forms.RibbonOrbStyle.Office_2010;
            this.ribbon1.OrbText = "Program";
            this.ribbon1.OrbVisible = false;
            this.ribbon1.PanelCaptionHeight = 20;
            this.ribbon1.RibbonTabFont = new System.Drawing.Font("Segoe UI", 9F);
            this.ribbon1.Size = new System.Drawing.Size(1008, 130);
            this.ribbon1.TabIndex = 0;
            this.ribbon1.Tabs.Add(this.ribbonTab1);
            this.ribbon1.TabsMargin = new System.Windows.Forms.Padding(12, 2, 20, 0);
            this.ribbon1.Text = "ribbon1";
            this.ribbon1.ThemeColor = System.Windows.Forms.RibbonTheme.Blue;
            this.ribbon1.Visible = false;
            // 
            // ribbonTab1
            // 
            this.ribbonTab1.Panels.Add(this.ribbonPanelKasir);
            this.ribbonTab1.Panels.Add(this.ribbonPanelPenjualan);
            this.ribbonTab1.Panels.Add(this.ribbonPanelPengaturan);
            this.ribbonTab1.Text = "KASIR";
            // 
            // ribbonPanelKasir
            // 
            this.ribbonPanelKasir.ButtonMoreVisible = false;
            this.ribbonPanelKasir.Text = "PEGAWAI KASIR";
            // 
            // ribbonPanelPenjualan
            // 
            this.ribbonPanelPenjualan.ButtonMoreVisible = false;
            this.ribbonPanelPenjualan.Items.Add(this.ribbonButtonPenjualan);
            this.ribbonPanelPenjualan.Items.Add(this.ribbonButtonPenjualanRefund);
            this.ribbonPanelPenjualan.Text = "PENJUALAN";
            // 
            // ribbonButtonPenjualan
            // 
            this.ribbonButtonPenjualan.Image = global::MCS_POS.Kasir.Properties.Resources.shopcart32;
            this.ribbonButtonPenjualan.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large;
            this.ribbonButtonPenjualan.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large;
            this.ribbonButtonPenjualan.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButtonPenjualan.SmallImage")));
            this.ribbonButtonPenjualan.Text = "Data Penjualan";
            this.ribbonButtonPenjualan.Click += new System.EventHandler(this.ribbonButtonPenjualan_Click);
            // 
            // ribbonButtonPenjualanRefund
            // 
            this.ribbonButtonPenjualanRefund.Image = global::MCS_POS.Kasir.Properties.Resources.shopcartexclude32;
            this.ribbonButtonPenjualanRefund.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButtonPenjualanRefund.SmallImage")));
            this.ribbonButtonPenjualanRefund.Text = "Data Retur";
            this.ribbonButtonPenjualanRefund.Click += new System.EventHandler(this.ribbonButtonPenjualanRefund_Click);
            // 
            // ribbonPanelPengaturan
            // 
            this.ribbonPanelPengaturan.ButtonMoreVisible = false;
            this.ribbonPanelPengaturan.Items.Add(this.ribbonButtonPrinterSetting);
            this.ribbonPanelPengaturan.Items.Add(this.ribbonButtonDepartemen);
            this.ribbonPanelPengaturan.Items.Add(this.ribbonLabelInfoVersi);
            this.ribbonPanelPengaturan.Items.Add(this.ribbonLabelVersi);
            this.ribbonPanelPengaturan.Items.Add(this.ribbonLabelVersi2);
            this.ribbonPanelPengaturan.Text = "PENGATURAN";
            this.ribbonPanelPengaturan.ButtonMoreClick += new System.EventHandler(this.ribbonPanelPengaturan_ButtonMoreClick);
            // 
            // ribbonButtonPrinterSetting
            // 
            this.ribbonButtonPrinterSetting.Image = global::MCS_POS.Kasir.Properties.Resources.print32;
            this.ribbonButtonPrinterSetting.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large;
            this.ribbonButtonPrinterSetting.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large;
            this.ribbonButtonPrinterSetting.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButtonPrinterSetting.SmallImage")));
            this.ribbonButtonPrinterSetting.Text = "Printer";
            this.ribbonButtonPrinterSetting.Click += new System.EventHandler(this.ribbonButtonPrinterSetting_Click);
            // 
            // ribbonButtonDepartemen
            // 
            this.ribbonButtonDepartemen.Image = global::MCS_POS.Kasir.Properties.Resources.departemen32;
            this.ribbonButtonDepartemen.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButtonDepartemen.SmallImage")));
            this.ribbonButtonDepartemen.Text = "Cabang";
            this.ribbonButtonDepartemen.Click += new System.EventHandler(this.ribbonButtonDepartemen_Click);
            // 
            // ribbonLabelInfoVersi
            // 
            this.ribbonLabelInfoVersi.Text = "Versi :";
            // 
            // ribbonLabelVersi
            // 
            this.ribbonLabelVersi.LabelWidth = 130;
            this.ribbonLabelVersi.Text = "v0.0.0.0";
            // 
            // ribbonLabelVersi2
            // 
            this.ribbonLabelVersi2.LabelWidth = 130;
            this.ribbonLabelVersi2.Text = "v0.0.0.0";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.ribbon1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "MainForm";
            this.Text = "MCS POS Kasir";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.ResizeEnd += new System.EventHandler(this.MainForm_ResizeEnd);
            this.Move += new System.EventHandler(this.MainForm_Move);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Ribbon ribbon1;
        private System.Windows.Forms.RibbonTab ribbonTab1;
        private System.Windows.Forms.RibbonPanel ribbonPanelKasir;
        private System.Windows.Forms.RibbonPanel ribbonPanelPengaturan;
        private System.Windows.Forms.RibbonButton ribbonButtonPrinterSetting;
        private System.Windows.Forms.RibbonButton ribbonButtonDepartemen;
        private System.Windows.Forms.RibbonPanel ribbonPanelPenjualan;
        private System.Windows.Forms.RibbonButton ribbonButtonPenjualan;
        private System.Windows.Forms.RibbonButton ribbonButtonPenjualanRefund;
        private System.Windows.Forms.RibbonLabel ribbonLabelVersi;
        private System.Windows.Forms.RibbonLabel ribbonLabelVersi2;
        private System.Windows.Forms.RibbonLabel ribbonLabelInfoVersi;
    }
}