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
        private Coursa4Context context;
        private List<Employee> allEmployees;
        private Dictionary<string, ComboBox> specializationComboBoxes = new Dictionary<string, ComboBox>();
        private Dictionary<string, List<Employee>> employeesBySpecialization = new Dictionary<string, List<Employee>>();

        public AddOrder()
        {
            InitializeComponent();
            context = new Coursa4Context();
            comboBoxClients.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxVehicles.DropDownStyle = ComboBoxStyle.DropDownList;
            LoadClients();
            LoadServices();
            LoadAllEmployees(); 
            SetDefaultDates();
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
        private void CreateEmployeeSelectionControls()
        {
            panelEmployeeControls.Controls.Clear();
            specializationComboBoxes.Clear();

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
                var label = new Label();
                label.Text = $"{specialization}:";
                label.Location = new Point(10, yPosition);
                label.Size = new Size(150, 25);
                label.TextAlign = ContentAlignment.MiddleRight;

                var comboBox = new ComboBox();
                comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                comboBox.Location = new Point(170, yPosition);
                comboBox.Size = new Size(300, 28);
                comboBox.Tag = specialization;

                if (employeesBySpecialization.ContainsKey(specialization))
                {
                    comboBox.DisplayMember = "DisplayName";
                    comboBox.ValueMember = "Id";

                    var employees = employeesBySpecialization[specialization];
                    foreach (var employee in employees)
                    {
                        comboBox.Items.Add(new
                        {
                            Id = employee.Id,
                            DisplayName = $"{employee.LastName} {employee.FirstName} - {employee.Status}",
                            Employee = employee
                        });
                    }

                    if (comboBox.Items.Count > 0)
                        comboBox.SelectedIndex = 0;
                }
                else
                {
                    comboBox.Items.Add("Нет доступных сотрудников");
                    comboBox.SelectedIndex = 0;
                    comboBox.Enabled = false;
                }

                panelEmployeeControls.Controls.Add(label);
                panelEmployeeControls.Controls.Add(comboBox);

                specializationComboBoxes[specialization] = comboBox;

                yPosition += 35;
            }
        }
        private void SetDefaultDates()
        {
            dateTimePickerAcceptanceDate.Value = DateTime.Now;
            dateTimePickerEstimatedDate.Value = DateTime.Now.AddDays(7);
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
                var order = new Order
                {
                    ClientId = (int)((dynamic)comboBoxClients.SelectedItem).Id,
                    VehicleId = (int)((dynamic)comboBoxVehicles.SelectedItem).Id,
                    AcceptionDate = dateTimePickerAcceptanceDate.Value,
                    EstimatedCompletionDate = dateTimePickerEstimatedDate.Value,
                    Status = "В работе",
                    Price = GetCurrentTotalPrice()
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

                foreach (var comboBox in specializationComboBoxes.Values)
                {
                    if (comboBox.SelectedItem != null && comboBox.Enabled)
                    {
                        var selectedItem = (dynamic)comboBox.SelectedItem;
                        var employee = selectedItem.Employee;

                        order.Employees.Add(employee);
                        if (employee.Status == "Свободен")
                        {
                            employee.Status = "Занят";
                        }
                    }
                }

                context.Orders.Add(order);
                context.SaveChanges();

                MessageBox.Show("Заказ успешно создан!", "Успех",
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
            SetDefaultDates();
        }
        private void dataGridViewServices_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                CalculateTotalPrice();
                CreateEmployeeSelectionControls(); 
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

        private void buttonAutoAssignEmployees_Click(object sender, EventArgs e)
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
                            if (item.Id == freeEmployee.Id)
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
