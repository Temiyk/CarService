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
                    var fileInfo = new FileInfo(openFileDialog.FileName);
                    if (fileInfo.Length > 5 * 1024 * 1024) // 5MB
                    {
                        MessageBox.Show("Размер фото не должен превышать 5MB", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".bmp" };
                    var fileExtension = Path.GetExtension(openFileDialog.FileName).ToLower();
                    if (!allowedExtensions.Contains(fileExtension))
                    {
                        MessageBox.Show("Допустимые форматы фото: JPG, JPEG, PNG, BMP", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    using (var originalImage = Image.FromFile(openFileDialog.FileName))
                    {
                        var resizedImage = new Bitmap(originalImage, new Size(200, 200));
                        pictureBoxEmployee.Image = resizedImage;
                        tempPhotoPath = openFileDialog.FileName;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке фото: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool ValidateInput()
        {
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

            if (!string.IsNullOrEmpty(tempPhotoPath))
            {
                try
                {
                    var fileInfo = new FileInfo(tempPhotoPath);
                    if (fileInfo.Length > 5 * 1024 * 1024) 
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
        public bool IsEmployeeExists(string firstName, string lastName)
        {
            try
            {
                using var context = new Coursa4Context();
                return context.Employees
                    .Any(e =>
                        e.FirstName.ToLower() == firstName.Trim().ToLower() &&
                        e.LastName.ToLower() == lastName.Trim().ToLower());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при проверке сотрудника: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

    }
}
