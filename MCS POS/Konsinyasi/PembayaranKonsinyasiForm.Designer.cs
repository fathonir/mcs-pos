namespace MCS_POS.Konsinyasi
{
    partial class PembayaranKonsinyasiForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.KodeTransaksiTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TanggalDTP = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.KodeKonsinyasiTextBox = new System.Windows.Forms.TextBox();
            this.UserTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.TunaiRadioButton = new System.Windows.Forms.RadioButton();
            this.NonTunaiRadioButton = new System.Windows.Forms.RadioButton();
            this.BankComboBox = new System.Windows.Forms.ComboBox();
            this.DGV = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.TotalBiayaAkhirTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.BackButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.ColumnID_Detail_Konsinyasi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnKodeItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNamaItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnJumlah = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnKeluarBayar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnJumlahRetur = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnJumlahKeluar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSatuan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnHarga = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.KodeTransaksiTextBox, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.TanggalDTP, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.KodeKonsinyasiTextBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.UserTextBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 3, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(665, 84);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // KodeTransaksiTextBox
            // 
            this.KodeTransaksiTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.KodeTransaksiTextBox.Location = new System.Drawing.Point(139, 61);
            this.KodeTransaksiTextBox.Name = "KodeTransaksiTextBox";
            this.KodeTransaksiTextBox.ReadOnly = true;
            this.KodeTransaksiTextBox.Size = new System.Drawing.Size(150, 20);
            this.KodeTransaksiTextBox.TabIndex = 15;
            this.KodeTransaksiTextBox.TabStop = false;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(130, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Kode Trans Pembayaran :";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(295, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Jenis Pembayaran :";
            // 
            // TanggalDTP
            // 
            this.TanggalDTP.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.TanggalDTP.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.TanggalDTP.Location = new System.Drawing.Point(400, 3);
            this.TanggalDTP.Name = "TanggalDTP";
            this.TanggalDTP.Size = new System.Drawing.Size(150, 20);
            this.TanggalDTP.TabIndex = 7;
            this.TanggalDTP.TabStop = false;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(342, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tanggal :";
            // 
            // KodeKonsinyasiTextBox
            // 
            this.KodeKonsinyasiTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.KodeKonsinyasiTextBox.Location = new System.Drawing.Point(139, 33);
            this.KodeKonsinyasiTextBox.Name = "KodeKonsinyasiTextBox";
            this.KodeKonsinyasiTextBox.ReadOnly = true;
            this.KodeKonsinyasiTextBox.Size = new System.Drawing.Size(150, 20);
            this.KodeKonsinyasiTextBox.TabIndex = 6;
            this.KodeKonsinyasiTextBox.TabStop = false;
            // 
            // UserTextBox
            // 
            this.UserTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.UserTextBox.Location = new System.Drawing.Point(139, 4);
            this.UserTextBox.Name = "UserTextBox";
            this.UserTextBox.ReadOnly = true;
            this.UserTextBox.Size = new System.Drawing.Size(150, 20);
            this.UserTextBox.TabIndex = 5;
            this.UserTextBox.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(74, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "User Aktif :";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Kode Trans Konsinyasi :";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.TunaiRadioButton);
            this.flowLayoutPanel1.Controls.Add(this.NonTunaiRadioButton);
            this.flowLayoutPanel1.Controls.Add(this.BankComboBox);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(398, 30);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(1);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(266, 27);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // TunaiRadioButton
            // 
            this.TunaiRadioButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.TunaiRadioButton.AutoSize = true;
            this.TunaiRadioButton.Location = new System.Drawing.Point(3, 5);
            this.TunaiRadioButton.Name = "TunaiRadioButton";
            this.TunaiRadioButton.Size = new System.Drawing.Size(52, 17);
            this.TunaiRadioButton.TabIndex = 0;
            this.TunaiRadioButton.TabStop = true;
            this.TunaiRadioButton.Text = "Tunai";
            this.TunaiRadioButton.UseVisualStyleBackColor = true;
            this.TunaiRadioButton.Click += new System.EventHandler(this.TunaiRadioButton_Click);
            // 
            // NonTunaiRadioButton
            // 
            this.NonTunaiRadioButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.NonTunaiRadioButton.AutoSize = true;
            this.NonTunaiRadioButton.Location = new System.Drawing.Point(61, 5);
            this.NonTunaiRadioButton.Name = "NonTunaiRadioButton";
            this.NonTunaiRadioButton.Size = new System.Drawing.Size(75, 17);
            this.NonTunaiRadioButton.TabIndex = 1;
            this.NonTunaiRadioButton.TabStop = true;
            this.NonTunaiRadioButton.Text = "Non-Tunai";
            this.NonTunaiRadioButton.UseVisualStyleBackColor = true;
            this.NonTunaiRadioButton.Click += new System.EventHandler(this.NonTunaiRadioButton_Click);
            // 
            // BankComboBox
            // 
            this.BankComboBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.BankComboBox.FormattingEnabled = true;
            this.BankComboBox.Location = new System.Drawing.Point(142, 3);
            this.BankComboBox.Name = "BankComboBox";
            this.BankComboBox.Size = new System.Drawing.Size(121, 21);
            this.BankComboBox.TabIndex = 2;
            // 
            // DGV
            // 
            this.DGV.AllowUserToAddRows = false;
            this.DGV.AllowUserToDeleteRows = false;
            this.DGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGV.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.DGV.ColumnHeadersHeight = 30;
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnID_Detail_Konsinyasi,
            this.ColumnKodeItem,
            this.ColumnNamaItem,
            this.ColumnJumlah,
            this.ColumnKeluarBayar,
            this.ColumnJumlahRetur,
            this.ColumnJumlahKeluar,
            this.ColumnSatuan,
            this.ColumnHarga,
            this.ColumnTotal});
            this.DGV.EnableHeadersVisualStyles = false;
            this.DGV.Location = new System.Drawing.Point(12, 102);
            this.DGV.Name = "DGV";
            this.DGV.ReadOnly = true;
            this.DGV.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.DGV.RowHeadersWidth = 20;
            this.DGV.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.DGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV.Size = new System.Drawing.Size(845, 255);
            this.DGV.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.TotalBiayaAkhirTextBox, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label8, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(651, 363);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(206, 26);
            this.tableLayoutPanel2.TabIndex = 10;
            // 
            // TotalBiayaAkhirTextBox
            // 
            this.TotalBiayaAkhirTextBox.Location = new System.Drawing.Point(103, 3);
            this.TotalBiayaAkhirTextBox.Name = "TotalBiayaAkhirTextBox";
            this.TotalBiayaAkhirTextBox.ReadOnly = true;
            this.TotalBiayaAkhirTextBox.Size = new System.Drawing.Size(100, 20);
            this.TotalBiayaAkhirTextBox.TabIndex = 7;
            this.TotalBiayaAkhirTextBox.Text = "0";
            this.TotalBiayaAkhirTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 6);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Total Biaya Akhir :";
            // 
            // BackButton
            // 
            this.BackButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BackButton.Location = new System.Drawing.Point(782, 395);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(75, 23);
            this.BackButton.TabIndex = 13;
            this.BackButton.Text = "Batal";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveButton.Location = new System.Drawing.Point(701, 395);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 12;
            this.SaveButton.Text = "Simpan";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // ColumnID_Detail_Konsinyasi
            // 
            this.ColumnID_Detail_Konsinyasi.DataPropertyName = "id_konsinyasi_detail";
            this.ColumnID_Detail_Konsinyasi.HeaderText = "ID_Detail_Konsinyasi";
            this.ColumnID_Detail_Konsinyasi.Name = "ColumnID_Detail_Konsinyasi";
            this.ColumnID_Detail_Konsinyasi.ReadOnly = true;
            this.ColumnID_Detail_Konsinyasi.Visible = false;
            // 
            // ColumnKodeItem
            // 
            this.ColumnKodeItem.DataPropertyName = "kode_item";
            this.ColumnKodeItem.HeaderText = "Kode Item";
            this.ColumnKodeItem.Name = "ColumnKodeItem";
            this.ColumnKodeItem.ReadOnly = true;
            // 
            // ColumnNamaItem
            // 
            this.ColumnNamaItem.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnNamaItem.DataPropertyName = "nama_item";
            this.ColumnNamaItem.HeaderText = "Item";
            this.ColumnNamaItem.Name = "ColumnNamaItem";
            this.ColumnNamaItem.ReadOnly = true;
            // 
            // ColumnJumlah
            // 
            this.ColumnJumlah.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnJumlah.DataPropertyName = "jumlah";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColumnJumlah.DefaultCellStyle = dataGridViewCellStyle1;
            this.ColumnJumlah.HeaderText = "Jumlah";
            this.ColumnJumlah.Name = "ColumnJumlah";
            this.ColumnJumlah.ReadOnly = true;
            this.ColumnJumlah.Width = 64;
            // 
            // ColumnKeluarBayar
            // 
            this.ColumnKeluarBayar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnKeluarBayar.DataPropertyName = "jumlah_bayar";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColumnKeluarBayar.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColumnKeluarBayar.HeaderText = "Jumlah Bayar";
            this.ColumnKeluarBayar.MinimumWidth = 100;
            this.ColumnKeluarBayar.Name = "ColumnKeluarBayar";
            this.ColumnKeluarBayar.ReadOnly = true;
            // 
            // ColumnJumlahRetur
            // 
            this.ColumnJumlahRetur.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnJumlahRetur.DataPropertyName = "jumlah_retur";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColumnJumlahRetur.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColumnJumlahRetur.HeaderText = "Retur";
            this.ColumnJumlahRetur.Name = "ColumnJumlahRetur";
            this.ColumnJumlahRetur.ReadOnly = true;
            this.ColumnJumlahRetur.Width = 57;
            // 
            // ColumnJumlahKeluar
            // 
            this.ColumnJumlahKeluar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnJumlahKeluar.DataPropertyName = "jumlah_belum_bayar";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColumnJumlahKeluar.DefaultCellStyle = dataGridViewCellStyle4;
            this.ColumnJumlahKeluar.HeaderText = "Belum Bayar";
            this.ColumnJumlahKeluar.MinimumWidth = 90;
            this.ColumnJumlahKeluar.Name = "ColumnJumlahKeluar";
            this.ColumnJumlahKeluar.ReadOnly = true;
            this.ColumnJumlahKeluar.Width = 90;
            // 
            // ColumnSatuan
            // 
            this.ColumnSatuan.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnSatuan.DataPropertyName = "nama_satuan";
            this.ColumnSatuan.HeaderText = "Satuan";
            this.ColumnSatuan.Name = "ColumnSatuan";
            this.ColumnSatuan.ReadOnly = true;
            this.ColumnSatuan.Width = 65;
            // 
            // ColumnHarga
            // 
            this.ColumnHarga.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnHarga.DataPropertyName = "harga_beli";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N0";
            this.ColumnHarga.DefaultCellStyle = dataGridViewCellStyle5;
            this.ColumnHarga.HeaderText = "Harga";
            this.ColumnHarga.Name = "ColumnHarga";
            this.ColumnHarga.ReadOnly = true;
            this.ColumnHarga.Width = 60;
            // 
            // ColumnTotal
            // 
            this.ColumnTotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnTotal.DataPropertyName = "sub_total";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N0";
            this.ColumnTotal.DefaultCellStyle = dataGridViewCellStyle6;
            this.ColumnTotal.HeaderText = "Total";
            this.ColumnTotal.Name = "ColumnTotal";
            this.ColumnTotal.ReadOnly = true;
            this.ColumnTotal.Width = 55;
            // 
            // PembayaranKonsinyasiForm
            // 
            this.ClientSize = new System.Drawing.Size(869, 430);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.DGV);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "PembayaranKonsinyasiForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Pembayaran Konsinyasi";
            this.Load += new System.EventHandler(this.PembayaranKonsinyasiForm_Load);
            this.Shown += new System.EventHandler(this.PembayaranKonsinyasiForm_Shown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox UserTextBox;
        private System.Windows.Forms.TextBox KodeKonsinyasiTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker TanggalDTP;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.RadioButton TunaiRadioButton;
        private System.Windows.Forms.RadioButton NonTunaiRadioButton;
        private System.Windows.Forms.ComboBox BankComboBox;
        private System.Windows.Forms.DataGridView DGV;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox TotalBiayaAkhirTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.TextBox KodeTransaksiTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnID_Detail_Konsinyasi;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnKodeItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNamaItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnJumlah;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnKeluarBayar;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnJumlahRetur;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnJumlahKeluar;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSatuan;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnHarga;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTotal;
    }
}
