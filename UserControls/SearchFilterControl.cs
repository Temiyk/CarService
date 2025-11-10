using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace coursa4.UserControls
{
    public partial class SearchFilterControl : UserControl
    {
        public event EventHandler SearchApplied;
        public event EventHandler FilterReset;

        public string SearchText => textBoxSearch.Text;
        public string FilterBy => comboBoxFilterBy.SelectedItem?.ToString() ?? "Все";
        public string SortBy => comboBoxSortBy.SelectedItem?.ToString() ?? "Имя";
        public string SortOrder => comboBoxOrder.SelectedItem?.ToString() ?? "По возрастанию";

        public SearchFilterControl()
        {
            InitializeComponent();
            SetupDefaultValues();
        }

        public void SetFilterOptions(string[] options)
        {
            comboBoxFilterBy.Items.Clear();
            comboBoxFilterBy.Items.AddRange(options);
            if (options.Length > 0) comboBoxFilterBy.SelectedIndex = 0;
        }

        public void SetSortOptions(string[] options)
        {
            comboBoxSortBy.Items.Clear();
            comboBoxSortBy.Items.AddRange(options);
            if (options.Length > 0) comboBoxSortBy.SelectedIndex = 0;
        }
        public void ResetAll()
        {
            textBoxSearch.Clear();
            if (comboBoxFilterBy.Items.Count > 0) comboBoxFilterBy.SelectedIndex = 0;
            if (comboBoxSortBy.Items.Count > 0) comboBoxSortBy.SelectedIndex = 0;
            comboBoxOrder.SelectedIndex = 0;
        }
        public void ClearSearch()
        {
            textBoxSearch.Clear();
        }

        private void SetupDefaultValues()
        {
            comboBoxOrder.Items.AddRange(new object[] { "По возрастанию", "По убыванию" });
            comboBoxOrder.SelectedIndex = 0;
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            SearchApplied?.Invoke(this, EventArgs.Empty);
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            ResetAll();
            FilterReset?.Invoke(this, EventArgs.Empty);
        }
    }
}
