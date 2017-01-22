namespace MCS_POS.Kasir
{
    partial class PenjualanForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.KasirComboBox = new System.Windows.Forms.ComboBox();
            this.FilterComboBox = new System.Windows.Forms.ComboBox();
            this.DGV = new System.Windows.Forms.DataGridView();
            this.ColumnID_Penjualan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNoTransaksi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTanggal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnKasir = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnJumlahItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnItemRefund = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DetailButton = new MCS_POS.Kasir.TouchButton();
            this.RefundButton = new MCS_POS.Kasir.TouchButton();
            this.PrintButton = new MCS_POS.Kasir.TouchButton();
            this.ScrollDownButton = new MCS_POS.Kasir.TouchButton();
            this.ScrollUpButton = new MCS_POS.Kasir.TouchButton();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.KasirComboBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.FilterComboBox, 3, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(11, 11);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(537, 36);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Kasir :";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(253, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Filter Data :";
            // 
            // KasirComboBox
            // 
            this.KasirComboBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.KasirComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.KasirComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.KasirComboBox.FormattingEnabled = true;
            this.KasirComboBox.Location = new System.Drawing.Point(53, 4);
            this.KasirComboBox.Name = "KasirComboBox";
            this.KasirComboBox.Size = new System.Drawing.Size(180, 28);
            this.KasirComboBox.TabIndex = 1;
            this.KasirComboBox.SelectedIndexChanged += new System.EventHandler(this.KasirComboBox_SelectedIndexChanged);
            // 
            // FilterComboBox
            // 
            this.FilterComboBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.FilterComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FilterComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.FilterComboBox.FormattingEnabled = true;
            this.FilterComboBox.Items.AddRange(new object[] {
            "Hari Ini",
            "Kemarin",
            "1 Minggu",
            "2 Minggu",
            "3 Minggu",
            "1 Bulan"});
            this.FilterComboBox.Location = new System.Drawing.Point(334, 4);
            this.FilterComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.FilterComboBox.Name = "FilterComboBox";
            this.FilterComboBox.Size = new System.Drawing.Size(180, 28);
            this.FilterComboBox.TabIndex = 3;
            this.FilterComboBox.SelectedIndexChanged += new System.EventHandler(this.FilterComboBox_SelectedIndexChanged);
            // 
            // DGV
            // 
            this.DGV.AllowUserToAddRows = false;
            this.DGV.AllowUserToDeleteRows = false;
            this.DGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGV.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle17;
            this.DGV.ColumnHeadersHeight = 40;
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnID_Penjualan,
            this.ColumnNoTransaksi,
            this.ColumnTanggal,
            this.ColumnKasir,
            this.ColumnJumlahItem,
            this.ColumnItemRefund,
            this.ColumnTotal});
            this.DGV.EnableHeadersVisualStyles = false;
            this.DGV.Location = new System.Drawing.Point(11, 51);
            this.DGV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DGV.MultiSelect = false;
            this.DGV.Name = "DGV";
            this.DGV.ReadOnly = true;
            this.DGV.RowTemplate.Height = 35;
            this.DGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV.Size = new System.Drawing.Size(709, 427);
            this.DGV.TabIndex = 1;
            // 
            // ColumnID_Penjualan
            // 
            this.ColumnID_Penjualan.DataPropertyName = "id_penjualan";
            this.ColumnID_Penjualan.HeaderText = "ID_Penjualan";
            this.ColumnID_Penjualan.Name = "ColumnID_Penjualan";
            this.ColumnID_Penjualan.ReadOnly = true;
            this.ColumnID_Penjualan.Visible = false;
            // 
            // ColumnNoTransaksi
            // 
            this.ColumnNoTransaksi.DataPropertyName = "kode_transaksi";
            this.ColumnNoTransaksi.HeaderText = "No Transaksi";
            this.ColumnNoTransaksi.Name = "ColumnNoTransaksi";
            this.ColumnNoTransaksi.ReadOnly = true;
            this.ColumnNoTransaksi.Width = 120;
            // 
            // ColumnTanggal
            // 
            this.ColumnTanggal.DataPropertyName = "waktu_transaksi";
            dataGridViewCellStyle18.Format = "d";
            dataGridViewCellStyle18.NullValue = null;
            this.ColumnTanggal.DefaultCellStyle = dataGridViewCellStyle18;
            this.ColumnTanggal.HeaderText = "Tanggal";
            this.ColumnTanggal.Name = "ColumnTanggal";
            this.ColumnTanggal.ReadOnly = true;
            // 
            // ColumnKasir
            // 
            this.ColumnKasir.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnKasir.DataPropertyName = "nama_user";
            this.ColumnKasir.HeaderText = "Kasir";
            this.ColumnKasir.Name = "ColumnKasir";
            this.ColumnKasir.ReadOnly = true;
            // 
            // ColumnJumlahItem
            // 
            this.ColumnJumlahItem.DataPropertyName = "jumlah_item";
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle19.Format = "N0";
            this.ColumnJumlahItem.DefaultCellStyle = dataGridViewCellStyle19;
            this.ColumnJumlahItem.HeaderText = "Jumlah Item";
            this.ColumnJumlahItem.Name = "ColumnJumlahItem";
            this.ColumnJumlahItem.ReadOnly = true;
            // 
            // ColumnItemRefund
            // 
            this.ColumnItemRefund.DataPropertyName = "jumlah_item_refund";
            this.ColumnItemRefund.HeaderText = "Jumlah Item Refund";
            this.ColumnItemRefund.Name = "ColumnItemRefund";
            this.ColumnItemRefund.ReadOnly = true;
            this.ColumnItemRefund.Visible = false;
            // 
            // ColumnTotal
            // 
            this.ColumnTotal.DataPropertyName = "total_biaya_akhir";
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle20.Format = "N0";
            this.ColumnTotal.DefaultCellStyle = dataGridViewCellStyle20;
            this.ColumnTotal.HeaderText = "Total";
            this.ColumnTotal.Name = "ColumnTotal";
            this.ColumnTotal.ReadOnly = true;
            this.ColumnTotal.Width = 120;
            // 
            // DetailButton
            // 
            this.DetailButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.DetailButton.Image = global::MCS_POS.Kasir.Properties.Resources.list_information32;
            this.DetailButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DetailButton.Location = new System.Drawing.Point(215, 487);
            this.DetailButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DetailButton.Name = "DetailButton";
            this.DetailButton.Padding = new System.Windows.Forms.Padding(11, 0, 11, 0);
            this.DetailButton.Size = new System.Drawing.Size(107, 40);
            this.DetailButton.TabIndex = 4;
            this.DetailButton.Text = "Detail";
            this.DetailButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.DetailButton.UseVisualStyleBackColor = true;
            this.DetailButton.Click += new System.EventHandler(this.DetailButton_Click);
            // 
            // RefundButton
            // 
            this.RefundButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.RefundButton.ForeColor = System.Drawing.Color.Red;
            this.RefundButton.Image = global::MCS_POS.Kasir.Properties.Resources.shopcartexclude32;
            this.RefundButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.RefundButton.Location = new System.Drawing.Point(491, 487);
            this.RefundButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RefundButton.Name = "RefundButton";
            this.RefundButton.Padding = new System.Windows.Forms.Padding(11, 0, 11, 0);
            this.RefundButton.Size = new System.Drawing.Size(114, 40);
            this.RefundButton.TabIndex = 3;
            this.RefundButton.Text = "Retur";
            this.RefundButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.RefundButton.UseVisualStyleBackColor = true;
            this.RefundButton.Click += new System.EventHandler(this.RefundButton_Click);
            // 
            // PrintButton
            // 
            this.PrintButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.PrintButton.Image = global::MCS_POS.Kasir.Properties.Resources.print32;
            this.PrintButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.PrintButton.Location = new System.Drawing.Point(328, 482);
            this.PrintButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PrintButton.Name = "PrintButton";
            this.PrintButton.Padding = new System.Windows.Forms.Padding(11, 0, 11, 0);
            this.PrintButton.Size = new System.Drawing.Size(157, 50);
            this.PrintButton.TabIndex = 2;
            this.PrintButton.Text = "Cetak Ulang";
            this.PrintButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.PrintButton.UseVisualStyleBackColor = true;
            this.PrintButton.Click += new System.EventHandler(this.PrintButton_Click);
            // 
            // ScrollDownButton
            // 
            this.ScrollDownButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ScrollDownButton.Image = global::MCS_POS.Kasir.Properties.Resources.arrow_down32;
            this.ScrollDownButton.Location = new System.Drawing.Point(726, 428);
            this.ScrollDownButton.Name = "ScrollDownButton";
            this.ScrollDownButton.Size = new System.Drawing.Size(75, 50);
            this.ScrollDownButton.TabIndex = 19;
            this.ScrollDownButton.TabStop = false;
            this.ScrollDownButton.UseVisualStyleBackColor = true;
            this.ScrollDownButton.Click += new System.EventHandler(this.ScrollDownButton_Click);
            // 
            // ScrollUpButton
            // 
            this.ScrollUpButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ScrollUpButton.Image = global::MCS_POS.Kasir.Properties.Resources.arrow_up32;
            this.ScrollUpButton.Location = new System.Drawing.Point(726, 91);
            this.ScrollUpButton.Name = "ScrollUpButton";
            this.ScrollUpButton.Size = new System.Drawing.Size(75, 50);
            this.ScrollUpButton.TabIndex = 18;
            this.ScrollUpButton.TabStop = false;
            this.ScrollUpButton.UseVisualStyleBackColor = true;
            this.ScrollUpButton.Click += new System.EventHandler(this.ScrollUpButton_Click);
            // 
            // PenjualanForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 543);
            this.Controls.Add(this.ScrollDownButton);
            this.Controls.Add(this.ScrollUpButton);
            this.Controls.Add(this.DetailButton);
            this.Controls.Add(this.RefundButton);
            this.Controls.Add(this.PrintButton);
            this.Controls.Add(this.DGV);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "PenjualanForm";
            this.Text = "Data Penjualan";
            this.Load += new System.EventHandler(this.PenjualanForm_Load);
            this.Shown += new System.EventHandler(this.PenjualanForm_Shown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox KasirComboBox;
        private System.Windows.Forms.ComboBox FilterComboBox;
        private System.Windows.Forms.DataGridView DGV;
        private TouchButton PrintButton;
        private TouchButton RefundButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnID_Penjualan;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNoTransaksi;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTanggal;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnKasir;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnJumlahItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnItemRefund;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTotal;
        private TouchButton DetailButton;
        private TouchButton ScrollDownButton;
        private TouchButton ScrollUpButton;
    }
}