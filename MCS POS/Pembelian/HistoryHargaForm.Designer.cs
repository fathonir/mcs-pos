namespace MCS_POS.Pembelian
{
    partial class HistoryHargaForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.TanggalDTP2 = new System.Windows.Forms.DateTimePicker();
            this.TanggalDTP1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BrowseButton = new System.Windows.Forms.Button();
            this.ItemTextBox = new System.Windows.Forms.TextBox();
            this.ColumnID_Pembelian = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSupplier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNoTransaksi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTanggal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnKodeItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNamaItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSatuan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnHarga = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(597, 70);
            this.SaveButton.Visible = false;
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(597, 99);
            this.DeleteButton.Visible = false;
            // 
            // DGV
            // 
            this.DGV.AllowUserToAddRows = false;
            this.DGV.AllowUserToDeleteRows = false;
            this.DGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnID_Pembelian,
            this.ColumnSupplier,
            this.ColumnNoTransaksi,
            this.ColumnTanggal,
            this.ColumnKodeItem,
            this.ColumnNamaItem,
            this.ColumnSatuan,
            this.ColumnHarga});
            this.DGV.Location = new System.Drawing.Point(12, 47);
            this.DGV.ReadOnly = true;
            this.DGV.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.DGV.Size = new System.Drawing.Size(660, 302);
            // 
            // TambahButton
            // 
            this.TambahButton.Location = new System.Drawing.Point(597, 12);
            this.TambahButton.Visible = false;
            // 
            // EditButton
            // 
            this.EditButton.Location = new System.Drawing.Point(597, 41);
            this.EditButton.Visible = false;
            // 
            // BackButton
            // 
            this.BackButton.Location = new System.Drawing.Point(597, 128);
            this.BackButton.Visible = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.TanggalDTP2, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.TanggalDTP1, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.BrowseButton, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.ItemTextBox, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(568, 29);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // TanggalDTP2
            // 
            this.TanggalDTP2.CustomFormat = "dd MMM yyyy";
            this.TanggalDTP2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.TanggalDTP2.Location = new System.Drawing.Point(445, 3);
            this.TanggalDTP2.Name = "TanggalDTP2";
            this.TanggalDTP2.Size = new System.Drawing.Size(120, 20);
            this.TanggalDTP2.TabIndex = 6;
            this.TanggalDTP2.ValueChanged += new System.EventHandler(this.TanggalDTP2_ValueChanged);
            // 
            // TanggalDTP1
            // 
            this.TanggalDTP1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.TanggalDTP1.CustomFormat = "dd MMM yyyy";
            this.TanggalDTP1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.TanggalDTP1.Location = new System.Drawing.Point(319, 4);
            this.TanggalDTP1.Name = "TanggalDTP1";
            this.TanggalDTP1.Size = new System.Drawing.Size(120, 20);
            this.TanggalDTP1.TabIndex = 6;
            this.TanggalDTP1.ValueChanged += new System.EventHandler(this.TanggalDTP1_ValueChanged);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(261, 8);
            this.label2.Margin = new System.Windows.Forms.Padding(20, 0, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Tanggal :";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Item :";
            // 
            // BrowseButton
            // 
            this.BrowseButton.Location = new System.Drawing.Point(198, 3);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new System.Drawing.Size(40, 23);
            this.BrowseButton.TabIndex = 1;
            this.BrowseButton.Text = "Cari";
            this.BrowseButton.UseVisualStyleBackColor = true;
            this.BrowseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // ItemTextBox
            // 
            this.ItemTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ItemTextBox.Location = new System.Drawing.Point(42, 4);
            this.ItemTextBox.Name = "ItemTextBox";
            this.ItemTextBox.ReadOnly = true;
            this.ItemTextBox.Size = new System.Drawing.Size(150, 20);
            this.ItemTextBox.TabIndex = 2;
            // 
            // ColumnID_Pembelian
            // 
            this.ColumnID_Pembelian.DataPropertyName = "id_pembelian";
            this.ColumnID_Pembelian.HeaderText = "ID_Pembelian";
            this.ColumnID_Pembelian.Name = "ColumnID_Pembelian";
            this.ColumnID_Pembelian.ReadOnly = true;
            this.ColumnID_Pembelian.Visible = false;
            // 
            // ColumnSupplier
            // 
            this.ColumnSupplier.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnSupplier.DataPropertyName = "nama_supplier";
            this.ColumnSupplier.HeaderText = "Supplier";
            this.ColumnSupplier.Name = "ColumnSupplier";
            this.ColumnSupplier.ReadOnly = true;
            this.ColumnSupplier.Width = 70;
            // 
            // ColumnNoTransaksi
            // 
            this.ColumnNoTransaksi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnNoTransaksi.DataPropertyName = "kode_transaksi";
            this.ColumnNoTransaksi.HeaderText = "No Transaksi";
            this.ColumnNoTransaksi.Name = "ColumnNoTransaksi";
            this.ColumnNoTransaksi.ReadOnly = true;
            this.ColumnNoTransaksi.Width = 94;
            // 
            // ColumnTanggal
            // 
            this.ColumnTanggal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnTanggal.DataPropertyName = "waktu_transaksi";
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.ColumnTanggal.DefaultCellStyle = dataGridViewCellStyle1;
            this.ColumnTanggal.HeaderText = "Tanggal";
            this.ColumnTanggal.Name = "ColumnTanggal";
            this.ColumnTanggal.ReadOnly = true;
            this.ColumnTanggal.Width = 68;
            // 
            // ColumnKodeItem
            // 
            this.ColumnKodeItem.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnKodeItem.DataPropertyName = "kode_item";
            this.ColumnKodeItem.HeaderText = "Kode Item";
            this.ColumnKodeItem.Name = "ColumnKodeItem";
            this.ColumnKodeItem.ReadOnly = true;
            this.ColumnKodeItem.Width = 78;
            // 
            // ColumnNamaItem
            // 
            this.ColumnNamaItem.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnNamaItem.DataPropertyName = "nama_item";
            this.ColumnNamaItem.HeaderText = "Nama Item";
            this.ColumnNamaItem.Name = "ColumnNamaItem";
            this.ColumnNamaItem.ReadOnly = true;
            // 
            // ColumnSatuan
            // 
            this.ColumnSatuan.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnSatuan.DataPropertyName = "nama_satuan";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColumnSatuan.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColumnSatuan.HeaderText = "Satuan";
            this.ColumnSatuan.Name = "ColumnSatuan";
            this.ColumnSatuan.ReadOnly = true;
            this.ColumnSatuan.Width = 65;
            // 
            // ColumnHarga
            // 
            this.ColumnHarga.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnHarga.DataPropertyName = "harga_beli";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = null;
            this.ColumnHarga.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColumnHarga.HeaderText = "Harga";
            this.ColumnHarga.Name = "ColumnHarga";
            this.ColumnHarga.ReadOnly = true;
            this.ColumnHarga.Width = 60;
            // 
            // HistoryHargaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(684, 361);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "HistoryHargaForm";
            this.Text = "History Harga Beli";
            this.Load += new System.EventHandler(this.HistoryHargaForm_Load);
            this.Controls.SetChildIndex(this.DGV, 0);
            this.Controls.SetChildIndex(this.SaveButton, 0);
            this.Controls.SetChildIndex(this.EditButton, 0);
            this.Controls.SetChildIndex(this.TambahButton, 0);
            this.Controls.SetChildIndex(this.BackButton, 0);
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            this.Controls.SetChildIndex(this.DeleteButton, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BrowseButton;
        private System.Windows.Forms.TextBox ItemTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker TanggalDTP1;
        private System.Windows.Forms.DateTimePicker TanggalDTP2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnID_Pembelian;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSupplier;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNoTransaksi;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTanggal;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnKodeItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNamaItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSatuan;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnHarga;
    }
}
