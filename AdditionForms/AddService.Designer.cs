namespace coursa4
{
    partial class AddService
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddService));
            buttonAddService = new Button();
            textBoxServicePrice = new TextBox();
            textBoxServiceDescription = new TextBox();
            textBoxServiceName = new TextBox();
            labelNewService = new Label();
            SuspendLayout();
            // 
            // buttonAddService
            // 
            buttonAddService.Location = new Point(191, 433);
            buttonAddService.Name = "buttonAddService";
            buttonAddService.Size = new Size(152, 48);
            buttonAddService.TabIndex = 13;
            buttonAddService.Text = "Подтвердить";
            buttonAddService.UseVisualStyleBackColor = true;
            // 
            // textBoxServicePrice
            // 
            textBoxServicePrice.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxServicePrice.Location = new Point(144, 304);
            textBoxServicePrice.MaxLength = 15;
            textBoxServicePrice.Name = "textBoxServicePrice";
            textBoxServicePrice.PlaceholderText = "Стоимость";
            textBoxServicePrice.Size = new Size(248, 30);
            textBoxServicePrice.TabIndex = 12;
            // 
            // textBoxServiceDescription
            // 
            textBoxServiceDescription.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxServiceDescription.Location = new Point(144, 200);
            textBoxServiceDescription.MaxLength = 80;
            textBoxServiceDescription.Multiline = true;
            textBoxServiceDescription.Name = "textBoxServiceDescription";
            textBoxServiceDescription.PlaceholderText = "Описание";
            textBoxServiceDescription.Size = new Size(248, 88);
            textBoxServiceDescription.TabIndex = 11;
            // 
            // textBoxServiceName
            // 
            textBoxServiceName.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxServiceName.Location = new Point(144, 152);
            textBoxServiceName.MaxLength = 15;
            textBoxServiceName.Name = "textBoxServiceName";
            textBoxServiceName.PlaceholderText = "Название";
            textBoxServiceName.Size = new Size(248, 30);
            textBoxServiceName.TabIndex = 10;
            // 
            // labelNewService
            // 
            labelNewService.AutoSize = true;
            labelNewService.Font = new Font("Garamond", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelNewService.Location = new Point(128, 40);
            labelNewService.Name = "labelNewService";
            labelNewService.Size = new Size(281, 50);
            labelNewService.TabIndex = 9;
            labelNewService.Text = "Новая услуга";
            // 
            // AddService
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(534, 561);
            Controls.Add(buttonAddService);
            Controls.Add(textBoxServicePrice);
            Controls.Add(textBoxServiceDescription);
            Controls.Add(textBoxServiceName);
            Controls.Add(labelNewService);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "AddService";
            Text = "MotorbreathMaster";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonAddService;
        private TextBox textBoxServicePrice;
        private TextBox textBoxServiceDescription;
        private TextBox textBoxServiceName;
        private Label labelNewService;
    }
}