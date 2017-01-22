namespace MCS_POS.Master
{
    partial class CustomerForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.ColumnID_Customer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNama_Customer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAlamat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTelp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.SuspendLayout();
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(497, 12);
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(497, 41);
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // DGV
            // 
            this.DGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnID_Customer,
            this.ColumnNama_Customer,
            this.ColumnAlamat,
            this.ColumnTelp});
            this.DGV.Size = new System.Drawing.Size(479, 224);
            // 
            // TambahButton
            // 
            this.TambahButton.Location = new System.Drawing.Point(497, 70);
            this.TambahButton.Visible = false;
            // 
            // EditButton
            // 
            this.EditButton.Location = new System.Drawing.Point(497, 99);
            this.EditButton.Visible = false;
            // 
            // BackButton
            // 
            this.BackButton.Location = new System.Drawing.Point(497, 128);
            this.BackButton.Visible = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 239);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(428, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "* Tiap Cabang minimal harus ada customer yang bernama \"UMUM\" untuk transaksi kasi" +
    "r.";
            // 
            // ColumnID_Customer
            // 
            this.ColumnID_Customer.DataPropertyName = "id_customer";
            this.ColumnID_Customer.HeaderText = "ID_Customer";
            this.ColumnID_Customer.Name = "ColumnID_Customer";
            this.ColumnID_Customer.Visible = false;
            // 
            // ColumnNama_Customer
            // 
            this.ColumnNama_Customer.DataPropertyName = "nama_customer";
            this.ColumnNama_Customer.HeaderText = "Nama Customer";
            this.ColumnNama_Customer.Name = "ColumnNama_Customer";
            // 
            // ColumnAlamat
            // 
            this.ColumnAlamat.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ColumnAlamat.DataPropertyName = "alamat_customer";
            this.ColumnAlamat.HeaderText = "Alamat";
            this.ColumnAlamat.Name = "ColumnAlamat";
            this.ColumnAlamat.Width = 65;
            // 
            // ColumnTelp
            // 
            this.ColumnTelp.DataPropertyName = "telp_customer";
            this.ColumnTelp.HeaderText = "Telp";
            this.ColumnTelp.Name = "ColumnTelp";
            // 
            // CustomerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(584, 261);
            this.Controls.Add(this.label1);
            this.Name = "CustomerForm";
            this.Text = "Customer";
            this.Load += new System.EventHandler(this.CustomerForm_Load);
            this.Controls.SetChildIndex(this.DeleteButton, 0);
            this.Controls.SetChildIndex(this.DGV, 0);
            this.Controls.SetChildIndex(this.SaveButton, 0);
            this.Controls.SetChildIndex(this.EditButton, 0);
            this.Controls.SetChildIndex(this.TambahButton, 0);
            this.Controls.SetChildIndex(this.BackButton, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnID_Customer;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNama_Customer;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAlamat;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTelp;







    }
}
