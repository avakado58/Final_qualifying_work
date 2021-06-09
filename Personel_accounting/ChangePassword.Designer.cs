namespace Personel_accounting
{
    partial class ChangePassword
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
            this.butСhangePassword = new System.Windows.Forms.Button();
            this.textOldPassword = new System.Windows.Forms.TextBox();
            this.textNewPassword = new System.Windows.Forms.TextBox();
            this.labelOldPassword = new System.Windows.Forms.Label();
            this.labelNewPassword = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // butСhangePassword
            // 
            this.butСhangePassword.Location = new System.Drawing.Point(131, 144);
            this.butСhangePassword.Name = "butСhangePassword";
            this.butСhangePassword.Size = new System.Drawing.Size(105, 37);
            this.butСhangePassword.TabIndex = 0;
            this.butСhangePassword.Text = "Изменить";
            this.butСhangePassword.UseVisualStyleBackColor = true;
            // 
            // textOldPassword
            // 
            this.textOldPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textOldPassword.Location = new System.Drawing.Point(12, 43);
            this.textOldPassword.Name = "textOldPassword";
            this.textOldPassword.PasswordChar = '*';
            this.textOldPassword.Size = new System.Drawing.Size(361, 29);
            this.textOldPassword.TabIndex = 1;
            // 
            // textNewPassword
            // 
            this.textNewPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textNewPassword.Location = new System.Drawing.Point(12, 109);
            this.textNewPassword.Name = "textNewPassword";
            this.textNewPassword.PasswordChar = '*';
            this.textNewPassword.Size = new System.Drawing.Size(361, 29);
            this.textNewPassword.TabIndex = 2;
            // 
            // labelOldPassword
            // 
            this.labelOldPassword.AutoSize = true;
            this.labelOldPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelOldPassword.Location = new System.Drawing.Point(78, 9);
            this.labelOldPassword.Name = "labelOldPassword";
            this.labelOldPassword.Size = new System.Drawing.Size(227, 24);
            this.labelOldPassword.TabIndex = 3;
            this.labelOldPassword.Text = "Ввидите старый пароль";
            // 
            // labelNewPassword
            // 
            this.labelNewPassword.AutoSize = true;
            this.labelNewPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelNewPassword.Location = new System.Drawing.Point(78, 75);
            this.labelNewPassword.Name = "labelNewPassword";
            this.labelNewPassword.Size = new System.Drawing.Size(219, 24);
            this.labelNewPassword.TabIndex = 4;
            this.labelNewPassword.Text = "Ввидите новый пароль";
            // 
            // ChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 191);
            this.Controls.Add(this.labelNewPassword);
            this.Controls.Add(this.labelOldPassword);
            this.Controls.Add(this.textNewPassword);
            this.Controls.Add(this.textOldPassword);
            this.Controls.Add(this.butСhangePassword);
            this.MaximumSize = new System.Drawing.Size(401, 230);
            this.MinimumSize = new System.Drawing.Size(401, 230);
            this.Name = "ChangePassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Смена пароля";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butСhangePassword;
        private System.Windows.Forms.TextBox textOldPassword;
        private System.Windows.Forms.TextBox textNewPassword;
        private System.Windows.Forms.Label labelOldPassword;
        private System.Windows.Forms.Label labelNewPassword;
    }
}