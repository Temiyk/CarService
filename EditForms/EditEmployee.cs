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
    public partial class EditEmployee : Form
    {
        private int employeeId;
        private Employee employee;
        private string tempPhotoPath;
        public EditEmployee(int employeeId)
        {
            InitializeComponent();
            CreatePhotosDirectory();
            LoadEmployee();
            this.employeeId = employeeId;
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            openFileDialog.Title = "Выберите фото сотрудника";
        }
        private void LoadEmployee()
        {
            try
            {
                using var context = new Coursa4Context();
                employee = context.Employees.Find(employeeId);
                if (employee != null)
                {
                    textBoxEditEmployeeFN.Text = employee.FirstName;
                    textBoxEditEmloyeeLN.Text = employee.LastName;
                    textBoxEditSpec.Text = employee.Specialization;
                }
                else
                {
                    MessageBox.Show("Сотрудник не найден!", "Ошибка редактирования",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CreatePhotosDirectory()
        {
            var photosDir = Path.Combine(Application.StartupPath, "EmployeePhotos");
            if (!Directory.Exists(photosDir))
            {
                Directory.CreateDirectory(photosDir);
            }
        }
        private void buttonEditEmployee_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                try
                {
                    using var context = new Coursa4Context();
                    employee.FirstName = textBoxEditEmployeeFN.Text.Trim();
                    employee.LastName = textBoxEditEmloyeeLN.Text.Trim();
                    employee.Specialization = textBoxEditSpec.Text.Trim();

                    context.Employees.Update(employee);
                    context.SaveChanges();

                    if (!string.IsNullOrEmpty(tempPhotoPath))
                    {
                        SaveEmployeePhoto(employee.Id);
                    }

                    MessageBox.Show("Данные сотрудника успешно изменены!", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при изменении сотрудника: {ex.Message}", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void SaveEmployeePhoto(int employeeId)
        {
            if (string.IsNullOrEmpty(tempPhotoPath) || pictureBoxEditEmployee.Image == null)
                return;

            try
            {
                var photosDir = Path.Combine(Application.StartupPath, "EmployeePhotos");
                var photoPath = Path.Combine(photosDir, $"employee_{employeeId}.jpg");

                pictureBoxEditEmployee.Image.Save(photoPath, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении фото: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void pictureBoxEditEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var fileInfo = new FileInfo(openFileDialog.FileName);
                    if (fileInfo.Length > 5 * 1024 * 1024) 
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
                        pictureBoxEditEmployee.Image = resizedImage;
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
            if (string.IsNullOrWhiteSpace(textBoxEditEmloyeeLN.Text))
            {
                MessageBox.Show("Введите фамилию сотрудника", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxEditEmloyeeLN.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(textBoxEditEmployeeFN.Text))
            {
                MessageBox.Show("Введите имя сотрудника", "Ошибка",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxEditEmployeeFN.Focus();
                return false;
            }
            if (textBoxEditEmployeeFN.Text.Trim().Length > 50)
            {
                MessageBox.Show("Имя не должно превышать 50 символов", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxEditEmployeeFN.Focus();
                textBoxEditEmployeeFN.SelectAll();
                return false;
            }
            if (textBoxEditEmloyeeLN.Text.Trim().Length < 2)
            {
                MessageBox.Show("Фамилия должна содержать минимум 2 символа", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxEditEmloyeeLN.Focus();
                textBoxEditEmloyeeLN.SelectAll();
                return false;
            }
            if (textBoxEditSpec.Text.Trim().Length < 3)
            {
                MessageBox.Show("Специализация должна содержать минимум 3 символа", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxEditSpec.Focus();
                textBoxEditSpec.SelectAll();
                return false;
            }
            if (textBoxEditSpec.Text.Trim().Length > 100)
            {
                MessageBox.Show("Специализация не должна превышать 100 символов", "Ошибка",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxEditSpec.Focus();
                textBoxEditSpec.SelectAll();
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
            if (IsEmployeeExists(textBoxEditEmployeeFN.Text.Trim(), textBoxEditEmloyeeLN.Text.Trim()))
            {
                MessageBox.Show("Сотрудник с таким именем и фамилией уже существует", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxEditEmployeeFN.Focus();
                textBoxEditEmployeeFN.SelectAll();
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
