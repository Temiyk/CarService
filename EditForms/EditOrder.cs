using coursa4.Data;
using coursa4.Models;
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

namespace coursa4.EditForms
{
    public partial class EditOrder : Form
    {
        private int orderId;
        private Order order;
        private List<Service> allServices;
        private Coursa4Context context;

        private List<Employee> allEmployees;
        private Dictionary<string, ComboBox> specializationComboBoxes = new Dictionary<string, ComboBox>();
        private Dictionary<string, List<Employee>> employeesBySpecialization = new Dictionary<string, List<Employee>>();
        public EditOrder(int orderId)
        {
            InitializeComponent();
            this.orderId = orderId;
            context = new Coursa4Context();
            comboBoxClients.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxVehicles.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxClients.SelectedIndexChanged += comboBoxClients_SelectedIndexChanged;
            dataGridViewServices.CellValueChanged += dataGridViewServices_CellValueChanged;
            LoadClients();
            LoadAllEmployees();
            LoadServices();
            LoadOrderData();
        }
        private void LoadAllEmployees()
        {
            try
            {
                allEmployees = context.Employees
                    .OrderBy(e => e.Specialization)
                    .ThenBy(e => e.LastName)
                    .ThenBy(e => e.FirstName)
                    .ToList();

                employeesBySpecialization = allEmployees
                    .GroupBy(e => e.Specialization)
                    .ToDictionary(g => g.Key, g => g.ToList());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке сотрудников: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadOrderData()
        {
            try
            {
                order = context.Orders
                    .Include(o => o.Client)
                    .Include(o => o.Vehicle)
                    .Include(o => o.Employees)
                    .Include(o => o.Services)
                    .FirstOrDefault(o => o.Id == orderId);

                if (order != null)
                {
                    // Загрузка клиента
                    foreach (dynamic item in comboBoxClients.Items)
                    {
                        if (item.Id == order.ClientId)
                        {
                            comboBoxClients.SelectedItem = item;
                            break;
                        }
                    }

                    LoadClientVehicles();
                    foreach (dynamic item in comboBoxVehicles.Items)
                    {
                        if (item.Id == order.VehicleId)
                        {
                            comboBoxVehicles.SelectedItem = item;
                            break;
                        }
                    }

                    dateTimePickerAcceptanceDate.Value = order.AcceptionDate;
                    dateTimePickerEstimatedDate.Value = order.EstimatedCompletionDate;
                    LoadServices();
                    CreateEmployeeSelectionControls();
                    SelectAssignedEmployees();
                    CalculateTotalPrice();
                }
                else
                {
                    MessageBox.Show("Заказ не найден!", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных заказа: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadClientVehicles()
        {
            if (comboBoxClients.SelectedItem == null) return;
            try
            {
                var clientId = (int)((dynamic)comboBoxClients.SelectedItem).Id;

                var vehicles = context.Vehicles
                    .Where(v => v.ClientId == clientId)
                    .OrderBy(v => v.Brand)
                    .ThenBy(v => v.Model)
                    .ToList();

                comboBoxVehicles.DisplayMember = "DisplayName";
                comboBoxVehicles.ValueMember = "Id";

                comboBoxVehicles.Items.Clear();
                foreach (var vehicle in vehicles)
                {
                    comboBoxVehicles.Items.Add(new
                    {
                        Id = vehicle.Id,
                        DisplayName = $"{vehicle.Brand} {vehicle.Model} - {vehicle.LicensePlate}"
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке автомобилей: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CreateEmployeeSelectionControls()
        {
            // Очищаем панель
            panelEmployeeControls.Controls.Clear();
            specializationComboBoxes.Clear();

            // Получаем требуемые специализации из выбранных услуг
            var requiredSpecializations = GetRequiredSpecializations();

            if (requiredSpecializations.Count == 0)
            {
                var label = new Label();
                label.Text = "Выберите услуги для отображения списка сотрудников";
                label.Location = new Point(10, 10);
                label.AutoSize = true;
                panelEmployeeControls.Controls.Add(label);
                return;
            }

            int yPosition = 10;

            foreach (var specialization in requiredSpecializations)
            {
                // Label для специализации
                var label = new Label();
                label.Text = $"{specialization}:";
                label.Location = new Point(10, yPosition);
                label.Size = new Size(150, 25);
                label.TextAlign = ContentAlignment.MiddleRight;

                // ComboBox для выбора сотрудника
                var comboBox = new ComboBox();
                comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                comboBox.Location = new Point(170, yPosition);
                comboBox.Size = new Size(300, 28);
                comboBox.Tag = specialization;

                // Заполняем ComboBox сотрудниками этой специализации
                if (employeesBySpecialization.ContainsKey(specialization))
                {
                    comboBox.DisplayMember = "DisplayName";
                    comboBox.ValueMember = "Id";

                    var employees = employeesBySpecialization[specialization];

                    // Добавляем пустой элемент ПЕРВЫМ
                    comboBox.Items.Add(new
                    {
                        Id = 0,
                        DisplayName = "Не назначено",
                        Employee = (Employee)null
                    });

                    // Затем добавляем сотрудников
                    foreach (var employee in employees)
                    {
                        comboBox.Items.Add(new
                        {
                            Id = employee.Id,
                            DisplayName = $"{employee.LastName} {employee.FirstName} - {employee.Status}",
                            Employee = employee
                        });
                    }

                    comboBox.SelectedIndex = 0;
                }
                else
                {
                    // Если нет сотрудников, добавляем только информационную строку
                    comboBox.Items.Add("Нет доступных сотрудников");
                    comboBox.SelectedIndex = 0;
                    comboBox.Enabled = false;
                }

                // Добавляем контролы на панель
                panelEmployeeControls.Controls.Add(label);
                panelEmployeeControls.Controls.Add(comboBox);

                // Сохраняем ссылку на ComboBox
                specializationComboBoxes[specialization] = comboBox;

                yPosition += 35;
            }
        }
        private void SelectAssignedEmployees()
        {
            if (order == null || order.Employees == null)
                return;

            foreach (var employee in order.Employees)
            {
                var specialization = employee.Specialization;

                if (specializationComboBoxes.ContainsKey(specialization))
                {
                    var comboBox = specializationComboBoxes[specialization];

                    // Ищем элемент с нужным ID сотрудника
                    for (int i = 0; i < comboBox.Items.Count; i++)
                    {
                        var item = comboBox.Items[i];

                        // Пропускаем строковые элементы (например, "Нет доступных сотрудников")
                        if (item is string)
                        {
                            continue;
                        }

                        try
                        {
                            // Пытаемся получить Id элемента с помощью dynamic-доступа.
                            // Если элемент не является анонимным типом с Id, может сработать исключение.
                            var dynamicItem = (dynamic)item;

                            // Сравниваем Id элемента с Id сотрудника.
                            if (dynamicItem.Id == employee.Id)
                            {
                                comboBox.SelectedIndex = i;
                                break;
                            }
                        }
                        catch (Microsoft.CSharp.RuntimeBinder.RuntimeBinderException)
                        {
                            // Игнорируем элементы, которые не имеют ожидаемых свойств (например, "Id")
                            continue;
                        }
                        catch (Exception)
                        {
                            // Игнорируем другие ошибки при попытке доступа к свойству
                            continue;
                        }
                    }
                }
            }
        }
        private void LoadServices()
        {
            try
            {
                allServices = context.Services.ToList();
                dataGridViewServices.Rows.Clear();

                foreach (var service in allServices)
                {
                    bool isSelected = order?.Services?.Any(s => s.Id == service.Id) ?? false;

                    dataGridViewServices.Rows.Add(
                        isSelected,
                        service.Name,
                        service.Price,
                        service.RequiredSpecialization
                    );
                }

                CalculateTotalPrice();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке услуг: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadClients()
        {
            try
            {
                var clients = context.Clients
                    .OrderBy(c => c.LastName)
                    .ThenBy(c => c.FirstName)
                    .ToList();

                comboBoxClients.DisplayMember = "DisplayName";
                comboBoxClients.ValueMember = "Id";

                comboBoxClients.Items.Clear();
                foreach (var client in clients)
                {
                    comboBoxClients.Items.Add(new
                    {
                        Id = client.Id,
                        DisplayName = $"{client.LastName} {client.FirstName} - {client.PhoneNumber}"
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке клиентов: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalculateTotalPrice()
        {
            decimal total = 0;

            foreach (DataGridViewRow row in dataGridViewServices.Rows)
            {
                if (row.Cells[0].Value is bool isSelected && isSelected)
                {
                    if (row.Cells["colPrice"].Value != null)
                    {
                        decimal price = Convert.ToDecimal(row.Cells["colPrice"].Value);
                        total += price;
                    }
                }
            }

            textBoxTotalPrice.Text = total.ToString("F2");
        }

        private void buttonEditOrder_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            try
            {
                // Сохраняем старых сотрудников для обновления статусов
                var oldEmployees = order.Employees.ToList();

                // Обновляем основные данные
                order.ClientId = (int)((dynamic)comboBoxClients.SelectedItem).Id;
                order.VehicleId = (int)((dynamic)comboBoxVehicles.SelectedItem).Id;
                order.AcceptionDate = dateTimePickerAcceptanceDate.Value;
                order.EstimatedCompletionDate = dateTimePickerEstimatedDate.Value;
                order.Price = decimal.Parse(textBoxTotalPrice.Text);

                // Обновляем услуги
                order.Services.Clear();
                foreach (DataGridViewRow row in dataGridViewServices.Rows)
                {
                    if (row.Cells[0].Value is bool isSelected && isSelected)
                    {
                        var serviceName = row.Cells[1].Value.ToString();
                        var service = allServices.First(s => s.Name == serviceName);
                        order.Services.Add(service);
                    }
                }

                // Обновляем сотрудников
                order.Employees.Clear();
                foreach (var comboBox in specializationComboBoxes.Values)
                {
                    if (comboBox.SelectedItem != null && comboBox.Enabled)
                    {
                        var selectedItem = (dynamic)comboBox.SelectedItem;
                        var employee = selectedItem.Employee;

                        if (employee != null)
                        {
                            order.Employees.Add(employee);

                            // Обновляем статус сотрудника, если он стал назначенным
                            if (employee.Status == "Свободен")
                            {
                                employee.Status = "Занят";
                            }
                        }
                    }
                }

                // Освобождаем сотрудников, которые больше не назначены
                foreach (var oldEmployee in oldEmployees)
                {
                    if (!order.Employees.Any(e => e.Id == oldEmployee.Id))
                    {
                        // Проверяем, есть ли у сотрудника другие активные заказы
                        var hasOtherOrders = context.Orders
                            .Any(o => o.Employees.Any(emp => emp.Id == oldEmployee.Id) &&
                                    o.Id != order.Id && o.Status != "Завершен");

                        if (!hasOtherOrders)
                        {
                            oldEmployee.Status = "Свободен";
                        }
                    }
                }

                context.SaveChanges();

                MessageBox.Show("Заказ успешно обновлен!", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при обновлении заказа: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool ValidateInput()
        {
            if (comboBoxClients.SelectedItem == null)
            {
                MessageBox.Show("Выберите клиента", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (comboBoxVehicles.SelectedItem == null)
            {
                MessageBox.Show("Выберите автомобиль", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            bool hasSelectedServices = false;
            foreach (DataGridViewRow row in dataGridViewServices.Rows)
            {
                if (row.Cells[0].Value is bool isSelected && isSelected)
                {
                    hasSelectedServices = true;
                    break;
                }
            }

            if (!hasSelectedServices)
            {
                MessageBox.Show("Выберите хотя бы одну услугу", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (dateTimePickerEstimatedDate.Value <= dateTimePickerAcceptanceDate.Value)
            {
                MessageBox.Show("Дата завершения должна быть позже даты приема", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            bool hasAssignedEmployees = false;
            foreach (var comboBox in specializationComboBoxes.Values)
            {
                if (comboBox.SelectedItem != null && comboBox.Enabled)
                {
                    var selectedItem = (dynamic)comboBox.SelectedItem;
                    if (selectedItem.Employee != null)
                    {
                        hasAssignedEmployees = true;
                        break;
                    }
                }
            }

            if (!hasAssignedEmployees)
            {
                var result = MessageBox.Show("Не назначен ни один сотрудник. Продолжить сохранение заказа?",
                    "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                return result == DialogResult.Yes;
            }

            return true;
        }
        private List<string> GetRequiredSpecializations()
        {
            var specializations = new List<string>();

            foreach (DataGridViewRow row in dataGridViewServices.Rows)
            {
                if (row.Cells[0].Value is bool isSelected && isSelected)
                {
                    var specialization = row.Cells[3].Value?.ToString();
                    if (!string.IsNullOrEmpty(specialization) && !specializations.Contains(specialization))
                    {
                        specializations.Add(specialization);
                    }
                }
            }

            return specializations;
        }
        private void buttonAddNewVehicle_Click(object sender, EventArgs e)
        {
            if (comboBoxClients.SelectedItem == null)
            {
                MessageBox.Show("Сначала выберите клиента", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var clientId = (int)((dynamic)comboBoxClients.SelectedItem).Id;
            var addVehicleForm = new AddVehicle();

            if (addVehicleForm.ShowDialog() == DialogResult.OK)
            {
                LoadClientVehicles();
            }
        }
        private void buttonAddNewClient_Click(object sender, EventArgs e)
        {
            var addClientForm = new AddClient();
            if (addClientForm.ShowDialog() == DialogResult.OK)
            {
                LoadClients();
            }
        }

        private void comboBoxClients_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadClientVehicles();
        }

        private void dataGridViewServices_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                CalculateTotalPrice();
                CreateEmployeeSelectionControls(); 
                SelectAssignedEmployees();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var requiredSpecializations = GetRequiredSpecializations();

            if (requiredSpecializations.Count == 0)
            {
                MessageBox.Show("Сначала выберите услуги", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            foreach (var specialization in requiredSpecializations)
            {
                if (specializationComboBoxes.ContainsKey(specialization))
                {
                    var comboBox = specializationComboBoxes[specialization];
                    var freeEmployee = employeesBySpecialization[specialization]
                        ?.FirstOrDefault(e => e.Status == "Свободен");

                    if (freeEmployee != null)
                    {
                        for (int i = 0; i < comboBox.Items.Count; i++)
                        {
                            var item = (dynamic)comboBox.Items[i];
                            if (item.Employee != null && item.Id == freeEmployee.Id)
                            {
                                comboBox.SelectedIndex = i;
                                break;
                            }
                        }
                    }
                }
            }

            MessageBox.Show("Сотрудники автоматически подобраны", "Успех",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
