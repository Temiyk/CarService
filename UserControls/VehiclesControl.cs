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

namespace coursa4.UserControls
{
    public partial class VehiclesControl : BaseListControl
    {
        private List<Vehicle> vehicles;
        private List<Vehicle> filteredVehicles;

        public VehiclesControl()
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
            DataGridView.Columns.Add("Brand", "Марка");
            DataGridView.Columns.Add("Model", "Модель");
            DataGridView.Columns.Add("Year", "Год");
            DataGridView.Columns.Add("VIN", "VIN");
            DataGridView.Columns.Add("LicensePlate", "Гос. номер");
            DataGridView.Columns.Add("Mileage", "Пробег");
            DataGridView.Columns.Add("ClientName", "Владелец");
            DataGridView.Columns.Add("OrdersCount", "Кол-во заказов");

            DataGridView.Columns["Id"].Visible = false;
            DataGridView.Columns["Brand"].Width = 100;
            DataGridView.Columns["Model"].Width = 100;
            DataGridView.Columns["Year"].Width = 60;
            DataGridView.Columns["VIN"].Width = 150;
            DataGridView.Columns["LicensePlate"].Width = 100;
            DataGridView.Columns["Mileage"].Width = 80;
            DataGridView.Columns["ClientName"].Width = 150;
            DataGridView.Columns["OrdersCount"].Width = 80;
        }

        private void SetupSearchFilter()
        {
            string[] filterOptions = { "Все", "Марка", "Модель", "VIN", "Гос. номер", "Владелец" };
            string[] sortOptions = { "Марка", "Модель", "Год", "Пробег", "Владелец" };

            SearchFilter.SetFilterOptions(filterOptions);
            SearchFilter.SetSortOptions(sortOptions);
        }

        public override void LoadData()
        {
            try
            {
                using var context = new Coursa4Context();
                vehicles = context.Vehicles
                    .Include(v => v.Client)
                    .AsNoTracking()
                    .ToList();

                filteredVehicles = new List<Vehicle>(vehicles);
                DisplayVehicles();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке автомобилей: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayVehicles()
        {
            DataGridView.Rows.Clear();

            foreach (var vehicle in filteredVehicles)
            {
                DataGridView.Rows.Add(
                    vehicle.Id,
                    vehicle.Brand ?? "",
                    vehicle.Model ?? "",
                    vehicle.Year,
                    vehicle.VIN ?? "",
                    vehicle.LicensePlate ?? "",
                    vehicle.Mileage,
                    $"{vehicle.Client?.FirstName} {vehicle.Client?.LastName}"
                );
            }
        }

        protected override void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var addVehicleForm = new AddVehicle();
                if (addVehicleForm.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                    SearchFilter.ClearSearch();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при открытии формы добавления: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void buttonEdit_Click(object sender, EventArgs e)
        {
            // Реализация редактирования автомобиля
            MessageBox.Show("Функция редактирования автомобиля будет реализована позже", "Информация",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        protected override void buttonDelete_Click(object sender, EventArgs e)
        {
            if (DataGridView.SelectedRows.Count > 0)
            {
                var vehicleId = (int)DataGridView.SelectedRows[0].Cells["Id"].Value;
                var vehicleInfo = $"{DataGridView.SelectedRows[0].Cells["Brand"].Value} {DataGridView.SelectedRows[0].Cells["Model"].Value}";

                var result = MessageBox.Show($"Вы уверены, что хотите удалить автомобиль:\n{vehicleInfo}?",
                    "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        using var context = new Coursa4Context();
                        var vehicle = context.Vehicles.Find(vehicleId);

                        if (vehicle != null)
                        {
                            context.Vehicles.Remove(vehicle);
                            context.SaveChanges();

                            LoadData();
                            MessageBox.Show("Автомобиль успешно удален", "Успех",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при удалении автомобиля: {ex.Message}", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите автомобиль для удаления", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        protected override void buttonUpdate_Click(object sender, EventArgs e)
        {
            LoadData();
            SearchFilter.ResetAll();
        }
    }
}
