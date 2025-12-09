namespace coursa4
{
    partial class EditClient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditClient));
            buttonApplyChanges = new Button();
            textBoxEMail = new TextBox();
            textBoxPhoneNumber = new TextBox();
            textBoxClientLN = new TextBox();
            textBoxClientFN = new TextBox();
            labelEditClient = new Label();
            buttonCancel = new Button();
            SuspendLayout();
            // 
            // buttonApplyChanges
            // 
            buttonApplyChanges.BackColor = Color.SpringGreen;
            buttonApplyChanges.FlatAppearance.BorderSize = 0;
            buttonApplyChanges.FlatStyle = FlatStyle.Flat;
            buttonApplyChanges.Location = new Point(320, 272);
            buttonApplyChanges.Name = "buttonApplyChanges";
            buttonApplyChanges.Size = new Size(128, 32);
            buttonApplyChanges.TabIndex = 12;
            buttonApplyChanges.Text = "Применить";
            buttonApplyChanges.UseVisualStyleBackColor = false;
            buttonApplyChanges.Click += buttonApplyChanges_Click;
            // 
            // textBoxEMail
            // 
            textBoxEMail.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxEMail.Location = new Point(339, 192);
            textBoxEMail.MaxLength = 30;
            textBoxEMail.Name = "textBoxEMail";
            textBoxEMail.PlaceholderText = "example@mail.com";
            textBoxEMail.Size = new Size(184, 30);
            textBoxEMail.TabIndex = 11;
            // 
            // textBoxPhoneNumber
            // 
            textBoxPhoneNumber.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxPhoneNumber.Location = new Point(339, 136);
            textBoxPhoneNumber.MaxLength = 13;
            textBoxPhoneNumber.Name = "textBoxPhoneNumber";
            textBoxPhoneNumber.PlaceholderText = "+37512345678*";
            textBoxPhoneNumber.Size = new Size(184, 30);
            textBoxPhoneNumber.TabIndex = 10;
            // 
            // textBoxClientLN
            // 
            textBoxClientLN.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxClientLN.Location = new Point(59, 192);
            textBoxClientLN.MaxLength = 20;
            textBoxClientLN.Name = "textBoxClientLN";
            textBoxClientLN.PlaceholderText = "Иванов*";
            textBoxClientLN.Size = new Size(184, 30);
            textBoxClientLN.TabIndex = 9;
            // 
            // textBoxClientFN
            // 
            textBoxClientFN.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxClientFN.Location = new Point(59, 136);
            textBoxClientFN.MaxLength = 15;
            textBoxClientFN.Name = "textBoxClientFN";
            textBoxClientFN.PlaceholderText = "Иван*";
            textBoxClientFN.Size = new Size(184, 30);
            textBoxClientFN.TabIndex = 8;
            // 
            // labelEditClient
            // 
            labelEditClient.AutoSize = true;
            labelEditClient.Font = new Font("Garamond", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelEditClient.Location = new Point(40, 48);
            labelEditClient.Name = "labelEditClient";
            labelEditClient.Size = new Size(507, 50);
            labelEditClient.TabIndex = 7;
            labelEditClient.Text = "Редактирование клиента";
            // 
            // buttonCancel
            // 
            buttonCancel.BackColor = SystemColors.Control;
            buttonCancel.FlatAppearance.BorderSize = 0;
            buttonCancel.FlatStyle = FlatStyle.Flat;
            buttonCancel.Location = new Point(128, 272);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(128, 32);
            buttonCancel.TabIndex = 13;
            buttonCancel.Text = "Отмена";
            buttonCancel.UseVisualStyleBackColor = false;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // EditClient
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(582, 353);
            Controls.Add(buttonCancel);
            Controls.Add(buttonApplyChanges);
            Controls.Add(textBoxEMail);
            Controls.Add(textBoxPhoneNumber);
            Controls.Add(textBoxClientLN);
            Controls.Add(textBoxClientFN);
            Controls.Add(labelEditClient);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "EditClient";
            Text = "Редактирование клиента";
            FormClosing += EditClient_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonApplyChanges;
        private TextBox textBoxEMail;
        private TextBox textBoxPhoneNumber;
        private TextBox textBoxClientLN;
        private TextBox textBoxClientFN;
        private Label labelEditClient;
        private Button buttonCancel;
    }
}