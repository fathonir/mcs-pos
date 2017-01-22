namespace MCS_POS.Kasir
{
    partial class PembayaranForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.KembaliTextBox = new System.Windows.Forms.TextBox();
            this.BayarTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TotalTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.touchButton2 = new MCS_POS.Kasir.TouchButton();
            this.touchButton1 = new MCS_POS.Kasir.TouchButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.BayarTextBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.TotalTextBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.KembaliTextBox, 1, 2);
            this.tableLayoutPanel1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(450, 149);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // KembaliTextBox
            // 
            this.KembaliTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.KembaliTextBox.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KembaliTextBox.Location = new System.Drawing.Point(228, 102);
            this.KembaliTextBox.Name = "KembaliTextBox";
            this.KembaliTextBox.ReadOnly = true;
            this.KembaliTextBox.Size = new System.Drawing.Size(219, 43);
            this.KembaliTextBox.TabIndex = 3;
            this.KembaliTextBox.TabStop = false;
            this.KembaliTextBox.Text = "0";
            this.KembaliTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // BayarTextBox
            // 
            this.BayarTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.BayarTextBox.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BayarTextBox.Location = new System.Drawing.Point(228, 52);
            this.BayarTextBox.Name = "BayarTextBox";
            this.BayarTextBox.Size = new System.Drawing.Size(219, 43);
            this.BayarTextBox.TabIndex = 1;
            this.BayarTextBox.Text = "0";
            this.BayarTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.BayarTextBox.Click += new System.EventHandler(this.BayarTextBox_Click);
            this.BayarTextBox.TextChanged += new System.EventHandler(this.BayarTextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(68, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 30);
            this.label1.TabIndex = 4;
            this.label1.Text = "BIAYA TOTAL :";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(132, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 30);
            this.label2.TabIndex = 5;
            this.label2.Text = "BAYAR :";
            // 
            // TotalTextBox
            // 
            this.TotalTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TotalTextBox.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalTextBox.Location = new System.Drawing.Point(228, 3);
            this.TotalTextBox.Name = "TotalTextBox";
            this.TotalTextBox.ReadOnly = true;
            this.TotalTextBox.Size = new System.Drawing.Size(219, 43);
            this.TotalTextBox.TabIndex = 0;
            this.TotalTextBox.TabStop = false;
            this.TotalTextBox.Text = "0";
            this.TotalTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(42, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(180, 30);
            this.label4.TabIndex = 7;
            this.label4.Text = "Kurang/Kembali :";
            // 
            // touchButton2
            // 
            this.touchButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.touchButton2.Location = new System.Drawing.Point(362, 173);
            this.touchButton2.Margin = new System.Windows.Forms.Padding(4);
            this.touchButton2.Name = "touchButton2";
            this.touchButton2.Size = new System.Drawing.Size(96, 62);
            this.touchButton2.TabIndex = 2;
            this.touchButton2.Text = "BATAL";
            this.touchButton2.UseVisualStyleBackColor = true;
            this.touchButton2.Click += new System.EventHandler(this.touchButton2_Click);
            // 
            // touchButton1
            // 
            this.touchButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.touchButton1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.touchButton1.Location = new System.Drawing.Point(161, 173);
            this.touchButton1.Margin = new System.Windows.Forms.Padding(4);
            this.touchButton1.Name = "touchButton1";
            this.touchButton1.Size = new System.Drawing.Size(193, 62);
            this.touchButton1.TabIndex = 1;
            this.touchButton1.Text = "BAYAR && CETAK";
            this.touchButton1.UseVisualStyleBackColor = true;
            this.touchButton1.Click += new System.EventHandler(this.touchButton1_Click);
            // 
            // PembayaranForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 249);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.touchButton2);
            this.Controls.Add(this.touchButton1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "PembayaranForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Pembayaran";
            this.Load += new System.EventHandler(this.PembayaranForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TouchButton touchButton1;
        private TouchButton touchButton2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox TotalTextBox;
        public System.Windows.Forms.TextBox KembaliTextBox;
        public System.Windows.Forms.TextBox BayarTextBox;
        private System.Windows.Forms.Label label4;
    }
}