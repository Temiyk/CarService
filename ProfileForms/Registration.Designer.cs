namespace coursa4.Data
{
    partial class Registration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Registration));
            textBoxNewUserPassRep = new TextBox();
            buttonAddVehicle = new Button();
            textBoxNewUserPass = new TextBox();
            textBoxNewUserLogin = new TextBox();
            textBoxNewUserName = new TextBox();
            labelNewUser = new Label();
            buttonRegistrationComplete = new Button();
            SuspendLayout();
            // 
            // textBoxNewUserPassRep
            // 
            textBoxNewUserPassRep.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxNewUserPassRep.Location = new Point(144, 272);
            textBoxNewUserPassRep.MaxLength = 15;
            textBoxNewUserPassRep.Name = "textBoxNewUserPassRep";
            textBoxNewUserPassRep.PasswordChar = '*';
            textBoxNewUserPassRep.PlaceholderText = "Повторите пароль*";
            textBoxNewUserPassRep.Size = new Size(230, 30);
            textBoxNewUserPassRep.TabIndex = 25;
            // 
            // buttonAddVehicle
            // 
            buttonAddVehicle.Location = new Point(184, 656);
            buttonAddVehicle.Name = "buttonAddVehicle";
            buttonAddVehicle.Size = new Size(152, 48);
            buttonAddVehicle.TabIndex = 24;
            buttonAddVehicle.Text = "Подтвердить";
            buttonAddVehicle.UseVisualStyleBackColor = true;
            // 
            // textBoxNewUserPass
            // 
            textBoxNewUserPass.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxNewUserPass.Location = new Point(144, 224);
            textBoxNewUserPass.MaxLength = 15;
            textBoxNewUserPass.Name = "textBoxNewUserPass";
            textBoxNewUserPass.PasswordChar = '*';
            textBoxNewUserPass.PlaceholderText = "Пароль*";
            textBoxNewUserPass.Size = new Size(230, 30);
            textBoxNewUserPass.TabIndex = 22;
            // 
            // textBoxNewUserLogin
            // 
            textBoxNewUserLogin.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxNewUserLogin.Location = new Point(144, 176);
            textBoxNewUserLogin.MaxLength = 15;
            textBoxNewUserLogin.Name = "textBoxNewUserLogin";
            textBoxNewUserLogin.PlaceholderText = "Логин*";
            textBoxNewUserLogin.Size = new Size(230, 30);
            textBoxNewUserLogin.TabIndex = 21;
            // 
            // textBoxNewUserName
            // 
            textBoxNewUserName.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxNewUserName.Location = new Point(144, 128);
            textBoxNewUserName.MaxLength = 20;
            textBoxNewUserName.Name = "textBoxNewUserName";
            textBoxNewUserName.PlaceholderText = "Имя*";
            textBoxNewUserName.Size = new Size(230, 30);
            textBoxNewUserName.TabIndex = 20;
            // 
            // labelNewUser
            // 
            labelNewUser.AutoSize = true;
            labelNewUser.Font = new Font("Garamond", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelNewUser.Location = new Point(128, 32);
            labelNewUser.Name = "labelNewUser";
            labelNewUser.Size = new Size(271, 50);
            labelNewUser.TabIndex = 19;
            labelNewUser.Text = "Регистрация";
            // 
            // buttonRegistrationComplete
            // 
            buttonRegistrationComplete.Location = new Point(184, 344);
            buttonRegistrationComplete.Name = "buttonRegistrationComplete";
            buttonRegistrationComplete.Size = new Size(152, 48);
            buttonRegistrationComplete.TabIndex = 19;
            buttonRegistrationComplete.Text = "Подтвердить";
            buttonRegistrationComplete.UseVisualStyleBackColor = true;
            buttonRegistrationComplete.Click += buttonRegistrationComplete_Click;
            // 
            // Registration
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(517, 429);
            Controls.Add(buttonRegistrationComplete);
            Controls.Add(textBoxNewUserPassRep);
            Controls.Add(buttonAddVehicle);
            Controls.Add(textBoxNewUserPass);
            Controls.Add(textBoxNewUserLogin);
            Controls.Add(textBoxNewUserName);
            Controls.Add(labelNewUser);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Registration";
            Text = "MotorbreathMaster";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxNewUserPassRep;
        private Button buttonAddVehicle;
        private TextBox textBoxNewUserPass;
        private TextBox textBoxNewUserLogin;
        private TextBox textBoxNewUserName;
        private Label labelNewUser;
        private Button buttonRegistrationComplete;
    }
}