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
            SearchFilter.SearchApplied += SearchFilter_SearchApplied;
        }
        private void SearchFilter_SearchApplied(object sender, EventArgs e)
        {
            ApplyFilter(SearchFilter.SearchText, SearchFilter.FilterBy);
        }

        protected override void ApplyFilter(string searchText, string filterBy)
        {
            if (string.IsNullOrEmpty(searchText))
            {
                filteredVehicles = new List<Vehicle>(vehicles);
            }
            else
            {
                filteredVehicles = vehicles.Where(vehicle =>
                {
                    switch (filterBy)
                    {
                        case "Марка":
                            return vehicle.Brand?.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0;
                        case "Модель":
                            return vehicle.Model?.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0;
                        case "VIN":
                            return vehicle.VIN?.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0;
                        case "Гос. номер":
                            return vehicle.LicensePlate?.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0;
                        case "Владелец":
                            var ownerName = $"{vehicle.Client?.FirstName} {vehicle.Client?.LastName}";
                            return ownerName.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0;
                        case "Все":
                        default:
                            var ownerNameAll = $"{vehicle.Client?.FirstName} {vehicle.Client?.LastName}";
                            return (vehicle.Brand?.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0) ||
                                   (vehicle.Model?.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0) ||
                                   (vehicle.VIN?.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0) ||
                                   (vehicle.LicensePlate?.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0) ||
                                   (ownerNameAll.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0) ||
                                   (vehicle.Year.ToString().IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0) ||
                                   (vehicle.Mileage.ToString().IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0);
                    }
                }).ToList();
            }

            DisplayVehicles();
        }
        private void SetupDataGridViewColumns()
        {
            DataGridView.Columns.Clear();

            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn.Name = "Image";
            imageColumn.HeaderText = "Фото";
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
            imageColumn.Width = 80;
            imageColumn.DefaultCellStyle.NullValue = null; 
            DataGridView.Columns.Add(imageColumn);

            DataGridView.Columns.Add("Id", "ID");
            DataGridView.Columns.Add("Brand", "Марка");
            DataGridView.Columns.Add("Model", "Модель");
            DataGridView.Columns.Add("Year", "Год");
            DataGridView.Columns.Add("VIN", "VIN");
            DataGridView.Columns.Add("LicensePlate", "Гос. номер");
            DataGridView.Columns.Add("Mileage", "Пробег");
            DataGridView.Columns.Add("ClientName", "Владелец");

            DataGridView.Columns["Id"].Visible = false;
            DataGridView.Columns["Brand"].Width = 100;
            DataGridView.Columns["Model"].Width = 100;
            DataGridView.Columns["Year"].Width = 60;
            DataGridView.Columns["VIN"].Width = 150;
            DataGridView.Columns["LicensePlate"].Width = 100;
            DataGridView.Columns["Mileage"].Width = 80;
            DataGridView.Columns["ClientName"].Width = 150;

            DataGridView.RowTemplate.Height = 60;
        }

        private void SetupSearchFilter()
        {
            string[] filterOptions = { "Все", "Марка", "Модель", "VIN", "Гос. номер", "Владелец" };
            SearchFilter.SetFilterOptions(filterOptions);
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
                Image vehicleImage = LoadVehicleImage(vehicle.Id);

                DataGridView.Rows.Add(
                    vehicleImage, 
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
        private Image LoadVehicleImage(int vehicleId)
        {
            try
            {
                string imagesFolder = Path.Combine(Application.StartupPath, "VehicleImages");
                if (!Directory.Exists(imagesFolder))
                    return null; 
                string[] possibleExtensions = { "*.jpg", "*.jpeg", "*.png", "*.bmp", "*.gif" };

                foreach (string extension in possibleExtensions)
                {
                    string searchPattern = $"vehicle_{vehicleId}{extension.Replace("*", "")}";
                    string[] files = Directory.GetFiles(imagesFolder, searchPattern);

                    if (files.Length > 0)
                    {
                        using (var originalImage = Image.FromFile(files[0]))
                        {
                            return ResizeImageForGrid(originalImage, 70, 50);
                        }
                    }
                }

                return null; 
            }
            catch (Exception)
            {
                return null; 
            }
        }

        private Image ResizeImageForGrid(Image image, int width, int height)
        {
            var newImage = new Bitmap(width, height);

            using (var graphics = Graphics.FromImage(newImage))
            {
                graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                graphics.DrawImage(image, 0, 0, width, height);
            }

            return newImage;
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

                            DeleteVehicleImage(vehicleId);

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
        private void DeleteVehicleImage(int vehicleId)
        {
            try
            {
                string imagesFolder = Path.Combine(Application.StartupPath, "VehicleImages");
                if (!Directory.Exists(imagesFolder))
                    return;

                string[] possibleExtensions = { "*.jpg", "*.jpeg", "*.png", "*.bmp", "*.gif" };

                foreach (string extension in possibleExtensions)
                {
                    string searchPattern = $"vehicle_{vehicleId}{extension.Replace("*", "")}";
                    string[] files = Directory.GetFiles(imagesFolder, searchPattern);

                    foreach (string file in files)
                    {
                        File.Delete(file);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при удалении изображения: {ex.Message}");
            }
        }
        protected override void buttonUpdate_Click(object sender, EventArgs e)
        {
            LoadData();
            SearchFilter.ResetAll();
        }
    }
}
