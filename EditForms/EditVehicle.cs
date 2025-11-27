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

namespace coursa4.EditForms
{
    public partial class EditVehicle : Form
    {
        private int vehicleId;
        private Vehicle vehicle;
        private string imagePath = null;
        public EditVehicle(int vehicleId)
        {
            InitializeComponent();
            this.vehicleId = vehicleId;
            LoadVehicleData();
            LoadClients();
        }
        private void LoadClients()
        {
            try
            {
                using var context = new Coursa4Context();
                var clients = context.Clients.ToList();

                var clientsData = clients.Select(c => new
                {
                    Id = c.Id,
                    DisplayName = $"{c.FirstName} {c.LastName}",
                    c.FirstName,
                    c.LastName
                }).ToList();

                comboBoxEditClient.DataSource = clientsData;
                comboBoxEditClient.DisplayMember = "DisplayName";
                comboBoxEditClient.ValueMember = "Id";

                if (vehicle != null)
                {
                    comboBoxEditClient.SelectedValue = vehicle.ClientId;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке клиентов: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadVehicleData()
        {
            try
            {
                using var context = new Coursa4Context();
                vehicle = context.Vehicles.Find(vehicleId);

                if (vehicle != null)
                {
                    textBoxEditCarBrand.Text = vehicle.Brand;
                    textBoxEditCarModel.Text = vehicle.Model;
                    textBoxEditCarYear.Text = vehicle.Year.ToString();
                    textBoxEditCarVIN.Text = vehicle.VIN;
                    textBoxEditCarPlate.Text = vehicle.LicensePlate;
                    textBoxEditCarMileage.Text = vehicle.Mileage.ToString();

                    labelEditVehicle.Text = $"Редактирование {vehicle.Brand} {vehicle.Model}";
                }
                else
                {
                    MessageBox.Show("Автомобиль не найден!", "Ошибка редактирования",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadVehicleImage()
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

                    if (files.Length > 0)
                    {
                        using (var originalImage = Image.FromFile(files[0]))
                        {
                            var previewImage = ResizeImage(originalImage, 183, 125);
                            pictureBoxEditVehicle.Image = previewImage;
                            pictureBoxEditVehicle.SizeMode = PictureBoxSizeMode.Zoom;
                        }
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при загрузке изображения: {ex.Message}");
            }
        }
        private Image ResizeImage(Image image, int width, int height)
        {
            var ratioX = (double)width / image.Width;
            var ratioY = (double)height / image.Height;
            var ratio = Math.Min(ratioX, ratioY);

            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio);

            var newImage = new Bitmap(newWidth, newHeight);

            using (var graphics = Graphics.FromImage(newImage))
            {
                graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                graphics.DrawImage(image, 0, 0, newWidth, newHeight);
            }

            return newImage;
        }
        private void buttonEditVehicle_Click(object sender, EventArgs e)
        {
            try
            {

                if (string.IsNullOrWhiteSpace(textBoxEditCarBrand.Text) ||
                    string.IsNullOrWhiteSpace(textBoxEditCarModel.Text) ||
                    string.IsNullOrWhiteSpace(textBoxEditCarYear.Text) ||
                    string.IsNullOrWhiteSpace(textBoxEditCarVIN.Text) ||
                    string.IsNullOrWhiteSpace(textBoxEditCarPlate.Text) ||
                    string.IsNullOrWhiteSpace(textBoxEditCarMileage.Text))
                {
                    MessageBox.Show("Заполните все обязательные поля", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!int.TryParse(textBoxEditCarYear.Text, out int year) || year < 1900 || year > DateTime.Now.Year + 1)
                {
                    MessageBox.Show("Введите корректный год выпуска", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!int.TryParse(textBoxEditCarMileage.Text, out int mileage) || mileage < 0)
                {
                    MessageBox.Show("Введите корректный пробег", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using var context = new Coursa4Context();
                var existingVehicle = context.Vehicles.Find(vehicleId);

                if (existingVehicle != null)
                {
                    var duplicateVIN = context.Vehicles
                        .Any(v => v.VIN == textBoxEditCarVIN.Text && v.Id != vehicleId);

                    if (duplicateVIN)
                    {
                        MessageBox.Show("Автомобиль с таким VIN-номером уже существует!", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    var duplicatePlate = context.Vehicles
                        .Any(v => v.LicensePlate == textBoxEditCarPlate.Text && v.Id != vehicleId);

                    if (duplicatePlate)
                    {
                        MessageBox.Show("Автомобиль с таким гос. номером уже существует!", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    existingVehicle.Brand = textBoxEditCarBrand.Text;
                    existingVehicle.Model = textBoxEditCarModel.Text;
                    existingVehicle.Year = year;
                    existingVehicle.VIN = textBoxEditCarVIN.Text;
                    existingVehicle.LicensePlate = textBoxEditCarPlate.Text;
                    existingVehicle.Mileage = mileage;

                    if (comboBoxEditClient.SelectedValue != null &&
                        comboBoxEditClient.SelectedValue is int clientId)
                    {
                        existingVehicle.ClientId = clientId;
                    }

                    context.SaveChanges();

                    if (!string.IsNullOrEmpty(imagePath))
                    {
                        SaveVehicleImage(existingVehicle.Id, imagePath);
                    }

                    MessageBox.Show("Данные автомобиля успешно обновлены!", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SaveVehicleImage(int vehicleId, string sourceImagePath)
        {
            try
            {
                string appPath = Application.StartupPath;
                string imagesFolder = Path.Combine(appPath, "VehicleImages");
                if (!Directory.Exists(imagesFolder))
                {
                    Directory.CreateDirectory(imagesFolder);
                }
                using (var originalImage = Image.FromFile(sourceImagePath))
                {
                    var optimizedImage = ResizeImage(originalImage, 800, 600);

                    string extension = Path.GetExtension(sourceImagePath).ToLower();
                    string newFileName = $"vehicle_{vehicleId}{extension}";
                    string destinationPath = Path.Combine(imagesFolder, newFileName);
                    optimizedImage.Save(destinationPath);
                    optimizedImage.Dispose();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении изображения: {ex.Message}");
            }
        }
        private void pictureBoxEditVehicle_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                openFileDialog.Title = "Выберите изображение автомобиля";
                openFileDialog.Multiselect = false;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        imagePath = openFileDialog.FileName;

                        var originalImage = Image.FromFile(imagePath);

                        var previewImage = ResizeImage(originalImage, 400, 300);

                        pictureBoxEditVehicle.Image = previewImage;
                        pictureBoxEditVehicle.SizeMode = PictureBoxSizeMode.Zoom;
                        pictureBoxEditVehicle.Cursor = Cursors.Default;
                        originalImage.Dispose();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при загрузке изображения: {ex.Message}");
                    }
                }
            }
        }
    }
}
