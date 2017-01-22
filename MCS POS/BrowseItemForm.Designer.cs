namespace MCS_POS
{
    partial class BrowseItemForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.KeywordTextBox = new System.Windows.Forms.TextBox();
            this.DGV = new System.Windows.Forms.DataGridView();
            this.ColumnID_Item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnKode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNamaItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStok = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnID_Satuan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSatuan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnHargaPokok = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnHargaJual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnRak = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMerek = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubmitButton = new System.Windows.Forms.Button();
            this.BackButton = new System.Windows.Forms.Button();
            this.JumlahItemLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kata Kunci [F3] :";
            // 
            // KeywordTextBox
            // 
            this.KeywordTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.KeywordTextBox.Location = new System.Drawing.Point(102, 10);
            this.KeywordTextBox.Name = "KeywordTextBox";
            this.KeywordTextBox.Size = new System.Drawing.Size(672, 20);
            this.KeywordTextBox.TabIndex = 1;
            this.KeywordTextBox.TextChanged += new System.EventHandler(this.KeywordTextBox_TextChanged);
            this.KeywordTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeywordTextBox_KeyDown);
            // 
            // DGV
            // 
            this.DGV.AllowUserToAddRows = false;
            this.DGV.AllowUserToDeleteRows = false;
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
            this.DGV.ColumnHeadersHeight = 25;
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnID_Item,
            this.ColumnKode,
            this.ColumnNamaItem,
            this.ColumnStok,
            this.ColumnID_Satuan,
            this.ColumnSatuan,
            this.ColumnHargaPokok,
            this.ColumnHargaJual,
            this.ColumnRak,
            this.ColumnMerek});
            this.DGV.EnableHeadersVisualStyles = false;
            this.DGV.Location = new System.Drawing.Point(12, 36);
            this.DGV.MultiSelect = false;
            this.DGV.Name = "DGV";
            this.DGV.ReadOnly = true;
            this.DGV.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.DGV.RowHeadersWidth = 25;
            this.DGV.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.DGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV.Size = new System.Drawing.Size(760, 290);
            this.DGV.TabIndex = 2;
            this.DGV.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_CellDoubleClick);
            this.DGV.Enter += new System.EventHandler(this.DGV_Enter);
            this.DGV.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DGV_KeyDown);
            this.DGV.Leave += new System.EventHandler(this.DGV_Leave);
            // 
            // ColumnID_Item
            // 
            this.ColumnID_Item.DataPropertyName = "id_item";
            this.ColumnID_Item.HeaderText = "ID_Item";
            this.ColumnID_Item.Name = "ColumnID_Item";
            this.ColumnID_Item.ReadOnly = true;
            this.ColumnID_Item.Visible = false;
            // 
            // ColumnKode
            // 
            this.ColumnKode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnKode.DataPropertyName = "kode_item";
            this.ColumnKode.HeaderText = "Kode";
            this.ColumnKode.Name = "ColumnKode";
            this.ColumnKode.ReadOnly = true;
            this.ColumnKode.Width = 56;
            // 
            // ColumnNamaItem
            // 
            this.ColumnNamaItem.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnNamaItem.DataPropertyName = "nama_item";
            this.ColumnNamaItem.HeaderText = "Nama";
            this.ColumnNamaItem.Name = "ColumnNamaItem";
            this.ColumnNamaItem.ReadOnly = true;
            // 
            // ColumnStok
            // 
            this.ColumnStok.DataPropertyName = "stok";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColumnStok.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColumnStok.HeaderText = "Stok";
            this.ColumnStok.Name = "ColumnStok";
            this.ColumnStok.ReadOnly = true;
            this.ColumnStok.Width = 60;
            // 
            // ColumnID_Satuan
            // 
            this.ColumnID_Satuan.DataPropertyName = "id_satuan";
            this.ColumnID_Satuan.HeaderText = "ID_Satuan";
            this.ColumnID_Satuan.Name = "ColumnID_Satuan";
            this.ColumnID_Satuan.ReadOnly = true;
            this.ColumnID_Satuan.Visible = false;
            // 
            // ColumnSatuan
            // 
            this.ColumnSatuan.DataPropertyName = "nama_satuan";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColumnSatuan.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColumnSatuan.HeaderText = "Satuan";
            this.ColumnSatuan.Name = "ColumnSatuan";
            this.ColumnSatuan.ReadOnly = true;
            this.ColumnSatuan.Width = 60;
            // 
            // ColumnHargaPokok
            // 
            this.ColumnHargaPokok.DataPropertyName = "harga_pokok";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N0";
            this.ColumnHargaPokok.DefaultCellStyle = dataGridViewCellStyle4;
            this.ColumnHargaPokok.HeaderText = "Harga Pokok";
            this.ColumnHargaPokok.Name = "ColumnHargaPokok";
            this.ColumnHargaPokok.ReadOnly = true;
            // 
            // ColumnHargaJual
            // 
            this.ColumnHargaJual.DataPropertyName = "harga_jual";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N0";
            this.ColumnHargaJual.DefaultCellStyle = dataGridViewCellStyle5;
            this.ColumnHargaJual.HeaderText = "Harga Jual";
            this.ColumnHargaJual.Name = "ColumnHargaJual";
            this.ColumnHargaJual.ReadOnly = true;
            this.ColumnHargaJual.Width = 85;
            // 
            // ColumnRak
            // 
            this.ColumnRak.DataPropertyName = "nama_rak";
            this.ColumnRak.HeaderText = "Rak";
            this.ColumnRak.Name = "ColumnRak";
            this.ColumnRak.ReadOnly = true;
            this.ColumnRak.Width = 80;
            // 
            // ColumnMerek
            // 
            this.ColumnMerek.DataPropertyName = "nama_merek_item";
            this.ColumnMerek.HeaderText = "Merek";
            this.ColumnMerek.Name = "ColumnMerek";
            this.ColumnMerek.ReadOnly = true;
            this.ColumnMerek.Width = 80;
            // 
            // SubmitButton
            // 
            this.SubmitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SubmitButton.AutoSize = true;
            this.SubmitButton.Location = new System.Drawing.Point(640, 331);
            this.SubmitButton.Name = "SubmitButton";
            this.SubmitButton.Size = new System.Drawing.Size(64, 23);
            this.SubmitButton.TabIndex = 3;
            this.SubmitButton.Text = "Pilih";
            this.SubmitButton.UseVisualStyleBackColor = true;
            this.SubmitButton.Click += new System.EventHandler(this.SubmitButton_Click);
            // 
            // BackButton
            // 
            this.BackButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BackButton.AutoSize = true;
            this.BackButton.Location = new System.Drawing.Point(709, 331);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(64, 23);
            this.BackButton.TabIndex = 4;
            this.BackButton.Text = "Batal";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // JumlahItemLabel
            // 
            this.JumlahItemLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.JumlahItemLabel.AutoSize = true;
            this.JumlahItemLabel.Location = new System.Drawing.Point(9, 331);
            this.JumlahItemLabel.Name = "JumlahItemLabel";
            this.JumlahItemLabel.Size = new System.Drawing.Size(78, 13);
            this.JumlahItemLabel.TabIndex = 5;
            this.JumlahItemLabel.Text = "Jumlah Item : 0";
            // 
            // BrowseItemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 361);
            this.Controls.Add(this.JumlahItemLabel);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.SubmitButton);
            this.Controls.Add(this.DGV);
            this.Controls.Add(this.KeywordTextBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "BrowseItemForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Browse Item";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BrowseItemForm_FormClosing);
            this.Load += new System.EventHandler(this.BrowseItemForm_Load);
            this.Shown += new System.EventHandler(this.BrowseItemForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox KeywordTextBox;
        private System.Windows.Forms.DataGridView DGV;
        private System.Windows.Forms.Button SubmitButton;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Label JumlahItemLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnID_Item;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnKode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNamaItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStok;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnID_Satuan;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSatuan;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnHargaPokok;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnHargaJual;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnRak;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMerek;
    }
}