namespace MCS_POS.Konsinyasi
{
    partial class KonsinyasiForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.BelumLunasRadioButton = new System.Windows.Forms.RadioButton();
            this.LunasRadioButton = new System.Windows.Forms.RadioButton();
            this.SemuaRadioButton = new System.Windows.Forms.RadioButton();
            this.SupplierComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DGV2 = new System.Windows.Forms.FrDataGridView();
            this.ColumnID_Konsinyasi_Detail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnKodeItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnJumlah = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSatuan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnRetur = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnKeluar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBayar2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSisa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BayarButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.ColumnID_Konsinyasi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnKodeTransaksi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTanggal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSupplier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPotonganRetur = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBayar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV2)).BeginInit();
            this.SuspendLayout();
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(561, 252);
            this.SaveButton.Visible = false;
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(561, 281);
            this.DeleteButton.Visible = false;
            // 
            // DGV
            // 
            this.DGV.AllowUserToAddRows = false;
            this.DGV.AllowUserToDeleteRows = false;
            this.DGV.AllowUserToResizeRows = false;
            this.DGV.ColumnHeadersHeight = 30;
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnID_Konsinyasi,
            this.ColumnKodeTransaksi,
            this.ColumnTanggal,
            this.ColumnSupplier,
            this.ColumnTotal,
            this.ColumnPotonganRetur,
            this.ColumnBayar});
            this.DGV.Location = new System.Drawing.Point(12, 45);
            this.DGV.ReadOnly = true;
            this.DGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV.Size = new System.Drawing.Size(760, 81);
            this.DGV.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_RowEnter);
            // 
            // TambahButton
            // 
            this.TambahButton.Location = new System.Drawing.Point(561, 194);
            this.TambahButton.Visible = false;
            // 
            // EditButton
            // 
            this.EditButton.Location = new System.Drawing.Point(561, 223);
            this.EditButton.Visible = false;
            // 
            // BackButton
            // 
            this.BackButton.Location = new System.Drawing.Point(561, 310);
            this.BackButton.Visible = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.SupplierComboBox, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(616, 29);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.BelumLunasRadioButton);
            this.flowLayoutPanel1.Controls.Add(this.LunasRadioButton);
            this.flowLayoutPanel1.Controls.Add(this.SemuaRadioButton);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(77, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(216, 23);
            this.flowLayoutPanel1.TabIndex = 12;
            // 
            // BelumLunasRadioButton
            // 
            this.BelumLunasRadioButton.AutoSize = true;
            this.BelumLunasRadioButton.Checked = true;
            this.BelumLunasRadioButton.Location = new System.Drawing.Point(3, 3);
            this.BelumLunasRadioButton.Name = "BelumLunasRadioButton";
            this.BelumLunasRadioButton.Size = new System.Drawing.Size(86, 17);
            this.BelumLunasRadioButton.TabIndex = 0;
            this.BelumLunasRadioButton.TabStop = true;
            this.BelumLunasRadioButton.Text = "Belum Lunas";
            this.BelumLunasRadioButton.UseVisualStyleBackColor = true;
            this.BelumLunasRadioButton.Click += new System.EventHandler(this.BelumLunasRadioButton_Click);
            // 
            // LunasRadioButton
            // 
            this.LunasRadioButton.AutoSize = true;
            this.LunasRadioButton.Location = new System.Drawing.Point(95, 3);
            this.LunasRadioButton.Name = "LunasRadioButton";
            this.LunasRadioButton.Size = new System.Drawing.Size(54, 17);
            this.LunasRadioButton.TabIndex = 1;
            this.LunasRadioButton.TabStop = true;
            this.LunasRadioButton.Text = "Lunas";
            this.LunasRadioButton.UseVisualStyleBackColor = true;
            this.LunasRadioButton.Click += new System.EventHandler(this.LunasRadioButton_Click);
            // 
            // SemuaRadioButton
            // 
            this.SemuaRadioButton.AutoSize = true;
            this.SemuaRadioButton.Location = new System.Drawing.Point(155, 3);
            this.SemuaRadioButton.Name = "SemuaRadioButton";
            this.SemuaRadioButton.Size = new System.Drawing.Size(58, 17);
            this.SemuaRadioButton.TabIndex = 2;
            this.SemuaRadioButton.TabStop = true;
            this.SemuaRadioButton.Text = "Semua";
            this.SemuaRadioButton.UseVisualStyleBackColor = true;
            this.SemuaRadioButton.Click += new System.EventHandler(this.SemuaRadioButton_Click);
            // 
            // SupplierComboBox
            // 
            this.SupplierComboBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.SupplierComboBox.FormattingEnabled = true;
            this.SupplierComboBox.Location = new System.Drawing.Point(363, 4);
            this.SupplierComboBox.Name = "SupplierComboBox";
            this.SupplierComboBox.Size = new System.Drawing.Size(250, 21);
            this.SupplierComboBox.TabIndex = 10;
            this.SupplierComboBox.SelectedIndexChanged += new System.EventHandler(this.SupplierComboBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(306, 8);
            this.label2.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Supplier :";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Filter Status :";
            // 
            // DGV2
            // 
            this.DGV2.AllowUserToAddRows = false;
            this.DGV2.AllowUserToDeleteRows = false;
            this.DGV2.AllowUserToResizeRows = false;
            this.DGV2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGV2.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 8F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.DGV2.ColumnHeadersHeight = 30;
            this.DGV2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGV2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnID_Konsinyasi_Detail,
            this.ColumnKodeItem,
            this.ColumnItem,
            this.ColumnJumlah,
            this.ColumnSatuan,
            this.ColumnRetur,
            this.ColumnKeluar,
            this.ColumnBayar2,
            this.ColumnSisa});
            this.DGV2.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.DGV2.EnableHeadersVisualStyles = false;
            this.DGV2.Location = new System.Drawing.Point(12, 161);
            this.DGV2.MultiSelect = false;
            this.DGV2.Name = "DGV2";
            this.DGV2.ReadOnly = true;
            this.DGV2.RowHeadersWidth = 25;
            this.DGV2.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.DGV2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV2.Size = new System.Drawing.Size(760, 188);
            this.DGV2.TabIndex = 8;
            // 
            // ColumnID_Konsinyasi_Detail
            // 
            this.ColumnID_Konsinyasi_Detail.DataPropertyName = "id_konsinyasi_detail";
            this.ColumnID_Konsinyasi_Detail.HeaderText = "ID_Konsinyasi_Detail";
            this.ColumnID_Konsinyasi_Detail.Name = "ColumnID_Konsinyasi_Detail";
            this.ColumnID_Konsinyasi_Detail.ReadOnly = true;
            this.ColumnID_Konsinyasi_Detail.Visible = false;
            // 
            // ColumnKodeItem
            // 
            this.ColumnKodeItem.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnKodeItem.DataPropertyName = "kode_item";
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnKodeItem.DefaultCellStyle = dataGridViewCellStyle5;
            this.ColumnKodeItem.HeaderText = "Kode Item";
            this.ColumnKodeItem.Name = "ColumnKodeItem";
            this.ColumnKodeItem.ReadOnly = true;
            this.ColumnKodeItem.Width = 78;
            // 
            // ColumnItem
            // 
            this.ColumnItem.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnItem.DataPropertyName = "nama_item";
            this.ColumnItem.HeaderText = "Item";
            this.ColumnItem.Name = "ColumnItem";
            this.ColumnItem.ReadOnly = true;
            // 
            // ColumnJumlah
            // 
            this.ColumnJumlah.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnJumlah.DataPropertyName = "jumlah";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColumnJumlah.DefaultCellStyle = dataGridViewCellStyle6;
            this.ColumnJumlah.HeaderText = "Jumlah";
            this.ColumnJumlah.Name = "ColumnJumlah";
            this.ColumnJumlah.ReadOnly = true;
            this.ColumnJumlah.Width = 64;
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
            // ColumnRetur
            // 
            this.ColumnRetur.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnRetur.DataPropertyName = "jumlah_retur";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColumnRetur.DefaultCellStyle = dataGridViewCellStyle7;
            this.ColumnRetur.HeaderText = "Retur";
            this.ColumnRetur.Name = "ColumnRetur";
            this.ColumnRetur.ReadOnly = true;
            this.ColumnRetur.Width = 57;
            // 
            // ColumnKeluar
            // 
            this.ColumnKeluar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnKeluar.DataPropertyName = "jumlah_keluar";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColumnKeluar.DefaultCellStyle = dataGridViewCellStyle8;
            this.ColumnKeluar.HeaderText = "Keluar";
            this.ColumnKeluar.Name = "ColumnKeluar";
            this.ColumnKeluar.ReadOnly = true;
            this.ColumnKeluar.Width = 62;
            // 
            // ColumnBayar2
            // 
            this.ColumnBayar2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnBayar2.DataPropertyName = "jumlah_bayar";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColumnBayar2.DefaultCellStyle = dataGridViewCellStyle9;
            this.ColumnBayar2.HeaderText = "Bayar";
            this.ColumnBayar2.Name = "ColumnBayar2";
            this.ColumnBayar2.ReadOnly = true;
            this.ColumnBayar2.Width = 60;
            // 
            // ColumnSisa
            // 
            this.ColumnSisa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnSisa.DataPropertyName = "jumlah_sisa";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColumnSisa.DefaultCellStyle = dataGridViewCellStyle10;
            this.ColumnSisa.HeaderText = "Sisa";
            this.ColumnSisa.Name = "ColumnSisa";
            this.ColumnSisa.ReadOnly = true;
            this.ColumnSisa.Width = 52;
            // 
            // BayarButton
            // 
            this.BayarButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BayarButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BayarButton.Location = new System.Drawing.Point(12, 132);
            this.BayarButton.Name = "BayarButton";
            this.BayarButton.Size = new System.Drawing.Size(75, 23);
            this.BayarButton.TabIndex = 9;
            this.BayarButton.Text = "Bayar";
            this.BayarButton.UseVisualStyleBackColor = true;
            this.BayarButton.Click += new System.EventHandler(this.BayarButton_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(672, 132);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 10;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Location = new System.Drawing.Point(566, 132);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 11;
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ColumnID_Konsinyasi
            // 
            this.ColumnID_Konsinyasi.DataPropertyName = "id_konsinyasi";
            this.ColumnID_Konsinyasi.HeaderText = "ID_Konsinyasi";
            this.ColumnID_Konsinyasi.Name = "ColumnID_Konsinyasi";
            this.ColumnID_Konsinyasi.ReadOnly = true;
            this.ColumnID_Konsinyasi.Visible = false;
            // 
            // ColumnKodeTransaksi
            // 
            this.ColumnKodeTransaksi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ColumnKodeTransaksi.DataPropertyName = "kode_transaksi";
            this.ColumnKodeTransaksi.HeaderText = "Kode Transaksi";
            this.ColumnKodeTransaksi.Name = "ColumnKodeTransaksi";
            this.ColumnKodeTransaksi.ReadOnly = true;
            this.ColumnKodeTransaksi.Width = 106;
            // 
            // ColumnTanggal
            // 
            this.ColumnTanggal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ColumnTanggal.DataPropertyName = "waktu_transaksi";
            this.ColumnTanggal.HeaderText = "Tanggal";
            this.ColumnTanggal.Name = "ColumnTanggal";
            this.ColumnTanggal.ReadOnly = true;
            this.ColumnTanggal.Width = 68;
            // 
            // ColumnSupplier
            // 
            this.ColumnSupplier.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnSupplier.DataPropertyName = "nama_supplier";
            this.ColumnSupplier.HeaderText = "Supplier";
            this.ColumnSupplier.Name = "ColumnSupplier";
            this.ColumnSupplier.ReadOnly = true;
            // 
            // ColumnTotal
            // 
            this.ColumnTotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ColumnTotal.DataPropertyName = "total_biaya_akhir";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N0";
            this.ColumnTotal.DefaultCellStyle = dataGridViewCellStyle1;
            this.ColumnTotal.HeaderText = "Total";
            this.ColumnTotal.Name = "ColumnTotal";
            this.ColumnTotal.ReadOnly = true;
            this.ColumnTotal.Width = 53;
            // 
            // ColumnPotonganRetur
            // 
            this.ColumnPotonganRetur.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ColumnPotonganRetur.DataPropertyName = "total_biaya_retur";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N0";
            this.ColumnPotonganRetur.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColumnPotonganRetur.HeaderText = "Potongan Retur";
            this.ColumnPotonganRetur.Name = "ColumnPotonganRetur";
            this.ColumnPotonganRetur.ReadOnly = true;
            this.ColumnPotonganRetur.Width = 105;
            // 
            // ColumnBayar
            // 
            this.ColumnBayar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ColumnBayar.DataPropertyName = "total_pembayaran";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N0";
            this.ColumnBayar.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColumnBayar.HeaderText = "Bayar";
            this.ColumnBayar.Name = "ColumnBayar";
            this.ColumnBayar.ReadOnly = true;
            this.ColumnBayar.Width = 60;
            // 
            // KonsinyasiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(784, 361);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.BayarButton);
            this.Controls.Add(this.DGV2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "KonsinyasiForm";
            this.Text = "Daftar Konsinyasi";
            this.Load += new System.EventHandler(this.KonsinyasiForm_Load);
            this.Shown += new System.EventHandler(this.KonsinyasiForm_Shown);
            this.Controls.SetChildIndex(this.DGV, 0);
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            this.Controls.SetChildIndex(this.DGV2, 0);
            this.Controls.SetChildIndex(this.BayarButton, 0);
            this.Controls.SetChildIndex(this.DeleteButton, 0);
            this.Controls.SetChildIndex(this.SaveButton, 0);
            this.Controls.SetChildIndex(this.EditButton, 0);
            this.Controls.SetChildIndex(this.TambahButton, 0);
            this.Controls.SetChildIndex(this.BackButton, 0);
            this.Controls.SetChildIndex(this.textBox1, 0);
            this.Controls.SetChildIndex(this.textBox2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FrDataGridView DGV2;
        private System.Windows.Forms.Button BayarButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox SupplierComboBox;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.RadioButton BelumLunasRadioButton;
        private System.Windows.Forms.RadioButton LunasRadioButton;
        private System.Windows.Forms.RadioButton SemuaRadioButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnID_Konsinyasi;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnKodeTransaksi;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTanggal;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSupplier;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPotonganRetur;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnBayar;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnID_Konsinyasi_Detail;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnKodeItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnJumlah;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSatuan;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnRetur;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnKeluar;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnBayar2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSisa;
    }
}
