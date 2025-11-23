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

        public SearchFilterControl()
        {
            InitializeComponent();
        }
        public void SetFilterOptions(string[] options)
        {
            comboBoxFilterBy.Items.Clear();
            comboBoxFilterBy.Items.AddRange(options);
            if (options.Length > 0) comboBoxFilterBy.SelectedIndex = 0;
        }
        public void ResetAll()
        {
            textBoxSearch.Clear();
            if (comboBoxFilterBy.Items.Count > 0) comboBoxFilterBy.SelectedIndex = 0;
        }
        public void ClearSearch()
        {
            textBoxSearch.Clear();
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
