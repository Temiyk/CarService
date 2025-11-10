namespace coursa4
{
    partial class Authorization
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Authorization));
            buttonAuth = new Button();
            textBoxAuthLogin = new TextBox();
            textBoxPassAuth = new TextBox();
            labelAuth = new Label();
            buttonRegistration = new Button();
            SuspendLayout();
            // 
            // buttonAuth
            // 
            buttonAuth.Location = new Point(168, 272);
            buttonAuth.Name = "buttonAuth";
            buttonAuth.Size = new Size(128, 37);
            buttonAuth.TabIndex = 0;
            buttonAuth.Text = "Вход";
            buttonAuth.UseVisualStyleBackColor = true;
            buttonAuth.Click += buttonAuth_Click;
            // 
            // textBoxAuthLogin
            // 
            textBoxAuthLogin.Location = new Point(152, 160);
            textBoxAuthLogin.MaxLength = 15;
            textBoxAuthLogin.Name = "textBoxAuthLogin";
            textBoxAuthLogin.PlaceholderText = "Логин";
            textBoxAuthLogin.Size = new Size(160, 27);
            textBoxAuthLogin.TabIndex = 1;
            // 
            // textBoxPassAuth
            // 
            textBoxPassAuth.Location = new Point(152, 208);
            textBoxPassAuth.MaxLength = 25;
            textBoxPassAuth.Name = "textBoxPassAuth";
            textBoxPassAuth.PasswordChar = '*';
            textBoxPassAuth.PlaceholderText = "*********";
            textBoxPassAuth.Size = new Size(160, 27);
            textBoxPassAuth.TabIndex = 2;
            textBoxPassAuth.UseSystemPasswordChar = true;
            // 
            // labelAuth
            // 
            labelAuth.AutoSize = true;
            labelAuth.Font = new Font("Garamond", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelAuth.Location = new Point(48, 48);
            labelAuth.Name = "labelAuth";
            labelAuth.Size = new Size(379, 68);
            labelAuth.TabIndex = 3;
            labelAuth.Text = "Авторизация";
            // 
            // buttonRegistration
            // 
            buttonRegistration.Location = new Point(168, 336);
            buttonRegistration.Name = "buttonRegistration";
            buttonRegistration.Size = new Size(128, 37);
            buttonRegistration.TabIndex = 4;
            buttonRegistration.Text = "Регистрация";
            buttonRegistration.UseVisualStyleBackColor = true;
            buttonRegistration.Click += buttonRegistration_Click;
            // 
            // Authorization
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(474, 412);
            Controls.Add(buttonRegistration);
            Controls.Add(labelAuth);
            Controls.Add(textBoxPassAuth);
            Controls.Add(textBoxAuthLogin);
            Controls.Add(buttonAuth);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Authorization";
            Text = "MotorbreathMaster";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonAuth;
        private TextBox textBoxAuthLogin;
        private TextBox textBoxPassAuth;
        private Label labelAuth;
        private Button buttonRegistration;
    }
}
