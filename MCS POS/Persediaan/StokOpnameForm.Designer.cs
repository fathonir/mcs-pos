namespace MCS_POS.Persediaan
{
    partial class StokOpnameForm
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
            this.DGV = new System.Windows.Forms.DataGridView();
            this.ColumnID_Stok_Opname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnID_Item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnKodeItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNamaItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSatuan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAwal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMasuk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnKeluar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBuku = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOpnameMasuk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOpnameKeluar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFisik = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSelisih = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.KeywordTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TanggalOpname = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.DeleteItemButton = new System.Windows.Forms.Button();
            this.BackButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
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
            this.DGV.ColumnHeadersHeight = 25;
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnID_Stok_Opname,
            this.ColumnID_Item,
            this.ColumnKodeItem,
            this.ColumnNamaItem,
            this.ColumnSatuan,
            this.ColumnAwal,
            this.ColumnMasuk,
            this.ColumnKeluar,
            this.ColumnBuku,
            this.ColumnOpnameMasuk,
            this.ColumnOpnameKeluar,
            this.ColumnFisik,
            this.ColumnSelisih});
            this.DGV.EnableHeadersVisualStyles = false;
            this.DGV.Location = new System.Drawing.Point(12, 70);
            this.DGV.MultiSelect = false;
            this.DGV.Name = "DGV";
            this.DGV.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.DGV.RowHeadersWidth = 20;
            this.DGV.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.DGV.Size = new System.Drawing.Size(760, 350);
            this.DGV.TabIndex = 2;
            this.DGV.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.DGV_CellBeginEdit);
            this.DGV.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_CellEndEdit);
            this.DGV.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.DGV_CellValidating);
            this.DGV.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.DGV_DataError);
            // 
            // ColumnID_Stok_Opname
            // 
            this.ColumnID_Stok_Opname.DataPropertyName = "id_stok_opname";
            this.ColumnID_Stok_Opname.HeaderText = "ID_Stok_Opname";
            this.ColumnID_Stok_Opname.Name = "ColumnID_Stok_Opname";
            this.ColumnID_Stok_Opname.Visible = false;
            // 
            // ColumnID_Item
            // 
            this.ColumnID_Item.DataPropertyName = "id_item";
            this.ColumnID_Item.HeaderText = "ID_Item";
            this.ColumnID_Item.Name = "ColumnID_Item";
            this.ColumnID_Item.Visible = false;
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
            this.ColumnNamaItem.HeaderText = "Nama Item";
            this.ColumnNamaItem.Name = "ColumnNamaItem";
            this.ColumnNamaItem.ReadOnly = true;
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
            // ColumnAwal
            // 
            this.ColumnAwal.DataPropertyName = "awal";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N0";
            dataGridViewCellStyle1.NullValue = null;
            this.ColumnAwal.DefaultCellStyle = dataGridViewCellStyle1;
            this.ColumnAwal.HeaderText = "Awal";
            this.ColumnAwal.Name = "ColumnAwal";
            this.ColumnAwal.ReadOnly = true;
            this.ColumnAwal.Width = 65;
            // 
            // ColumnMasuk
            // 
            this.ColumnMasuk.DataPropertyName = "masuk";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N0";
            this.ColumnMasuk.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColumnMasuk.HeaderText = "Masuk";
            this.ColumnMasuk.Name = "ColumnMasuk";
            this.ColumnMasuk.ReadOnly = true;
            this.ColumnMasuk.Width = 65;
            // 
            // ColumnKeluar
            // 
            this.ColumnKeluar.DataPropertyName = "keluar";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N0";
            this.ColumnKeluar.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColumnKeluar.HeaderText = "Keluar";
            this.ColumnKeluar.Name = "ColumnKeluar";
            this.ColumnKeluar.ReadOnly = true;
            this.ColumnKeluar.Width = 65;
            // 
            // ColumnBuku
            // 
            this.ColumnBuku.DataPropertyName = "buku";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N0";
            this.ColumnBuku.DefaultCellStyle = dataGridViewCellStyle4;
            this.ColumnBuku.HeaderText = "Buku";
            this.ColumnBuku.Name = "ColumnBuku";
            this.ColumnBuku.ReadOnly = true;
            this.ColumnBuku.Width = 65;
            // 
            // ColumnOpnameMasuk
            // 
            this.ColumnOpnameMasuk.DataPropertyName = "opname_masuk";
            this.ColumnOpnameMasuk.HeaderText = "Opname Masuk";
            this.ColumnOpnameMasuk.Name = "ColumnOpnameMasuk";
            this.ColumnOpnameMasuk.Visible = false;
            // 
            // ColumnOpnameKeluar
            // 
            this.ColumnOpnameKeluar.DataPropertyName = "opname_keluar";
            this.ColumnOpnameKeluar.HeaderText = "Opname Keluar";
            this.ColumnOpnameKeluar.Name = "ColumnOpnameKeluar";
            this.ColumnOpnameKeluar.Visible = false;
            // 
            // ColumnFisik
            // 
            this.ColumnFisik.DataPropertyName = "fisik";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            dataGridViewCellStyle5.Format = "N0";
            dataGridViewCellStyle5.NullValue = "NULL";
            this.ColumnFisik.DefaultCellStyle = dataGridViewCellStyle5;
            this.ColumnFisik.HeaderText = "Fisik";
            this.ColumnFisik.Name = "ColumnFisik";
            this.ColumnFisik.Width = 65;
            // 
            // ColumnSelisih
            // 
            this.ColumnSelisih.DataPropertyName = "selisih";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N0";
            this.ColumnSelisih.DefaultCellStyle = dataGridViewCellStyle6;
            this.ColumnSelisih.HeaderText = "Selisih";
            this.ColumnSelisih.Name = "ColumnSelisih";
            this.ColumnSelisih.ReadOnly = true;
            this.ColumnSelisih.Width = 65;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 571F));
            this.tableLayoutPanel1.Controls.Add(this.KeywordTextBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.TanggalOpname, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(760, 52);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // KeywordTextBox
            // 
            this.KeywordTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel1.SetColumnSpan(this.KeywordTextBox, 3);
            this.KeywordTextBox.Location = new System.Drawing.Point(106, 29);
            this.KeywordTextBox.Name = "KeywordTextBox";
            this.KeywordTextBox.Size = new System.Drawing.Size(200, 20);
            this.KeywordTextBox.TabIndex = 12;
            this.KeywordTextBox.TextChanged += new System.EventHandler(this.KeywordTextBox_TextChanged);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(69, 32);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Cari :";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tanggal Opname :";
            // 
            // TanggalOpname
            // 
            this.TanggalOpname.CustomFormat = "";
            this.TanggalOpname.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.TanggalOpname.Location = new System.Drawing.Point(106, 3);
            this.TanggalOpname.Name = "TanggalOpname";
            this.TanggalOpname.Size = new System.Drawing.Size(80, 20);
            this.TanggalOpname.TabIndex = 1;
            this.TanggalOpname.ValueChanged += new System.EventHandler(this.TanggalOpname_ValueChanged);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label3, 2);
            this.label3.ForeColor = System.Drawing.Color.Green;
            this.label3.Location = new System.Drawing.Point(192, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(152, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Stok dihitung sampai tanggal : ";
            // 
            // DeleteItemButton
            // 
            this.DeleteItemButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DeleteItemButton.ForeColor = System.Drawing.Color.Red;
            this.DeleteItemButton.Location = new System.Drawing.Point(12, 426);
            this.DeleteItemButton.Name = "DeleteItemButton";
            this.DeleteItemButton.Size = new System.Drawing.Size(80, 23);
            this.DeleteItemButton.TabIndex = 11;
            this.DeleteItemButton.Text = "Hapus Item";
            this.DeleteItemButton.UseVisualStyleBackColor = true;
            // 
            // BackButton
            // 
            this.BackButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BackButton.Location = new System.Drawing.Point(697, 426);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(75, 23);
            this.BackButton.TabIndex = 10;
            this.BackButton.Text = "Batal";
            this.BackButton.UseVisualStyleBackColor = true;
            // 
            // SaveButton
            // 
            this.SaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveButton.Location = new System.Drawing.Point(616, 426);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 9;
            this.SaveButton.Text = "Simpan";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // StokOpnameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.DeleteItemButton);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.DGV);
            this.Name = "StokOpnameForm";
            this.Text = "Stok Opname";
            this.Load += new System.EventHandler(this.StokOpnameForm_Load);
            this.Shown += new System.EventHandler(this.StokOpnameForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DGV;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker TanggalOpname;
        private System.Windows.Forms.Button DeleteItemButton;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox KeywordTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnID_Stok_Opname;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnID_Item;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnKodeItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNamaItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSatuan;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAwal;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMasuk;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnKeluar;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnBuku;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOpnameMasuk;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOpnameKeluar;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFisik;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSelisih;

    }
}
