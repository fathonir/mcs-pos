namespace MCS_POS.Kasir
{
    partial class RefundForm
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
            this.WaktuRefundDTP = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.NamaPegawaiReturTextBox = new System.Windows.Forms.TextBox();
            this.WaktuTransaksiDTP = new System.Windows.Forms.DateTimePicker();
            this.TotalBiayaRefundTextBox = new System.Windows.Forms.TextBox();
            this.DGV = new System.Windows.Forms.DataGridView();
            this.ColumnID_Penjualan_Detail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnIsRefund = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnKodeItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNamaItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnJumlah = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnHarga = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnJumlahRefund = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnHargaRefund = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSubTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.TotalBiayaAkhirTextBox = new System.Windows.Forms.TextBox();
            this.TotalBiayaTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.BiayaLainTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.BiayaPotonganRefundTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.BiayaPotonganTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ReturButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.ScrollDownButton = new MCS_POS.Kasir.TouchButton();
            this.ScrollUpButton = new MCS_POS.Kasir.TouchButton();
            this.label10 = new System.Windows.Forms.Label();
            this.NamaPegawaiTextBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.NamaPegawaiTextBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label10, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.WaktuRefundDTP, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.WaktuTransaksiDTP, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.NamaPegawaiReturTextBox, 1, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(326, 116);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // WaktuRefundDTP
            // 
            this.WaktuRefundDTP.CustomFormat = "dd/MM/yyyy hh:mm:ss";
            this.WaktuRefundDTP.Enabled = false;
            this.WaktuRefundDTP.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.WaktuRefundDTP.Location = new System.Drawing.Point(143, 90);
            this.WaktuRefundDTP.Name = "WaktuRefundDTP";
            this.WaktuRefundDTP.Size = new System.Drawing.Size(180, 23);
            this.WaktuRefundDTP.TabIndex = 5;
            this.WaktuRefundDTP.TabStop = false;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tanggal Retur :";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tanggal Transaksi :";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Pegawai Retur :";
            // 
            // NamaPegawaiReturTextBox
            // 
            this.NamaPegawaiReturTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.NamaPegawaiReturTextBox.Location = new System.Drawing.Point(143, 61);
            this.NamaPegawaiReturTextBox.Name = "NamaPegawaiReturTextBox";
            this.NamaPegawaiReturTextBox.ReadOnly = true;
            this.NamaPegawaiReturTextBox.Size = new System.Drawing.Size(180, 23);
            this.NamaPegawaiReturTextBox.TabIndex = 0;
            this.NamaPegawaiReturTextBox.TabStop = false;
            this.NamaPegawaiReturTextBox.Text = "[PEGAWAI RETUR]";
            // 
            // WaktuTransaksiDTP
            // 
            this.WaktuTransaksiDTP.CustomFormat = "dd/MM/yyyy hh:mm:ss";
            this.WaktuTransaksiDTP.Enabled = false;
            this.WaktuTransaksiDTP.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.WaktuTransaksiDTP.Location = new System.Drawing.Point(143, 32);
            this.WaktuTransaksiDTP.Name = "WaktuTransaksiDTP";
            this.WaktuTransaksiDTP.Size = new System.Drawing.Size(180, 23);
            this.WaktuTransaksiDTP.TabIndex = 1;
            this.WaktuTransaksiDTP.TabStop = false;
            // 
            // TotalBiayaRefundTextBox
            // 
            this.TotalBiayaRefundTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TotalBiayaRefundTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.TotalBiayaRefundTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalBiayaRefundTextBox.Location = new System.Drawing.Point(344, 43);
            this.TotalBiayaRefundTextBox.Name = "TotalBiayaRefundTextBox";
            this.TotalBiayaRefundTextBox.ReadOnly = true;
            this.TotalBiayaRefundTextBox.Size = new System.Drawing.Size(428, 53);
            this.TotalBiayaRefundTextBox.TabIndex = 6;
            this.TotalBiayaRefundTextBox.TabStop = false;
            this.TotalBiayaRefundTextBox.Text = "0";
            this.TotalBiayaRefundTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
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
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DGV.ColumnHeadersHeight = 40;
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnID_Penjualan_Detail,
            this.ColumnIsRefund,
            this.ColumnKodeItem,
            this.ColumnNamaItem,
            this.ColumnJumlah,
            this.ColumnHarga,
            this.ColumnJumlahRefund,
            this.ColumnHargaRefund,
            this.ColumnSubTotal});
            this.DGV.EnableHeadersVisualStyles = false;
            this.DGV.Location = new System.Drawing.Point(12, 131);
            this.DGV.MultiSelect = false;
            this.DGV.Name = "DGV";
            this.DGV.RowHeadersWidth = 25;
            this.DGV.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.DGV.RowTemplate.Height = 35;
            this.DGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV.Size = new System.Drawing.Size(689, 294);
            this.DGV.TabIndex = 15;
            this.DGV.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_CellDoubleClick);
            this.DGV.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DGV_CellMouseUp);
            this.DGV.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_CellValueChanged);
            // 
            // ColumnID_Penjualan_Detail
            // 
            this.ColumnID_Penjualan_Detail.DataPropertyName = "id_penjualan_detail";
            this.ColumnID_Penjualan_Detail.HeaderText = "ID_Penjualan_Detail";
            this.ColumnID_Penjualan_Detail.Name = "ColumnID_Penjualan_Detail";
            this.ColumnID_Penjualan_Detail.ReadOnly = true;
            this.ColumnID_Penjualan_Detail.Visible = false;
            // 
            // ColumnIsRefund
            // 
            this.ColumnIsRefund.DataPropertyName = "is_refund";
            this.ColumnIsRefund.FalseValue = "False";
            this.ColumnIsRefund.HeaderText = "Retur";
            this.ColumnIsRefund.Name = "ColumnIsRefund";
            this.ColumnIsRefund.TrueValue = "True";
            this.ColumnIsRefund.Width = 50;
            // 
            // ColumnKodeItem
            // 
            this.ColumnKodeItem.DataPropertyName = "kode_item";
            this.ColumnKodeItem.HeaderText = "Kode Item";
            this.ColumnKodeItem.Name = "ColumnKodeItem";
            this.ColumnKodeItem.ReadOnly = true;
            this.ColumnKodeItem.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnKodeItem.Width = 80;
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
            this.ColumnJumlah.HeaderText = "Jml";
            this.ColumnJumlah.Name = "ColumnJumlah";
            this.ColumnJumlah.ReadOnly = true;
            this.ColumnJumlah.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnJumlah.Width = 50;
            // 
            // ColumnHarga
            // 
            this.ColumnHarga.DataPropertyName = "harga_jual";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N0";
            this.ColumnHarga.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColumnHarga.HeaderText = "Harga";
            this.ColumnHarga.Name = "ColumnHarga";
            this.ColumnHarga.ReadOnly = true;
            this.ColumnHarga.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnHarga.Width = 90;
            // 
            // ColumnJumlahRefund
            // 
            this.ColumnJumlahRefund.DataPropertyName = "jumlah_refund";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColumnJumlahRefund.DefaultCellStyle = dataGridViewCellStyle4;
            this.ColumnJumlahRefund.HeaderText = "Jml Retur";
            this.ColumnJumlahRefund.Name = "ColumnJumlahRefund";
            this.ColumnJumlahRefund.ReadOnly = true;
            this.ColumnJumlahRefund.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColumnHargaRefund
            // 
            this.ColumnHargaRefund.DataPropertyName = "harga_refund";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N0";
            this.ColumnHargaRefund.DefaultCellStyle = dataGridViewCellStyle5;
            this.ColumnHargaRefund.HeaderText = "Harga Retur";
            this.ColumnHargaRefund.Name = "ColumnHargaRefund";
            this.ColumnHargaRefund.ReadOnly = true;
            this.ColumnHargaRefund.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColumnSubTotal
            // 
            this.ColumnSubTotal.DataPropertyName = "sub_total";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N0";
            this.ColumnSubTotal.DefaultCellStyle = dataGridViewCellStyle6;
            this.ColumnSubTotal.HeaderText = "Sub Total";
            this.ColumnSubTotal.Name = "ColumnSubTotal";
            this.ColumnSubTotal.ReadOnly = true;
            this.ColumnSubTotal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.TotalBiayaAkhirTextBox, 3, 2);
            this.tableLayoutPanel2.Controls.Add(this.TotalBiayaTextBox, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.label5, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.label4, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.BiayaLainTextBox, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.label9, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.BiayaPotonganRefundTextBox, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.label7, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.BiayaPotonganTextBox, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label6, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(233, 431);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(468, 118);
            this.tableLayoutPanel2.TabIndex = 20;
            // 
            // TotalBiayaAkhirTextBox
            // 
            this.TotalBiayaAkhirTextBox.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.TotalBiayaAkhirTextBox.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.TotalBiayaAkhirTextBox.Location = new System.Drawing.Point(364, 82);
            this.TotalBiayaAkhirTextBox.Name = "TotalBiayaAkhirTextBox";
            this.TotalBiayaAkhirTextBox.ReadOnly = true;
            this.TotalBiayaAkhirTextBox.Size = new System.Drawing.Size(100, 32);
            this.TotalBiayaAkhirTextBox.TabIndex = 24;
            this.TotalBiayaAkhirTextBox.Text = "0";
            this.TotalBiayaAkhirTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // TotalBiayaTextBox
            // 
            this.TotalBiayaTextBox.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.TotalBiayaTextBox.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.TotalBiayaTextBox.Location = new System.Drawing.Point(364, 4);
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
            this.label5.Location = new System.Drawing.Point(280, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 17);
            this.label5.TabIndex = 18;
            this.label5.Text = "Sub Total :";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(234, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Total Biaya Akhir :";
            // 
            // BiayaLainTextBox
            // 
            this.BiayaLainTextBox.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.BiayaLainTextBox.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.BiayaLainTextBox.Location = new System.Drawing.Point(364, 43);
            this.BiayaLainTextBox.Name = "BiayaLainTextBox";
            this.BiayaLainTextBox.ReadOnly = true;
            this.BiayaLainTextBox.Size = new System.Drawing.Size(100, 32);
            this.BiayaLainTextBox.TabIndex = 1;
            this.BiayaLainTextBox.Text = "0";
            this.BiayaLainTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(275, 50);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 17);
            this.label9.TabIndex = 24;
            this.label9.Text = "Biaya Lain :";
            // 
            // BiayaPotonganRefundTextBox
            // 
            this.BiayaPotonganRefundTextBox.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.BiayaPotonganRefundTextBox.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.BiayaPotonganRefundTextBox.Location = new System.Drawing.Point(127, 82);
            this.BiayaPotonganRefundTextBox.Name = "BiayaPotonganRefundTextBox";
            this.BiayaPotonganRefundTextBox.ReadOnly = true;
            this.BiayaPotonganRefundTextBox.Size = new System.Drawing.Size(100, 32);
            this.BiayaPotonganRefundTextBox.TabIndex = 21;
            this.BiayaPotonganRefundTextBox.Text = "0";
            this.BiayaPotonganRefundTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 89);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(116, 17);
            this.label7.TabIndex = 21;
            this.label7.Text = "Potongan Retur :";
            // 
            // BiayaPotonganTextBox
            // 
            this.BiayaPotonganTextBox.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.BiayaPotonganTextBox.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.BiayaPotonganTextBox.Location = new System.Drawing.Point(127, 4);
            this.BiayaPotonganTextBox.Name = "BiayaPotonganTextBox";
            this.BiayaPotonganTextBox.ReadOnly = true;
            this.BiayaPotonganTextBox.Size = new System.Drawing.Size(100, 32);
            this.BiayaPotonganTextBox.TabIndex = 0;
            this.BiayaPotonganTextBox.Text = "0";
            this.BiayaPotonganTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(43, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 17);
            this.label6.TabIndex = 2;
            this.label6.Text = "Potongan :";
            // 
            // ReturButton
            // 
            this.ReturButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ReturButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.ReturButton.ForeColor = System.Drawing.Color.Blue;
            this.ReturButton.Location = new System.Drawing.Point(707, 431);
            this.ReturButton.Name = "ReturButton";
            this.ReturButton.Size = new System.Drawing.Size(65, 65);
            this.ReturButton.TabIndex = 21;
            this.ReturButton.Text = "RETUR";
            this.ReturButton.UseVisualStyleBackColor = true;
            this.ReturButton.Click += new System.EventHandler(this.ReturButton_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CloseButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.CloseButton.ForeColor = System.Drawing.Color.Red;
            this.CloseButton.Location = new System.Drawing.Point(12, 431);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(65, 65);
            this.CloseButton.TabIndex = 22;
            this.CloseButton.Text = "Tutup";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(642, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(130, 17);
            this.label8.TabIndex = 23;
            this.label8.Text = "RETUR BARANG";
            // 
            // ScrollDownButton
            // 
            this.ScrollDownButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ScrollDownButton.Image = global::MCS_POS.Kasir.Properties.Resources.arrow_down32;
            this.ScrollDownButton.Location = new System.Drawing.Point(707, 375);
            this.ScrollDownButton.Name = "ScrollDownButton";
            this.ScrollDownButton.Size = new System.Drawing.Size(65, 50);
            this.ScrollDownButton.TabIndex = 19;
            this.ScrollDownButton.TabStop = false;
            this.ScrollDownButton.UseVisualStyleBackColor = true;
            this.ScrollDownButton.Click += new System.EventHandler(this.ScrollDownButton_Click);
            // 
            // ScrollUpButton
            // 
            this.ScrollUpButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ScrollUpButton.Image = global::MCS_POS.Kasir.Properties.Resources.arrow_up32;
            this.ScrollUpButton.Location = new System.Drawing.Point(707, 131);
            this.ScrollUpButton.Name = "ScrollUpButton";
            this.ScrollUpButton.Size = new System.Drawing.Size(65, 50);
            this.ScrollUpButton.TabIndex = 18;
            this.ScrollUpButton.TabStop = false;
            this.ScrollUpButton.UseVisualStyleBackColor = true;
            this.ScrollUpButton.Click += new System.EventHandler(this.ScrollUpButton_Click);
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(68, 6);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 17);
            this.label10.TabIndex = 24;
            this.label10.Text = "Pegawai :";
            // 
            // NamaPegawaiTextBox
            // 
            this.NamaPegawaiTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.NamaPegawaiTextBox.Location = new System.Drawing.Point(143, 3);
            this.NamaPegawaiTextBox.Name = "NamaPegawaiTextBox";
            this.NamaPegawaiTextBox.ReadOnly = true;
            this.NamaPegawaiTextBox.Size = new System.Drawing.Size(180, 23);
            this.NamaPegawaiTextBox.TabIndex = 24;
            this.NamaPegawaiTextBox.TabStop = false;
            this.NamaPegawaiTextBox.Text = "[PEGAWAI]";
            // 
            // RefundForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.ReturButton);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.ScrollDownButton);
            this.Controls.Add(this.ScrollUpButton);
            this.Controls.Add(this.DGV);
            this.Controls.Add(this.TotalBiayaRefundTextBox);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "RefundForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Retur Barang";
            this.Load += new System.EventHandler(this.RefundForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox NamaPegawaiReturTextBox;
        private System.Windows.Forms.DateTimePicker WaktuTransaksiDTP;
        private System.Windows.Forms.TextBox TotalBiayaRefundTextBox;
        private System.Windows.Forms.DataGridView DGV;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker WaktuRefundDTP;
        private TouchButton ScrollDownButton;
        private TouchButton ScrollUpButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox TotalBiayaTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox BiayaLainTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox BiayaPotonganTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox BiayaPotonganRefundTextBox;
        private System.Windows.Forms.Button ReturButton;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox TotalBiayaAkhirTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnID_Penjualan_Detail;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnIsRefund;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnKodeItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNamaItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnJumlah;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnHarga;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnJumlahRefund;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnHargaRefund;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSubTotal;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox NamaPegawaiTextBox;
    }
}