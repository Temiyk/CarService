namespace coursa4
{
    partial class AddNewOrder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddNewOrder));
            buttonAddVehicle = new Button();
            labelNewOrder = new Label();
            SuspendLayout();
            // 
            // buttonAddVehicle
            // 
            buttonAddVehicle.Location = new Point(184, 648);
            buttonAddVehicle.Name = "buttonAddVehicle";
            buttonAddVehicle.Size = new Size(152, 48);
            buttonAddVehicle.TabIndex = 22;
            buttonAddVehicle.Text = "Подтвердить";
            buttonAddVehicle.UseVisualStyleBackColor = true;
            // 
            // labelNewOrder
            // 
            labelNewOrder.AutoSize = true;
            labelNewOrder.Font = new Font("Garamond", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelNewOrder.Location = new Point(128, 32);
            labelNewOrder.Name = "labelNewOrder";
            labelNewOrder.Size = new Size(277, 50);
            labelNewOrder.TabIndex = 18;
            labelNewOrder.Text = "Новый заказ";
            // 
            // AddNewOrder
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(517, 753);
            Controls.Add(labelNewOrder);
            Controls.Add(buttonAddVehicle);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "AddNewOrder";
            Text = "MotorbreathMaster";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button buttonAddVehicle;
        private Label labelNewOrder;
    }
}