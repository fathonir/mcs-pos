namespace MCS_POS.Penjualan
{
    partial class EditItemPenjualanForm
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
            this.SubmitButton = new System.Windows.Forms.Button();
            this.BackButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.SubTotalTextBox = new System.Windows.Forms.TextBox();
            this.HargaJualTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.KodeItemTextBox = new System.Windows.Forms.TextBox();
            this.NamaItemTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.JumlahTextBox = new System.Windows.Forms.TextBox();
            this.SatuanComboBox = new System.Windows.Forms.ComboBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.HelpStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tableLayoutPanel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SubmitButton
            // 
            this.SubmitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SubmitButton.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.SubmitButton.Location = new System.Drawing.Point(136, 191);
            this.SubmitButton.Name = "SubmitButton";
            this.SubmitButton.Size = new System.Drawing.Size(75, 23);
            this.SubmitButton.TabIndex = 1;
            this.SubmitButton.Text = "OK [Enter]";
            this.SubmitButton.UseVisualStyleBackColor = true;
            this.SubmitButton.Click += new System.EventHandler(this.SubmitButton_Click);
            // 
            // BackButton
            // 
            this.BackButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BackButton.Location = new System.Drawing.Point(217, 191);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(75, 23);
            this.BackButton.TabIndex = 2;
            this.BackButton.Text = "Batal [Esc]";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.SubTotalTextBox, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.HargaJualTextBox, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.KodeItemTextBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.NamaItemTextBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.JumlahTextBox, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.SatuanComboBox, 1, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(280, 173);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // SubTotalTextBox
            // 
            this.SubTotalTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.SubTotalTextBox.Location = new System.Drawing.Point(76, 142);
            this.SubTotalTextBox.Name = "SubTotalTextBox";
            this.SubTotalTextBox.ReadOnly = true;
            this.SubTotalTextBox.Size = new System.Drawing.Size(80, 22);
            this.SubTotalTextBox.TabIndex = 5;
            this.SubTotalTextBox.TabStop = false;
            this.SubTotalTextBox.Text = "Rp0,00";
            this.SubTotalTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // HargaJualTextBox
            // 
            this.HargaJualTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.HargaJualTextBox.Location = new System.Drawing.Point(76, 114);
            this.HargaJualTextBox.Name = "HargaJualTextBox";
            this.HargaJualTextBox.Size = new System.Drawing.Size(80, 22);
            this.HargaJualTextBox.TabIndex = 4;
            this.HargaJualTextBox.Text = "Rp0,00";
            this.HargaJualTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.HargaJualTextBox.Enter += new System.EventHandler(this.CurrencyTextBox_Enter);
            this.HargaJualTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NumbersOnly_KeyDown);
            this.HargaJualTextBox.Leave += new System.EventHandler(this.CurrencyTextBox_Leave);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 146);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Sub Total :";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Jumlah :";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kode Item :";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nama Item :";
            // 
            // KodeItemTextBox
            // 
            this.KodeItemTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.KodeItemTextBox.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.KodeItemTextBox.Location = new System.Drawing.Point(76, 3);
            this.KodeItemTextBox.Name = "KodeItemTextBox";
            this.KodeItemTextBox.ReadOnly = true;
            this.KodeItemTextBox.Size = new System.Drawing.Size(100, 22);
            this.KodeItemTextBox.TabIndex = 0;
            this.KodeItemTextBox.TabStop = false;
            // 
            // NamaItemTextBox
            // 
            this.NamaItemTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.NamaItemTextBox.Location = new System.Drawing.Point(76, 31);
            this.NamaItemTextBox.Name = "NamaItemTextBox";
            this.NamaItemTextBox.ReadOnly = true;
            this.NamaItemTextBox.Size = new System.Drawing.Size(200, 22);
            this.NamaItemTextBox.TabIndex = 1;
            this.NamaItemTextBox.TabStop = false;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Satuan :";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Harga Jual :";
            // 
            // JumlahTextBox
            // 
            this.JumlahTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.JumlahTextBox.Location = new System.Drawing.Point(76, 59);
            this.JumlahTextBox.Name = "JumlahTextBox";
            this.JumlahTextBox.Size = new System.Drawing.Size(80, 22);
            this.JumlahTextBox.TabIndex = 2;
            this.JumlahTextBox.Text = "0";
            this.JumlahTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // SatuanComboBox
            // 
            this.SatuanComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SatuanComboBox.FormattingEnabled = true;
            this.SatuanComboBox.Location = new System.Drawing.Point(76, 87);
            this.SatuanComboBox.Name = "SatuanComboBox";
            this.SatuanComboBox.Size = new System.Drawing.Size(100, 21);
            this.SatuanComboBox.TabIndex = 3;
            this.SatuanComboBox.Enter += new System.EventHandler(this.SatuanComboBox_Enter);
            this.SatuanComboBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SatuanComboBox_KeyDown);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HelpStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 217);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(304, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // HelpStatusLabel
            // 
            this.HelpStatusLabel.Name = "HelpStatusLabel";
            this.HelpStatusLabel.Size = new System.Drawing.Size(136, 17);
            this.HelpStatusLabel.Text = "[Tab] Berpindah inputan";
            // 
            // EditItemPenjualanForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 239);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.SubmitButton);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "EditItemPenjualanForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Item";
            this.Load += new System.EventHandler(this.EditItemPenjualanForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SubmitButton;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox KodeItemTextBox;
        private System.Windows.Forms.TextBox NamaItemTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox JumlahTextBox;
        private System.Windows.Forms.ComboBox SatuanComboBox;
        private System.Windows.Forms.TextBox SubTotalTextBox;
        private System.Windows.Forms.TextBox HargaJualTextBox;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel HelpStatusLabel;
    }
}