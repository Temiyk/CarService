namespace coursa4
{
    partial class AddVehicle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddVehicle));
            buttonAddVehicle = new Button();
            pictureBoxNewVehicle = new PictureBox();
            textBoxCarYear = new TextBox();
            textBoxCarModel = new TextBox();
            textBoxCarBrand = new TextBox();
            labelNewVehicle = new Label();
            textBoxCarVIN = new TextBox();
            textBoxCarPlate = new TextBox();
            textBoxCarMileage = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBoxNewVehicle).BeginInit();
            SuspendLayout();
            // 
            // buttonAddVehicle
            // 
            buttonAddVehicle.Location = new Point(184, 656);
            buttonAddVehicle.Name = "buttonAddVehicle";
            buttonAddVehicle.Size = new Size(152, 48);
            buttonAddVehicle.TabIndex = 14;
            buttonAddVehicle.Text = "Подтвердить";
            buttonAddVehicle.UseVisualStyleBackColor = true;
            // 
            // pictureBoxNewVehicle
            // 
            pictureBoxNewVehicle.Location = new Point(168, 112);
            pictureBoxNewVehicle.Name = "pictureBoxNewVehicle";
            pictureBoxNewVehicle.Size = new Size(183, 125);
            pictureBoxNewVehicle.TabIndex = 13;
            pictureBoxNewVehicle.TabStop = false;
            // 
            // textBoxCarYear
            // 
            textBoxCarYear.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxCarYear.Location = new Point(144, 376);
            textBoxCarYear.MaxLength = 4;
            textBoxCarYear.Name = "textBoxCarYear";
            textBoxCarYear.PlaceholderText = "Год выпуска";
            textBoxCarYear.Size = new Size(230, 30);
            textBoxCarYear.TabIndex = 12;
            // 
            // textBoxCarModel
            // 
            textBoxCarModel.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxCarModel.Location = new Point(144, 328);
            textBoxCarModel.MaxLength = 15;
            textBoxCarModel.Name = "textBoxCarModel";
            textBoxCarModel.PlaceholderText = "Модель";
            textBoxCarModel.Size = new Size(230, 30);
            textBoxCarModel.TabIndex = 11;
            // 
            // textBoxCarBrand
            // 
            textBoxCarBrand.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxCarBrand.Location = new Point(144, 280);
            textBoxCarBrand.MaxLength = 20;
            textBoxCarBrand.Name = "textBoxCarBrand";
            textBoxCarBrand.PlaceholderText = "Марка";
            textBoxCarBrand.Size = new Size(230, 30);
            textBoxCarBrand.TabIndex = 10;
            // 
            // labelNewVehicle
            // 
            labelNewVehicle.AutoSize = true;
            labelNewVehicle.Font = new Font("Garamond", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelNewVehicle.Location = new Point(128, 32);
            labelNewVehicle.Name = "labelNewVehicle";
            labelNewVehicle.Size = new Size(260, 50);
            labelNewVehicle.TabIndex = 9;
            labelNewVehicle.Text = "Новый авто";
            // 
            // textBoxCarVIN
            // 
            textBoxCarVIN.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxCarVIN.Location = new Point(144, 424);
            textBoxCarVIN.MaxLength = 12;
            textBoxCarVIN.Name = "textBoxCarVIN";
            textBoxCarVIN.PlaceholderText = "VIN-номер";
            textBoxCarVIN.Size = new Size(230, 30);
            textBoxCarVIN.TabIndex = 15;
            // 
            // textBoxCarPlate
            // 
            textBoxCarPlate.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxCarPlate.Location = new Point(144, 472);
            textBoxCarPlate.MaxLength = 20;
            textBoxCarPlate.Name = "textBoxCarPlate";
            textBoxCarPlate.PlaceholderText = "Гос. номер";
            textBoxCarPlate.Size = new Size(230, 30);
            textBoxCarPlate.TabIndex = 16;
            // 
            // textBoxCarMileage
            // 
            textBoxCarMileage.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxCarMileage.Location = new Point(144, 520);
            textBoxCarMileage.MaxLength = 7;
            textBoxCarMileage.Name = "textBoxCarMileage";
            textBoxCarMileage.PlaceholderText = "Пробег(км.)";
            textBoxCarMileage.Size = new Size(230, 30);
            textBoxCarMileage.TabIndex = 17;
            // 
            // AddVehicle
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(517, 753);
            Controls.Add(textBoxCarMileage);
            Controls.Add(textBoxCarPlate);
            Controls.Add(textBoxCarVIN);
            Controls.Add(buttonAddVehicle);
            Controls.Add(pictureBoxNewVehicle);
            Controls.Add(textBoxCarYear);
            Controls.Add(textBoxCarModel);
            Controls.Add(textBoxCarBrand);
            Controls.Add(labelNewVehicle);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "AddVehicle";
            Text = "MotorbreathMaster";
            ((System.ComponentModel.ISupportInitialize)pictureBoxNewVehicle).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonAddVehicle;
        private PictureBox pictureBoxNewVehicle;
        private TextBox textBoxCarYear;
        private TextBox textBoxCarModel;
        private TextBox textBoxCarBrand;
        private Label labelNewVehicle;
        private TextBox textBoxCarVIN;
        private TextBox textBoxCarPlate;
        private TextBox textBoxCarMileage;
    }
}