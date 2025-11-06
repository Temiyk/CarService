namespace coursa4
{
    partial class AddClient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddClient));
            labelAddClient = new Label();
            textBoxClientFN = new TextBox();
            textBoxClientLN = new TextBox();
            textBoxPhoneNumber = new TextBox();
            textBoxEMail = new TextBox();
            buttonCompleteAdding = new Button();
            SuspendLayout();
            // 
            // labelAddClient
            // 
            labelAddClient.AutoSize = true;
            labelAddClient.Font = new Font("Garamond", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelAddClient.Location = new Point(144, 48);
            labelAddClient.Name = "labelAddClient";
            labelAddClient.Size = new Size(308, 50);
            labelAddClient.TabIndex = 0;
            labelAddClient.Text = "Новый клиент";
            // 
            // textBoxClientFN
            // 
            textBoxClientFN.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxClientFN.Location = new Point(72, 136);
            textBoxClientFN.MaxLength = 15;
            textBoxClientFN.Name = "textBoxClientFN";
            textBoxClientFN.PlaceholderText = "Иван";
            textBoxClientFN.Size = new Size(184, 30);
            textBoxClientFN.TabIndex = 2;
            // 
            // textBoxClientLN
            // 
            textBoxClientLN.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxClientLN.Location = new Point(72, 192);
            textBoxClientLN.MaxLength = 20;
            textBoxClientLN.Name = "textBoxClientLN";
            textBoxClientLN.PlaceholderText = "Иванов";
            textBoxClientLN.Size = new Size(184, 30);
            textBoxClientLN.TabIndex = 3;
            // 
            // textBoxPhoneNumber
            // 
            textBoxPhoneNumber.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxPhoneNumber.Location = new Point(352, 136);
            textBoxPhoneNumber.MaxLength = 15;
            textBoxPhoneNumber.Name = "textBoxPhoneNumber";
            textBoxPhoneNumber.PlaceholderText = "+375123456789";
            textBoxPhoneNumber.Size = new Size(184, 30);
            textBoxPhoneNumber.TabIndex = 4;
            // 
            // textBoxEMail
            // 
            textBoxEMail.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxEMail.Location = new Point(352, 192);
            textBoxEMail.MaxLength = 30;
            textBoxEMail.Name = "textBoxEMail";
            textBoxEMail.PlaceholderText = "example@mail.com";
            textBoxEMail.Size = new Size(184, 30);
            textBoxEMail.TabIndex = 5;
            // 
            // buttonCompleteAdding
            // 
            buttonCompleteAdding.Location = new Point(224, 256);
            buttonCompleteAdding.Name = "buttonCompleteAdding";
            buttonCompleteAdding.Size = new Size(152, 48);
            buttonCompleteAdding.TabIndex = 6;
            buttonCompleteAdding.Text = "Добавить";
            buttonCompleteAdding.UseVisualStyleBackColor = true;
            // 
            // AddClient
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(595, 351);
            Controls.Add(buttonCompleteAdding);
            Controls.Add(textBoxEMail);
            Controls.Add(textBoxPhoneNumber);
            Controls.Add(textBoxClientLN);
            Controls.Add(textBoxClientFN);
            Controls.Add(labelAddClient);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "AddClient";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelAddClient;
        private TextBox textBoxClientFN;
        private TextBox textBoxClientLN;
        private TextBox textBoxPhoneNumber;
        private TextBox textBoxEMail;
        private Button buttonCompleteAdding;
    }
}