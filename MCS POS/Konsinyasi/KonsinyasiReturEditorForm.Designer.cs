namespace MCS_POS.Konsinyasi
{
    partial class KonsinyasiReturEditorForm
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
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.BrowseItemButton = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.KodeItemTextBox = new System.Windows.Forms.TextBox();
            this.NamaItemLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.KodeTransaksiTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.UserTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TanggalDTP = new System.Windows.Forms.DateTimePicker();
            this.SupplierComboBox = new System.Windows.Forms.ComboBox();
            this.DGV = new System.Windows.Forms.DataGridView();
            this.JumlahItemLabel = new System.Windows.Forms.Label();
            this.DeleteItemButton = new System.Windows.Forms.Button();
            this.BackButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.ColumnID_Konsinyasi_Retur_Detail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnID_Konsinyasi_Retur = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnID_Item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnKodeItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnJumlah = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnID_Satuan = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.Controls.Add(this.BrowseItemButton, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.label9, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.KodeItemTextBox, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.NamaItemLabel, 3, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(12, 68);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Size = new System.Drawing.Size(565, 27);
            this.tableLayoutPanel3.TabIndex = 5;
            // 
            // BrowseItemButton
            // 
            this.BrowseItemButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.BrowseItemButton.AutoSize = true;
            this.BrowseItemButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BrowseItemButton.Location = new System.Drawing.Point(155, 2);
            this.BrowseItemButton.Margin = new System.Windows.Forms.Padding(2);
            this.BrowseItemButton.Name = "BrowseItemButton";
            this.BrowseItemButton.Size = new System.Drawing.Size(52, 23);
            this.BrowseItemButton.TabIndex = 2;
            this.BrowseItemButton.Text = "Browse";
            this.BrowseItemButton.UseVisualStyleBackColor = true;
            this.BrowseItemButton.Click += new System.EventHandler(this.BrowseItemButton_Click);
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 7);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Kode Item :";
            // 
            // KodeItemTextBox
            // 
            this.KodeItemTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.KodeItemTextBox.Location = new System.Drawing.Point(70, 3);
            this.KodeItemTextBox.Name = "KodeItemTextBox";
            this.KodeItemTextBox.Size = new System.Drawing.Size(80, 20);
            this.KodeItemTextBox.TabIndex = 1;
            // 
            // NamaItemLabel
            // 
            this.NamaItemLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.NamaItemLabel.Location = new System.Drawing.Point(212, 3);
            this.NamaItemLabel.Name = "NamaItemLabel";
            this.NamaItemLabel.Size = new System.Drawing.Size(350, 20);
            this.NamaItemLabel.TabIndex = 3;
            this.NamaItemLabel.Text = "[ITEM]";
            this.NamaItemLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.KodeTransaksiTextBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.UserTextBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.TanggalDTP, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.SupplierComboBox, 3, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(492, 53);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // KodeTransaksiTextBox
            // 
            this.KodeTransaksiTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.KodeTransaksiTextBox.Location = new System.Drawing.Point(103, 29);
            this.KodeTransaksiTextBox.Name = "KodeTransaksiTextBox";
            this.KodeTransaksiTextBox.ReadOnly = true;
            this.KodeTransaksiTextBox.Size = new System.Drawing.Size(150, 20);
            this.KodeTransaksiTextBox.TabIndex = 5;
            this.KodeTransaksiTextBox.TabStop = false;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Kode Transaksi :";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "User Aktif :";
            // 
            // UserTextBox
            // 
            this.UserTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.UserTextBox.Location = new System.Drawing.Point(103, 3);
            this.UserTextBox.Name = "UserTextBox";
            this.UserTextBox.ReadOnly = true;
            this.UserTextBox.Size = new System.Drawing.Size(150, 20);
            this.UserTextBox.TabIndex = 4;
            this.UserTextBox.TabStop = false;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(281, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Tanggal :";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(282, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Supplier :";
            // 
            // TanggalDTP
            // 
            this.TanggalDTP.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.TanggalDTP.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.TanggalDTP.Location = new System.Drawing.Point(339, 3);
            this.TanggalDTP.Name = "TanggalDTP";
            this.TanggalDTP.Size = new System.Drawing.Size(150, 20);
            this.TanggalDTP.TabIndex = 6;
            this.TanggalDTP.TabStop = false;
            // 
            // SupplierComboBox
            // 
            this.SupplierComboBox.FormattingEnabled = true;
            this.SupplierComboBox.Location = new System.Drawing.Point(339, 29);
            this.SupplierComboBox.Name = "SupplierComboBox";
            this.SupplierComboBox.Size = new System.Drawing.Size(150, 21);
            this.SupplierComboBox.TabIndex = 7;
            this.SupplierComboBox.TabStop = false;
            // 
            // DGV
            // 
            this.DGV.AllowUserToAddRows = false;
            this.DGV.AllowUserToDeleteRows = false;
            this.DGV.AllowUserToResizeRows = false;
            this.DGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGV.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DGV.ColumnHeadersHeight = 30;
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnID_Konsinyasi_Retur_Detail,
            this.ColumnID_Konsinyasi_Retur,
            this.ColumnID_Item,
            this.ColumnKodeItem,
            this.ColumnItem,
            this.ColumnJumlah,
            this.ColumnID_Satuan});
            this.DGV.EnableHeadersVisualStyles = false;
            this.DGV.Location = new System.Drawing.Point(12, 101);
            this.DGV.MultiSelect = false;
            this.DGV.Name = "DGV";
            this.DGV.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.DGV.RowHeadersWidth = 20;
            this.DGV.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.DGV.Size = new System.Drawing.Size(717, 326);
            this.DGV.TabIndex = 6;
            this.DGV.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.DGV_CellBeginEdit);
            this.DGV.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_CellEndEdit);
            this.DGV.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.DGV_CellValidating);
            // 
            // JumlahItemLabel
            // 
            this.JumlahItemLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.JumlahItemLabel.Location = new System.Drawing.Point(98, 437);
            this.JumlahItemLabel.Name = "JumlahItemLabel";
            this.JumlahItemLabel.Size = new System.Drawing.Size(120, 13);
            this.JumlahItemLabel.TabIndex = 10;
            this.JumlahItemLabel.Text = "Jumlah Item : 0";
            // 
            // DeleteItemButton
            // 
            this.DeleteItemButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DeleteItemButton.ForeColor = System.Drawing.Color.Red;
            this.DeleteItemButton.Location = new System.Drawing.Point(12, 433);
            this.DeleteItemButton.Name = "DeleteItemButton";
            this.DeleteItemButton.Size = new System.Drawing.Size(80, 21);
            this.DeleteItemButton.TabIndex = 9;
            this.DeleteItemButton.Text = "Hapus Item";
            this.DeleteItemButton.UseVisualStyleBackColor = true;
            this.DeleteItemButton.Click += new System.EventHandler(this.DeleteItemButton_Click);
            // 
            // BackButton
            // 
            this.BackButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BackButton.Location = new System.Drawing.Point(654, 433);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(75, 23);
            this.BackButton.TabIndex = 14;
            this.BackButton.Text = "Batal";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveButton.Location = new System.Drawing.Point(573, 433);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 13;
            this.SaveButton.Text = "Simpan";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // ColumnID_Konsinyasi_Retur_Detail
            // 
            this.ColumnID_Konsinyasi_Retur_Detail.DataPropertyName = "id_konsinyasi_retur_detail";
            this.ColumnID_Konsinyasi_Retur_Detail.HeaderText = "ID_Konsinyasi_Retur_Detail";
            this.ColumnID_Konsinyasi_Retur_Detail.Name = "ColumnID_Konsinyasi_Retur_Detail";
            this.ColumnID_Konsinyasi_Retur_Detail.Visible = false;
            // 
            // ColumnID_Konsinyasi_Retur
            // 
            this.ColumnID_Konsinyasi_Retur.DataPropertyName = "id_konsinyasi_retur";
            this.ColumnID_Konsinyasi_Retur.HeaderText = "ID_Konsinyasi_Retur";
            this.ColumnID_Konsinyasi_Retur.Name = "ColumnID_Konsinyasi_Retur";
            this.ColumnID_Konsinyasi_Retur.Visible = false;
            // 
            // ColumnID_Item
            // 
            this.ColumnID_Item.DataPropertyName = "id_item";
            this.ColumnID_Item.HeaderText = "ID_Item";
            this.ColumnID_Item.Name = "ColumnID_Item";
            this.ColumnID_Item.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnID_Item.Visible = false;
            // 
            // ColumnKodeItem
            // 
            this.ColumnKodeItem.DataPropertyName = "kode_item";
            this.ColumnKodeItem.HeaderText = "Kode Item";
            this.ColumnKodeItem.Name = "ColumnKodeItem";
            this.ColumnKodeItem.ReadOnly = true;
            this.ColumnKodeItem.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColumnItem
            // 
            this.ColumnItem.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnItem.DataPropertyName = "nama_item";
            this.ColumnItem.HeaderText = "Item";
            this.ColumnItem.Name = "ColumnItem";
            this.ColumnItem.ReadOnly = true;
            this.ColumnItem.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColumnJumlah
            // 
            this.ColumnJumlah.DataPropertyName = "jumlah";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Format = "N0";
            this.ColumnJumlah.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColumnJumlah.HeaderText = "Jumlah";
            this.ColumnJumlah.Name = "ColumnJumlah";
            this.ColumnJumlah.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnJumlah.Width = 50;
            // 
            // ColumnID_Satuan
            // 
            this.ColumnID_Satuan.DataPropertyName = "id_satuan";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.ColumnID_Satuan.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColumnID_Satuan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColumnID_Satuan.HeaderText = "Satuan";
            this.ColumnID_Satuan.Name = "ColumnID_Satuan";
            this.ColumnID_Satuan.Width = 80;
            // 
            // KonsinyasiReturEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(741, 468);
            this.Controls.Add(this.JumlahItemLabel);
            this.Controls.Add(this.DeleteItemButton);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.DGV);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "KonsinyasiReturEditorForm";
            this.Text = "Konsinyasi Retur";
            this.Load += new System.EventHandler(this.KonsinyasiReturEditorForm_Load);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button BrowseItemButton;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox KodeItemTextBox;
        private System.Windows.Forms.Label NamaItemLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox KodeTransaksiTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox UserTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker TanggalDTP;
        private System.Windows.Forms.ComboBox SupplierComboBox;
        private System.Windows.Forms.DataGridView DGV;
        private System.Windows.Forms.Label JumlahItemLabel;
        private System.Windows.Forms.Button DeleteItemButton;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnID_Konsinyasi_Retur_Detail;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnID_Konsinyasi_Retur;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnID_Item;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnKodeItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnJumlah;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColumnID_Satuan;
    }
}
