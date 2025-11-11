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
        public event EventHandler AddButtonClicked;
        public event EventHandler EditButtonClicked;
        public event EventHandler DeleteButtonClicked;
        public event EventHandler RefreshButtonClicked;

        public DataGridView DataGridView => dataGridView1;
        public SearchFilterControl SearchFilter => searchFilterControl1;

        public BaseListControl()
        {
            InitializeComponent();
            SetupDataGridView();
            SubscribeToEvents();
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
        }
        private void SubscribeToEvents()
        {
            buttonAdd.Click += buttonAdd_Click;
            buttonEdit.Click += buttonEdit_Click;
            buttonDelete.Click += buttonDelete_Click;
            buttonUpdate.Click += buttonUpdate_Click;

            searchFilterControl1.SearchApplied += searchFilterControl_SearchApplied;
            searchFilterControl1.FilterReset += searchFilterControl_FilterReset;
        }


        private void searchFilterControl_SearchApplied(object sender, EventArgs e)
        {
            //ApplyFilter(searchFilterControl1.SearchText, searchFilterControl1.FilterBy, searchFilterControl1.SortBy, searchFilterControl1.SortOrder);
        }

        internal void searchFilterControl_FilterReset(object sender, EventArgs e)
        {
            LoadData();
        }

        protected virtual void buttonAdd_Click(object sender, EventArgs e)
        {
            AddButtonClicked?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void buttonEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                EditButtonClicked?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                MessageBox.Show("Выберите запись для редактирования", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        protected virtual void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var result = MessageBox.Show("Вы уверены, что хотите удалить выбранную запись?",
                    "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    DeleteButtonClicked?.Invoke(this, EventArgs.Empty);
                }
            }
            else
            {
                MessageBox.Show("Выберите запись для удаления", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        protected virtual void buttonUpdate_Click(object sender, EventArgs e)
        {
            RefreshButtonClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
