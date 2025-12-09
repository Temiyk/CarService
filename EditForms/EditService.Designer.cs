namespace coursa4
{
    partial class EditService
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditService));
            textBoxSpecialization = new TextBox();
            buttonApplyServiceChanges = new Button();
            textBoxServicePrice = new TextBox();
            textBoxServiceDescription = new TextBox();
            textBoxServiceName = new TextBox();
            labelNewService = new Label();
            buttonCancel = new Button();
            SuspendLayout();
            // 
            // textBoxSpecialization
            // 
            textBoxSpecialization.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxSpecialization.Location = new Point(136, 328);
            textBoxSpecialization.MaxLength = 15;
            textBoxSpecialization.Name = "textBoxSpecialization";
            textBoxSpecialization.PlaceholderText = "Специализация сотрудника*";
            textBoxSpecialization.Size = new Size(248, 30);
            textBoxSpecialization.TabIndex = 20;
            // 
            // buttonApplyServiceChanges
            // 
            buttonApplyServiceChanges.Location = new Point(296, 416);
            buttonApplyServiceChanges.Name = "buttonApplyServiceChanges";
            buttonApplyServiceChanges.Size = new Size(136, 32);
            buttonApplyServiceChanges.TabIndex = 19;
            buttonApplyServiceChanges.Text = "Подтвердить";
            buttonApplyServiceChanges.UseVisualStyleBackColor = true;
            buttonApplyServiceChanges.Click += buttonApplyServiceChanges_Click;
            // 
            // textBoxServicePrice
            // 
            textBoxServicePrice.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxServicePrice.Location = new Point(137, 279);
            textBoxServicePrice.MaxLength = 10;
            textBoxServicePrice.Name = "textBoxServicePrice";
            textBoxServicePrice.PlaceholderText = "Стоимость*";
            textBoxServicePrice.Size = new Size(248, 30);
            textBoxServicePrice.TabIndex = 18;
            // 
            // textBoxServiceDescription
            // 
            textBoxServiceDescription.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxServiceDescription.Location = new Point(137, 175);
            textBoxServiceDescription.MaxLength = 80;
            textBoxServiceDescription.Multiline = true;
            textBoxServiceDescription.Name = "textBoxServiceDescription";
            textBoxServiceDescription.PlaceholderText = "Описание*";
            textBoxServiceDescription.Size = new Size(248, 88);
            textBoxServiceDescription.TabIndex = 17;
            // 
            // textBoxServiceName
            // 
            textBoxServiceName.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxServiceName.Location = new Point(137, 127);
            textBoxServiceName.MaxLength = 30;
            textBoxServiceName.Name = "textBoxServiceName";
            textBoxServiceName.PlaceholderText = "Название*";
            textBoxServiceName.Size = new Size(248, 30);
            textBoxServiceName.TabIndex = 16;
            // 
            // labelNewService
            // 
            labelNewService.AutoSize = true;
            labelNewService.Font = new Font("Garamond", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelNewService.Location = new Point(24, 40);
            labelNewService.Name = "labelNewService";
            labelNewService.Size = new Size(478, 50);
            labelNewService.TabIndex = 15;
            labelNewService.Text = "Редактирование услуги";
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(72, 416);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(136, 32);
            buttonCancel.TabIndex = 21;
            buttonCancel.Text = "Отмена";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // EditService
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(523, 501);
            Controls.Add(buttonCancel);
            Controls.Add(textBoxSpecialization);
            Controls.Add(buttonApplyServiceChanges);
            Controls.Add(textBoxServicePrice);
            Controls.Add(textBoxServiceDescription);
            Controls.Add(textBoxServiceName);
            Controls.Add(labelNewService);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "EditService";
            Text = "Редактирование услуги";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxSpecialization;
        private Button buttonApplyServiceChanges;
        private TextBox textBoxServicePrice;
        private TextBox textBoxServiceDescription;
        private TextBox textBoxServiceName;
        private Label labelNewService;
        private Button buttonCancel;
    }
}