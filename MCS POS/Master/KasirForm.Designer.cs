namespace MCS_POS.Master
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
            this.ColumnID_User = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTipe_User = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnUsername = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNamaUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPassword = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDepartemen = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColumnIS_Aktif = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnAksesRefund = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnAksesHargaJual = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnAksesDataPenjualan = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnCreated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnModified = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.SuspendLayout();
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(460, 12);
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(460, 41);
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // DGV
            // 
            this.DGV.ColumnHeadersHeight = 50;
            this.DGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnID_User,
            this.ColumnTipe_User,
            this.ColumnUsername,
            this.ColumnNamaUser,
            this.ColumnPassword,
            this.ColumnDepartemen,
            this.ColumnIS_Aktif,
            this.ColumnAksesRefund,
            this.ColumnAksesHargaJual,
            this.ColumnAksesDataPenjualan,
            this.ColumnCreated,
            this.ColumnModified});
            this.DGV.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.DGV.Size = new System.Drawing.Size(442, 237);
            // 
            // TambahButton
            // 
            this.TambahButton.Location = new System.Drawing.Point(460, 99);
            this.TambahButton.Visible = false;
            // 
            // EditButton
            // 
            this.EditButton.Location = new System.Drawing.Point(460, 128);
            this.EditButton.Visible = false;
            // 
            // BackButton
            // 
            this.BackButton.Location = new System.Drawing.Point(460, 70);
            this.BackButton.Visible = false;
            // 
            // ColumnID_User
            // 
            this.ColumnID_User.DataPropertyName = "id_user";
            this.ColumnID_User.HeaderText = "ID_User";
            this.ColumnID_User.Name = "ColumnID_User";
            this.ColumnID_User.Visible = false;
            // 
            // ColumnTipe_User
            // 
            this.ColumnTipe_User.DataPropertyName = "tipe_user";
            this.ColumnTipe_User.HeaderText = "Tipe_User";
            this.ColumnTipe_User.Name = "ColumnTipe_User";
            this.ColumnTipe_User.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnTipe_User.Visible = false;
            // 
            // ColumnUsername
            // 
            this.ColumnUsername.DataPropertyName = "username";
            this.ColumnUsername.HeaderText = "Username";
            this.ColumnUsername.Name = "ColumnUsername";
            this.ColumnUsername.Visible = false;
            // 
            // ColumnNamaUser
            // 
            this.ColumnNamaUser.DataPropertyName = "nama_user";
            this.ColumnNamaUser.HeaderText = "Nama Kasir";
            this.ColumnNamaUser.Name = "ColumnNamaUser";
            // 
            // ColumnPassword
            // 
            this.ColumnPassword.DataPropertyName = "password_hash";
            this.ColumnPassword.HeaderText = "Password";
            this.ColumnPassword.Name = "ColumnPassword";
            // 
            // ColumnDepartemen
            // 
            this.ColumnDepartemen.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ColumnDepartemen.DataPropertyName = "id_departemen";
            this.ColumnDepartemen.HeaderText = "Cabang";
            this.ColumnDepartemen.Name = "ColumnDepartemen";
            this.ColumnDepartemen.Width = 49;
            // 
            // ColumnIS_Aktif
            // 
            this.ColumnIS_Aktif.DataPropertyName = "is_aktif";
            this.ColumnIS_Aktif.HeaderText = "Aktif";
            this.ColumnIS_Aktif.Name = "ColumnIS_Aktif";
            this.ColumnIS_Aktif.Width = 50;
            // 
            // ColumnAksesRefund
            // 
            this.ColumnAksesRefund.DataPropertyName = "akses_refund";
            this.ColumnAksesRefund.FalseValue = "0";
            this.ColumnAksesRefund.HeaderText = "Akses Refund";
            this.ColumnAksesRefund.Name = "ColumnAksesRefund";
            this.ColumnAksesRefund.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnAksesRefund.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnAksesRefund.TrueValue = "1";
            this.ColumnAksesRefund.Width = 60;
            // 
            // ColumnAksesHargaJual
            // 
            this.ColumnAksesHargaJual.DataPropertyName = "akses_harga_jual";
            this.ColumnAksesHargaJual.FalseValue = "0";
            this.ColumnAksesHargaJual.HeaderText = "Akses Harga Jual";
            this.ColumnAksesHargaJual.Name = "ColumnAksesHargaJual";
            this.ColumnAksesHargaJual.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnAksesHargaJual.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnAksesHargaJual.TrueValue = "1";
            this.ColumnAksesHargaJual.Width = 60;
            // 
            // ColumnAksesDataPenjualan
            // 
            this.ColumnAksesDataPenjualan.DataPropertyName = "akses_data_penjualan";
            this.ColumnAksesDataPenjualan.FalseValue = "0";
            this.ColumnAksesDataPenjualan.HeaderText = "Akses Data Penjualan";
            this.ColumnAksesDataPenjualan.Name = "ColumnAksesDataPenjualan";
            this.ColumnAksesDataPenjualan.TrueValue = "1";
            this.ColumnAksesDataPenjualan.Width = 60;
            // 
            // ColumnCreated
            // 
            this.ColumnCreated.DataPropertyName = "created";
            this.ColumnCreated.HeaderText = "Created";
            this.ColumnCreated.Name = "ColumnCreated";
            this.ColumnCreated.Visible = false;
            // 
            // ColumnModified
            // 
            this.ColumnModified.DataPropertyName = "modified";
            this.ColumnModified.HeaderText = "Modified";
            this.ColumnModified.Name = "ColumnModified";
            this.ColumnModified.Visible = false;
            // 
            // KasirForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(547, 261);
            this.Name = "KasirForm";
            this.Text = "Kasir";
            this.Load += new System.EventHandler(this.KasirForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnID_User;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTipe_User;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnUsername;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNamaUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPassword;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColumnDepartemen;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnIS_Aktif;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnAksesRefund;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnAksesHargaJual;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnAksesDataPenjualan;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCreated;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnModified;


















    }
}
