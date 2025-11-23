using coursa4.Data;
using coursa4.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace coursa4.UserControls
{
    public partial class OrdersControl : BaseListControl
    {
        private List<Order> orders;
        public OrdersControl()
        {
            InitializeComponent();
            LoadData();
        }
        protected override void buttonAdd_Click(object sender, EventArgs e)
        {
            var addOrderForm = new AddOrder();
            if (addOrderForm.ShowDialog() == DialogResult.OK)
            {
                LoadData();
                SearchFilter.ClearSearch();
                return;
            }
        }
        protected override void buttonEdit_Click(object sender, EventArgs e)
        {
            if (DataGridView.SelectedRows.Count > 0)
            {

                try
                {
                    //var orderId =
                    //
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при открытии формы редактирования: {ex.Message}", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else {
                MessageBox.Show("Выберите заказ для редактирования", "Информация",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        protected override void buttonUpdate_Click(object sender, EventArgs e)
        {
            LoadData();
            SearchFilter.ResetAll();
        }
        protected override void buttonDelete_Click(object sender, EventArgs e)
        {
            if (DataGridView.SelectedRows.Count > 0)
            {
                var orderId = (int)DataGridView.SelectedRows[0].Cells["Id"].Value;
                var clientName = DataGridView.SelectedRows[0].Cells["Client"].Value.ToString();

                var result = MessageBox.Show($"Вы уверены, что хотите удалить заказ клиента {clientName}?",
                    "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        using var context = new Coursa4Context();
                        var order = context.Orders.Find(orderId);

                        if (order != null)
                        {
                            var employee = context.Employees.Find(order.EmployeeId);
                            if (employee != null)
                            {
                                employee.Status = "Свободен";
                            }

                            context.Orders.Remove(order);
                            context.SaveChanges();

                            LoadData();
                            MessageBox.Show("Заказ успешно удален", "Успех",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при удалении заказа: {ex.Message}", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите заказ для удаления", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public override void LoadData()
        {
            try
            {
                using var context = new Coursa4Context();
                orders = context.Orders
                    .Include(o => o.Client)
                    .Include(o => o.Vehicle)
                    .Include(o => o.Employee)
                    .Include(o => o.Services)
                    .AsNoTracking()
                    .ToList();

                if (orders.Count == 0)
                {
                    MessageBox.Show("В базе данных отсутствуют заказы.", "Информация",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                DisplayOrders();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке заказов: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayOrders()
        {
            DataGridView.Rows.Clear();

            foreach (var order in orders)
            {
                DataGridView.Rows.Add(
                    order.Id,
                    $"{order.Client?.FirstName} {order.Client?.LastName}",
                    $"{order.Vehicle?.Brand} {order.Vehicle?.Model}",
                    order.AcceptionDate.ToString("dd.MM.yyyy"),
                    order.EstimatedCompletionDate.ToString("dd.MM.yyyy"),
                    order.Status,
                    order.Price.ToString("C2"),
                    $"{order.Employee?.FirstName} {order.Employee?.LastName}",
                    order.Services.Count
                );
            }
        }
    }
}
