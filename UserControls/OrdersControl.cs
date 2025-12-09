using coursa4.Data;
using coursa4.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

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
                    CompleteOrder(orderId);
                }
            }
            else
            {
                MessageBox.Show("Выберите заказ для завершения", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void CompleteOrder(int orderId)
        {
            try
            {
                using var context = new Coursa4Context();

                // Загружаем заказ со всеми связанными данными
                var order = context.Orders
                    .Include(o => o.Client)
                    .Include(o => o.Vehicle)
                    .Include(o => o.Services)
                    .Include(o => o.Employees)
                    .FirstOrDefault(o => o.Id == orderId);

                if (order != null)
                {
                    // Используем DateTime.UtcNow вместо DateTime.Now
                    order.Status = "Завершен";
                    order.ActualCompletionDate = DateTime.UtcNow;  // <-- ИСПРАВЛЕНО

                    foreach (var employee in order.Employees)
                    {
                        employee.Status = "Свободен";
                    }

                    context.SaveChanges();

                    GenerateOrderReport(order);

                    MessageBox.Show("Заказ успешно завершен и отчет создан", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при завершении заказа: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void GenerateOrderReport(Order order)
        {
            try
            {
                // Создаем папку Reports, если ее нет
                string reportsFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reports");
                if (!Directory.Exists(reportsFolder))
                {
                    Directory.CreateDirectory(reportsFolder);
                }

                // Создаем имя файла
                string fileName = Path.Combine(reportsFolder, $"{order.Id}.docx");

                // Создаем документ Word
                using (WordprocessingDocument wordDocument =
                    WordprocessingDocument.Create(fileName, WordprocessingDocumentType.Document))
                {
                    // Добавляем главную часть документа
                    MainDocumentPart mainPart = wordDocument.AddMainDocumentPart();
                    mainPart.Document = new Document();
                    Body body = new Body();

                    // Заголовок отчета
                    Paragraph titleParagraph = CreateParagraph($"Отчет по заказу №{order.Id}", true, 28);
                    body.Append(titleParagraph);

                    // Добавляем пустую строку
                    body.Append(CreateParagraph(""));

                    // Добавляем информацию о заказе
                    body.Append(CreateParagraph($"Клиент: {order.Client?.LastName} {order.Client?.FirstName}"));
                    body.Append(CreateParagraph($"Автомобиль: {order.Vehicle?.Brand} {order.Vehicle?.Model}, VIN: {order.Vehicle?.VIN}"));
                    body.Append(CreateParagraph($"Дата приема: {order.AcceptionDate:dd.MM.yyyy}"));

                    string completionDate = order.ActualCompletionDate.HasValue
                        ? order.ActualCompletionDate.Value.ToString("dd.MM.yyyy")
                        : "Не завершен";
                    body.Append(CreateParagraph($"Дата завершения: {completionDate}"));

                    body.Append(CreateParagraph($"Статус: {order.Status}"));
                    body.Append(CreateParagraph($"Стоимость: {order.Price:C2}"));

                    // Добавляем пустую строку
                    body.Append(CreateParagraph(""));

                    // Заголовок для услуг
                    Paragraph servicesTitle = CreateParagraph("Выполненные услуги:", true, 24);
                    body.Append(servicesTitle);

                    // Список услуг
                    if (order.Services != null && order.Services.Any())
                    {
                        foreach (var service in order.Services)
                        {
                            body.Append(CreateParagraph($"• {service.Name} - {service.Price:C2}"));

                            if (!string.IsNullOrEmpty(service.Description))
                            {
                                body.Append(CreateParagraph($"  Описание: {service.Description}"));
                            }
                        }
                    }
                    else
                    {
                        body.Append(CreateParagraph("Нет услуг"));
                    }

                    // Добавляем пустую строку
                    body.Append(CreateParagraph(""));

                    // Заголовок для сотрудников
                    Paragraph employeesTitle = CreateParagraph("Ответственные сотрудники:", true, 24);
                    body.Append(employeesTitle);

                    // Список сотрудников
                    if (order.Employees != null && order.Employees.Any())
                    {
                        foreach (var employee in order.Employees)
                        {
                            body.Append(CreateParagraph($"• {employee.LastName} {employee.FirstName}"));
                            body.Append(CreateParagraph($"  Специализация: {employee.Specialization}"));
                            body.Append(CreateParagraph($"  Статус: {employee.Status}"));
                        }
                    }
                    else
                    {
                        body.Append(CreateParagraph("Нет назначенных сотрудников"));
                    }

                    // Сохраняем документ
                    mainPart.Document.Append(body);
                    wordDocument.Save();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при создании отчета: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private Paragraph CreateParagraph(string text, bool isBold = false, int fontSize = 11)
        {
            Paragraph paragraph = new Paragraph();
            Run run = new Run();
            RunProperties runProperties = new RunProperties();

            if (isBold)
            {
                runProperties.Append(new Bold());
            }

            if (fontSize > 0)
            {
                runProperties.Append(new FontSize() { Val = (fontSize * 2).ToString() }); // Word использует half-points
            }

            run.Append(runProperties);
            run.Append(new Text(text));
            paragraph.Append(run);

            return paragraph;
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
