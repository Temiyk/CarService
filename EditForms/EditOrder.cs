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
        private List<Employee> availableEmployees;
        private Coursa4Context context;
        private Employee assignedEmployee;
        public EditOrder(int orderId)
        {
            InitializeComponent();
            this.orderId = orderId;
            context = new Coursa4Context();
            comboBoxClients.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxVehicles.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxClients.SelectedIndexChanged += comboBoxClients_SelectedIndexChanged;
            dataGridViewServices.CellValueChanged += dataGridViewServices_CellValueChanged;
            LoadOrderData();
            LoadClients();
            LoadServices();
            LoadAvailableEmployees();
        }
        private void LoadOrderData()
        {
            try
            {
                order = context.Orders
                    .Include(o => o.Client)
                    .Include(o => o.Vehicle)
                    .Include(o => o.Employee)
                    .Include(o => o.Services)
                    .FirstOrDefault(o => o.Id == orderId);

                if (order != null)
                {
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

                    if (order.Employee != null)
                    {
                        assignedEmployee = order.Employee;
                        labelAssignedEmployee.Text = $"Назначенный сотрудник: {assignedEmployee.FirstName} {assignedEmployee.LastName} ({assignedEmployee.Specialization})";
                    }

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
        private void LoadAvailableEmployees()
        {
            try
            {
                availableEmployees = context.Employees
                    .Where(e => e.Status == "Свободен")
                    .OrderBy(e => e.Specialization)
                    .ThenBy(e => e.LastName)
                    .ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке сотрудников: {ex.Message}", "Ошибка",
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
                // Сохраняем старого сотрудника для проверки статуса
                var oldEmployeeId = order.EmployeeId;

                // Обновляем основные данные
                order.ClientId = (int)((dynamic)comboBoxClients.SelectedItem).Id;
                order.VehicleId = (int)((dynamic)comboBoxVehicles.SelectedItem).Id;
                order.AcceptionDate = dateTimePickerAcceptanceDate.Value;
                order.EstimatedCompletionDate = dateTimePickerEstimatedDate.Value;
                order.Price = decimal.Parse(textBoxTotalPrice.Text);

                // Обновляем сотрудника
                if (assignedEmployee != null)
                {
                    order.EmployeeId = assignedEmployee.Id;

                    // Обновляем статус сотрудника, если он изменился
                    if (assignedEmployee.Id != oldEmployeeId)
                    {
                        var newEmployee = context.Employees.Find(assignedEmployee.Id);
                        if (newEmployee != null && newEmployee.Status != "Занят")
                        {
                            newEmployee.Status = "Занят";
                        }
                    }
                }

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

            return true;
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
                    labelAssignedEmployee.Text = $"Назначенный сотрудник: {assignedEmployee.FirstName} {assignedEmployee.LastName} ({assignedEmployee.Specialization})";
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
        private Employee FindEmployeeForOrder()
        {
            var requiredSpecializations = GetRequiredSpecializations();

            if (requiredSpecializations.Count == 0)
                return null;

            foreach (var specialization in requiredSpecializations)
            {
                var freeEmployee = availableEmployees
                    .FirstOrDefault(e => e.Specialization == specialization);

                if (freeEmployee != null)
                {
                    return freeEmployee;
                }
            }

            return availableEmployees.FirstOrDefault();
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
            }
        }
    }
}
