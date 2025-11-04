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
            buttonCompleteAdding = new Button();
            textBoxNewPassword = new TextBox();
            textBoxOldPassword = new TextBox();
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
            // buttonCompleteAdding
            // 
            buttonCompleteAdding.Location = new Point(152, 248);
            buttonCompleteAdding.Name = "buttonCompleteAdding";
            buttonCompleteAdding.Size = new Size(152, 48);
            buttonCompleteAdding.TabIndex = 7;
            buttonCompleteAdding.Text = "Подтвердить";
            buttonCompleteAdding.UseVisualStyleBackColor = true;
            // 
            // textBoxNewPassword
            // 
            textBoxNewPassword.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxNewPassword.Location = new Point(136, 176);
            textBoxNewPassword.MaxLength = 15;
            textBoxNewPassword.Name = "textBoxNewPassword";
            textBoxNewPassword.PasswordChar = '*';
            textBoxNewPassword.PlaceholderText = "Новый_пароль";
            textBoxNewPassword.Size = new Size(184, 30);
            textBoxNewPassword.TabIndex = 9;
            // 
            // textBoxOldPassword
            // 
            textBoxOldPassword.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxOldPassword.Location = new Point(136, 120);
            textBoxOldPassword.MaxLength = 15;
            textBoxOldPassword.Name = "textBoxOldPassword";
            textBoxOldPassword.PasswordChar = '*';
            textBoxOldPassword.PlaceholderText = "Старый_пароль";
            textBoxOldPassword.Size = new Size(184, 30);
            textBoxOldPassword.TabIndex = 8;
            // 
            // ChangePassword
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(453, 371);
            Controls.Add(textBoxNewPassword);
            Controls.Add(textBoxOldPassword);
            Controls.Add(buttonCompleteAdding);
            Controls.Add(labelAddClient);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ChangePassword";
            Text = "MotorbreathMaster";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelAddClient;
        private Button buttonCompleteAdding;
        private TextBox textBoxNewPassword;
        private TextBox textBoxOldPassword;
    }
}