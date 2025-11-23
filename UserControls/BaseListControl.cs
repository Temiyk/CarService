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
    public partial class BaseListControl : UserControl
    {
        public DataGridView DataGridView => dataGridView1;
        public SearchFilterControl SearchFilter => searchFilterControl1;

        public BaseListControl()
        {
            InitializeComponent();
            SetupDataGridView();
        }
        virtual public void LoadData() {}
        private void SetupDataGridView()
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.BorderStyle = BorderStyle.None;

            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.Automatic;
            }
        }
        private void searchFilterControl_SearchApplied(object sender, EventArgs e)
        {
            ApplyFilter(searchFilterControl1.SearchText, searchFilterControl1.FilterBy);
        }

        internal void searchFilterControl_FilterReset(object sender, EventArgs e)
        {
            LoadData();
        }

        protected virtual void buttonAdd_Click(object sender, EventArgs e) {}
        protected virtual void buttonEdit_Click(object sender, EventArgs e) {}
        protected virtual void ApplyFilter(string searchText, string filterBy) {}
        protected virtual void buttonDelete_Click(object sender, EventArgs e) {}
        protected virtual void buttonUpdate_Click(object sender, EventArgs e) {}
    }
}
