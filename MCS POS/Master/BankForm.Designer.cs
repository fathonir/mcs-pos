namespace MCS_POS.Master
{
    partial class BankForm
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
            this.ColumnPK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCreated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnModified = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.SuspendLayout();
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(297, 12);
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(297, 41);
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // DGV
            // 
            this.DGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnPK,
            this.ColumnBank,
            this.ColumnCreated,
            this.ColumnModified});
            this.DGV.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_CellValueChanged);
            // 
            // TambahButton
            // 
            this.TambahButton.Location = new System.Drawing.Point(297, 70);
            this.TambahButton.Visible = false;
            // 
            // EditButton
            // 
            this.EditButton.Location = new System.Drawing.Point(297, 99);
            this.EditButton.Visible = false;
            // 
            // BackButton
            // 
            this.BackButton.Visible = false;
            // 
            // ColumnPK
            // 
            this.ColumnPK.DataPropertyName = "id_bank";
            this.ColumnPK.HeaderText = "PK";
            this.ColumnPK.Name = "ColumnPK";
            this.ColumnPK.Visible = false;
            // 
            // ColumnBank
            // 
            this.ColumnBank.DataPropertyName = "nama_bank";
            this.ColumnBank.HeaderText = "Bank";
            this.ColumnBank.Name = "ColumnBank";
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
            // BankForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(384, 261);
            this.Name = "BankForm";
            this.Text = "Bank";
            this.Load += new System.EventHandler(this.BankForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPK;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnBank;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCreated;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnModified;

    }
}
