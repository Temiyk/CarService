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
            labelAddClient.Location = new Point(128, 48);
            labelAddClient.Name = "labelAddClient";
            labelAddClient.Size = new Size(308, 50);
            labelAddClient.TabIndex = 0;
            labelAddClient.Text = "Новый клиент";
            // 
            // textBoxClientFN
            // 
            textBoxClientFN.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxClientFN.Location = new Point(56, 136);
            textBoxClientFN.MaxLength = 15;
            textBoxClientFN.Name = "textBoxClientFN";
            textBoxClientFN.PlaceholderText = "Иван*";
            textBoxClientFN.Size = new Size(184, 30);
            textBoxClientFN.TabIndex = 2;
            // 
            // textBoxClientLN
            // 
            textBoxClientLN.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxClientLN.Location = new Point(56, 192);
            textBoxClientLN.MaxLength = 20;
            textBoxClientLN.Name = "textBoxClientLN";
            textBoxClientLN.PlaceholderText = "Иванов*";
            textBoxClientLN.Size = new Size(184, 30);
            textBoxClientLN.TabIndex = 3;
            // 
            // textBoxPhoneNumber
            // 
            textBoxPhoneNumber.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxPhoneNumber.Location = new Point(336, 136);
            textBoxPhoneNumber.MaxLength = 13;
            textBoxPhoneNumber.Name = "textBoxPhoneNumber";
            textBoxPhoneNumber.PlaceholderText = "+37512345678*";
            textBoxPhoneNumber.Size = new Size(184, 30);
            textBoxPhoneNumber.TabIndex = 4;
            // 
            // textBoxEMail
            // 
            textBoxEMail.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxEMail.Location = new Point(336, 192);
            textBoxEMail.MaxLength = 30;
            textBoxEMail.Name = "textBoxEMail";
            textBoxEMail.PlaceholderText = "example@mail.com";
            textBoxEMail.Size = new Size(184, 30);
            textBoxEMail.TabIndex = 5;
            // 
            // buttonCompleteAdding
            // 
            buttonCompleteAdding.BackColor = Color.SpringGreen;
            buttonCompleteAdding.FlatAppearance.BorderSize = 0;
            buttonCompleteAdding.FlatStyle = FlatStyle.Flat;
            buttonCompleteAdding.Location = new Point(224, 272);
            buttonCompleteAdding.Name = "buttonCompleteAdding";
            buttonCompleteAdding.Size = new Size(128, 32);
            buttonCompleteAdding.TabIndex = 6;
            buttonCompleteAdding.Text = "Добавить";
            buttonCompleteAdding.UseVisualStyleBackColor = false;
            buttonCompleteAdding.Click += buttonCompleteAdding_Click;
            // 
            // AddClient
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(582, 353);
            Controls.Add(buttonCompleteAdding);
            Controls.Add(textBoxEMail);
            Controls.Add(textBoxPhoneNumber);
            Controls.Add(textBoxClientLN);
            Controls.Add(textBoxClientFN);
            Controls.Add(labelAddClient);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "AddClient";
            Text = "Новый клиент";
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