namespace coursa4
{
    partial class AddEmployee
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddEmployee));
            labelNewEmployee = new Label();
            textBoxEmployeeFN = new TextBox();
            textBoxEmloyeeLN = new TextBox();
            textBox2 = new TextBox();
            pictureBoxEmployee = new PictureBox();
            buttonAddEmployee = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBoxEmployee).BeginInit();
            SuspendLayout();
            // 
            // labelNewEmployee
            // 
            labelNewEmployee.AutoSize = true;
            labelNewEmployee.Font = new Font("Garamond", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelNewEmployee.Location = new Point(72, 32);
            labelNewEmployee.Name = "labelNewEmployee";
            labelNewEmployee.Size = new Size(377, 50);
            labelNewEmployee.TabIndex = 1;
            labelNewEmployee.Text = "Новый сотрудник";
            // 
            // textBoxEmployeeFN
            // 
            textBoxEmployeeFN.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxEmployeeFN.Location = new Point(168, 272);
            textBoxEmployeeFN.MaxLength = 15;
            textBoxEmployeeFN.Name = "textBoxEmployeeFN";
            textBoxEmployeeFN.PlaceholderText = "Иван*";
            textBoxEmployeeFN.Size = new Size(184, 30);
            textBoxEmployeeFN.TabIndex = 3;
            // 
            // textBoxEmloyeeLN
            // 
            textBoxEmloyeeLN.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxEmloyeeLN.Location = new Point(168, 320);
            textBoxEmloyeeLN.MaxLength = 15;
            textBoxEmloyeeLN.Name = "textBoxEmloyeeLN";
            textBoxEmloyeeLN.PlaceholderText = "Иванов*";
            textBoxEmloyeeLN.Size = new Size(184, 30);
            textBoxEmloyeeLN.TabIndex = 4;
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBox2.Location = new Point(168, 368);
            textBox2.MaxLength = 15;
            textBox2.Name = "textBox2";
            textBox2.PlaceholderText = "Инженер*";
            textBox2.Size = new Size(184, 30);
            textBox2.TabIndex = 5;
            // 
            // pictureBoxEmployee
            // 
            pictureBoxEmployee.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxEmployee.Location = new Point(192, 112);
            pictureBoxEmployee.Name = "pictureBoxEmployee";
            pictureBoxEmployee.Size = new Size(125, 125);
            pictureBoxEmployee.TabIndex = 6;
            pictureBoxEmployee.TabStop = false;
            // 
            // buttonAddEmployee
            // 
            buttonAddEmployee.Location = new Point(184, 440);
            buttonAddEmployee.Name = "buttonAddEmployee";
            buttonAddEmployee.Size = new Size(152, 48);
            buttonAddEmployee.TabIndex = 8;
            buttonAddEmployee.Text = "Подтвердить";
            buttonAddEmployee.UseVisualStyleBackColor = true;
            buttonAddEmployee.Click += buttonAddEmployee_Click;
            // 
            // AddEmployee
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(517, 523);
            Controls.Add(buttonAddEmployee);
            Controls.Add(pictureBoxEmployee);
            Controls.Add(textBox2);
            Controls.Add(textBoxEmloyeeLN);
            Controls.Add(textBoxEmployeeFN);
            Controls.Add(labelNewEmployee);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "AddEmployee";
            Text = "MotorbreathMaster";
            ((System.ComponentModel.ISupportInitialize)pictureBoxEmployee).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelNewEmployee;
        private TextBox textBoxEmployeeFN;
        private TextBox textBoxEmloyeeLN;
        private TextBox textBox2;
        private PictureBox pictureBoxEmployee;
        private Button buttonAddEmployee;
    }
}