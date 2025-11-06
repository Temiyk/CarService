using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using coursa4.Data;
using coursa4.Models;

namespace coursa4
{
    public partial class AddVehicle : Form
    {
        private List<Client> clients;
        private string imagePath = null;

        public AddVehicle()
        {
            InitializeComponent();
            LoadClients();
        }
        private void LoadClients()
        {
            using var context = new Coursa4Context();
            clients = context.Clients.ToList();
            comboBoxClient.DataSource = clients;
            comboBoxClient.DisplayMember = "FullName";
            comboBoxClient.ValueMember = "Id";

            var clientsData = clients.Select(c => new
            {
                Id = c.Id,
                DisplayName = $"{c.FirstName} {c.LastName}",
                FirstName = c.FirstName,
                LastName = c.LastName
            }).ToList();

            clientsData.Insert(0, new { Id = -1, DisplayName = "Добавить нового клиента...", FirstName = "", LastName = "" });

            comboBoxClient.DataSource = clientsData;
            comboBoxClient.DisplayMember = "DisplayName";
            comboBoxClient.ValueMember = "Id";

        }

        private void buttonAddVehicle_Click(object sender, EventArgs e)
        {
            int clientId;

            // Проверяем, выбран ли существующий клиент или нужно создать нового
            if ((int)comboBoxClient.SelectedValue == -1)
            {
                // Создаем нового клиента
                clientId = CreateNewClient();
                if (clientId == -1) // Если создание клиента отменено
                    return;
            }
            else
            {
                clientId = (int)comboBoxClient.SelectedValue;
            }

            if (string.IsNullOrWhiteSpace(textBoxCarBrand.Text) ||
                string.IsNullOrWhiteSpace(textBoxCarModel.Text) ||
                string.IsNullOrWhiteSpace(textBoxCarYear.Text) ||
                string.IsNullOrWhiteSpace(textBoxCarVIN.Text) ||
                string.IsNullOrWhiteSpace(textBoxCarPlate.Text) ||
                string.IsNullOrWhiteSpace(textBoxCarMileage.Text))
            {
                MessageBox.Show("Заполните все обязательные поля");
                return;
            }

            if (!int.TryParse(textBoxCarYear.Text, out int year) || year < 1900 || year > DateTime.Now.Year + 1)
            {
                MessageBox.Show("Введите корректный год выпуска");
                return;
            }

            if (!int.TryParse(textBoxCarMileage.Text, out int mileage) || mileage < 0)
            {
                MessageBox.Show("Введите корректный пробег");
                return;
            }

            try
            {
                using var context = new Coursa4Context();
                var vehicle = new Vehicle
                {
                    ClientId = clientId,
                    Brand = textBoxCarBrand.Text,
                    Model = textBoxCarModel.Text,
                    Year = year,
                    VIN = textBoxCarVIN.Text,
                    LicensePlate = textBoxCarPlate.Text,
                    Mileage = mileage
                };

                context.Vehicles.Add(vehicle);
                context.SaveChanges();

                // Сохранение изображения, если оно было загружено
                if (!string.IsNullOrEmpty(imagePath))
                {
                    SaveVehicleImage(vehicle.Id, imagePath);
                }

                MessageBox.Show("Автомобиль успешно добавлен!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении автомобиля: {ex.Message}");
            }

        }

        private void pictureBoxNewVehicle_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                openFileDialog.Title = "Выберите изображение автомобиля";
                openFileDialog.Multiselect = false;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    imagePath = openFileDialog.FileName;
                    pictureBoxNewVehicle.Image = Image.FromFile(imagePath);
                    pictureBoxNewVehicle.SizeMode = PictureBoxSizeMode.Zoom;

                    pictureBoxNewVehicle.Cursor = Cursors.Default;
                }
            }
        }
        private void SaveVehicleImage(int vehicleId, string imagePath)
        {
            try
            {
                string imagesFolder = Path.Combine(Application.StartupPath, "VehicleImages");
                if (!Directory.Exists(imagesFolder))
                {
                    Directory.CreateDirectory(imagesFolder);
                }

                string extension = Path.GetExtension(imagePath);
                string newFileName = $"vehicle_{vehicleId}{extension}";
                string destinationPath = Path.Combine(imagesFolder, newFileName);

                File.Copy(imagePath, destinationPath, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении изображения: {ex.Message}");
            }
        }
        private int CreateNewClient()
        {
            using (var addClientForm = new AddClient())
            {
                if (addClientForm.ShowDialog() == DialogResult.OK)
                {
                    // Перезагружаем список клиентов
                    LoadClients();

                    // Находим ID только что созданного клиента
                    using var context = new Coursa4Context();
                    var newClient = context.Clients.OrderByDescending(c => c.Id).FirstOrDefault();

                    if (newClient != null)
                    {
                        // Выбираем нового клиента в комбобоксе
                        comboBoxClient.SelectedValue = newClient.Id;
                        return newClient.Id;
                    }
                }
            }
            return -1; // Отменено
        }
    }
}
