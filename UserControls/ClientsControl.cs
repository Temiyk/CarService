using coursa4.Data;
using coursa4.Models;
using coursa4.UserControls;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace coursa4
{
    public partial class ClientsControl : BaseListControl
    {
        private List<Client> clients;
        private List<Client> filteredClients;
        public ClientsControl()
        {
            InitializeComponent();
            SetupDataGridViewColumns();
            SetupSearchFilter();
            LoadData();
        }
        private void SetupDataGridViewColumns()
        {
            DataGridView.Columns.Clear();

            DataGridView.Columns.Add("Id", "ID");
            DataGridView.Columns.Add("FirstName", "Имя");
            DataGridView.Columns.Add("LastName", "Фамилия");
            DataGridView.Columns.Add("PhoneNumber", "Телефон");
            DataGridView.Columns.Add("Email", "Email");
            DataGridView.Columns.Add("VehiclesCount", "Кол-во авто");
            DataGridView.Columns.Add("OrdersCount", "Кол-во заказов");

            DataGridView.Columns["Id"].Visible = false;
            DataGridView.Columns["FirstName"].Width = 120;
            DataGridView.Columns["LastName"].Width = 120;
            DataGridView.Columns["PhoneNumber"].Width = 130;
            DataGridView.Columns["Email"].Width = 150;
            DataGridView.Columns["VehiclesCount"].Width = 80;
            DataGridView.Columns["OrdersCount"].Width = 80;
        }
        private void SetupSearchFilter()
        {
            string[] filterOptions = { "Все", "Имя", "Фамилия", "Телефон", "Email" };
            string[] sortOptions = { "Имя", "Фамилия", "Телефон", "Email", "Кол-во авто", "Кол-во заказов" };

            SearchFilter.SetFilterOptions(filterOptions);
            SearchFilter.SetSortOptions(sortOptions);
        }
        public override void LoadData()
        {
            try
            {
                using var context = new Coursa4Context();
                clients = context.Clients
                    .Include(c => c.Vehicles)
                    .Include(c => c.Orders)
                    .AsNoTracking()
                    .ToList();

                filteredClients = new List<Client>(clients);
                DisplayClients();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке клиентов: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DisplayClients()
        {
            DataGridView.Rows.Clear();

            foreach (var client in filteredClients)
            {
                DataGridView.Rows.Add(
                    client.Id,
                    client.FirstName ?? "",
                    client.LastName ?? "",
                    client.PhoneNumber ?? "",
                    client.Email ?? "",
                    client.Vehicles?.Count ?? 0,
                    client.Orders?.Count ?? 0
                );
            }
        }
        protected override void buttonAdd_Click(object sender, EventArgs e)
        {
            var addClientForm = new AddClient();
            if (addClientForm.ShowDialog() == DialogResult.OK)
            {
                LoadData();
                SearchFilter.ClearSearch();
            }
        }
        protected override void buttonUpdate_Click(object sender, EventArgs e)
        {
            LoadData();
            SearchFilter.ResetAll();
        }
        protected override void buttonDelete_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Удаление сотрудников в разработке", "Информация",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
