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
    public partial class AddEmployee : Form
    {
        private string tempPhotoPath;

        public AddEmployee()
        {
            InitializeComponent();
            CreatePhotosDirectory();
        }
        private void CreatePhotosDirectory()
        {
            var photosDir = Path.Combine(Application.StartupPath, "EmployeePhotos");
            if (!Directory.Exists(photosDir))
            {
                Directory.CreateDirectory(photosDir);
            }
        }
        private void buttonAddEmployee_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                try
                {
                    using var context = new Coursa4Context();
                    var employee = new Employee
                    {
                        FirstName = textBoxEmployeeFN.Text.Trim(),
                        LastName = textBoxEmloyeeLN.Text.Trim(),
                        Specialization = textBox2.Text.Trim(),
                        Status = "Свободен"
                    };

                    context.Employees.Add(employee);
                    context.SaveChanges();

                    if (!string.IsNullOrEmpty(tempPhotoPath))
                    {
                        SaveEmployeePhoto(employee.Id);
                    }

                    MessageBox.Show("Сотрудник успешно добавлен!", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при добавлении сотрудника: {ex.Message}", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void SaveEmployeePhoto(int employeeId)
        {
            if (string.IsNullOrEmpty(tempPhotoPath) || pictureBoxEmployee.Image == null)
                return;

            try
            {
                var photosDir = Path.Combine(Application.StartupPath, "EmployeePhotos");
                var photoPath = Path.Combine(photosDir, $"employee_{employeeId}.jpg");

                // Сохраняем изображение в формате JPG
                pictureBoxEmployee.Image.Save(photoPath, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении фото: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void pictureBoxEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Проверяем размер файла перед загрузкой
                    var fileInfo = new FileInfo(openFileDialog.FileName);
                    if (fileInfo.Length > 5 * 1024 * 1024) // 5MB
                    {
                        MessageBox.Show("Размер фото не должен превышать 5MB", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Проверяем формат файла
                    var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".bmp" };
                    var fileExtension = Path.GetExtension(openFileDialog.FileName).ToLower();
                    if (!allowedExtensions.Contains(fileExtension))
                    {
                        MessageBox.Show("Допустимые форматы фото: JPG, JPEG, PNG, BMP", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Загружаем изображение
                    var image = Image.FromFile(openFileDialog.FileName);

                    // Ресайз изображения до 200x200 пикселей
                    var resizedImage = ResizeImage(image, 200, 200);
                    pictureBoxEmployee.Image = resizedImage;

                    // Сохраняем временный путь
                    tempPhotoPath = openFileDialog.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке фото: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SaveEmployeeImage(int employeeId, string imagePath)
        {
            try
            {
                string imagesFolder = Path.Combine(Application.StartupPath, "EmployeeImages");
                if (!Directory.Exists(imagesFolder))
                {
                    Directory.CreateDirectory(imagesFolder);
                }
                string extension = Path.GetExtension(imagePath);
                string newFileName = $"employee_{employeeId}{extension}";
                string destinationPath = Path.Combine(imagesFolder, newFileName);

                File.Copy(imagePath, destinationPath, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении изображения: {ex.Message}");
            }
        }
        private bool ValidateInput()
        {
            // Валидация имени
            if (string.IsNullOrWhiteSpace(textBoxEmployeeFN.Text))
            {
                MessageBox.Show("Введите имя сотрудника", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxEmployeeFN.Focus();
                return false;
            }

            if (textBoxEmployeeFN.Text.Trim().Length < 2)
            {
                MessageBox.Show("Имя должно содержать минимум 2 символа", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxEmployeeFN.Focus();
                textBoxEmployeeFN.SelectAll();
                return false;
            }

            if (textBoxEmployeeFN.Text.Trim().Length > 50)
            {
                MessageBox.Show("Имя не должно превышать 50 символов", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxEmployeeFN.Focus();
                textBoxEmployeeFN.SelectAll();
                return false;
            }

            // Валидация фамилии
            if (string.IsNullOrWhiteSpace(textBoxEmloyeeLN.Text))
            {
                MessageBox.Show("Введите фамилию сотрудника", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxEmloyeeLN.Focus();
                return false;
            }

            if (textBoxEmloyeeLN.Text.Trim().Length < 2)
            {
                MessageBox.Show("Фамилия должна содержать минимум 2 символа", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxEmloyeeLN.Focus();
                textBoxEmloyeeLN.SelectAll();
                return false;
            }

            if (textBoxEmloyeeLN.Text.Trim().Length > 50)
            {
                MessageBox.Show("Фамилия не должна превышать 50 символов", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxEmloyeeLN.Focus();
                textBoxEmloyeeLN.SelectAll();
                return false;
            }

            // Валидация специализации
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Введите специализацию сотрудника", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.Focus();
                return false;
            }

            if (textBox2.Text.Trim().Length < 3)
            {
                MessageBox.Show("Специализация должна содержать минимум 3 символа", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.Focus();
                textBox2.SelectAll();
                return false;
            }

            if (textBox2.Text.Trim().Length > 100)
            {
                MessageBox.Show("Специализация не должна превышать 100 символов", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.Focus();
                textBox2.SelectAll();
                return false;
            }

            // Валидация фото (если загружено)
            if (!string.IsNullOrEmpty(tempPhotoPath))
            {
                try
                {
                    var fileInfo = new FileInfo(tempPhotoPath);
                    if (fileInfo.Length > 5 * 1024 * 1024) // 5MB limit
                    {
                        MessageBox.Show("Размер фото не должен превышать 5MB", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при проверке фото: {ex.Message}", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            // Проверка на уникальность сотрудника
            if (IsEmployeeExists(textBoxEmployeeFN.Text.Trim(), textBoxEmloyeeLN.Text.Trim()))
            {
                MessageBox.Show("Сотрудник с таким именем и фамилией уже существует", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxEmployeeFN.Focus();
                textBoxEmployeeFN.SelectAll();
                return false;
            }

            return true;
        }


    }
}
