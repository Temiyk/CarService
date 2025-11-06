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
        private string imagePath = null;

        public AddEmployee()
        {
            InitializeComponent();
        }

        private void buttonAddEmployee_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxEmloyeeLN.Text) || string.IsNullOrWhiteSpace(textBoxEmployeeFN.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Заполните обязательные поля: Имя, Фамилия, Специализация");
                return;
            }

            try
            {
                using var context = new Coursa4Context();
                var employee = new Employee()
                {
                    FirstName = textBoxEmployeeFN.Text,
                    LastName = textBoxEmloyeeLN.Text,
                    Specialization = textBox2.Text,
                };

                context.Employees.Add(employee);
                context.SaveChanges();

                if (!string.IsNullOrEmpty(imagePath))
                {
                    SaveEmployeeImage(employee.Id, imagePath);
                }

                MessageBox.Show("Сотрудник успешно добавлен!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении сотрудника: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void pictureBoxEmployee_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                openFileDialog.Title = "Выберите фотографию сотрудника";
                openFileDialog.Multiselect = false;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    imagePath = openFileDialog.FileName;
                    pictureBoxEmployee.Image = Image.FromFile(imagePath);
                    pictureBoxEmployee.SizeMode = PictureBoxSizeMode.Zoom;

                    pictureBoxEmployee.Cursor = Cursors.Default;
                }
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
    }
}
