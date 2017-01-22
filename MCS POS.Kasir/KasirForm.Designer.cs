namespace MCS_POS.Kasir
{
    partial class KasirForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.DGV = new System.Windows.Forms.DataGridView();
            this.ColumnID_Penjualan_Detail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnID_Item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnKodeItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNamaItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnJumlah = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnID_Satuan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSatuan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnHarga = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSubTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.InfoItemLabel = new System.Windows.Forms.Label();
            this.TambahButton = new System.Windows.Forms.Button();
            this.BrowseButton = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.JumlahTextBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.TotalBiayaTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.BiayaLainTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.BiayaPotonganTextBox = new System.Windows.Forms.TextBox();
            this.TotalBiayaAkhirTextBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.NamaPegawaiTextBox = new System.Windows.Forms.TextBox();
            this.WaktuTransaksiDTP = new System.Windows.Forms.DateTimePicker();
            this.BayarButton = new System.Windows.Forms.Button();
            this.ScrollDownButton = new MCS_POS.Kasir.TouchButton();
            this.ScrollUpButton = new MCS_POS.Kasir.TouchButton();
            this.JumlahItemLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // DGV
            // 
            this.DGV.AllowUserToAddRows = false;
            this.DGV.AllowUserToDeleteRows = false;
            this.DGV.AllowUserToResizeColumns = false;
            this.DGV.AllowUserToResizeRows = false;
            this.DGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGV.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DGV.ColumnHeadersHeight = 40;
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnID_Penjualan_Detail,
            this.ColumnID_Item,
            this.ColumnKodeItem,
            this.ColumnNamaItem,
            this.ColumnJumlah,
            this.ColumnID_Satuan,
            this.ColumnSatuan,
            this.ColumnHarga,
            this.ColumnSubTotal});
            this.DGV.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.DGV.EnableHeadersVisualStyles = false;
            this.DGV.Location = new System.Drawing.Point(12, 175);
            this.DGV.MultiSelect = false;
            this.DGV.Name = "DGV";
            this.DGV.ReadOnly = true;
            this.DGV.RowHeadersWidth = 25;
            this.DGV.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.DGV.RowTemplate.Height = 35;
            this.DGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV.Size = new System.Drawing.Size(779, 371);
            this.DGV.TabIndex = 14;
            this.DGV.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_CellDoubleClick);
            this.DGV.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DGV_RowHeaderMouseClick);
            // 
            // ColumnID_Penjualan_Detail
            // 
            this.ColumnID_Penjualan_Detail.DataPropertyName = "id_penjualan_detail";
            this.ColumnID_Penjualan_Detail.HeaderText = "ID_Penjualan_Detail";
            this.ColumnID_Penjualan_Detail.Name = "ColumnID_Penjualan_Detail";
            this.ColumnID_Penjualan_Detail.ReadOnly = true;
            this.ColumnID_Penjualan_Detail.Visible = false;
            // 
            // ColumnID_Item
            // 
            this.ColumnID_Item.DataPropertyName = "id_item";
            this.ColumnID_Item.HeaderText = "ID_Item";
            this.ColumnID_Item.Name = "ColumnID_Item";
            this.ColumnID_Item.ReadOnly = true;
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
            // ColumnNamaItem
            // 
            this.ColumnNamaItem.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnNamaItem.DataPropertyName = "nama_item";
            this.ColumnNamaItem.HeaderText = "Nama Item";
            this.ColumnNamaItem.Name = "ColumnNamaItem";
            this.ColumnNamaItem.ReadOnly = true;
            this.ColumnNamaItem.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColumnJumlah
            // 
            this.ColumnJumlah.DataPropertyName = "jumlah";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColumnJumlah.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColumnJumlah.HeaderText = "Jumlah";
            this.ColumnJumlah.Name = "ColumnJumlah";
            this.ColumnJumlah.ReadOnly = true;
            this.ColumnJumlah.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnJumlah.Width = 80;
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
            this.ColumnSatuan.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnSatuan.Width = 80;
            // 
            // ColumnHarga
            // 
            this.ColumnHarga.DataPropertyName = "harga_jual";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N0";
            this.ColumnHarga.DefaultCellStyle = dataGridViewCellStyle4;
            this.ColumnHarga.HeaderText = "Harga";
            this.ColumnHarga.Name = "ColumnHarga";
            this.ColumnHarga.ReadOnly = true;
            this.ColumnHarga.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColumnSubTotal
            // 
            this.ColumnSubTotal.DataPropertyName = "sub_total";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N0";
            this.ColumnSubTotal.DefaultCellStyle = dataGridViewCellStyle5;
            this.ColumnSubTotal.HeaderText = "Sub Total";
            this.ColumnSubTotal.Name = "ColumnSubTotal";
            this.ColumnSubTotal.ReadOnly = true;
            this.ColumnSubTotal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DeleteButton
            // 
            this.DeleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DeleteButton.ForeColor = System.Drawing.Color.Red;
            this.DeleteButton.Location = new System.Drawing.Point(797, 175);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(75, 40);
            this.DeleteButton.TabIndex = 13;
            this.DeleteButton.TabStop = false;
            this.DeleteButton.Text = "HAPUS";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            this.DeleteButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button_MouseDown);
            this.DeleteButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button_MouseUp);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel3.ColumnCount = 5;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.Controls.Add(this.InfoItemLabel, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.TambahButton, 4, 0);
            this.tableLayoutPanel3.Controls.Add(this.BrowseButton, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.label9, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.JumlahTextBox, 3, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(12, 124);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(3, 17, 3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Size = new System.Drawing.Size(779, 45);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // InfoItemLabel
            // 
            this.InfoItemLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.InfoItemLabel.AutoSize = true;
            this.InfoItemLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.InfoItemLabel.Location = new System.Drawing.Point(59, 7);
            this.InfoItemLabel.Name = "InfoItemLabel";
            this.InfoItemLabel.Padding = new System.Windows.Forms.Padding(5);
            this.InfoItemLabel.Size = new System.Drawing.Size(160, 31);
            this.InfoItemLabel.TabIndex = 15;
            this.InfoItemLabel.Text = "[ITEM BELUM DIPILIH]";
            // 
            // TambahButton
            // 
            this.TambahButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.TambahButton.Location = new System.Drawing.Point(701, 3);
            this.TambahButton.Name = "TambahButton";
            this.TambahButton.Size = new System.Drawing.Size(75, 40);
            this.TambahButton.TabIndex = 11;
            this.TambahButton.Text = "Tambah";
            this.TambahButton.UseVisualStyleBackColor = true;
            this.TambahButton.Click += new System.EventHandler(this.TambahButton_Click);
            this.TambahButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button_MouseDown);
            this.TambahButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button_MouseUp);
            // 
            // BrowseButton
            // 
            this.BrowseButton.Location = new System.Drawing.Point(3, 3);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new System.Drawing.Size(50, 40);
            this.BrowseButton.TabIndex = 14;
            this.BrowseButton.Text = "Cari";
            this.BrowseButton.UseVisualStyleBackColor = true;
            this.BrowseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            this.BrowseButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button_MouseDown);
            this.BrowseButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button_MouseUp);
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(567, 13);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 19);
            this.label9.TabIndex = 18;
            this.label9.Text = "Jumlah :";
            // 
            // JumlahTextBox
            // 
            this.JumlahTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.JumlahTextBox.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.JumlahTextBox.Location = new System.Drawing.Point(632, 7);
            this.JumlahTextBox.Name = "JumlahTextBox";
            this.JumlahTextBox.Size = new System.Drawing.Size(63, 32);
            this.JumlahTextBox.TabIndex = 19;
            this.JumlahTextBox.Text = "1";
            this.JumlahTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.JumlahTextBox.Click += new System.EventHandler(this.JumlahTextBox_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.TotalBiayaTextBox, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label5, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.BiayaLainTextBox, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.BiayaPotonganTextBox, 1, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(599, 552);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(192, 118);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // TotalBiayaTextBox
            // 
            this.TotalBiayaTextBox.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.TotalBiayaTextBox.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.TotalBiayaTextBox.Location = new System.Drawing.Point(88, 4);
            this.TotalBiayaTextBox.Name = "TotalBiayaTextBox";
            this.TotalBiayaTextBox.ReadOnly = true;
            this.TotalBiayaTextBox.Size = new System.Drawing.Size(100, 32);
            this.TotalBiayaTextBox.TabIndex = 18;
            this.TotalBiayaTextBox.Text = "0";
            this.TotalBiayaTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 19);
            this.label5.TabIndex = 18;
            this.label5.Text = "Sub Total :";
            // 
            // BiayaLainTextBox
            // 
            this.BiayaLainTextBox.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.BiayaLainTextBox.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.BiayaLainTextBox.Location = new System.Drawing.Point(88, 82);
            this.BiayaLainTextBox.Name = "BiayaLainTextBox";
            this.BiayaLainTextBox.Size = new System.Drawing.Size(100, 32);
            this.BiayaLainTextBox.TabIndex = 1;
            this.BiayaLainTextBox.Text = "0";
            this.BiayaLainTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.BiayaLainTextBox.Click += new System.EventHandler(this.BiayaLainTextBox_Click);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 19);
            this.label4.TabIndex = 3;
            this.label4.Text = "Biaya Lain :";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "Potongan :";
            // 
            // BiayaPotonganTextBox
            // 
            this.BiayaPotonganTextBox.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.BiayaPotonganTextBox.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.BiayaPotonganTextBox.Location = new System.Drawing.Point(88, 43);
            this.BiayaPotonganTextBox.Name = "BiayaPotonganTextBox";
            this.BiayaPotonganTextBox.Size = new System.Drawing.Size(100, 32);
            this.BiayaPotonganTextBox.TabIndex = 0;
            this.BiayaPotonganTextBox.Text = "0";
            this.BiayaPotonganTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.BiayaPotonganTextBox.Click += new System.EventHandler(this.PotonganTextBox_Click);
            // 
            // TotalBiayaAkhirTextBox
            // 
            this.TotalBiayaAkhirTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TotalBiayaAkhirTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.TotalBiayaAkhirTextBox.Font = new System.Drawing.Font("Segoe UI", 42F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalBiayaAkhirTextBox.Location = new System.Drawing.Point(318, 16);
            this.TotalBiayaAkhirTextBox.Name = "TotalBiayaAkhirTextBox";
            this.TotalBiayaAkhirTextBox.ReadOnly = true;
            this.TotalBiayaAkhirTextBox.Size = new System.Drawing.Size(554, 82);
            this.TotalBiayaAkhirTextBox.TabIndex = 5;
            this.TotalBiayaAkhirTextBox.TabStop = false;
            this.TotalBiayaAkhirTextBox.Text = "0";
            this.TotalBiayaAkhirTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.NamaPegawaiTextBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.WaktuTransaksiDTP, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 14);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(284, 62);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tgl Transaksi :";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "Pegawai :";
            // 
            // NamaPegawaiTextBox
            // 
            this.NamaPegawaiTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.NamaPegawaiTextBox.Location = new System.Drawing.Point(101, 3);
            this.NamaPegawaiTextBox.Name = "NamaPegawaiTextBox";
            this.NamaPegawaiTextBox.ReadOnly = true;
            this.NamaPegawaiTextBox.Size = new System.Drawing.Size(180, 25);
            this.NamaPegawaiTextBox.TabIndex = 0;
            this.NamaPegawaiTextBox.TabStop = false;
            this.NamaPegawaiTextBox.Text = "[PEGAWAI]";
            // 
            // WaktuTransaksiDTP
            // 
            this.WaktuTransaksiDTP.CustomFormat = "dd/MM/yyyy hh:mm:ss";
            this.WaktuTransaksiDTP.Enabled = false;
            this.WaktuTransaksiDTP.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.WaktuTransaksiDTP.Location = new System.Drawing.Point(101, 34);
            this.WaktuTransaksiDTP.Name = "WaktuTransaksiDTP";
            this.WaktuTransaksiDTP.Size = new System.Drawing.Size(180, 25);
            this.WaktuTransaksiDTP.TabIndex = 1;
            this.WaktuTransaksiDTP.TabStop = false;
            // 
            // BayarButton
            // 
            this.BayarButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BayarButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.BayarButton.ForeColor = System.Drawing.Color.Blue;
            this.BayarButton.Location = new System.Drawing.Point(797, 552);
            this.BayarButton.Name = "BayarButton";
            this.BayarButton.Size = new System.Drawing.Size(75, 65);
            this.BayarButton.TabIndex = 15;
            this.BayarButton.Text = "Bayar";
            this.BayarButton.UseVisualStyleBackColor = true;
            this.BayarButton.Click += new System.EventHandler(this.BayarButton_Click);
            this.BayarButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button_MouseDown);
            this.BayarButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button_MouseUp);
            // 
            // ScrollDownButton
            // 
            this.ScrollDownButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ScrollDownButton.Image = global::MCS_POS.Kasir.Properties.Resources.arrow_down32;
            this.ScrollDownButton.Location = new System.Drawing.Point(797, 384);
            this.ScrollDownButton.Name = "ScrollDownButton";
            this.ScrollDownButton.Size = new System.Drawing.Size(75, 50);
            this.ScrollDownButton.TabIndex = 17;
            this.ScrollDownButton.TabStop = false;
            this.ScrollDownButton.UseVisualStyleBackColor = true;
            this.ScrollDownButton.Click += new System.EventHandler(this.ScrollDownButton_Click);
            // 
            // ScrollUpButton
            // 
            this.ScrollUpButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ScrollUpButton.Image = global::MCS_POS.Kasir.Properties.Resources.arrow_up32;
            this.ScrollUpButton.Location = new System.Drawing.Point(797, 299);
            this.ScrollUpButton.Name = "ScrollUpButton";
            this.ScrollUpButton.Size = new System.Drawing.Size(75, 50);
            this.ScrollUpButton.TabIndex = 16;
            this.ScrollUpButton.TabStop = false;
            this.ScrollUpButton.UseVisualStyleBackColor = true;
            this.ScrollUpButton.Click += new System.EventHandler(this.ScrollUpButton_Click);
            // 
            // JumlahItemLabel
            // 
            this.JumlahItemLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.JumlahItemLabel.AutoSize = true;
            this.JumlahItemLabel.Location = new System.Drawing.Point(12, 562);
            this.JumlahItemLabel.Name = "JumlahItemLabel";
            this.JumlahItemLabel.Size = new System.Drawing.Size(103, 19);
            this.JumlahItemLabel.TabIndex = 19;
            this.JumlahItemLabel.Text = "Jumlah Item : 0";
            // 
            // KasirForm
            // 
            this.ClientSize = new System.Drawing.Size(884, 682);
            this.Controls.Add(this.JumlahItemLabel);
            this.Controls.Add(this.ScrollDownButton);
            this.Controls.Add(this.ScrollUpButton);
            this.Controls.Add(this.BayarButton);
            this.Controls.Add(this.DGV);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.TotalBiayaAkhirTextBox);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "KasirForm";
            this.Text = "PENJUALAN KASIR";
            this.Load += new System.EventHandler(this.KasirForm_Load);
            this.Shown += new System.EventHandler(this.KasirForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox NamaPegawaiTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker WaktuTransaksiDTP;
        private System.Windows.Forms.TextBox TotalBiayaAkhirTextBox;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox BiayaLainTextBox;
        private System.Windows.Forms.TextBox BiayaPotonganTextBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button TambahButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button BrowseButton;
        private System.Windows.Forms.Label InfoItemLabel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox JumlahTextBox;
        private System.Windows.Forms.DataGridView DGV;
        private System.Windows.Forms.Button BayarButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnID_Penjualan_Detail;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnID_Item;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnKodeItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNamaItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnJumlah;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnID_Satuan;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSatuan;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnHarga;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSubTotal;
        private TouchButton ScrollUpButton;
        private TouchButton ScrollDownButton;
        private System.Windows.Forms.TextBox TotalBiayaTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label JumlahItemLabel;
    }
}
