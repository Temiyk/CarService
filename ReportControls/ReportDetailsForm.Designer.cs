namespace coursa4
{
    partial class ReportDetailsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportDetailsForm));
            labelOrderId = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            listBoxServices = new ListBox();
            listBoxEmployees = new ListBox();
            labelClientValue = new Label();
            labelVehicleValue = new Label();
            labelAcceptDateValue = new Label();
            labelCompleteDateValue = new Label();
            labelPriceValue = new Label();
            groupBox3 = new GroupBox();
            labelFileInfo = new Label();
            buttonOpenFile = new Button();
            tableLayoutPanel1.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // labelOrderId
            // 
            labelOrderId.AutoSize = true;
            labelOrderId.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelOrderId.ForeColor = Color.SteelBlue;
            labelOrderId.Location = new Point(20, 20);
            labelOrderId.Name = "labelOrderId";
            labelOrderId.Size = new Size(198, 28);
            labelOrderId.TabIndex = 0;
            labelOrderId.Text = "Отчет по заказу №";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(label2, 0, 1);
            tableLayoutPanel1.Controls.Add(label3, 0, 2);
            tableLayoutPanel1.Controls.Add(label4, 0, 3);
            tableLayoutPanel1.Controls.Add(label5, 0, 4);
            tableLayoutPanel1.Controls.Add(labelClientValue, 1, 0);
            tableLayoutPanel1.Controls.Add(labelVehicleValue, 1, 1);
            tableLayoutPanel1.Controls.Add(labelAcceptDateValue, 1, 2);
            tableLayoutPanel1.Controls.Add(labelCompleteDateValue, 1, 3);
            tableLayoutPanel1.Controls.Add(labelPriceValue, 1, 4);
            tableLayoutPanel1.Location = new Point(20, 60);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 5;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.Size = new Size(500, 150);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(66, 20);
            label1.TabIndex = 0;
            label1.Text = "Клиент:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label2.Location = new Point(3, 30);
            label2.Name = "label2";
            label2.Size = new Size(105, 20);
            label2.TabIndex = 1;
            label2.Text = "Автомобиль:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label3.Location = new Point(3, 60);
            label3.Name = "label3";
            label3.Size = new Size(107, 20);
            label3.TabIndex = 2;
            label3.Text = "Дата приёма:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label4.Location = new Point(3, 90);
            label4.Name = "label4";
            label4.Size = new Size(141, 20);
            label4.TabIndex = 3;
            label4.Text = "Дата завершения:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label5.Location = new Point(3, 120);
            label5.Name = "label5";
            label5.Size = new Size(90, 20);
            label5.TabIndex = 4;
            label5.Text = "Стоимость:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(listBoxServices);
            groupBox1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            groupBox1.Location = new Point(20, 220);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(350, 200);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Выполненные услуги";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(listBoxEmployees);
            groupBox2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            groupBox2.Location = new Point(400, 220);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(350, 200);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Ответственные сотрудники";
            // 
            // listBoxServices
            // 
            listBoxServices.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            listBoxServices.FormattingEnabled = true;
            listBoxServices.Location = new Point(10, 25);
            listBoxServices.Name = "listBoxServices";
            listBoxServices.Size = new Size(330, 164);
            listBoxServices.TabIndex = 0;
            // 
            // listBoxEmployees
            // 
            listBoxEmployees.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            listBoxEmployees.FormattingEnabled = true;
            listBoxEmployees.Location = new Point(10, 25);
            listBoxEmployees.Name = "listBoxEmployees";
            listBoxEmployees.Size = new Size(330, 164);
            listBoxEmployees.TabIndex = 0;
            // 
            // labelClientValue
            // 
            labelClientValue.AutoSize = true;
            labelClientValue.Location = new Point(153, 0);
            labelClientValue.Name = "labelClientValue";
            labelClientValue.Size = new Size(50, 20);
            labelClientValue.TabIndex = 5;
            labelClientValue.Text = "label6";
            labelClientValue.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelVehicleValue
            // 
            labelVehicleValue.AutoSize = true;
            labelVehicleValue.Location = new Point(153, 30);
            labelVehicleValue.Name = "labelVehicleValue";
            labelVehicleValue.Size = new Size(50, 20);
            labelVehicleValue.TabIndex = 6;
            labelVehicleValue.Text = "label7";
            labelVehicleValue.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelAcceptDateValue
            // 
            labelAcceptDateValue.AutoSize = true;
            labelAcceptDateValue.Location = new Point(153, 60);
            labelAcceptDateValue.Name = "labelAcceptDateValue";
            labelAcceptDateValue.Size = new Size(50, 20);
            labelAcceptDateValue.TabIndex = 7;
            labelAcceptDateValue.Text = "label8";
            labelAcceptDateValue.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelCompleteDateValue
            // 
            labelCompleteDateValue.AutoSize = true;
            labelCompleteDateValue.Location = new Point(153, 90);
            labelCompleteDateValue.Name = "labelCompleteDateValue";
            labelCompleteDateValue.Size = new Size(50, 20);
            labelCompleteDateValue.TabIndex = 8;
            labelCompleteDateValue.Text = "label9";
            labelCompleteDateValue.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelPriceValue
            // 
            labelPriceValue.AutoSize = true;
            labelPriceValue.Location = new Point(153, 120);
            labelPriceValue.Name = "labelPriceValue";
            labelPriceValue.Size = new Size(58, 20);
            labelPriceValue.TabIndex = 9;
            labelPriceValue.Text = "label10";
            labelPriceValue.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(buttonOpenFile);
            groupBox3.Controls.Add(labelFileInfo);
            groupBox3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            groupBox3.Location = new Point(20, 430);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(500, 80);
            groupBox3.TabIndex = 4;
            groupBox3.TabStop = false;
            groupBox3.Text = "Файл отчета";
            // 
            // labelFileInfo
            // 
            labelFileInfo.AutoSize = true;
            labelFileInfo.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelFileInfo.Location = new Point(10, 25);
            labelFileInfo.Name = "labelFileInfo";
            labelFileInfo.Size = new Size(0, 20);
            labelFileInfo.TabIndex = 0;
            // 
            // buttonOpenFile
            // 
            buttonOpenFile.BackColor = Color.DodgerBlue;
            buttonOpenFile.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonOpenFile.ForeColor = Color.White;
            buttonOpenFile.Location = new Point(320, 22);
            buttonOpenFile.Name = "buttonOpenFile";
            buttonOpenFile.Size = new Size(100, 30);
            buttonOpenFile.TabIndex = 1;
            buttonOpenFile.Text = "Открыть файл";
            buttonOpenFile.UseVisualStyleBackColor = false;
            buttonOpenFile.Click += buttonOpenFile_Click;
            // 
            // ReportDetailsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(782, 553);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(labelOrderId);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ReportDetailsForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Отчёт";
            Load += ReportDetailsForm_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelOrderId;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label labelClientValue;
        private Label labelVehicleValue;
        private Label labelAcceptDateValue;
        private Label labelCompleteDateValue;
        private Label labelPriceValue;
        private GroupBox groupBox1;
        private ListBox listBoxServices;
        private GroupBox groupBox2;
        private ListBox listBoxEmployees;
        private GroupBox groupBox3;
        private Button buttonOpenFile;
        private Label labelFileInfo;
    }
}