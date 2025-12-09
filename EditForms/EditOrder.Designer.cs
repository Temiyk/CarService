namespace coursa4.EditForms
{
    partial class EditOrder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditOrder));
            groupBoxDates = new GroupBox();
            dateTimePickerEstimatedDate = new DateTimePicker();
            dateTimePickerAcceptanceDate = new DateTimePicker();
            labelEstimatedDate = new Label();
            labelAcceptDate = new Label();
            textBoxTotalPrice = new TextBox();
            labelTotalPrice = new Label();
            groupBoxServices = new GroupBox();
            dataGridViewServices = new DataGridView();
            colSelect = new DataGridViewCheckBoxColumn();
            colServiceName = new DataGridViewTextBoxColumn();
            colPrice = new DataGridViewTextBoxColumn();
            colSpecialization = new DataGridViewTextBoxColumn();
            groupBoxVehicle = new GroupBox();
            comboBoxVehicles = new ComboBox();
            labelVehicle = new Label();
            buttonAddNewVehicle = new Button();
            groupBoxClient = new GroupBox();
            comboBoxClients = new ComboBox();
            buttonAddNewClient = new Button();
            labelСlient = new Label();
            labelEditOrder = new Label();
            buttonEditOrder = new Button();
            groupBoxEmployeeSelection = new GroupBox();
            button1 = new Button();
            panelEmployeeControls = new Panel();
            groupBoxDates.SuspendLayout();
            groupBoxServices.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewServices).BeginInit();
            groupBoxVehicle.SuspendLayout();
            groupBoxClient.SuspendLayout();
            groupBoxEmployeeSelection.SuspendLayout();
            SuspendLayout();
            // 
            // groupBoxDates
            // 
            groupBoxDates.Controls.Add(dateTimePickerEstimatedDate);
            groupBoxDates.Controls.Add(dateTimePickerAcceptanceDate);
            groupBoxDates.Controls.Add(labelEstimatedDate);
            groupBoxDates.Controls.Add(labelAcceptDate);
            groupBoxDates.Location = new Point(41, 776);
            groupBoxDates.Name = "groupBoxDates";
            groupBoxDates.Size = new Size(700, 80);
            groupBoxDates.TabIndex = 38;
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
            // textBoxTotalPrice
            // 
            textBoxTotalPrice.Location = new Point(221, 874);
            textBoxTotalPrice.Name = "textBoxTotalPrice";
            textBoxTotalPrice.ReadOnly = true;
            textBoxTotalPrice.Size = new Size(100, 27);
            textBoxTotalPrice.TabIndex = 37;
            textBoxTotalPrice.Text = "0";
            // 
            // labelTotalPrice
            // 
            labelTotalPrice.AutoSize = true;
            labelTotalPrice.Location = new Point(41, 874);
            labelTotalPrice.Name = "labelTotalPrice";
            labelTotalPrice.Size = new Size(136, 20);
            labelTotalPrice.TabIndex = 36;
            labelTotalPrice.Text = "Общая стоимость:";
            // 
            // groupBoxServices
            // 
            groupBoxServices.Controls.Add(dataGridViewServices);
            groupBoxServices.Location = new Point(41, 506);
            groupBoxServices.Name = "groupBoxServices";
            groupBoxServices.Size = new Size(700, 250);
            groupBoxServices.TabIndex = 35;
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
            // groupBoxVehicle
            // 
            groupBoxVehicle.Controls.Add(comboBoxVehicles);
            groupBoxVehicle.Controls.Add(labelVehicle);
            groupBoxVehicle.Controls.Add(buttonAddNewVehicle);
            groupBoxVehicle.Location = new Point(41, 210);
            groupBoxVehicle.Name = "groupBoxVehicle";
            groupBoxVehicle.Size = new Size(700, 100);
            groupBoxVehicle.TabIndex = 34;
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
            buttonAddNewVehicle.BackColor = Color.ForestGreen;
            buttonAddNewVehicle.ForeColor = Color.White;
            buttonAddNewVehicle.Location = new Point(550, 40);
            buttonAddNewVehicle.Name = "buttonAddNewVehicle";
            buttonAddNewVehicle.Size = new Size(120, 35);
            buttonAddNewVehicle.TabIndex = 0;
            buttonAddNewVehicle.Text = "Добавить...";
            buttonAddNewVehicle.UseVisualStyleBackColor = false;
            buttonAddNewVehicle.Click += buttonAddNewVehicle_Click;
            // 
            // groupBoxClient
            // 
            groupBoxClient.Controls.Add(comboBoxClients);
            groupBoxClient.Controls.Add(buttonAddNewClient);
            groupBoxClient.Controls.Add(labelСlient);
            groupBoxClient.Location = new Point(41, 90);
            groupBoxClient.Name = "groupBoxClient";
            groupBoxClient.Size = new Size(700, 100);
            groupBoxClient.TabIndex = 33;
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
            buttonAddNewClient.BackColor = Color.ForestGreen;
            buttonAddNewClient.ForeColor = Color.White;
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
            // labelEditOrder
            // 
            labelEditOrder.AutoSize = true;
            labelEditOrder.Font = new Font("Garamond", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelEditOrder.Location = new Point(241, 20);
            labelEditOrder.Name = "labelEditOrder";
            labelEditOrder.Size = new Size(277, 50);
            labelEditOrder.TabIndex = 31;
            labelEditOrder.Text = "Новый заказ";
            // 
            // buttonEditOrder
            // 
            buttonEditOrder.BackColor = Color.RoyalBlue;
            buttonEditOrder.ForeColor = Color.White;
            buttonEditOrder.Location = new Point(287, 936);
            buttonEditOrder.Name = "buttonEditOrder";
            buttonEditOrder.Size = new Size(200, 50);
            buttonEditOrder.TabIndex = 32;
            buttonEditOrder.Text = "Сохранить изменения";
            buttonEditOrder.UseVisualStyleBackColor = false;
            buttonEditOrder.Click += buttonEditOrder_Click;
            // 
            // groupBoxEmployeeSelection
            // 
            groupBoxEmployeeSelection.Controls.Add(button1);
            groupBoxEmployeeSelection.Controls.Add(panelEmployeeControls);
            groupBoxEmployeeSelection.Location = new Point(41, 336);
            groupBoxEmployeeSelection.Name = "groupBoxEmployeeSelection";
            groupBoxEmployeeSelection.Size = new Size(700, 150);
            groupBoxEmployeeSelection.TabIndex = 39;
            groupBoxEmployeeSelection.TabStop = false;
            groupBoxEmployeeSelection.Text = "Назначение сотрудников";
            // 
            // button1
            // 
            button1.BackColor = Color.Teal;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = Color.White;
            button1.Location = new Point(20, 20);
            button1.Name = "button1";
            button1.Size = new Size(200, 25);
            button1.TabIndex = 1;
            button1.Text = "Автоподбор сотрудников";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // panelEmployeeControls
            // 
            panelEmployeeControls.AutoScroll = true;
            panelEmployeeControls.Location = new Point(20, 50);
            panelEmployeeControls.Name = "panelEmployeeControls";
            panelEmployeeControls.Size = new Size(660, 90);
            panelEmployeeControls.TabIndex = 0;
            // 
            // EditOrder
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
            Controls.Add(labelEditOrder);
            Controls.Add(buttonEditOrder);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "EditOrder";
            Text = "Редактирование заказа";
            groupBoxDates.ResumeLayout(false);
            groupBoxDates.PerformLayout();
            groupBoxServices.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewServices).EndInit();
            groupBoxVehicle.ResumeLayout(false);
            groupBoxVehicle.PerformLayout();
            groupBoxClient.ResumeLayout(false);
            groupBoxClient.PerformLayout();
            groupBoxEmployeeSelection.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private GroupBox groupBoxDates;
        private DateTimePicker dateTimePickerEstimatedDate;
        private DateTimePicker dateTimePickerAcceptanceDate;
        private Label labelEstimatedDate;
        private Label labelAcceptDate;
        private TextBox textBoxTotalPrice;
        private Label labelTotalPrice;
        private GroupBox groupBoxServices;
        private DataGridView dataGridViewServices;
        private DataGridViewCheckBoxColumn colSelect;
        private DataGridViewTextBoxColumn colServiceName;
        private DataGridViewTextBoxColumn colPrice;
        private DataGridViewTextBoxColumn colSpecialization;
        private GroupBox groupBoxVehicle;
        private ComboBox comboBoxVehicles;
        private Label labelVehicle;
        private Button buttonAddNewVehicle;
        private GroupBox groupBoxClient;
        private ComboBox comboBoxClients;
        private Button buttonAddNewClient;
        private Label labelСlient;
        private Label labelEditOrder;
        private Button buttonEditOrder;
        private GroupBox groupBoxEmployeeSelection;
        private Panel panelEmployeeControls;
        private Button button1;
    }
}