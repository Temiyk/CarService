namespace coursa4
{
    partial class MainMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            panelSideBar = new Panel();
            buttonClients = new Button();
            buttonVehicles = new Button();
            buttonOrders = new Button();
            buttonEmployees = new Button();
            buttonServices = new Button();
            buttonReports = new Button();
            buttonLogout = new Button();
            buttonExit = new Button();
            buttonChangePassword = new Button();
            panelHeader = new Panel();
            labelTitle = new Label();
            labelTime = new Label();
            labelDate = new Label();
            labelRole = new Label();
            labelWelcome = new Label();
            panelSideBar.SuspendLayout();
            panelHeader.SuspendLayout();
            SuspendLayout();
            // 
            // panelSideBar
            // 
            panelSideBar.BackColor = Color.FromArgb(40, 40, 40);
            panelSideBar.Controls.Add(buttonClients);
            panelSideBar.Dock = DockStyle.Left;
            panelSideBar.Location = new Point(0, 0);
            panelSideBar.Name = "panelSideBar";
            panelSideBar.Size = new Size(220, 753);
            panelSideBar.TabIndex = 0;
            // 
            // buttonClients
            // 
            buttonClients.BackColor = Color.SteelBlue;
            buttonClients.FlatAppearance.BorderSize = 0;
            buttonClients.FlatStyle = FlatStyle.Flat;
            buttonClients.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            buttonClients.ForeColor = Color.White;
            buttonClients.ImageAlign = ContentAlignment.MiddleLeft;
            buttonClients.Location = new Point(10, 120);
            buttonClients.Name = "buttonClients";
            buttonClients.Size = new Size(200, 50);
            buttonClients.TabIndex = 1;
            buttonClients.Text = "Клиенты";
            buttonClients.TextAlign = ContentAlignment.MiddleLeft;
            buttonClients.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonClients.UseVisualStyleBackColor = false;
            buttonClients.Click += buttonClients_Click;
            // 
            // buttonVehicles
            // 
            buttonVehicles.BackColor = Color.SteelBlue;
            buttonVehicles.FlatAppearance.BorderSize = 0;
            buttonVehicles.FlatStyle = FlatStyle.Flat;
            buttonVehicles.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            buttonVehicles.ForeColor = Color.White;
            buttonVehicles.ImageAlign = ContentAlignment.MiddleLeft;
            buttonVehicles.Location = new Point(10, 180);
            buttonVehicles.Name = "buttonVehicles";
            buttonVehicles.Size = new Size(200, 50);
            buttonVehicles.TabIndex = 2;
            buttonVehicles.Text = "Автомобили";
            buttonVehicles.TextAlign = ContentAlignment.MiddleLeft;
            buttonVehicles.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonVehicles.UseVisualStyleBackColor = false;
            buttonVehicles.Click += buttonVehicles_Click;
            // 
            // buttonOrders
            // 
            buttonOrders.BackColor = Color.SteelBlue;
            buttonOrders.FlatAppearance.BorderSize = 0;
            buttonOrders.FlatStyle = FlatStyle.Flat;
            buttonOrders.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            buttonOrders.ForeColor = Color.White;
            buttonOrders.ImageAlign = ContentAlignment.MiddleLeft;
            buttonOrders.Location = new Point(10, 240);
            buttonOrders.Name = "buttonOrders";
            buttonOrders.Size = new Size(200, 50);
            buttonOrders.TabIndex = 3;
            buttonOrders.Text = "Заказы";
            buttonOrders.TextAlign = ContentAlignment.MiddleLeft;
            buttonOrders.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonOrders.UseVisualStyleBackColor = false;
            buttonOrders.Click += buttonOrders_Click;
            // 
            // buttonEmployees
            // 
            buttonEmployees.BackColor = Color.SteelBlue;
            buttonEmployees.FlatAppearance.BorderSize = 0;
            buttonEmployees.FlatStyle = FlatStyle.Flat;
            buttonEmployees.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            buttonEmployees.ForeColor = Color.White;
            buttonEmployees.ImageAlign = ContentAlignment.MiddleLeft;
            buttonEmployees.Location = new Point(10, 300);
            buttonEmployees.Name = "buttonEmployees";
            buttonEmployees.Size = new Size(200, 50);
            buttonEmployees.TabIndex = 4;
            buttonEmployees.Text = "Сотрудники";
            buttonEmployees.TextAlign = ContentAlignment.MiddleLeft;
            buttonEmployees.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonEmployees.UseVisualStyleBackColor = false;
            buttonEmployees.Click += buttonEmployees_Click;
            // 
            // buttonServices
            // 
            buttonServices.BackColor = Color.SteelBlue;
            buttonServices.FlatAppearance.BorderSize = 0;
            buttonServices.FlatStyle = FlatStyle.Flat;
            buttonServices.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            buttonServices.ForeColor = Color.White;
            buttonServices.ImageAlign = ContentAlignment.MiddleLeft;
            buttonServices.Location = new Point(10, 360);
            buttonServices.Name = "buttonServices";
            buttonServices.Size = new Size(200, 50);
            buttonServices.TabIndex = 5;
            buttonServices.Text = "Услуги";
            buttonServices.TextAlign = ContentAlignment.MiddleLeft;
            buttonServices.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonServices.UseVisualStyleBackColor = false;
            buttonServices.Click += buttonServices_Click;
            // 
            // buttonReports
            // 
            buttonReports.BackColor = Color.SteelBlue;
            buttonReports.FlatAppearance.BorderSize = 0;
            buttonReports.FlatStyle = FlatStyle.Flat;
            buttonReports.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            buttonReports.ForeColor = Color.White;
            buttonReports.ImageAlign = ContentAlignment.MiddleLeft;
            buttonReports.Location = new Point(10, 420);
            buttonReports.Name = "buttonReports";
            buttonReports.Size = new Size(200, 50);
            buttonReports.TabIndex = 6;
            buttonReports.Text = "Отчёты";
            buttonReports.TextAlign = ContentAlignment.MiddleLeft;
            buttonReports.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonReports.UseVisualStyleBackColor = false;
            buttonReports.Click += buttonReports_Click;
            // 
            // buttonLogout
            // 
            buttonLogout.BackColor = Color.SteelBlue;
            buttonLogout.FlatAppearance.BorderSize = 0;
            buttonLogout.FlatStyle = FlatStyle.Flat;
            buttonLogout.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            buttonLogout.ForeColor = Color.White;
            buttonLogout.ImageAlign = ContentAlignment.MiddleLeft;
            buttonLogout.Location = new Point(10, 600);
            buttonLogout.Name = "buttonLogout";
            buttonLogout.Size = new Size(200, 40);
            buttonLogout.TabIndex = 7;
            buttonLogout.Text = "Выйти";
            buttonLogout.TextAlign = ContentAlignment.MiddleLeft;
            buttonLogout.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonLogout.UseVisualStyleBackColor = false;
            buttonLogout.Click += buttonLogout_Click;
            // 
            // buttonExit
            // 
            buttonExit.BackColor = Color.SteelBlue;
            buttonExit.FlatAppearance.BorderSize = 0;
            buttonExit.FlatStyle = FlatStyle.Flat;
            buttonExit.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            buttonExit.ForeColor = Color.White;
            buttonExit.ImageAlign = ContentAlignment.MiddleLeft;
            buttonExit.Location = new Point(10, 650);
            buttonExit.Name = "buttonExit";
            buttonExit.Size = new Size(200, 40);
            buttonExit.TabIndex = 8;
            buttonExit.Text = "Закрыть";
            buttonExit.TextAlign = ContentAlignment.MiddleLeft;
            buttonExit.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonExit.UseVisualStyleBackColor = false;
            // 
            // buttonChangePassword
            // 
            buttonChangePassword.BackColor = Color.SteelBlue;
            buttonChangePassword.FlatAppearance.BorderSize = 0;
            buttonChangePassword.FlatStyle = FlatStyle.Flat;
            buttonChangePassword.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            buttonChangePassword.ForeColor = Color.White;
            buttonChangePassword.ImageAlign = ContentAlignment.MiddleLeft;
            buttonChangePassword.Location = new Point(10, 550);
            buttonChangePassword.Name = "buttonChangePassword";
            buttonChangePassword.Size = new Size(200, 40);
            buttonChangePassword.TabIndex = 9;
            buttonChangePassword.Text = "Сменить пароль";
            buttonChangePassword.TextAlign = ContentAlignment.MiddleLeft;
            buttonChangePassword.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonChangePassword.UseVisualStyleBackColor = false;
            buttonChangePassword.Click += buttonChangePassword_Click;
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(30, 30, 30);
            panelHeader.Controls.Add(labelTitle);
            panelHeader.Controls.Add(labelTime);
            panelHeader.Controls.Add(labelDate);
            panelHeader.Controls.Add(labelRole);
            panelHeader.Controls.Add(labelWelcome);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(220, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(962, 100);
            panelHeader.TabIndex = 10;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Garamond", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTitle.ForeColor = Color.SteelBlue;
            labelTitle.Location = new Point(30, 25);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(354, 45);
            labelTitle.TabIndex = 16;
            labelTitle.Text = "MotorbreathMaster";
            // 
            // labelTime
            // 
            labelTime.AutoSize = true;
            labelTime.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelTime.ForeColor = Color.White;
            labelTime.Location = new Point(800, 50);
            labelTime.Name = "labelTime";
            labelTime.Size = new Size(60, 23);
            labelTime.TabIndex = 15;
            labelTime.Text = "Время";
            // 
            // labelDate
            // 
            labelDate.AutoSize = true;
            labelDate.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelDate.ForeColor = Color.LightGray;
            labelDate.Location = new Point(800, 20);
            labelDate.Name = "labelDate";
            labelDate.Size = new Size(47, 23);
            labelDate.TabIndex = 14;
            labelDate.Text = "Дата";
            // 
            // labelRole
            // 
            labelRole.AutoSize = true;
            labelRole.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelRole.ForeColor = Color.LightGray;
            labelRole.Location = new Point(500, 50);
            labelRole.Name = "labelRole";
            labelRole.Size = new Size(180, 23);
            labelRole.TabIndex = 13;
            labelRole.Text = "Роль: Администратор";
            // 
            // labelWelcome
            // 
            labelWelcome.AutoSize = true;
            labelWelcome.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelWelcome.ForeColor = Color.White;
            labelWelcome.Location = new Point(500, 20);
            labelWelcome.Name = "labelWelcome";
            labelWelcome.Size = new Size(182, 25);
            labelWelcome.TabIndex = 12;
            labelWelcome.Text = "Добро пожаловать";
            // 
            // MainMenu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1182, 753);
            Controls.Add(panelHeader);
            Controls.Add(buttonChangePassword);
            Controls.Add(buttonExit);
            Controls.Add(buttonLogout);
            Controls.Add(buttonReports);
            Controls.Add(buttonServices);
            Controls.Add(buttonEmployees);
            Controls.Add(buttonOrders);
            Controls.Add(buttonVehicles);
            Controls.Add(panelSideBar);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(1200, 800);
            Name = "MainMenu";
            RightToLeftLayout = true;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MotorbreathMaster - Главное меню";
            panelSideBar.ResumeLayout(false);
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelSideBar;
        private Button buttonClients;
        private Button buttonVehicles;
        private Button buttonOrders;
        private Button buttonEmployees;
        private Button buttonServices;
        private Button buttonReports;
        private Button buttonLogout;
        private Button buttonExit;
        private Button buttonChangePassword;
        private Panel panelHeader;
        private Label labelWelcome;
        private Label labelDate;
        private Label labelRole;
        private Label labelTime;
        private Label labelTitle;
    }
}