namespace coursa4
{
    partial class AddOrder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddOrder));
            buttonAddOrder = new Button();
            labelNewOrder = new Label();
            groupBoxClient = new GroupBox();
            comboBoxClients = new ComboBox();
            buttonAddNewClient = new Button();
            labelСlient = new Label();
            groupBoxVehicle = new GroupBox();
            comboBoxVehicles = new ComboBox();
            labelVehicle = new Label();
            buttonAddNewVehicle = new Button();
            groupBoxServices = new GroupBox();
            dataGridViewServices = new DataGridView();
            colSelect = new DataGridViewCheckBoxColumn();
            colServiceName = new DataGridViewTextBoxColumn();
            colPrice = new DataGridViewTextBoxColumn();
            colSpecialization = new DataGridViewTextBoxColumn();
            labelTotalPrice = new Label();
            textBoxTotalPrice = new TextBox();
            groupBoxDates = new GroupBox();
            dateTimePickerEstimatedDate = new DateTimePicker();
            dateTimePickerAcceptanceDate = new DateTimePicker();
            labelEstimatedDate = new Label();
            labelAcceptDate = new Label();
            groupBoxEmployeeSelection = new GroupBox();
            buttonAutoAssignEmployees = new Button();
            panelEmployeeControls = new Panel();
            groupBoxClient.SuspendLayout();
            groupBoxVehicle.SuspendLayout();
            groupBoxServices.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewServices).BeginInit();
            groupBoxDates.SuspendLayout();
            groupBoxEmployeeSelection.SuspendLayout();
            SuspendLayout();
            // 
            // buttonAddOrder
            // 
            buttonAddOrder.BackColor = Color.SteelBlue;
            buttonAddOrder.Location = new Point(296, 936);
            buttonAddOrder.Name = "buttonAddOrder";
            buttonAddOrder.Size = new Size(200, 50);
            buttonAddOrder.TabIndex = 22;
            buttonAddOrder.Text = "Создать заказ";
            buttonAddOrder.UseVisualStyleBackColor = false;
            buttonAddOrder.Click += buttonAddOrder_Click;
            // 
            // labelNewOrder
            // 
            labelNewOrder.AutoSize = true;
            labelNewOrder.Font = new Font("Garamond", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelNewOrder.Location = new Point(250, 20);
            labelNewOrder.Name = "labelNewOrder";
            labelNewOrder.Size = new Size(277, 50);
            labelNewOrder.TabIndex = 18;
            labelNewOrder.Text = "Новый заказ";
            // 
            // groupBoxClient
            // 
            groupBoxClient.Controls.Add(comboBoxClients);
            groupBoxClient.Controls.Add(buttonAddNewClient);
            groupBoxClient.Controls.Add(labelСlient);
            groupBoxClient.Location = new Point(50, 90);
            groupBoxClient.Name = "groupBoxClient";
            groupBoxClient.Size = new Size(700, 100);
            groupBoxClient.TabIndex = 23;
            groupBoxClient.TabStop = false;
            groupBoxClient.Text = "Клиент";
            // 
            // comboBoxClients
            // 
            comboBoxClients.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxClients.FormattingEnabled = true;
            comboBoxClients.Location = new Point(150, 45);
            comboBoxClients.Name = "comboBoxClients";
            comboBoxClients.Size = new Size(350, 28);
            comboBoxClients.TabIndex = 2;
            comboBoxClients.SelectedIndexChanged += comboBoxClients_SelectedIndexChanged;
            // 
            // buttonAddNewClient
            // 
            buttonAddNewClient.BackColor = Color.LightSeaGreen;
            buttonAddNewClient.Location = new Point(550, 40);
            buttonAddNewClient.Name = "buttonAddNewClient";
            buttonAddNewClient.Size = new Size(120, 35);
            buttonAddNewClient.TabIndex = 1;
            buttonAddNewClient.Text = "Добавить...";
            buttonAddNewClient.UseVisualStyleBackColor = false;
            buttonAddNewClient.Click += buttonAddNewClient_Click;
            // 
            // labelСlient
            // 
            labelСlient.AutoSize = true;
            labelСlient.Location = new Point(30, 45);
            labelСlient.Name = "labelСlient";
            labelСlient.Size = new Size(58, 20);
            labelСlient.TabIndex = 0;
            labelСlient.Text = "Клиент";
            // 
            // groupBoxVehicle
            // 
            groupBoxVehicle.Controls.Add(comboBoxVehicles);
            groupBoxVehicle.Controls.Add(labelVehicle);
            groupBoxVehicle.Controls.Add(buttonAddNewVehicle);
            groupBoxVehicle.Location = new Point(50, 210);
            groupBoxVehicle.Name = "groupBoxVehicle";
            groupBoxVehicle.Size = new Size(700, 100);
            groupBoxVehicle.TabIndex = 24;
            groupBoxVehicle.TabStop = false;
            groupBoxVehicle.Text = "Автомобиль";
            // 
            // comboBoxVehicles
            // 
            comboBoxVehicles.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxVehicles.FormattingEnabled = true;
            comboBoxVehicles.Location = new Point(150, 45);
            comboBoxVehicles.Name = "comboBoxVehicles";
            comboBoxVehicles.Size = new Size(350, 28);
            comboBoxVehicles.TabIndex = 2;
            // 
            // labelVehicle
            // 
            labelVehicle.AutoSize = true;
            labelVehicle.Location = new Point(30, 45);
            labelVehicle.Name = "labelVehicle";
            labelVehicle.Size = new Size(96, 20);
            labelVehicle.TabIndex = 1;
            labelVehicle.Text = "Автомобиль";
            // 
            // buttonAddNewVehicle
            // 
            buttonAddNewVehicle.BackColor = Color.LightSeaGreen;
            buttonAddNewVehicle.Location = new Point(550, 40);
            buttonAddNewVehicle.Name = "buttonAddNewVehicle";
            buttonAddNewVehicle.Size = new Size(120, 35);
            buttonAddNewVehicle.TabIndex = 0;
            buttonAddNewVehicle.Text = "Добавить...";
            buttonAddNewVehicle.UseVisualStyleBackColor = false;
            buttonAddNewVehicle.Click += buttonAddNewVehicle_Click;
            // 
            // groupBoxServices
            // 
            groupBoxServices.Controls.Add(dataGridViewServices);
            groupBoxServices.Location = new Point(50, 506);
            groupBoxServices.Name = "groupBoxServices";
            groupBoxServices.Size = new Size(700, 250);
            groupBoxServices.TabIndex = 25;
            groupBoxServices.TabStop = false;
            groupBoxServices.Text = "Услуги";
            // 
            // dataGridViewServices
            // 
            dataGridViewServices.AllowUserToAddRows = false;
            dataGridViewServices.AllowUserToDeleteRows = false;
            dataGridViewServices.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewServices.BackgroundColor = Color.White;
            dataGridViewServices.BorderStyle = BorderStyle.None;
            dataGridViewServices.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewServices.Columns.AddRange(new DataGridViewColumn[] { colSelect, colServiceName, colPrice, colSpecialization });
            dataGridViewServices.Dock = DockStyle.Fill;
            dataGridViewServices.Location = new Point(3, 23);
            dataGridViewServices.MultiSelect = false;
            dataGridViewServices.Name = "dataGridViewServices";
            dataGridViewServices.RowHeadersVisible = false;
            dataGridViewServices.RowHeadersWidth = 51;
            dataGridViewServices.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewServices.Size = new Size(694, 224);
            dataGridViewServices.TabIndex = 0;
            dataGridViewServices.CellContentClick += dataGridViewServices_CellContentClick;
            dataGridViewServices.CellValueChanged += dataGridViewServices_CellValueChanged;
            // 
            // colSelect
            // 
            colSelect.FillWeight = 70F;
            colSelect.HeaderText = "Выбрать";
            colSelect.MinimumWidth = 6;
            colSelect.Name = "colSelect";
            // 
            // colServiceName
            // 
            colServiceName.FillWeight = 164.136459F;
            colServiceName.HeaderText = "Название услуги";
            colServiceName.MinimumWidth = 6;
            colServiceName.Name = "colServiceName";
            colServiceName.ReadOnly = true;
            // 
            // colPrice
            // 
            colPrice.FillWeight = 80F;
            colPrice.HeaderText = "Цена, Br";
            colPrice.MinimumWidth = 6;
            colPrice.Name = "colPrice";
            colPrice.ReadOnly = true;
            // 
            // colSpecialization
            // 
            colSpecialization.FillWeight = 98.48188F;
            colSpecialization.HeaderText = "Специализация";
            colSpecialization.MinimumWidth = 6;
            colSpecialization.Name = "colSpecialization";
            colSpecialization.ReadOnly = true;
            // 
            // labelTotalPrice
            // 
            labelTotalPrice.AutoSize = true;
            labelTotalPrice.Location = new Point(50, 874);
            labelTotalPrice.Name = "labelTotalPrice";
            labelTotalPrice.Size = new Size(136, 20);
            labelTotalPrice.TabIndex = 26;
            labelTotalPrice.Text = "Общая стоимость:";
            // 
            // textBoxTotalPrice
            // 
            textBoxTotalPrice.Location = new Point(230, 874);
            textBoxTotalPrice.Name = "textBoxTotalPrice";
            textBoxTotalPrice.ReadOnly = true;
            textBoxTotalPrice.Size = new Size(100, 27);
            textBoxTotalPrice.TabIndex = 27;
            textBoxTotalPrice.Text = "0";
            // 
            // groupBoxDates
            // 
            groupBoxDates.Controls.Add(dateTimePickerEstimatedDate);
            groupBoxDates.Controls.Add(dateTimePickerAcceptanceDate);
            groupBoxDates.Controls.Add(labelEstimatedDate);
            groupBoxDates.Controls.Add(labelAcceptDate);
            groupBoxDates.Location = new Point(50, 776);
            groupBoxDates.Name = "groupBoxDates";
            groupBoxDates.Size = new Size(700, 80);
            groupBoxDates.TabIndex = 29;
            groupBoxDates.TabStop = false;
            groupBoxDates.Text = "Даты";
            // 
            // dateTimePickerEstimatedDate
            // 
            dateTimePickerEstimatedDate.Location = new Point(450, 35);
            dateTimePickerEstimatedDate.Name = "dateTimePickerEstimatedDate";
            dateTimePickerEstimatedDate.Size = new Size(200, 27);
            dateTimePickerEstimatedDate.TabIndex = 3;
            // 
            // dateTimePickerAcceptanceDate
            // 
            dateTimePickerAcceptanceDate.Location = new Point(150, 35);
            dateTimePickerAcceptanceDate.Name = "dateTimePickerAcceptanceDate";
            dateTimePickerAcceptanceDate.Size = new Size(200, 27);
            dateTimePickerAcceptanceDate.TabIndex = 2;
            // 
            // labelEstimatedDate
            // 
            labelEstimatedDate.AutoSize = true;
            labelEstimatedDate.Location = new Point(370, 35);
            labelEstimatedDate.Name = "labelEstimatedDate";
            labelEstimatedDate.Size = new Size(67, 20);
            labelEstimatedDate.TabIndex = 1;
            labelEstimatedDate.Text = "Срок до:";
            // 
            // labelAcceptDate
            // 
            labelAcceptDate.AutoSize = true;
            labelAcceptDate.Location = new Point(30, 35);
            labelAcceptDate.Name = "labelAcceptDate";
            labelAcceptDate.Size = new Size(102, 20);
            labelAcceptDate.TabIndex = 0;
            labelAcceptDate.Text = "Дата приёма:";
            // 
            // groupBoxEmployeeSelection
            // 
            groupBoxEmployeeSelection.Controls.Add(buttonAutoAssignEmployees);
            groupBoxEmployeeSelection.Controls.Add(panelEmployeeControls);
            groupBoxEmployeeSelection.Location = new Point(50, 336);
            groupBoxEmployeeSelection.Name = "groupBoxEmployeeSelection";
            groupBoxEmployeeSelection.Size = new Size(700, 150);
            groupBoxEmployeeSelection.TabIndex = 30;
            groupBoxEmployeeSelection.TabStop = false;
            groupBoxEmployeeSelection.Text = "Назначение сотрудники";
            // 
            // buttonAutoAssignEmployees
            // 
            buttonAutoAssignEmployees.BackColor = Color.MediumPurple;
            buttonAutoAssignEmployees.FlatAppearance.BorderSize = 0;
            buttonAutoAssignEmployees.FlatStyle = FlatStyle.Flat;
            buttonAutoAssignEmployees.ForeColor = Color.White;
            buttonAutoAssignEmployees.Location = new Point(20, 20);
            buttonAutoAssignEmployees.Name = "buttonAutoAssignEmployees";
            buttonAutoAssignEmployees.Size = new Size(200, 25);
            buttonAutoAssignEmployees.TabIndex = 1;
            buttonAutoAssignEmployees.Text = "Автоподбор сотрудников";
            buttonAutoAssignEmployees.UseVisualStyleBackColor = false;
            buttonAutoAssignEmployees.Click += buttonAutoAssignEmployees_Click;
            // 
            // panelEmployeeControls
            // 
            panelEmployeeControls.AutoScroll = true;
            panelEmployeeControls.Location = new Point(20, 50);
            panelEmployeeControls.Name = "panelEmployeeControls";
            panelEmployeeControls.Size = new Size(660, 90);
            panelEmployeeControls.TabIndex = 0;
            // 
            // AddOrder
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(782, 1012);
            Controls.Add(groupBoxEmployeeSelection);
            Controls.Add(groupBoxDates);
            Controls.Add(textBoxTotalPrice);
            Controls.Add(labelTotalPrice);
            Controls.Add(groupBoxServices);
            Controls.Add(groupBoxVehicle);
            Controls.Add(groupBoxClient);
            Controls.Add(labelNewOrder);
            Controls.Add(buttonAddOrder);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "AddOrder";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Новый заказ";
            groupBoxClient.ResumeLayout(false);
            groupBoxClient.PerformLayout();
            groupBoxVehicle.ResumeLayout(false);
            groupBoxVehicle.PerformLayout();
            groupBoxServices.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewServices).EndInit();
            groupBoxDates.ResumeLayout(false);
            groupBoxDates.PerformLayout();
            groupBoxEmployeeSelection.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button buttonAddOrder;
        private Label labelNewOrder;
        private GroupBox groupBoxClient;
        private ComboBox comboBoxClients;
        private Button buttonAddNewClient;
        private Label labelСlient;
        private GroupBox groupBoxVehicle;
        private ComboBox comboBoxVehicles;
        private Label labelVehicle;
        private Button buttonAddNewVehicle;
        private GroupBox groupBoxServices;
        private DataGridView dataGridViewServices;
        private Label labelTotalPrice;
        private TextBox textBoxTotalPrice;
        private GroupBox groupBoxDates;
        private DateTimePicker dateTimePickerAcceptanceDate;
        private Label labelEstimatedDate;
        private Label labelAcceptDate;
        private DateTimePicker dateTimePickerEstimatedDate;
        private DataGridViewCheckBoxColumn colSelect;
        private DataGridViewTextBoxColumn colServiceName;
        private DataGridViewTextBoxColumn colPrice;
        private DataGridViewTextBoxColumn colSpecialization;
        private GroupBox groupBoxEmployeeSelection;
        private Button buttonAutoAssignEmployees;
        private Panel panelEmployeeControls;
    }
}