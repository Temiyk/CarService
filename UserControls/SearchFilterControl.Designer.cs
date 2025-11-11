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
            comboBoxSortBy = new ComboBox();
            labelSort = new Label();
            comboBoxOrder = new ComboBox();
            labelOrder = new Label();
            buttonApply = new Button();
            buttonReset = new Button();
            SuspendLayout();
            // 
            // textBoxSearch
            // 
            textBoxSearch.Location = new Point(10, 25);
            textBoxSearch.Name = "textBoxSearch";
            textBoxSearch.PlaceholderText = "Поиск...";
            textBoxSearch.Size = new Size(180, 27);
            textBoxSearch.TabIndex = 0;
            // 
            // labelFilter
            // 
            labelFilter.AutoSize = true;
            labelFilter.Location = new Point(210, 5);
            labelFilter.Name = "labelFilter";
            labelFilter.Size = new Size(63, 20);
            labelFilter.TabIndex = 1;
            labelFilter.Text = "Фильтр:";
            // 
            // comboBoxFilterBy
            // 
            comboBoxFilterBy.FormattingEnabled = true;
            comboBoxFilterBy.Location = new Point(210, 25);
            comboBoxFilterBy.Name = "comboBoxFilterBy";
            comboBoxFilterBy.Size = new Size(120, 28);
            comboBoxFilterBy.TabIndex = 2;
            // 
            // comboBoxSortBy
            // 
            comboBoxSortBy.FormattingEnabled = true;
            comboBoxSortBy.Location = new Point(350, 25);
            comboBoxSortBy.Name = "comboBoxSortBy";
            comboBoxSortBy.Size = new Size(120, 28);
            comboBoxSortBy.TabIndex = 4;
            // 
            // labelSort
            // 
            labelSort.AutoSize = true;
            labelSort.Location = new Point(350, 5);
            labelSort.Name = "labelSort";
            labelSort.Size = new Size(95, 20);
            labelSort.TabIndex = 3;
            labelSort.Text = "Сортировка:";
            // 
            // comboBoxOrder
            // 
            comboBoxOrder.FormattingEnabled = true;
            comboBoxOrder.Location = new Point(490, 25);
            comboBoxOrder.Name = "comboBoxOrder";
            comboBoxOrder.Size = new Size(130, 28);
            comboBoxOrder.TabIndex = 5;
            // 
            // labelOrder
            // 
            labelOrder.AutoSize = true;
            labelOrder.Location = new Point(490, 5);
            labelOrder.Name = "labelOrder";
            labelOrder.Size = new Size(73, 20);
            labelOrder.TabIndex = 6;
            labelOrder.Text = "Порядок:";
            // 
            // buttonApply
            // 
            buttonApply.BackColor = Color.SteelBlue;
            buttonApply.ForeColor = Color.White;
            buttonApply.Location = new Point(648, 25);
            buttonApply.Name = "buttonApply";
            buttonApply.Size = new Size(104, 30);
            buttonApply.TabIndex = 7;
            buttonApply.Text = "Применить";
            buttonApply.UseVisualStyleBackColor = false;
            buttonApply.Click += buttonApply_Click;
            // 
            // buttonReset
            // 
            buttonReset.BackColor = Color.LightGray;
            buttonReset.ForeColor = Color.Black;
            buttonReset.Location = new Point(768, 25);
            buttonReset.Name = "buttonReset";
            buttonReset.Size = new Size(104, 30);
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
            Controls.Add(labelOrder);
            Controls.Add(comboBoxOrder);
            Controls.Add(comboBoxSortBy);
            Controls.Add(labelSort);
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
        private ComboBox comboBoxSortBy;
        private Label labelSort;
        private ComboBox comboBoxOrder;
        private Label labelOrder;
        private Button buttonApply;
        private Button buttonReset;
    }
}
