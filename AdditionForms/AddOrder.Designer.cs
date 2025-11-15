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
            labelСlient = new Label();
            buttonAddNewClient = new Button();
            comboBoxClient = new ComboBox();
            groupBoxVehicle = new GroupBox();
            buttonAddNewVehicle = new Button();
            labelVehicle = new Label();
            comboBoxVehicles = new ComboBox();
            groupBoxServices = new GroupBox();
            dataGridViewServices = new DataGridView();
            labelTotalPrice = new Label();
            textBoxTotalPrice = new TextBox();
            buttonCalculateTotal = new Button();
            groupBoxDates = new GroupBox();
            labelAcceptDate = new Label();
            labelEstimatedDate = new Label();
            dateTimePickerAcceptanceDate = new DateTimePicker();
            dateTimePickerEstimatedDate = new DateTimePicker();
            colSelect = new DataGridViewCheckBoxColumn();
            colServiceName = new DataGridViewTextBoxColumn();
            colPrice = new DataGridViewTextBoxColumn();
            colSpecialization = new DataGridViewTextBoxColumn();
            groupBoxClient.SuspendLayout();
            groupBoxVehicle.SuspendLayout();
            groupBoxServices.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewServices).BeginInit();
            groupBoxDates.SuspendLayout();
            SuspendLayout();
            // 
            // buttonAddOrder
            // 
            buttonAddOrder.BackColor = Color.SteelBlue;
            buttonAddOrder.Location = new Point(296, 776);
            buttonAddOrder.Name = "buttonAddOrder";
            buttonAddOrder.Size = new Size(200, 50);
            buttonAddOrder.TabIndex = 22;
            buttonAddOrder.Text = "Создать заказ";
            buttonAddOrder.UseVisualStyleBackColor = false;
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
            groupBoxClient.Controls.Add(comboBoxClient);
            groupBoxClient.Controls.Add(buttonAddNewClient);
            groupBoxClient.Controls.Add(labelСlient);
            groupBoxClient.Location = new Point(50, 90);
            groupBoxClient.Name = "groupBoxClient";
            groupBoxClient.Size = new Size(700, 100);
            groupBoxClient.TabIndex = 23;
            groupBoxClient.TabStop = false;
            groupBoxClient.Text = "Клиент";
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
            // buttonAddNewClient
            // 
            buttonAddNewClient.BackColor = Color.LightSeaGreen;
            buttonAddNewClient.Location = new Point(550, 40);
            buttonAddNewClient.Name = "buttonAddNewClient";
            buttonAddNewClient.Size = new Size(120, 35);
            buttonAddNewClient.TabIndex = 1;
            buttonAddNewClient.Text = "Добавить...";
            buttonAddNewClient.UseVisualStyleBackColor = false;
            // 
            // comboBoxClient
            // 
            comboBoxClient.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxClient.FormattingEnabled = true;
            comboBoxClient.Location = new Point(150, 45);
            comboBoxClient.Name = "comboBoxClient";
            comboBoxClient.Size = new Size(350, 28);
            comboBoxClient.TabIndex = 2;
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
            // buttonAddNewVehicle
            // 
            buttonAddNewVehicle.BackColor = Color.LightSeaGreen;
            buttonAddNewVehicle.Location = new Point(550, 40);
            buttonAddNewVehicle.Name = "buttonAddNewVehicle";
            buttonAddNewVehicle.Size = new Size(120, 35);
            buttonAddNewVehicle.TabIndex = 0;
            buttonAddNewVehicle.Text = "Добавить...";
            buttonAddNewVehicle.UseVisualStyleBackColor = false;
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
            // comboBoxVehicles
            // 
            comboBoxVehicles.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxVehicles.FormattingEnabled = true;
            comboBoxVehicles.Location = new Point(150, 45);
            comboBoxVehicles.Name = "comboBoxVehicles";
            comboBoxVehicles.Size = new Size(350, 28);
            comboBoxVehicles.TabIndex = 2;
            // 
            // groupBoxServices
            // 
            groupBoxServices.Controls.Add(dataGridViewServices);
            groupBoxServices.Location = new Point(50, 330);
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
            dataGridViewServices.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewServices.Columns.AddRange(new DataGridViewColumn[] { colSelect, colServiceName, colPrice, colSpecialization });
            dataGridViewServices.Dock = DockStyle.Fill;
            dataGridViewServices.Location = new Point(3, 23);
            dataGridViewServices.Name = "dataGridViewServices";
            dataGridViewServices.RowHeadersWidth = 51;
            dataGridViewServices.Size = new Size(694, 224);
            dataGridViewServices.TabIndex = 0;
            // 
            // labelTotalPrice
            // 
            labelTotalPrice.AutoSize = true;
            labelTotalPrice.Location = new Point(50, 698);
            labelTotalPrice.Name = "labelTotalPrice";
            labelTotalPrice.Size = new Size(136, 20);
            labelTotalPrice.TabIndex = 26;
            labelTotalPrice.Text = "Общая стоимость:";
            // 
            // textBoxTotalPrice
            // 
            textBoxTotalPrice.Location = new Point(230, 698);
            textBoxTotalPrice.Name = "textBoxTotalPrice";
            textBoxTotalPrice.ReadOnly = true;
            textBoxTotalPrice.Size = new Size(100, 27);
            textBoxTotalPrice.TabIndex = 27;
            textBoxTotalPrice.Text = "0";
            // 
            // buttonCalculateTotal
            // 
            buttonCalculateTotal.BackColor = Color.Goldenrod;
            buttonCalculateTotal.Location = new Point(600, 696);
            buttonCalculateTotal.Name = "buttonCalculateTotal";
            buttonCalculateTotal.Size = new Size(150, 35);
            buttonCalculateTotal.TabIndex = 28;
            buttonCalculateTotal.Text = "Рассчитать итог";
            buttonCalculateTotal.UseVisualStyleBackColor = false;
            // 
            // groupBoxDates
            // 
            groupBoxDates.Controls.Add(dateTimePickerEstimatedDate);
            groupBoxDates.Controls.Add(dateTimePickerAcceptanceDate);
            groupBoxDates.Controls.Add(labelEstimatedDate);
            groupBoxDates.Controls.Add(labelAcceptDate);
            groupBoxDates.Location = new Point(50, 600);
            groupBoxDates.Name = "groupBoxDates";
            groupBoxDates.Size = new Size(700, 80);
            groupBoxDates.TabIndex = 29;
            groupBoxDates.TabStop = false;
            groupBoxDates.Text = "Даты";
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
            // labelEstimatedDate
            // 
            labelEstimatedDate.AutoSize = true;
            labelEstimatedDate.Location = new Point(370, 35);
            labelEstimatedDate.Name = "labelEstimatedDate";
            labelEstimatedDate.Size = new Size(67, 20);
            labelEstimatedDate.TabIndex = 1;
            labelEstimatedDate.Text = "Срок до:";
            // 
            // dateTimePickerAcceptanceDate
            // 
            dateTimePickerAcceptanceDate.Location = new Point(150, 35);
            dateTimePickerAcceptanceDate.Name = "dateTimePickerAcceptanceDate";
            dateTimePickerAcceptanceDate.Size = new Size(200, 27);
            dateTimePickerAcceptanceDate.TabIndex = 2;
            // 
            // dateTimePickerEstimatedDate
            // 
            dateTimePickerEstimatedDate.Location = new Point(450, 35);
            dateTimePickerEstimatedDate.Name = "dateTimePickerEstimatedDate";
            dateTimePickerEstimatedDate.Size = new Size(200, 27);
            dateTimePickerEstimatedDate.TabIndex = 3;
            // 
            // colSelect
            // 
            colSelect.HeaderText = "Выбрать";
            colSelect.MinimumWidth = 6;
            colSelect.Name = "colSelect";
            colSelect.Width = 125;
            // 
            // colServiceName
            // 
            colServiceName.HeaderText = "Название услуги";
            colServiceName.MinimumWidth = 6;
            colServiceName.Name = "colServiceName";
            colServiceName.ReadOnly = true;
            colServiceName.Width = 125;
            // 
            // colPrice
            // 
            colPrice.HeaderText = "Цена";
            colPrice.MinimumWidth = 6;
            colPrice.Name = "colPrice";
            colPrice.ReadOnly = true;
            colPrice.Width = 125;
            // 
            // colSpecialization
            // 
            colSpecialization.HeaderText = "Специализация";
            colSpecialization.MinimumWidth = 6;
            colSpecialization.Name = "colSpecialization";
            colSpecialization.ReadOnly = true;
            colSpecialization.Width = 125;
            // 
            // AddOrder
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(782, 853);
            Controls.Add(groupBoxDates);
            Controls.Add(buttonCalculateTotal);
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
            Text = "MotorbreathMaster - Новый заказ";
            groupBoxClient.ResumeLayout(false);
            groupBoxClient.PerformLayout();
            groupBoxVehicle.ResumeLayout(false);
            groupBoxVehicle.PerformLayout();
            groupBoxServices.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewServices).EndInit();
            groupBoxDates.ResumeLayout(false);
            groupBoxDates.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button buttonAddOrder;
        private Label labelNewOrder;
        private GroupBox groupBoxClient;
        private ComboBox comboBoxClient;
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
        private Button buttonCalculateTotal;
        private GroupBox groupBoxDates;
        private DateTimePicker dateTimePickerAcceptanceDate;
        private Label labelEstimatedDate;
        private Label labelAcceptDate;
        private DateTimePicker dateTimePickerEstimatedDate;
        private DataGridViewCheckBoxColumn colSelect;
        private DataGridViewTextBoxColumn colServiceName;
        private DataGridViewTextBoxColumn colPrice;
        private DataGridViewTextBoxColumn colSpecialization;
    }
}