namespace coursa4.EditForms
{
    partial class EditVehicle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditVehicle));
            comboBoxEditClient = new ComboBox();
            textBoxEditCarMileage = new TextBox();
            textBoxEditCarPlate = new TextBox();
            textBoxEditCarVIN = new TextBox();
            buttonEditVehicle = new Button();
            pictureBoxEditVehicle = new PictureBox();
            textBoxEditCarYear = new TextBox();
            textBoxEditCarModel = new TextBox();
            textBoxEditCarBrand = new TextBox();
            labelEditVehicle = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBoxEditVehicle).BeginInit();
            SuspendLayout();
            // 
            // comboBoxEditClient
            // 
            comboBoxEditClient.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            comboBoxEditClient.FormattingEnabled = true;
            comboBoxEditClient.Location = new Point(144, 568);
            comboBoxEditClient.Name = "comboBoxEditClient";
            comboBoxEditClient.Size = new Size(232, 31);
            comboBoxEditClient.TabIndex = 28;
            comboBoxEditClient.Text = "Владелец*";
            // 
            // textBoxEditCarMileage
            // 
            textBoxEditCarMileage.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxEditCarMileage.Location = new Point(144, 520);
            textBoxEditCarMileage.MaxLength = 7;
            textBoxEditCarMileage.Name = "textBoxEditCarMileage";
            textBoxEditCarMileage.PlaceholderText = "Пробег(км.)*";
            textBoxEditCarMileage.Size = new Size(230, 30);
            textBoxEditCarMileage.TabIndex = 27;
            // 
            // textBoxEditCarPlate
            // 
            textBoxEditCarPlate.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxEditCarPlate.Location = new Point(144, 472);
            textBoxEditCarPlate.MaxLength = 20;
            textBoxEditCarPlate.Name = "textBoxEditCarPlate";
            textBoxEditCarPlate.PlaceholderText = "Гос. номер*";
            textBoxEditCarPlate.Size = new Size(230, 30);
            textBoxEditCarPlate.TabIndex = 26;
            // 
            // textBoxEditCarVIN
            // 
            textBoxEditCarVIN.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxEditCarVIN.Location = new Point(144, 424);
            textBoxEditCarVIN.MaxLength = 17;
            textBoxEditCarVIN.Name = "textBoxEditCarVIN";
            textBoxEditCarVIN.PlaceholderText = "VIN-номер*";
            textBoxEditCarVIN.Size = new Size(230, 30);
            textBoxEditCarVIN.TabIndex = 25;
            // 
            // buttonEditVehicle
            // 
            buttonEditVehicle.Location = new Point(184, 656);
            buttonEditVehicle.Name = "buttonEditVehicle";
            buttonEditVehicle.Size = new Size(152, 48);
            buttonEditVehicle.TabIndex = 24;
            buttonEditVehicle.Text = "Подтвердить";
            buttonEditVehicle.UseVisualStyleBackColor = true;
            buttonEditVehicle.Click += buttonEditVehicle_Click;
            // 
            // pictureBoxEditVehicle
            // 
            pictureBoxEditVehicle.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxEditVehicle.Location = new Point(168, 112);
            pictureBoxEditVehicle.Name = "pictureBoxEditVehicle";
            pictureBoxEditVehicle.Size = new Size(183, 125);
            pictureBoxEditVehicle.TabIndex = 23;
            pictureBoxEditVehicle.TabStop = false;
            pictureBoxEditVehicle.Click += pictureBoxEditVehicle_Click;
            // 
            // textBoxEditCarYear
            // 
            textBoxEditCarYear.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxEditCarYear.Location = new Point(144, 376);
            textBoxEditCarYear.MaxLength = 4;
            textBoxEditCarYear.Name = "textBoxEditCarYear";
            textBoxEditCarYear.PlaceholderText = "Год выпуска*";
            textBoxEditCarYear.Size = new Size(230, 30);
            textBoxEditCarYear.TabIndex = 22;
            // 
            // textBoxEditCarModel
            // 
            textBoxEditCarModel.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxEditCarModel.Location = new Point(144, 328);
            textBoxEditCarModel.MaxLength = 20;
            textBoxEditCarModel.Name = "textBoxEditCarModel";
            textBoxEditCarModel.PlaceholderText = "Модель*";
            textBoxEditCarModel.Size = new Size(230, 30);
            textBoxEditCarModel.TabIndex = 21;
            // 
            // textBoxEditCarBrand
            // 
            textBoxEditCarBrand.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxEditCarBrand.Location = new Point(144, 280);
            textBoxEditCarBrand.MaxLength = 20;
            textBoxEditCarBrand.Name = "textBoxEditCarBrand";
            textBoxEditCarBrand.PlaceholderText = "Марка*";
            textBoxEditCarBrand.Size = new Size(230, 30);
            textBoxEditCarBrand.TabIndex = 20;
            // 
            // labelEditVehicle
            // 
            labelEditVehicle.AutoSize = true;
            labelEditVehicle.Font = new Font("Garamond", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelEditVehicle.Location = new Point(40, 32);
            labelEditVehicle.Name = "labelEditVehicle";
            labelEditVehicle.Size = new Size(438, 50);
            labelEditVehicle.TabIndex = 19;
            labelEditVehicle.Text = "Редактирование авто";
            // 
            // EditVehicle
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(517, 753);
            Controls.Add(comboBoxEditClient);
            Controls.Add(textBoxEditCarMileage);
            Controls.Add(textBoxEditCarPlate);
            Controls.Add(textBoxEditCarVIN);
            Controls.Add(buttonEditVehicle);
            Controls.Add(pictureBoxEditVehicle);
            Controls.Add(textBoxEditCarYear);
            Controls.Add(textBoxEditCarModel);
            Controls.Add(textBoxEditCarBrand);
            Controls.Add(labelEditVehicle);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "EditVehicle";
            Text = "MotorbreathMaster - Редактирование авто";
            ((System.ComponentModel.ISupportInitialize)pictureBoxEditVehicle).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBoxEditClient;
        private TextBox textBoxEditCarMileage;
        private TextBox textBoxEditCarPlate;
        private TextBox textBoxEditCarVIN;
        private Button buttonEditVehicle;
        private PictureBox pictureBoxEditVehicle;
        private TextBox textBoxEditCarYear;
        private TextBox textBoxEditCarModel;
        private TextBox textBoxEditCarBrand;
        private Label labelEditVehicle;
    }
}