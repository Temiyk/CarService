using coursa4.Data;
using coursa4.Models;
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
    public partial class AddOrder : Form
    {
        private List<Service> allServices;
        private List<Employee> availableEmployees;
        private Coursa4Context context;
        private Employee assignedEmployee;
        private Label labelAssignedEmployee;
        public AddOrder()
        {
            InitializeComponent();
            context = new Coursa4Context();
        }
        private void SetDefaultDates()
        {
            dateTimePickerAcceptanceDate.Value = DateTime.Now;
            dateTimePickerEstimatedDate.Value = DateTime.Now.AddDays(7);
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

                if (comboBoxClients.Items.Count > 0)
                    comboBoxClients.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке клиентов: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    dataGridViewServices.Rows.Add(
                        false, // Checkbox - не выбран
                        service.Name,
                        service.Price.ToString("C2"),
                        service.RequiredSpecialization
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке услуг: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void comboBoxClients_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadClientVehicles();
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

                if (comboBoxVehicles.Items.Count > 0)
                    comboBoxVehicles.SelectedIndex = 0;
                else
                    comboBoxVehicles.Text = "Нет автомобилей";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке автомобилей: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void buttonAddNewVehicle_Click(object sender, EventArgs e)
        {
            if (comboBoxClients.SelectedItem == null)
            {
                MessageBox.Show("Сначала выберите клиента", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var clientId = (int)((dynamic)comboBoxClients.SelectedItem).Id;
            // Здесь нужно создать форму AddVehicle (аналогично AddClient)
            MessageBox.Show("Форма добавления автомобиля будет реализована позже", "Информация",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonCalculateTotal_Click(object sender, EventArgs e)
        {
            CalculateTotalPrice();
        }
        private void CalculateTotalPrice()
        {
            decimal total = 0;

            foreach (DataGridViewRow row in dataGridViewServices.Rows)
            {
                if (row.Cells[0].Value is bool isSelected && isSelected)
                {
                    if (decimal.TryParse(row.Cells[2].Value?.ToString().Replace("₽", "").Replace("$", "").Trim(), out decimal price))
                    {
                        total += price;
                    }
                }
            }

            textBoxTotalPrice.Text = total.ToString("C2");
        }
        private void dataGridViewServices_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Если кликнули по checkbox
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                CalculateTotalPrice();
            }
        }
        private void buttonAddOrder_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            try
            {
                if (assignedEmployee == null)
                {
                    assignedEmployee = FindEmployeeForOrder();
                }

                if (assignedEmployee == null)
                {
                    MessageBox.Show("Не удалось назначить сотрудника для выполнения заказа", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var order = new Order
                {
                    ClientId = (int)((dynamic)comboBoxClients.SelectedItem).Id,
                    VehicleId = (int)((dynamic)comboBoxVehicles.SelectedItem).Id,
                    AcceptionDate = dateTimePickerAcceptanceDate.Value,
                    EstimatedCompletionDate = dateTimePickerEstimatedDate.Value,
                    Status = "Создан",
                    Price = decimal.Parse(textBoxTotalPrice.Text.Replace("₽", "").Replace("$", "").Trim()),
                    EmployeeId = assignedEmployee.Id
                };

                // Добавляем выбранные услуги
                foreach (DataGridViewRow row in dataGridViewServices.Rows)
                {
                    if (row.Cells[0].Value is bool isSelected && isSelected)
                    {
                        var serviceName = row.Cells[1].Value.ToString();
                        var service = allServices.First(s => s.Name == serviceName);
                        order.Services.Add(service);
                    }
                }

                context.Orders.Add(order);
                assignedEmployee.Status = "Занят";
                context.SaveChanges();

                MessageBox.Show($"Заказ успешно создан! Назначен сотрудник: {assignedEmployee.FirstName} {assignedEmployee.LastName}", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при создании заказа: {ex.Message}", "Ошибка",
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

            return true;
        }

        private void AddOrder_Load(object sender, EventArgs e)
        {
            LoadClients();
            LoadServices();
            LoadAvailableEmployees();
            SetDefaultDates();
        }

        private void LoadAvailableEmployees()
        {
            try
            {
                availableEmployees = context.Employees
                    .Where(e => e.Status == "Свободен")
                    .OrderBy(e => e.Specialization)
                    .ThenBy(e => e.LastName)
                    .ToList();

                UpdateAssignedEmployeeLabel();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке сотрудников: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void UpdateAssignedEmployeeLabel()
        {
            if (assignedEmployee != null)
            {
                labelAssignedEmployee.Text = $"Назначенный сотрудник: {assignedEmployee.FirstName} {assignedEmployee.LastName} ({assignedEmployee.Specialization})";
            }
            else
            {
                labelAssignedEmployee.Text = "Назначенный сотрудник: автоматический подбор при создании";
            }
        }
        private List<Employee> AssignEmployeesToOrder()
        {
            var requiredSpecializations = GetRequiredSpecializations();
            var assignedEmployees = new List<Employee>();

            foreach (var specialization in requiredSpecializations)
            {
                var employee = FindEmployeeForSpecialization(specialization);
                if (employee != null)
                {
                    assignedEmployees.Add(employee);
                }
            }

            return assignedEmployees;
        }

        private Employee FindEmployeeForOrder()
        {
            var requiredSpecializations = GetRequiredSpecializations();

            if (requiredSpecializations.Count == 0)
                return null;

            // 1. Ищем свободного сотрудника с подходящей специализацией
            foreach (var specialization in requiredSpecializations)
            {
                var freeEmployee = availableEmployees
                    .FirstOrDefault(e => e.Specialization == specialization);

                if (freeEmployee != null)
                {
                    return freeEmployee;
                }
            }

            // 2. Если нет свободных с нужной специализацией, ищем любого свободного
            var anyFreeEmployee = availableEmployees.FirstOrDefault();
            if (anyFreeEmployee != null)
            {
                return anyFreeEmployee;
            }

            // 3. Если все заняты, ищем того кто освободится раньше всех
            var busyEmployee = context.Employees
                .Where(e => e.Status == "Занят")
                .Select(e => new
                {
                    Employee = e,
                    EarliestCompletionDate = e.Orders
                        .Where(o => o.Status != "Завершен" && o.Status != "Отменен")
                        .Min(o => o.EstimatedCompletionDate)
                })
                .Where(x => x.EarliestCompletionDate != null)
                .OrderBy(x => x.EarliestCompletionDate)
                .FirstOrDefault();

            return busyEmployee?.Employee;
        }
        private Employee FindEmployeeForSpecialization(string specialization)
        {
            // 1. Ищем свободного сотрудника с нужной специализацией
            var freeEmployee = availableEmployees
                .FirstOrDefault(e => e.Specialization == specialization && e.Status == "Свободен");

            if (freeEmployee != null)
            {
                return freeEmployee;
            }

            // 2. Если свободных нет, ищем сотрудника который освободится раньше всех
            var busyEmployee = context.Employees
                .Where(e => e.Specialization == specialization && e.Status == "Занят")
                .Select(e => new
                {
                    Employee = e,
                    EarliestCompletionDate = e.Orders
                        .Where(o => o.Status != "Завершен")
                        .Min(o => o.EstimatedCompletionDate)
                })
                .OrderBy(x => x.EarliestCompletionDate)
                .FirstOrDefault();

            return busyEmployee?.Employee;
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
    }
}
