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
            comboBoxClients.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxVehicles.DropDownStyle = ComboBoxStyle.DropDownList;
            LoadClients();
            LoadServices();
            LoadAvailableEmployees();
            SetDefaultDates();
            LoadServices();
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
                else
                    comboBoxClients.Text = "Нет клиентов";
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
                        false,
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
            var addVehicleForm = new AddVehicle();

            if (addVehicleForm.ShowDialog() == DialogResult.OK)
            {
                LoadClientVehicles();
            }
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
                    if (row.Cells["colPrice"].Value != null)
                    {
                        decimal price = Convert.ToDecimal(row.Cells["colPrice"].Value);
                        total += price;
                    }
                }
            }

            textBoxTotalPrice.Text = total.ToString("C2");
        }
        private void dataGridViewServices_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                dataGridViewServices.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
        private decimal GetCurrentTotalPrice()
        {
            if (string.IsNullOrEmpty(textBoxTotalPrice.Text))
                return 0;

            string priceText = textBoxTotalPrice.Text.Replace("₽", "").Replace("$", "").Replace("€", "").Replace(" ", "").Trim();
            if (decimal.TryParse(priceText, out decimal result))
            {
                return result;
            }
            return 0;
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
                    var result = MessageBox.Show("Нет доступных сотрудников. Создать заказ без назначения сотрудника?", "Внимание",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result != DialogResult.Yes)
                        return;
                }

                var order = new Order
                {
                    ClientId = (int)((dynamic)comboBoxClients.SelectedItem).Id,
                    VehicleId = (int)((dynamic)comboBoxVehicles.SelectedItem).Id,
                    AcceptionDate = dateTimePickerAcceptanceDate.Value,
                    EstimatedCompletionDate = dateTimePickerEstimatedDate.Value,
                    Status = "В работе",
                    Price = decimal.Parse(textBoxTotalPrice.Text.Replace("₽", "").Replace("$", "").Trim()),
                    EmployeeId = assignedEmployee?.Id ?? 0 // Защита от null
                };
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

                if (assignedEmployee != null)
                {
                    assignedEmployee.Status = "Занят";
                }

                context.SaveChanges();

                if (assignedEmployee != null)
                {
                    MessageBox.Show($"Заказ успешно создан! Назначен сотрудник: {assignedEmployee.FirstName} {assignedEmployee.LastName}", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Заказ успешно создан! Сотрудник не назначен.", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

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

                Console.WriteLine($"Доступно сотрудников: {availableEmployees.Count}");
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
                labelAssignedEmployee.ForeColor = Color.Green;
            }
            else
            {
                labelAssignedEmployee.Text = "Назначенный сотрудник: не выбран";
                labelAssignedEmployee.ForeColor = Color.Red;
            }
        }
        public static void ReleaseEmployee(int employeeId)
        {
            try
            {
                using var context = new Coursa4Context();
                var employee = context.Employees.Find(employeeId);
                if (employee != null)
                {
                    // Проверяем, есть ли у сотрудника активные заказы
                    var hasActiveOrders = context.Orders
                        .Any(o => o.EmployeeId == employeeId && o.Status == "Занят");

                    if (!hasActiveOrders)
                    {
                        employee.Status = "Свободен";
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при освобождении сотрудника: {ex.Message}");
            }
        }
        private Employee FindEmployeeForOrder()
        {
            var requiredSpecializations = GetRequiredSpecializations();

            if (requiredSpecializations.Count == 0)
            {
                MessageBox.Show("Не выбрано ни одной услуги", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }

            LoadAvailableEmployees();

            foreach (var specialization in requiredSpecializations)
            {
                var freeEmployee = availableEmployees
                    .FirstOrDefault(e => e.Specialization == specialization);

                if (freeEmployee != null)
                {
                    return freeEmployee;
                }
            }

            var anyFreeEmployee = availableEmployees.FirstOrDefault();
            if (anyFreeEmployee != null)
            {
                MessageBox.Show($"Сотрудник с нужной специализацией не найден. Назначен: {anyFreeEmployee.FirstName} {anyFreeEmployee.LastName} ({anyFreeEmployee.Specialization})",
                    "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return anyFreeEmployee;
            }

            try
            {
                var busyEmployees = context.Employees
                    .Where(e => e.Status == "Занят")
                    .Include(e => e.Orders)
                    .ToList();

                foreach (var specialization in requiredSpecializations)
                {
                    var busyEmployee = busyEmployees
                        .Where(e => e.Specialization == specialization)
                        .OrderBy(e => e.Orders.Count)
                        .FirstOrDefault();

                    if (busyEmployee != null)
                    {
                        MessageBox.Show($"Все сотрудники заняты. Рекомендуется: {busyEmployee.FirstName} {busyEmployee.LastName} ({busyEmployee.Specialization})",
                            "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return busyEmployee;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при поиске занятых сотрудников: {ex.Message}");
            }

            return null;
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
        private void buttonAutoAssignEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                var requiredSpecializations = GetRequiredSpecializations();

                if (requiredSpecializations.Count == 0)
                {
                    MessageBox.Show("Сначала выберите услуги", "Информация",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                assignedEmployee = FindEmployeeForOrder();

                if (assignedEmployee != null)
                {
                    UpdateAssignedEmployeeLabel();
                    MessageBox.Show($"Назначен сотрудник: {assignedEmployee.FirstName} {assignedEmployee.LastName} ({assignedEmployee.Specialization})", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Не удалось найти подходящего сотрудника. Все сотрудники заняты.", "Внимание",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при подборе сотрудника: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dataGridViewServices_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                CalculateTotalPrice();
            }
        }
        private void UpdateTotalPrice()
        {
            decimal total = 0;

            foreach (Control control in groupBoxServices.Controls)
            {
                if (control is CheckBox checkBox && checkBox.Checked)
                {
                    if (checkBox.Tag is Service service)
                    {
                        total += service.Price;
                    }
                }
            }
            textBoxTotalPrice.Text = total.ToString("C2");
        }
    }
}
