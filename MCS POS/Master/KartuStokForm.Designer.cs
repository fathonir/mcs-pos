namespace MCS_POS.Master
{
    partial class KartuStokForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.BulanComboBox = new System.Windows.Forms.ComboBox();
            this.DepartemenComboBox = new System.Windows.Forms.ComboBox();
            this.ProsesButton = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.KodeItemTextBox = new System.Windows.Forms.TextBox();
            this.BrowseButton = new System.Windows.Forms.Button();
            this.ItemLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DGV = new System.Windows.Forms.DataGridView();
            this.ColumnKodeTransaksi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTanggal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTipe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnKeterangan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMasuk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnKeluar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSaldo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPelangganSupplier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.SaldoAkhirTextBox = new System.Windows.Forms.TextBox();
            this.SaldoAwalTextBox = new System.Windows.Forms.TextBox();
            this.TotalKeluarTextBox = new System.Windows.Forms.TextBox();
            this.TotalMasukTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TahunComboBox = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(471, 58);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel2.Controls.Add(this.BulanComboBox);
            this.flowLayoutPanel2.Controls.Add(this.TahunComboBox);
            this.flowLayoutPanel2.Controls.Add(this.DepartemenComboBox);
            this.flowLayoutPanel2.Controls.Add(this.ProsesButton);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(55, 29);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(396, 29);
            this.flowLayoutPanel2.TabIndex = 6;
            // 
            // BulanComboBox
            // 
            this.BulanComboBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.BulanComboBox.FormattingEnabled = true;
            this.BulanComboBox.Items.AddRange(new object[] {
            "Januari",
            "Februari",
            "Maret",
            "April",
            "Mei",
            "Juni",
            "Juli",
            "Agustus",
            "September",
            "Oktober",
            "November",
            "Desember"});
            this.BulanComboBox.Location = new System.Drawing.Point(3, 4);
            this.BulanComboBox.Name = "BulanComboBox";
            this.BulanComboBox.Size = new System.Drawing.Size(100, 21);
            this.BulanComboBox.TabIndex = 0;
            // 
            // DepartemenComboBox
            // 
            this.DepartemenComboBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.DepartemenComboBox.FormattingEnabled = true;
            this.DepartemenComboBox.Location = new System.Drawing.Point(165, 4);
            this.DepartemenComboBox.Name = "DepartemenComboBox";
            this.DepartemenComboBox.Size = new System.Drawing.Size(170, 21);
            this.DepartemenComboBox.TabIndex = 4;
            // 
            // ProsesButton
            // 
            this.ProsesButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ProsesButton.Location = new System.Drawing.Point(341, 3);
            this.ProsesButton.Name = "ProsesButton";
            this.ProsesButton.Size = new System.Drawing.Size(52, 23);
            this.ProsesButton.TabIndex = 3;
            this.ProsesButton.Text = "Proses";
            this.ProsesButton.UseVisualStyleBackColor = true;
            this.ProsesButton.Click += new System.EventHandler(this.ProsesButton_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.KodeItemTextBox);
            this.flowLayoutPanel1.Controls.Add(this.BrowseButton);
            this.flowLayoutPanel1.Controls.Add(this.ItemLabel);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(55, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(169, 29);
            this.flowLayoutPanel1.TabIndex = 6;
            // 
            // KodeItemTextBox
            // 
            this.KodeItemTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.KodeItemTextBox.Location = new System.Drawing.Point(3, 4);
            this.KodeItemTextBox.Name = "KodeItemTextBox";
            this.KodeItemTextBox.Size = new System.Drawing.Size(60, 20);
            this.KodeItemTextBox.TabIndex = 0;
            // 
            // BrowseButton
            // 
            this.BrowseButton.Location = new System.Drawing.Point(69, 3);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new System.Drawing.Size(52, 23);
            this.BrowseButton.TabIndex = 1;
            this.BrowseButton.Text = "Browse";
            this.BrowseButton.UseVisualStyleBackColor = true;
            this.BrowseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // ItemLabel
            // 
            this.ItemLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ItemLabel.AutoSize = true;
            this.ItemLabel.Location = new System.Drawing.Point(127, 8);
            this.ItemLabel.Name = "ItemLabel";
            this.ItemLabel.Size = new System.Drawing.Size(39, 13);
            this.ItemLabel.TabIndex = 1;
            this.ItemLabel.Text = "[ITEM]";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Periode :";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Item :";
            // 
            // DGV
            // 
            this.DGV.AllowUserToAddRows = false;
            this.DGV.AllowUserToDeleteRows = false;
            this.DGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGV.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.DGV.ColumnHeadersHeight = 25;
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnKodeTransaksi,
            this.ColumnTanggal,
            this.ColumnTipe,
            this.ColumnKeterangan,
            this.ColumnMasuk,
            this.ColumnKeluar,
            this.ColumnSaldo,
            this.ColumnPelangganSupplier});
            this.DGV.EnableHeadersVisualStyles = false;
            this.DGV.Location = new System.Drawing.Point(12, 74);
            this.DGV.Name = "DGV";
            this.DGV.ReadOnly = true;
            this.DGV.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.DGV.RowHeadersWidth = 25;
            this.DGV.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.DGV.Size = new System.Drawing.Size(760, 328);
            this.DGV.TabIndex = 1;
            // 
            // ColumnKodeTransaksi
            // 
            this.ColumnKodeTransaksi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnKodeTransaksi.HeaderText = "Kode Transaksi";
            this.ColumnKodeTransaksi.Name = "ColumnKodeTransaksi";
            this.ColumnKodeTransaksi.ReadOnly = true;
            this.ColumnKodeTransaksi.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnKodeTransaksi.Width = 86;
            // 
            // ColumnTanggal
            // 
            this.ColumnTanggal.HeaderText = "Waktu Transaksi";
            this.ColumnTanggal.Name = "ColumnTanggal";
            this.ColumnTanggal.ReadOnly = true;
            this.ColumnTanggal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnTanggal.Width = 120;
            // 
            // ColumnTipe
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColumnTipe.DefaultCellStyle = dataGridViewCellStyle1;
            this.ColumnTipe.HeaderText = "Tipe";
            this.ColumnTipe.Name = "ColumnTipe";
            this.ColumnTipe.ReadOnly = true;
            this.ColumnTipe.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnTipe.Width = 40;
            // 
            // ColumnKeterangan
            // 
            this.ColumnKeterangan.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnKeterangan.HeaderText = "Keterangan";
            this.ColumnKeterangan.Name = "ColumnKeterangan";
            this.ColumnKeterangan.ReadOnly = true;
            this.ColumnKeterangan.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColumnMasuk
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColumnMasuk.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColumnMasuk.HeaderText = "Masuk";
            this.ColumnMasuk.Name = "ColumnMasuk";
            this.ColumnMasuk.ReadOnly = true;
            this.ColumnMasuk.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnMasuk.Width = 60;
            // 
            // ColumnKeluar
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColumnKeluar.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColumnKeluar.HeaderText = "Keluar";
            this.ColumnKeluar.Name = "ColumnKeluar";
            this.ColumnKeluar.ReadOnly = true;
            this.ColumnKeluar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnKeluar.Width = 60;
            // 
            // ColumnSaldo
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColumnSaldo.DefaultCellStyle = dataGridViewCellStyle4;
            this.ColumnSaldo.HeaderText = "Saldo";
            this.ColumnSaldo.Name = "ColumnSaldo";
            this.ColumnSaldo.ReadOnly = true;
            this.ColumnSaldo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnSaldo.Width = 60;
            // 
            // ColumnPelangganSupplier
            // 
            this.ColumnPelangganSupplier.HeaderText = "Pelanggan/Supplier";
            this.ColumnPelangganSupplier.Name = "ColumnPelangganSupplier";
            this.ColumnPelangganSupplier.ReadOnly = true;
            this.ColumnPelangganSupplier.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnPelangganSupplier.Width = 140;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.Controls.Add(this.SaldoAkhirTextBox, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.SaldoAwalTextBox, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.TotalKeluarTextBox, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.TotalMasukTextBox, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label7, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.label6, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.label5, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(12, 408);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(351, 52);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // SaldoAkhirTextBox
            // 
            this.SaldoAkhirTextBox.Location = new System.Drawing.Point(254, 29);
            this.SaldoAkhirTextBox.Name = "SaldoAkhirTextBox";
            this.SaldoAkhirTextBox.ReadOnly = true;
            this.SaldoAkhirTextBox.Size = new System.Drawing.Size(60, 20);
            this.SaldoAkhirTextBox.TabIndex = 4;
            this.SaldoAkhirTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // SaldoAwalTextBox
            // 
            this.SaldoAwalTextBox.Location = new System.Drawing.Point(254, 3);
            this.SaldoAwalTextBox.Name = "SaldoAwalTextBox";
            this.SaldoAwalTextBox.ReadOnly = true;
            this.SaldoAwalTextBox.Size = new System.Drawing.Size(60, 20);
            this.SaldoAwalTextBox.TabIndex = 4;
            this.SaldoAwalTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // TotalKeluarTextBox
            // 
            this.TotalKeluarTextBox.Location = new System.Drawing.Point(81, 29);
            this.TotalKeluarTextBox.Name = "TotalKeluarTextBox";
            this.TotalKeluarTextBox.ReadOnly = true;
            this.TotalKeluarTextBox.Size = new System.Drawing.Size(60, 20);
            this.TotalKeluarTextBox.TabIndex = 4;
            this.TotalKeluarTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // TotalMasukTextBox
            // 
            this.TotalMasukTextBox.Location = new System.Drawing.Point(81, 3);
            this.TotalMasukTextBox.Name = "TotalMasukTextBox";
            this.TotalMasukTextBox.ReadOnly = true;
            this.TotalMasukTextBox.Size = new System.Drawing.Size(60, 20);
            this.TotalMasukTextBox.TabIndex = 3;
            this.TotalMasukTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(181, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Saldo Akhir :";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(182, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Saldo Awal :";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Total Keluar :";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Total Masuk :";
            // 
            // TahunComboBox
            // 
            this.TahunComboBox.FormattingEnabled = true;
            this.TahunComboBox.Location = new System.Drawing.Point(109, 3);
            this.TahunComboBox.MaxDropDownItems = 5;
            this.TahunComboBox.Name = "TahunComboBox";
            this.TahunComboBox.Size = new System.Drawing.Size(50, 21);
            this.TahunComboBox.TabIndex = 5;
            this.TahunComboBox.Text = "2016";
            // 
            // KartuStokForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(784, 472);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.DGV);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "KartuStokForm";
            this.Text = "Kartu Stok";
            this.Load += new System.EventHandler(this.KartuStokForm_Load);
            this.Shown += new System.EventHandler(this.KartuStokForm_Shown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox KodeItemTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BrowseButton;
        private System.Windows.Forms.ComboBox BulanComboBox;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label ItemLabel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.DataGridView DGV;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox SaldoAkhirTextBox;
        private System.Windows.Forms.TextBox SaldoAwalTextBox;
        private System.Windows.Forms.TextBox TotalKeluarTextBox;
        private System.Windows.Forms.TextBox TotalMasukTextBox;
        private System.Windows.Forms.Button ProsesButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnKodeTransaksi;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTanggal;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTipe;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnKeterangan;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMasuk;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnKeluar;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSaldo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPelangganSupplier;
        private System.Windows.Forms.ComboBox DepartemenComboBox;
        private System.Windows.Forms.ComboBox TahunComboBox;
    }
}
