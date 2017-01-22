namespace MCS_POS
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.UserComboBox = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.BackButton = new System.Windows.Forms.Button();
            this.buttonBackspace = new System.Windows.Forms.Button();
            this.buttonK0 = new System.Windows.Forms.Button();
            this.buttonK4 = new System.Windows.Forms.Button();
            this.buttonK7 = new System.Windows.Forms.Button();
            this.buttonK8 = new System.Windows.Forms.Button();
            this.buttonK9 = new System.Windows.Forms.Button();
            this.buttonK5 = new System.Windows.Forms.Button();
            this.buttonK6 = new System.Windows.Forms.Button();
            this.buttonK1 = new System.Windows.Forms.Button();
            this.buttonK2 = new System.Windows.Forms.Button();
            this.buttonK3 = new System.Windows.Forms.Button();
            this.ClearButton = new System.Windows.Forms.Button();
            this.SubmitButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.PasswordTextBox.Location = new System.Drawing.Point(99, 54);
            this.PasswordTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.Size = new System.Drawing.Size(199, 30);
            this.PasswordTextBox.TabIndex = 3;
            this.PasswordTextBox.UseSystemPasswordChar = true;
            this.PasswordTextBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PasswordTextBox_MouseClick);
            this.PasswordTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PasswordTextBox_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Otorisator :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(7, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Password :";
            // 
            // UserComboBox
            // 
            this.UserComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.UserComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.UserComboBox.FormattingEnabled = true;
            this.UserComboBox.Location = new System.Drawing.Point(99, 14);
            this.UserComboBox.Name = "UserComboBox";
            this.UserComboBox.Size = new System.Drawing.Size(199, 33);
            this.UserComboBox.TabIndex = 8;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.buttonBackspace, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonK0, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.buttonK4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonK7, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonK8, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonK9, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonK5, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonK6, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonK1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.buttonK2, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.buttonK3, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.ClearButton, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.SubmitButton, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.BackButton, 3, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(42, 91);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(256, 256);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // BackButton
            // 
            this.BackButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.BackButton.Location = new System.Drawing.Point(194, 194);
            this.BackButton.Margin = new System.Windows.Forms.Padding(2);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(60, 60);
            this.BackButton.TabIndex = 14;
            this.BackButton.TabStop = false;
            this.BackButton.Text = "Batal";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            this.BackButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button_MouseDown);
            this.BackButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button_MouseUp);
            // 
            // buttonBackspace
            // 
            this.buttonBackspace.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.buttonBackspace.Image = global::MCS_POS.Kasir.Properties.Resources.arrow_left_circle1;
            this.buttonBackspace.Location = new System.Drawing.Point(194, 2);
            this.buttonBackspace.Margin = new System.Windows.Forms.Padding(2);
            this.buttonBackspace.Name = "buttonBackspace";
            this.buttonBackspace.Size = new System.Drawing.Size(60, 60);
            this.buttonBackspace.TabIndex = 11;
            this.buttonBackspace.TabStop = false;
            this.buttonBackspace.UseVisualStyleBackColor = true;
            this.buttonBackspace.Click += new System.EventHandler(this.buttonBackspace_Click);
            this.buttonBackspace.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button_MouseDown);
            this.buttonBackspace.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button_MouseUp);
            // 
            // buttonK0
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.buttonK0, 2);
            this.buttonK0.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.buttonK0.Location = new System.Drawing.Point(2, 194);
            this.buttonK0.Margin = new System.Windows.Forms.Padding(2);
            this.buttonK0.Name = "buttonK0";
            this.buttonK0.Size = new System.Drawing.Size(124, 60);
            this.buttonK0.TabIndex = 16;
            this.buttonK0.TabStop = false;
            this.buttonK0.Text = "0";
            this.buttonK0.UseVisualStyleBackColor = true;
            this.buttonK0.Click += new System.EventHandler(this.buttonK0_Click);
            this.buttonK0.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button_MouseDown);
            this.buttonK0.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button_MouseUp);
            // 
            // buttonK4
            // 
            this.buttonK4.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.buttonK4.Location = new System.Drawing.Point(2, 66);
            this.buttonK4.Margin = new System.Windows.Forms.Padding(2);
            this.buttonK4.Name = "buttonK4";
            this.buttonK4.Size = new System.Drawing.Size(60, 60);
            this.buttonK4.TabIndex = 10;
            this.buttonK4.TabStop = false;
            this.buttonK4.Text = "4";
            this.buttonK4.UseVisualStyleBackColor = true;
            this.buttonK4.Click += new System.EventHandler(this.buttonK4_Click);
            this.buttonK4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button_MouseDown);
            this.buttonK4.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button_MouseUp);
            // 
            // buttonK7
            // 
            this.buttonK7.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.buttonK7.Location = new System.Drawing.Point(2, 2);
            this.buttonK7.Margin = new System.Windows.Forms.Padding(2);
            this.buttonK7.Name = "buttonK7";
            this.buttonK7.Size = new System.Drawing.Size(60, 60);
            this.buttonK7.TabIndex = 7;
            this.buttonK7.TabStop = false;
            this.buttonK7.Text = "7";
            this.buttonK7.UseVisualStyleBackColor = true;
            this.buttonK7.Click += new System.EventHandler(this.buttonK7_Click);
            this.buttonK7.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button_MouseDown);
            this.buttonK7.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button_MouseUp);
            // 
            // buttonK8
            // 
            this.buttonK8.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.buttonK8.Location = new System.Drawing.Point(66, 2);
            this.buttonK8.Margin = new System.Windows.Forms.Padding(2);
            this.buttonK8.Name = "buttonK8";
            this.buttonK8.Size = new System.Drawing.Size(60, 60);
            this.buttonK8.TabIndex = 8;
            this.buttonK8.TabStop = false;
            this.buttonK8.Text = "8";
            this.buttonK8.UseVisualStyleBackColor = true;
            this.buttonK8.Click += new System.EventHandler(this.buttonK8_Click);
            this.buttonK8.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button_MouseDown);
            this.buttonK8.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button_MouseUp);
            // 
            // buttonK9
            // 
            this.buttonK9.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.buttonK9.Location = new System.Drawing.Point(130, 2);
            this.buttonK9.Margin = new System.Windows.Forms.Padding(2);
            this.buttonK9.Name = "buttonK9";
            this.buttonK9.Size = new System.Drawing.Size(60, 60);
            this.buttonK9.TabIndex = 9;
            this.buttonK9.TabStop = false;
            this.buttonK9.Text = "9";
            this.buttonK9.UseVisualStyleBackColor = true;
            this.buttonK9.Click += new System.EventHandler(this.buttonK9_Click);
            this.buttonK9.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button_MouseDown);
            this.buttonK9.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button_MouseUp);
            // 
            // buttonK5
            // 
            this.buttonK5.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.buttonK5.Location = new System.Drawing.Point(66, 66);
            this.buttonK5.Margin = new System.Windows.Forms.Padding(2);
            this.buttonK5.Name = "buttonK5";
            this.buttonK5.Size = new System.Drawing.Size(60, 60);
            this.buttonK5.TabIndex = 11;
            this.buttonK5.TabStop = false;
            this.buttonK5.Text = "5";
            this.buttonK5.UseVisualStyleBackColor = true;
            this.buttonK5.Click += new System.EventHandler(this.buttonK5_Click);
            this.buttonK5.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button_MouseDown);
            this.buttonK5.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button_MouseUp);
            // 
            // buttonK6
            // 
            this.buttonK6.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.buttonK6.Location = new System.Drawing.Point(130, 66);
            this.buttonK6.Margin = new System.Windows.Forms.Padding(2);
            this.buttonK6.Name = "buttonK6";
            this.buttonK6.Size = new System.Drawing.Size(60, 60);
            this.buttonK6.TabIndex = 12;
            this.buttonK6.TabStop = false;
            this.buttonK6.Text = "6";
            this.buttonK6.UseVisualStyleBackColor = true;
            this.buttonK6.Click += new System.EventHandler(this.buttonK6_Click);
            this.buttonK6.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button_MouseDown);
            this.buttonK6.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button_MouseUp);
            // 
            // buttonK1
            // 
            this.buttonK1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.buttonK1.Location = new System.Drawing.Point(2, 130);
            this.buttonK1.Margin = new System.Windows.Forms.Padding(2);
            this.buttonK1.Name = "buttonK1";
            this.buttonK1.Size = new System.Drawing.Size(60, 60);
            this.buttonK1.TabIndex = 13;
            this.buttonK1.TabStop = false;
            this.buttonK1.Text = "1";
            this.buttonK1.UseVisualStyleBackColor = true;
            this.buttonK1.Click += new System.EventHandler(this.buttonK1_Click);
            this.buttonK1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button_MouseDown);
            this.buttonK1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button_MouseUp);
            // 
            // buttonK2
            // 
            this.buttonK2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.buttonK2.Location = new System.Drawing.Point(66, 130);
            this.buttonK2.Margin = new System.Windows.Forms.Padding(2);
            this.buttonK2.Name = "buttonK2";
            this.buttonK2.Size = new System.Drawing.Size(60, 60);
            this.buttonK2.TabIndex = 14;
            this.buttonK2.TabStop = false;
            this.buttonK2.Text = "2";
            this.buttonK2.UseVisualStyleBackColor = true;
            this.buttonK2.Click += new System.EventHandler(this.buttonK2_Click);
            this.buttonK2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button_MouseDown);
            this.buttonK2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button_MouseUp);
            // 
            // buttonK3
            // 
            this.buttonK3.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.buttonK3.Location = new System.Drawing.Point(130, 130);
            this.buttonK3.Margin = new System.Windows.Forms.Padding(2);
            this.buttonK3.Name = "buttonK3";
            this.buttonK3.Size = new System.Drawing.Size(60, 60);
            this.buttonK3.TabIndex = 15;
            this.buttonK3.TabStop = false;
            this.buttonK3.Text = "3";
            this.buttonK3.UseVisualStyleBackColor = true;
            this.buttonK3.Click += new System.EventHandler(this.buttonK3_Click);
            this.buttonK3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button_MouseDown);
            this.buttonK3.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button_MouseUp);
            // 
            // ClearButton
            // 
            this.ClearButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ClearButton.Location = new System.Drawing.Point(130, 194);
            this.ClearButton.Margin = new System.Windows.Forms.Padding(2);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(60, 60);
            this.ClearButton.TabIndex = 13;
            this.ClearButton.TabStop = false;
            this.ClearButton.Text = "Clear";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            this.ClearButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button_MouseDown);
            this.ClearButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button_MouseUp);
            // 
            // SubmitButton
            // 
            this.SubmitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.SubmitButton.Location = new System.Drawing.Point(194, 66);
            this.SubmitButton.Margin = new System.Windows.Forms.Padding(2);
            this.SubmitButton.Name = "SubmitButton";
            this.tableLayoutPanel1.SetRowSpan(this.SubmitButton, 2);
            this.SubmitButton.Size = new System.Drawing.Size(60, 124);
            this.SubmitButton.TabIndex = 18;
            this.SubmitButton.TabStop = false;
            this.SubmitButton.Text = "OK";
            this.SubmitButton.UseVisualStyleBackColor = true;
            this.SubmitButton.Click += new System.EventHandler(this.LoginButton_Click);
            this.SubmitButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button_MouseDown);
            this.SubmitButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button_MouseUp);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 363);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.UserComboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PasswordTextBox);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "LoginForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Otorisasi";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox UserComboBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Button buttonBackspace;
        private System.Windows.Forms.Button buttonK0;
        private System.Windows.Forms.Button buttonK4;
        private System.Windows.Forms.Button buttonK7;
        private System.Windows.Forms.Button buttonK8;
        private System.Windows.Forms.Button buttonK9;
        private System.Windows.Forms.Button buttonK5;
        private System.Windows.Forms.Button buttonK6;
        private System.Windows.Forms.Button buttonK1;
        private System.Windows.Forms.Button buttonK2;
        private System.Windows.Forms.Button buttonK3;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.Button SubmitButton;
    }
}