namespace MCS_POS.Master
{
    partial class ItemForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.TotalLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.KeywordTextBox = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.HelpStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.ColumnID_Item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnKode_Item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNamaItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSatuan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStok = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnRak = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnJenisItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMerekItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnHargaPokok = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnHargaJual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStokMin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSupplier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnKeterangan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RefreshButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(647, 133);
            this.SaveButton.TabIndex = 5;
            this.SaveButton.Visible = false;
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(647, 104);
            this.DeleteButton.TabIndex = 4;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // DGV
            // 
            this.DGV.AllowUserToAddRows = false;
            this.DGV.AllowUserToDeleteRows = false;
            this.DGV.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.DGV.ColumnHeadersHeight = 30;
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnID_Item,
            this.ColumnKode_Item,
            this.ColumnNamaItem,
            this.ColumnSatuan,
            this.ColumnStok,
            this.ColumnRak,
            this.ColumnJenisItem,
            this.ColumnMerekItem,
            this.ColumnHargaPokok,
            this.ColumnHargaJual,
            this.ColumnStokMin,
            this.ColumnSupplier,
            this.ColumnKeterangan});
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Arial", 8F);
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV.DefaultCellStyle = dataGridViewCellStyle10;
            this.DGV.EnableHeadersVisualStyles = false;
            this.DGV.Location = new System.Drawing.Point(12, 46);
            this.DGV.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.DGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV.Size = new System.Drawing.Size(629, 313);
            this.DGV.TabIndex = 1;
            this.DGV.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_CellDoubleClick);
            this.DGV.Enter += new System.EventHandler(this.DGV_Enter);
            this.DGV.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DGV_KeyDown);
            this.DGV.Leave += new System.EventHandler(this.DGV_Leave);
            // 
            // TambahButton
            // 
            this.TambahButton.Location = new System.Drawing.Point(647, 46);
            this.TambahButton.TabIndex = 2;
            this.TambahButton.Click += new System.EventHandler(this.TambahButton_Click);
            // 
            // EditButton
            // 
            this.EditButton.ForeColor = System.Drawing.Color.Green;
            this.EditButton.Location = new System.Drawing.Point(647, 75);
            this.EditButton.TabIndex = 3;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // BackButton
            // 
            this.BackButton.Location = new System.Drawing.Point(447, 128);
            // 
            // TotalLabel
            // 
            this.TotalLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TotalLabel.AutoSize = true;
            this.TotalLabel.Location = new System.Drawing.Point(12, 362);
            this.TotalLabel.Name = "TotalLabel";
            this.TotalLabel.Size = new System.Drawing.Size(72, 13);
            this.TotalLabel.TabIndex = 6;
            this.TotalLabel.Text = "Total Data : 0";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.KeywordTextBox, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(477, 26);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kata Kunci :";
            // 
            // KeywordTextBox
            // 
            this.KeywordTextBox.Location = new System.Drawing.Point(74, 3);
            this.KeywordTextBox.Name = "KeywordTextBox";
            this.KeywordTextBox.Size = new System.Drawing.Size(400, 20);
            this.KeywordTextBox.TabIndex = 1;
            this.KeywordTextBox.TextChanged += new System.EventHandler(this.KeywordTextBox_TextChanged);
            this.KeywordTextBox.Enter += new System.EventHandler(this.KeywordTextBox_Enter);
            this.KeywordTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeywordTextBox_KeyDown);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HelpStripStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 389);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(734, 22);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // HelpStripStatusLabel
            // 
            this.HelpStripStatusLabel.Name = "HelpStripStatusLabel";
            this.HelpStripStatusLabel.Size = new System.Drawing.Size(133, 17);
            this.HelpStripStatusLabel.Text = "[F3] Kata kunci [F4] Grid";
            // 
            // ColumnID_Item
            // 
            this.ColumnID_Item.DataPropertyName = "id_item";
            this.ColumnID_Item.HeaderText = "ID_ITEM";
            this.ColumnID_Item.Name = "ColumnID_Item";
            this.ColumnID_Item.ReadOnly = true;
            this.ColumnID_Item.Visible = false;
            // 
            // ColumnKode_Item
            // 
            this.ColumnKode_Item.DataPropertyName = "kode_item";
            this.ColumnKode_Item.HeaderText = "Kode";
            this.ColumnKode_Item.MinimumWidth = 60;
            this.ColumnKode_Item.Name = "ColumnKode_Item";
            this.ColumnKode_Item.ReadOnly = true;
            this.ColumnKode_Item.Width = 60;
            // 
            // ColumnNamaItem
            // 
            this.ColumnNamaItem.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnNamaItem.DataPropertyName = "nama_item";
            this.ColumnNamaItem.HeaderText = "Nama Item";
            this.ColumnNamaItem.MinimumWidth = 150;
            this.ColumnNamaItem.Name = "ColumnNamaItem";
            this.ColumnNamaItem.ReadOnly = true;
            // 
            // ColumnSatuan
            // 
            this.ColumnSatuan.DataPropertyName = "nama_satuan";
            this.ColumnSatuan.HeaderText = "Satuan";
            this.ColumnSatuan.Name = "ColumnSatuan";
            this.ColumnSatuan.ReadOnly = true;
            this.ColumnSatuan.Width = 60;
            // 
            // ColumnStok
            // 
            this.ColumnStok.DataPropertyName = "stok";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Format = "#,##0.##";
            dataGridViewCellStyle6.NullValue = null;
            this.ColumnStok.DefaultCellStyle = dataGridViewCellStyle6;
            this.ColumnStok.HeaderText = "Stok";
            this.ColumnStok.MinimumWidth = 60;
            this.ColumnStok.Name = "ColumnStok";
            this.ColumnStok.ReadOnly = true;
            this.ColumnStok.Width = 60;
            // 
            // ColumnRak
            // 
            this.ColumnRak.DataPropertyName = "nama_rak";
            this.ColumnRak.HeaderText = "Rak";
            this.ColumnRak.Name = "ColumnRak";
            this.ColumnRak.ReadOnly = true;
            this.ColumnRak.Width = 50;
            // 
            // ColumnJenisItem
            // 
            this.ColumnJenisItem.DataPropertyName = "nama_jenis_item";
            this.ColumnJenisItem.HeaderText = "Jenis";
            this.ColumnJenisItem.Name = "ColumnJenisItem";
            this.ColumnJenisItem.ReadOnly = true;
            this.ColumnJenisItem.Width = 60;
            // 
            // ColumnMerekItem
            // 
            this.ColumnMerekItem.DataPropertyName = "nama_merek_item";
            this.ColumnMerekItem.HeaderText = "Merek";
            this.ColumnMerekItem.Name = "ColumnMerekItem";
            this.ColumnMerekItem.ReadOnly = true;
            this.ColumnMerekItem.Width = 70;
            // 
            // ColumnHargaPokok
            // 
            this.ColumnHargaPokok.DataPropertyName = "harga_pokok";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N0";
            dataGridViewCellStyle7.NullValue = null;
            this.ColumnHargaPokok.DefaultCellStyle = dataGridViewCellStyle7;
            this.ColumnHargaPokok.HeaderText = "Harga Pokok";
            this.ColumnHargaPokok.MinimumWidth = 80;
            this.ColumnHargaPokok.Name = "ColumnHargaPokok";
            this.ColumnHargaPokok.ReadOnly = true;
            this.ColumnHargaPokok.Width = 80;
            // 
            // ColumnHargaJual
            // 
            this.ColumnHargaJual.DataPropertyName = "harga_jual";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N0";
            dataGridViewCellStyle8.NullValue = null;
            this.ColumnHargaJual.DefaultCellStyle = dataGridViewCellStyle8;
            this.ColumnHargaJual.HeaderText = "Harga Jual";
            this.ColumnHargaJual.MinimumWidth = 80;
            this.ColumnHargaJual.Name = "ColumnHargaJual";
            this.ColumnHargaJual.ReadOnly = true;
            this.ColumnHargaJual.Width = 80;
            // 
            // ColumnStokMin
            // 
            this.ColumnStokMin.DataPropertyName = "stok_minimum";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "N0";
            dataGridViewCellStyle9.NullValue = null;
            this.ColumnStokMin.DefaultCellStyle = dataGridViewCellStyle9;
            this.ColumnStokMin.HeaderText = "Stok Min";
            this.ColumnStokMin.Name = "ColumnStokMin";
            this.ColumnStokMin.ReadOnly = true;
            this.ColumnStokMin.Width = 60;
            // 
            // ColumnSupplier
            // 
            this.ColumnSupplier.DataPropertyName = "nama_supplier";
            this.ColumnSupplier.HeaderText = "Supplier";
            this.ColumnSupplier.Name = "ColumnSupplier";
            this.ColumnSupplier.ReadOnly = true;
            // 
            // ColumnKeterangan
            // 
            this.ColumnKeterangan.DataPropertyName = "keterangan";
            this.ColumnKeterangan.HeaderText = "Keterangan";
            this.ColumnKeterangan.Name = "ColumnKeterangan";
            this.ColumnKeterangan.ReadOnly = true;
            // 
            // RefreshButton
            // 
            this.RefreshButton.Location = new System.Drawing.Point(492, 13);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(75, 23);
            this.RefreshButton.TabIndex = 8;
            this.RefreshButton.Text = "Refresh";
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // ItemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(734, 411);
            this.Controls.Add(this.RefreshButton);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.TotalLabel);
            this.Name = "ItemForm";
            this.Text = "Data Item";
            this.Load += new System.EventHandler(this.ItemForm_Load);
            this.Shown += new System.EventHandler(this.ItemForm_Shown);
            this.Controls.SetChildIndex(this.BackButton, 0);
            this.Controls.SetChildIndex(this.DeleteButton, 0);
            this.Controls.SetChildIndex(this.DGV, 0);
            this.Controls.SetChildIndex(this.SaveButton, 0);
            this.Controls.SetChildIndex(this.EditButton, 0);
            this.Controls.SetChildIndex(this.TambahButton, 0);
            this.Controls.SetChildIndex(this.TotalLabel, 0);
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            this.Controls.SetChildIndex(this.statusStrip1, 0);
            this.Controls.SetChildIndex(this.RefreshButton, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TotalLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox KeywordTextBox;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel HelpStripStatusLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnID_Item;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnKode_Item;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNamaItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSatuan;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStok;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnRak;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnJenisItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMerekItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnHargaPokok;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnHargaJual;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStokMin;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSupplier;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnKeterangan;
        private System.Windows.Forms.Button RefreshButton;










    }
}
