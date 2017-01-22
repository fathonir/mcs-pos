namespace MCS_POS.Persediaan
{
    partial class ProsesBulananForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProsesBulananForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BulanComboBox = new System.Windows.Forms.ComboBox();
            this.TahunUpDown = new System.Windows.Forms.NumericUpDown();
            this.ProsesButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.PerbaikiStokCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.TahunUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(55, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(375, 132);
            this.label1.TabIndex = 0;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 187);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Periode :";
            // 
            // BulanComboBox
            // 
            this.BulanComboBox.FormattingEnabled = true;
            this.BulanComboBox.Items.AddRange(new object[] {
            "Januari",
            "Februari",
            "Maret",
            "April",
            "Mei",
            "Juni",
            "Juli",
            "Agustus",
            "September",
            "Oktober",
            "November",
            "Desember"});
            this.BulanComboBox.Location = new System.Drawing.Point(110, 184);
            this.BulanComboBox.Name = "BulanComboBox";
            this.BulanComboBox.Size = new System.Drawing.Size(121, 21);
            this.BulanComboBox.TabIndex = 5;
            // 
            // TahunUpDown
            // 
            this.TahunUpDown.Location = new System.Drawing.Point(237, 185);
            this.TahunUpDown.Maximum = new decimal(new int[] {
            2015,
            0,
            0,
            0});
            this.TahunUpDown.Minimum = new decimal(new int[] {
            2015,
            0,
            0,
            0});
            this.TahunUpDown.Name = "TahunUpDown";
            this.TahunUpDown.Size = new System.Drawing.Size(62, 20);
            this.TahunUpDown.TabIndex = 6;
            this.TahunUpDown.Value = new decimal(new int[] {
            2015,
            0,
            0,
            0});
            // 
            // ProsesButton
            // 
            this.ProsesButton.Location = new System.Drawing.Point(305, 184);
            this.ProsesButton.Name = "ProsesButton";
            this.ProsesButton.Size = new System.Drawing.Size(75, 23);
            this.ProsesButton.TabIndex = 7;
            this.ProsesButton.Text = "Proses";
            this.ProsesButton.UseVisualStyleBackColor = true;
            this.ProsesButton.Click += new System.EventHandler(this.ProsesButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Green;
            this.label3.Location = new System.Drawing.Point(55, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "Periode Awal Aplikasi :";
            // 
            // PerbaikiStokCheckBox
            // 
            this.PerbaikiStokCheckBox.AutoSize = true;
            this.PerbaikiStokCheckBox.Location = new System.Drawing.Point(110, 211);
            this.PerbaikiStokCheckBox.Name = "PerbaikiStokCheckBox";
            this.PerbaikiStokCheckBox.Size = new System.Drawing.Size(89, 17);
            this.PerbaikiStokCheckBox.TabIndex = 8;
            this.PerbaikiStokCheckBox.Text = "Perbaiki Stok";
            this.PerbaikiStokCheckBox.UseVisualStyleBackColor = true;
            // 
            // ProsesBulananForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 265);
            this.Controls.Add(this.PerbaikiStokCheckBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ProsesButton);
            this.Controls.Add(this.TahunUpDown);
            this.Controls.Add(this.BulanComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProsesBulananForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Proses Bulanan";
            this.Load += new System.EventHandler(this.ProsesBulananForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TahunUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox BulanComboBox;
        private System.Windows.Forms.NumericUpDown TahunUpDown;
        private System.Windows.Forms.Button ProsesButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox PerbaikiStokCheckBox;
    }
}