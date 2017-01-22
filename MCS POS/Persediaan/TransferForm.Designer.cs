namespace MCS_POS.Persediaan
{
    partial class TransferForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ColumnID_Transfer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnKodeTransfer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTanggal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDeptAsal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDeptTujuan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnJumlah = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.TanggalDTP2 = new System.Windows.Forms.DateTimePicker();
            this.tanggalLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DayFilterComboBox = new System.Windows.Forms.ComboBox();
            this.TanggalDTP1 = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(647, 190);
            this.SaveButton.Visible = false;
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(647, 103);
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // DGV
            // 
            this.DGV.AllowUserToAddRows = false;
            this.DGV.AllowUserToDeleteRows = false;
            this.DGV.ColumnHeadersHeight = 30;
            this.DGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnID_Transfer,
            this.ColumnKodeTransfer,
            this.ColumnTanggal,
            this.ColumnDeptAsal,
            this.ColumnDeptTujuan,
            this.ColumnJumlah});
            this.DGV.Location = new System.Drawing.Point(12, 45);
            this.DGV.ReadOnly = true;
            this.DGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV.Size = new System.Drawing.Size(629, 354);
            // 
            // TambahButton
            // 
            this.TambahButton.Location = new System.Drawing.Point(647, 45);
            this.TambahButton.Click += new System.EventHandler(this.TambahButton_Click);
            // 
            // EditButton
            // 
            this.EditButton.Location = new System.Drawing.Point(647, 74);
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // BackButton
            // 
            this.BackButton.Location = new System.Drawing.Point(647, 161);
            this.BackButton.Visible = false;
            // 
            // ColumnID_Transfer
            // 
            this.ColumnID_Transfer.DataPropertyName = "id_transfer";
            this.ColumnID_Transfer.HeaderText = "ID_Transfer";
            this.ColumnID_Transfer.Name = "ColumnID_Transfer";
            this.ColumnID_Transfer.ReadOnly = true;
            this.ColumnID_Transfer.Visible = false;
            // 
            // ColumnKodeTransfer
            // 
            this.ColumnKodeTransfer.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnKodeTransfer.DataPropertyName = "kode_transaksi";
            this.ColumnKodeTransfer.HeaderText = "Kode Transfer";
            this.ColumnKodeTransfer.Name = "ColumnKodeTransfer";
            this.ColumnKodeTransfer.ReadOnly = true;
            this.ColumnKodeTransfer.Width = 101;
            // 
            // ColumnTanggal
            // 
            this.ColumnTanggal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnTanggal.DataPropertyName = "waktu_transaksi";
            this.ColumnTanggal.HeaderText = "Tanggal";
            this.ColumnTanggal.Name = "ColumnTanggal";
            this.ColumnTanggal.ReadOnly = true;
            this.ColumnTanggal.Width = 68;
            // 
            // ColumnDeptAsal
            // 
            this.ColumnDeptAsal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnDeptAsal.DataPropertyName = "departemen_asal";
            this.ColumnDeptAsal.HeaderText = "Asal";
            this.ColumnDeptAsal.Name = "ColumnDeptAsal";
            this.ColumnDeptAsal.ReadOnly = true;
            // 
            // ColumnDeptTujuan
            // 
            this.ColumnDeptTujuan.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnDeptTujuan.DataPropertyName = "departemen_tujuan";
            this.ColumnDeptTujuan.HeaderText = "Tujuan";
            this.ColumnDeptTujuan.Name = "ColumnDeptTujuan";
            this.ColumnDeptTujuan.ReadOnly = true;
            // 
            // ColumnJumlah
            // 
            this.ColumnJumlah.DataPropertyName = "jumlah_item";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N0";
            this.ColumnJumlah.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColumnJumlah.HeaderText = "Jumlah";
            this.ColumnJumlah.Name = "ColumnJumlah";
            this.ColumnJumlah.ReadOnly = true;
            this.ColumnJumlah.Width = 80;
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
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.TanggalDTP2, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.tanggalLabel, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.DayFilterComboBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.TanggalDTP1, 3, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(566, 27);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // TanggalDTP2
            // 
            this.TanggalDTP2.CustomFormat = "dd MMM yyyy";
            this.TanggalDTP2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.TanggalDTP2.Location = new System.Drawing.Point(423, 3);
            this.TanggalDTP2.Name = "TanggalDTP2";
            this.TanggalDTP2.Size = new System.Drawing.Size(120, 20);
            this.TanggalDTP2.TabIndex = 4;
            this.TanggalDTP2.Visible = false;
            this.TanggalDTP2.ValueChanged += new System.EventHandler(this.TanggalDTP2_ValueChanged);
            // 
            // tanggalLabel
            // 
            this.tanggalLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.tanggalLabel.AutoSize = true;
            this.tanggalLabel.Location = new System.Drawing.Point(239, 7);
            this.tanggalLabel.Margin = new System.Windows.Forms.Padding(20, 0, 3, 0);
            this.tanggalLabel.Name = "tanggalLabel";
            this.tanggalLabel.Size = new System.Drawing.Size(52, 13);
            this.tanggalLabel.TabIndex = 2;
            this.tanggalLabel.Text = "Tanggal :";
            this.tanggalLabel.Visible = false;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Filter Hari :";
            // 
            // DayFilterComboBox
            // 
            this.DayFilterComboBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.DayFilterComboBox.FormattingEnabled = true;
            this.DayFilterComboBox.Items.AddRange(new object[] {
            "Hari Ini",
            "Kemarin",
            "3 Hari",
            "1 Minggu",
            "2 Minggu",
            "1 Bulan",
            "2 Bulan",
            "Custom"});
            this.DayFilterComboBox.Location = new System.Drawing.Point(66, 3);
            this.DayFilterComboBox.Name = "DayFilterComboBox";
            this.DayFilterComboBox.Size = new System.Drawing.Size(150, 21);
            this.DayFilterComboBox.TabIndex = 1;
            this.DayFilterComboBox.SelectedIndexChanged += new System.EventHandler(this.DayFilterComboBox_SelectedIndexChanged);
            // 
            // TanggalDTP1
            // 
            this.TanggalDTP1.CustomFormat = "dd MMM yyyy";
            this.TanggalDTP1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.TanggalDTP1.Location = new System.Drawing.Point(297, 3);
            this.TanggalDTP1.Name = "TanggalDTP1";
            this.TanggalDTP1.Size = new System.Drawing.Size(120, 20);
            this.TanggalDTP1.TabIndex = 3;
            this.TanggalDTP1.Visible = false;
            this.TanggalDTP1.ValueChanged += new System.EventHandler(this.TanggalDTP1_ValueChanged);
            // 
            // TransferForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(734, 411);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "TransferForm";
            this.Text = "Data Transfer Item";
            this.Load += new System.EventHandler(this.TransferItemForm_Load);
            this.Shown += new System.EventHandler(this.TransferForm_Shown);
            this.Controls.SetChildIndex(this.DeleteButton, 0);
            this.Controls.SetChildIndex(this.DGV, 0);
            this.Controls.SetChildIndex(this.SaveButton, 0);
            this.Controls.SetChildIndex(this.EditButton, 0);
            this.Controls.SetChildIndex(this.TambahButton, 0);
            this.Controls.SetChildIndex(this.BackButton, 0);
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnID_Transfer;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnKodeTransfer;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTanggal;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDeptAsal;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDeptTujuan;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnJumlah;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DateTimePicker TanggalDTP2;
        private System.Windows.Forms.Label tanggalLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox DayFilterComboBox;
        private System.Windows.Forms.DateTimePicker TanggalDTP1;








    }
}
