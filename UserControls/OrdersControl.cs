using coursa4.Data;
using coursa4.Models;
using coursa4.ReportControls;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace coursa4.UserControls
{
    public partial class OrdersControl : BaseListControl
    {
        private List<Order> orders;
        private List<Order> filteredOrders;
        private Button buttonComplete;

        public OrdersControl()
        {
            InitializeComponent();
            SetupDataGridViewColumns();
            SetupSearchFilter();
            LoadData();
            SearchFilter.SearchApplied += SearchFilter_SearchApplied;
            AddCompleteButton();
        }
        private void AddCompleteButton()
        {
            buttonComplete = new System.Windows.Forms.Button // Явное указание
            {
                Text = "Завершить заказ",
                BackColor = System.Drawing.Color.ForestGreen, // Явное указание
                ForeColor = System.Drawing.Color.White, // Явное указание
                FlatStyle = FlatStyle.Flat,
                Size = new System.Drawing.Size(120, 30),
                Location = new System.Drawing.Point(450, 10)
            };
            buttonComplete.Click += buttonComplete_Click;
            this.Controls.Add(buttonComplete);
            buttonComplete.BringToFront();
        }
        private void buttonComplete_Click(object sender, EventArgs e)
        {
            if (DataGridView.SelectedRows.Count > 0)
            {
                var orderId = (int)DataGridView.SelectedRows[0].Cells["Id"].Value;
                var clientName = DataGridView.SelectedRows[0].Cells["Client"].Value.ToString();

                var result = MessageBox.Show($"Вы уверены, что хотите завершить заказ клиента {clientName}?",
                    "Подтверждение завершения", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        using (var context = new Coursa4Context())
                        {
                            // Находим заказ в базе данных
                            var order = context.Orders
                                .Include(o => o.Client)
                                .Include(o => o.Vehicle)
                                .Include(o => o.Services)
                                .Include(o => o.Employees)
                                .FirstOrDefault(o => o.Id == orderId);

                            if (order != null)
                            {
                                // Проверяем текущий статус
                                if (order.Status == "Завершен")
                                {
                                    MessageBox.Show("Этот заказ уже завершен",
                                        "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }

                                // Обновляем свойства заказа
                                order.Status = "Завершен";
                                // Преобразуем Local в UTC для PostgreSQL
                                order.ActualCompletionDate = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);

                                // Обновляем статус сотрудников на "Свободен"
                                foreach (var employee in order.Employees)
                                {
                                    employee.Status = "Свободен";
                                    context.Entry(employee).State = EntityState.Modified;
                                }

                                // Сохраняем изменения в БД
                                context.SaveChanges();

                                // Обновляем данные на форме
                                LoadData();

                                // Генерируем отчет в отдельном потоке
                                Task.Run(() =>
                                {
                                    try
                                    {
                                        var reportGenerator = new ReportGenerator();
                                        bool reportGenerated = reportGenerator.GenerateOrderReport(orderId);

                                        this.Invoke((MethodInvoker)delegate
                                        {
                                            if (reportGenerated)
                                            {
                                                MessageBox.Show($"Заказ №{orderId} успешно завершен. Отчет сгенерирован.",
                                                    "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            }
                                            else
                                            {
                                                MessageBox.Show($"Заказ №{orderId} завершен, но отчет не был сгенерирован.",
                                                    "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            }
                                        });
                                    }
                                    catch (Exception ex)
                                    {
                                        this.Invoke((MethodInvoker)delegate
                                        {
                                            MessageBox.Show($"Ошибка при генерации отчета: {ex.Message}",
                                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        });
                                    }
                                });
                            }
                            else
                            {
                                MessageBox.Show("Заказ не найден в базе данных",
                                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Показываем полную информацию об ошибке
                        string errorMessage = $"Ошибка при завершении заказа: {ex.Message}";

                        if (ex.InnerException != null)
                        {
                            errorMessage += $"\nВнутренняя ошибка: {ex.InnerException.Message}";
                        }

                        MessageBox.Show(errorMessage,
                            "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите заказ для завершения", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void SetupSearchFilter()
        {
            string[] filterOptions = { "Все", "Клиент", "Автомобиль", "Статус" };
            SearchFilter.SetFilterOptions(filterOptions);
        }

        private void SetupDataGridViewColumns()
        {
            DataGridView.Columns.Clear();

            DataGridView.Columns.Add("Id", "ID");
            DataGridView.Columns.Add("Client", "Клиент");
            DataGridView.Columns.Add("Vehicle", "Автомобиль");
            DataGridView.Columns.Add("AcceptDate", "Дата приема");
            DataGridView.Columns.Add("CompleteDate", "Дата завершения");
            DataGridView.Columns.Add("Status", "Статус");
            DataGridView.Columns.Add("Price", "Стоимость");
            DataGridView.Columns.Add("ServicesCount", "Кол-во услуг");

            DataGridView.Columns["Id"].Visible = false;
            DataGridView.Columns["Price"].DefaultCellStyle.Format = "C2";

            DataGridView.Columns["Client"].Width = 150;
            DataGridView.Columns["Vehicle"].Width = 150;
            DataGridView.Columns["AcceptDate"].Width = 100;
            DataGridView.Columns["CompleteDate"].Width = 100;
            DataGridView.Columns["Status"].Width = 100;
            DataGridView.Columns["Price"].Width = 100;
            DataGridView.Columns["ServicesCount"].Width = 80;
        }

        private void SearchFilter_SearchApplied(object sender, EventArgs e)
        {
            ApplyFilter(SearchFilter.SearchText, SearchFilter.FilterBy);
        }

        protected override void ApplyFilter(string searchText, string filterBy)
        {
            if (string.IsNullOrEmpty(searchText))
            {
                filteredOrders = new List<Order>(orders);
            }
            else
            {
                filteredOrders = orders.Where(order =>
                {
                    switch (filterBy)
                    {
                        case "Клиент":
                            var clientName = $"{order.Client?.FirstName} {order.Client?.LastName}";
                            return clientName.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0;
                        case "Автомобиль":
                            var vehicleInfo = $"{order.Vehicle?.Brand} {order.Vehicle?.Model}";
                            return vehicleInfo.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0;
                        case "Статус":
                            return order.Status?.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0;
                        case "Все":
                        default:
                            var clientNameAll = $"{order.Client?.FirstName} {order.Client?.LastName}";
                            var vehicleInfoAll = $"{order.Vehicle?.Brand} {order.Vehicle?.Model}";

                            return (clientNameAll.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0) ||
                                   (vehicleInfoAll.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0) ||
                                   (order.Status?.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0) ||
                                   (order.Price.ToString().IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0);
                    }
                }).ToList();
            }

            DisplayOrders();
        }
        protected override void buttonAdd_Click(object sender, EventArgs e)
        {
            var addOrderForm = new AddOrder();
            if (addOrderForm.ShowDialog() == DialogResult.OK)
            {
                LoadData();
                SearchFilter.ClearSearch();
            }
        }
        protected override void buttonEdit_Click(object sender, EventArgs e)
        {
            if (DataGridView.SelectedRows.Count > 0)
            {
                var orderId = (int)DataGridView.SelectedRows[0].Cells["Id"].Value;
                try
                {
                    var editOrderForm = new EditForms.EditOrder(orderId);
                    if (editOrderForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadData();
                        SearchFilter.ClearSearch();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при открытии формы редактирования: {ex.Message}", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
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
                        var order = context.Orders
                            .Include(o => o.Services)
                            .FirstOrDefault(o => o.Id == orderId);

                        if (order != null)
                        {
                            order.Services.Clear();
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
                    .Include(o => o.Services)
                    .AsNoTracking()
                    .OrderByDescending(o => o.AcceptionDate)
                    .ToList();

                filteredOrders = new List<Order>(orders);
                DisplayOrders();

                if (orders.Count == 0)
                {
                    MessageBox.Show("В базе данных отсутствуют заказы.", "Информация",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
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

            foreach (var order in filteredOrders)
            {
                string acceptDate = order.AcceptionDate.ToString("dd.MM.yyyy");
                string completeDate = order.EstimatedCompletionDate.ToString("dd.MM.yyyy");
                string status = order.Status;
                string price = order.Price.ToString("C2");

                DataGridView.Rows.Add(
                    order.Id,
                    $"{order.Client?.FirstName} {order.Client?.LastName}",
                    $"{order.Vehicle?.Brand} {order.Vehicle?.Model}",
                    acceptDate,
                    completeDate,
                    status,
                    price,
                    order.Services.Count
                );
            }
        }
    }
}
