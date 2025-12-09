namespace coursa4
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangePassword));
            labelAddClient = new Label();
            buttonCompletePassChange = new Button();
            textBoxNewPassword = new TextBox();
            textBoxOldPassword = new TextBox();
            textBoxNewPasswordRep = new TextBox();
            SuspendLayout();
            // 
            // labelAddClient
            // 
            labelAddClient.AutoSize = true;
            labelAddClient.Font = new Font("Garamond", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelAddClient.Location = new Point(80, 32);
            labelAddClient.Name = "labelAddClient";
            labelAddClient.Size = new Size(293, 50);
            labelAddClient.TabIndex = 1;
            labelAddClient.Text = "Смена пароля";
            // 
            // buttonCompletePassChange
            // 
            buttonCompletePassChange.Location = new Point(152, 280);
            buttonCompletePassChange.Name = "buttonCompletePassChange";
            buttonCompletePassChange.Size = new Size(152, 48);
            buttonCompletePassChange.TabIndex = 7;
            buttonCompletePassChange.Text = "Подтвердить";
            buttonCompletePassChange.UseVisualStyleBackColor = true;
            buttonCompletePassChange.Click += buttonCompletePassChange_Click;
            // 
            // textBoxNewPassword
            // 
            textBoxNewPassword.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxNewPassword.Location = new Point(136, 168);
            textBoxNewPassword.MaxLength = 15;
            textBoxNewPassword.Name = "textBoxNewPassword";
            textBoxNewPassword.PasswordChar = '*';
            textBoxNewPassword.PlaceholderText = "Новый пароль*";
            textBoxNewPassword.Size = new Size(184, 30);
            textBoxNewPassword.TabIndex = 9;
            textBoxNewPassword.UseSystemPasswordChar = true;
            // 
            // textBoxOldPassword
            // 
            textBoxOldPassword.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxOldPassword.Location = new Point(136, 120);
            textBoxOldPassword.MaxLength = 15;
            textBoxOldPassword.Name = "textBoxOldPassword";
            textBoxOldPassword.PasswordChar = '*';
            textBoxOldPassword.PlaceholderText = "Старый пароль*";
            textBoxOldPassword.Size = new Size(184, 30);
            textBoxOldPassword.TabIndex = 8;
            textBoxOldPassword.UseSystemPasswordChar = true;
            // 
            // textBoxNewPasswordRep
            // 
            textBoxNewPasswordRep.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxNewPasswordRep.Location = new Point(136, 216);
            textBoxNewPasswordRep.MaxLength = 15;
            textBoxNewPasswordRep.Name = "textBoxNewPasswordRep";
            textBoxNewPasswordRep.PasswordChar = '*';
            textBoxNewPasswordRep.PlaceholderText = "Повторите пароль*";
            textBoxNewPasswordRep.Size = new Size(184, 30);
            textBoxNewPasswordRep.TabIndex = 10;
            textBoxNewPasswordRep.UseSystemPasswordChar = true;
            // 
            // ChangePassword
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(453, 372);
            Controls.Add(textBoxNewPasswordRep);
            Controls.Add(textBoxNewPassword);
            Controls.Add(textBoxOldPassword);
            Controls.Add(buttonCompletePassChange);
            Controls.Add(labelAddClient);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ChangePassword";
            Text = "Смена пароля";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelAddClient;
        private Button buttonCompletePassChange;
        private TextBox textBoxNewPassword;
        private TextBox textBoxOldPassword;
        private TextBox textBoxNewPasswordRep;
    }
}