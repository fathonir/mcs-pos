namespace MCS_POS.Master
{
    partial class CabangForm
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
            this.ColumnID_Departemen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnKode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNama = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAlamat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnKota = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.ColumnID_Departemen,
            this.ColumnKode,
            this.ColumnNama,
            this.ColumnAlamat,
            this.ColumnKota,
            this.ColumnTelp});
            this.DGV.Size = new System.Drawing.Size(479, 237);
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
            // ColumnID_Departemen
            // 
            this.ColumnID_Departemen.DataPropertyName = "id_departemen";
            this.ColumnID_Departemen.HeaderText = "ID_Departemen";
            this.ColumnID_Departemen.Name = "ColumnID_Departemen";
            this.ColumnID_Departemen.Visible = false;
            // 
            // ColumnKode
            // 
            this.ColumnKode.DataPropertyName = "kode_departemen";
            this.ColumnKode.HeaderText = "Kode Cabang";
            this.ColumnKode.Name = "ColumnKode";
            // 
            // ColumnNama
            // 
            this.ColumnNama.DataPropertyName = "nama_departemen";
            this.ColumnNama.HeaderText = "Nama Cabang";
            this.ColumnNama.Name = "ColumnNama";
            // 
            // ColumnAlamat
            // 
            this.ColumnAlamat.DataPropertyName = "alamat_departemen";
            this.ColumnAlamat.HeaderText = "Alamat";
            this.ColumnAlamat.Name = "ColumnAlamat";
            // 
            // ColumnKota
            // 
            this.ColumnKota.DataPropertyName = "kota_departemen";
            this.ColumnKota.HeaderText = "Kota";
            this.ColumnKota.Name = "ColumnKota";
            // 
            // ColumnTelp
            // 
            this.ColumnTelp.DataPropertyName = "telp_departemen";
            this.ColumnTelp.HeaderText = "Telp";
            this.ColumnTelp.Name = "ColumnTelp";
            // 
            // CabangForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(584, 261);
            this.Name = "CabangForm";
            this.Text = "Cabang";
            this.Load += new System.EventHandler(this.CabangForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnID_Departemen;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnKode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNama;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAlamat;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnKota;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTelp;



    }
}
