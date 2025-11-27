namespace coursa4.EditForms
{
    partial class EditEmployee
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditEmployee));
            buttonEditEmployee = new Button();
            pictureBoxEditEmployee = new PictureBox();
            textBoxEditSpec = new TextBox();
            textBoxEditEmloyeeLN = new TextBox();
            textBoxEditEmployeeFN = new TextBox();
            labelEditEmployee = new Label();
            openFileDialog = new OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)pictureBoxEditEmployee).BeginInit();
            SuspendLayout();
            // 
            // buttonEditEmployee
            // 
            buttonEditEmployee.Location = new Point(182, 440);
            buttonEditEmployee.Name = "buttonEditEmployee";
            buttonEditEmployee.Size = new Size(152, 48);
            buttonEditEmployee.TabIndex = 14;
            buttonEditEmployee.Text = "Подтвердить";
            buttonEditEmployee.UseVisualStyleBackColor = true;
            buttonEditEmployee.Click += buttonEditEmployee_Click;
            // 
            // pictureBoxEditEmployee
            // 
            pictureBoxEditEmployee.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxEditEmployee.Location = new Point(190, 112);
            pictureBoxEditEmployee.Name = "pictureBoxEditEmployee";
            pictureBoxEditEmployee.Size = new Size(125, 125);
            pictureBoxEditEmployee.TabIndex = 13;
            pictureBoxEditEmployee.TabStop = false;
            pictureBoxEditEmployee.Click += pictureBoxEditEmployee_Click;
            // 
            // textBoxEditSpec
            // 
            textBoxEditSpec.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxEditSpec.Location = new Point(166, 368);
            textBoxEditSpec.MaxLength = 15;
            textBoxEditSpec.Name = "textBoxEditSpec";
            textBoxEditSpec.PlaceholderText = "Инженер*";
            textBoxEditSpec.Size = new Size(184, 30);
            textBoxEditSpec.TabIndex = 12;
            // 
            // textBoxEditEmloyeeLN
            // 
            textBoxEditEmloyeeLN.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxEditEmloyeeLN.Location = new Point(166, 320);
            textBoxEditEmloyeeLN.MaxLength = 15;
            textBoxEditEmloyeeLN.Name = "textBoxEditEmloyeeLN";
            textBoxEditEmloyeeLN.PlaceholderText = "Иванов*";
            textBoxEditEmloyeeLN.Size = new Size(184, 30);
            textBoxEditEmloyeeLN.TabIndex = 11;
            // 
            // textBoxEditEmployeeFN
            // 
            textBoxEditEmployeeFN.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxEditEmployeeFN.Location = new Point(166, 272);
            textBoxEditEmployeeFN.MaxLength = 15;
            textBoxEditEmployeeFN.Name = "textBoxEditEmployeeFN";
            textBoxEditEmployeeFN.PlaceholderText = "Иван*";
            textBoxEditEmployeeFN.Size = new Size(184, 30);
            textBoxEditEmployeeFN.TabIndex = 10;
            // 
            // labelEditEmployee
            // 
            labelEditEmployee.AutoSize = true;
            labelEditEmployee.Font = new Font("Garamond", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelEditEmployee.Location = new Point(24, 32);
            labelEditEmployee.Name = "labelEditEmployee";
            labelEditEmployee.Size = new Size(480, 50);
            labelEditEmployee.TabIndex = 9;
            labelEditEmployee.Text = "Изменение сотрудника";
            // 
            // openFileDialog
            // 
            openFileDialog.FileName = "openFileDialog1";
            // 
            // EditEmployee
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(517, 523);
            Controls.Add(buttonEditEmployee);
            Controls.Add(pictureBoxEditEmployee);
            Controls.Add(textBoxEditSpec);
            Controls.Add(textBoxEditEmloyeeLN);
            Controls.Add(textBoxEditEmployeeFN);
            Controls.Add(labelEditEmployee);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "EditEmployee";
            Text = "MotorbreathMaster - Редактирование сотрудника";
            ((System.ComponentModel.ISupportInitialize)pictureBoxEditEmployee).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonEditEmployee;
        private PictureBox pictureBoxEditEmployee;
        private TextBox textBoxEditSpec;
        private TextBox textBoxEditEmloyeeLN;
        private TextBox textBoxEditEmployeeFN;
        private Label labelEditEmployee;
        private OpenFileDialog openFileDialog;
    }
}