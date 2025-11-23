namespace coursa4.UserControls
{
    partial class SearchFilterControl
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            textBoxSearch = new TextBox();
            labelFilter = new Label();
            comboBoxFilterBy = new ComboBox();
            buttonApply = new Button();
            buttonReset = new Button();
            SuspendLayout();
            // 
            // textBoxSearch
            // 
            textBoxSearch.Location = new Point(10, 25);
            textBoxSearch.Name = "textBoxSearch";
            textBoxSearch.PlaceholderText = "Поиск...";
            textBoxSearch.Size = new Size(250, 27);
            textBoxSearch.TabIndex = 0;
            // 
            // labelFilter
            // 
            labelFilter.AutoSize = true;
            labelFilter.Location = new Point(280, 5);
            labelFilter.Name = "labelFilter";
            labelFilter.Size = new Size(63, 20);
            labelFilter.TabIndex = 1;
            labelFilter.Text = "Фильтр:";
            // 
            // comboBoxFilterBy
            // 
            comboBoxFilterBy.FormattingEnabled = true;
            comboBoxFilterBy.Location = new Point(280, 25);
            comboBoxFilterBy.Name = "comboBoxFilterBy";
            comboBoxFilterBy.Size = new Size(150, 28);
            comboBoxFilterBy.TabIndex = 2;
            // 
            // buttonApply
            // 
            buttonApply.BackColor = Color.SteelBlue;
            buttonApply.ForeColor = Color.White;
            buttonApply.Location = new Point(450, 25);
            buttonApply.Name = "buttonApply";
            buttonApply.Size = new Size(100, 30);
            buttonApply.TabIndex = 7;
            buttonApply.Text = "Применить";
            buttonApply.UseVisualStyleBackColor = false;
            buttonApply.Click += buttonApply_Click;
            // 
            // buttonReset
            // 
            buttonReset.BackColor = Color.LightGray;
            buttonReset.ForeColor = Color.Black;
            buttonReset.Location = new Point(560, 25);
            buttonReset.Name = "buttonReset";
            buttonReset.Size = new Size(100, 30);
            buttonReset.TabIndex = 8;
            buttonReset.Text = "Сбросить";
            buttonReset.UseVisualStyleBackColor = false;
            buttonReset.Click += buttonReset_Click;
            // 
            // SearchFilterControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(buttonReset);
            Controls.Add(buttonApply);
            Controls.Add(comboBoxFilterBy);
            Controls.Add(labelFilter);
            Controls.Add(textBoxSearch);
            Name = "SearchFilterControl";
            Size = new Size(900, 70);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxSearch;
        private Label labelFilter;
        private ComboBox comboBoxFilterBy;
        private Button buttonApply;
        private Button buttonReset;
    }
}
