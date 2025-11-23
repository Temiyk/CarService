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
    public partial class EmployeesControl : BaseListControl
    {
        private const int PHOTO_SIZE = 80; // Размер фото в пикселях

        public EmployeesControl()
        {
            InitializeComponent();
            SetupDataGridViewColumns();
            SetupSearchFilter();
            LoadData();
        }

        private void SetupDataGridViewColumns()
        {
            DataGridView.Columns.Clear();

            var photoColumn = new DataGridViewImageColumn
            {
                Name = "Photo",
                HeaderText = "Фото",
                Width = PHOTO_SIZE + 20, // +20 для отступов
                ImageLayout = DataGridViewImageCellLayout.Zoom,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    NullValue = null,
                    Alignment = DataGridViewContentAlignment.MiddleCenter,
                    Padding = new Padding(5)
                }
            };
            DataGridView.Columns.Add(photoColumn);

            DataGridView.Columns.Add("Id", "ID");
            DataGridView.Columns.Add("FirstName", "Имя");
            DataGridView.Columns.Add("LastName", "Фамилия");
            DataGridView.Columns.Add("Specialization", "Специализация");
            DataGridView.Columns.Add("Status", "Статус");

            DataGridView.Columns["Id"].Visible = false;
            DataGridView.Columns["FirstName"].Width = 120;
            DataGridView.Columns["LastName"].Width = 120;
            DataGridView.Columns["Specialization"].Width = 200; // Увеличим ширину для специализации
            DataGridView.Columns["Status"].Width = 120; // Немного увеличим для статуса

            // Устанавливаем высоту строк
            DataGridView.RowTemplate.Height = PHOTO_SIZE + 10;
            DataGridView.Columns["Status"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void SetupSearchFilter()
        {
            string[] filterOptions = { "Все", "Имя", "Фамилия", "Специализация", "Статус" };
            SearchFilter.SetFilterOptions(filterOptions);
        }
        protected override void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var addEmployeeForm = new AddEmployee();
                if (addEmployeeForm.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                    SearchFilter.ClearSearch();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось открыть форму добавления: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        protected override void buttonUpdate_Click(object sender, EventArgs e)
        {
            LoadData();
            SearchFilter.ClearSearch();
        }

        protected override void buttonDelete_Click(object sender, EventArgs e)
        {
            if (DataGridView.SelectedRows.Count > 0)
            {
                var employeeId = (int)DataGridView.SelectedRows[0].Cells["Id"].Value;
                var employeeName = DataGridView.SelectedRows[0].Cells["FirstName"].Value + " " +
                                  DataGridView.SelectedRows[0].Cells["LastName"].Value;

                var result = MessageBox.Show($"Вы уверены, что хотите удалить сотрудника:\n{employeeName}?",
                    "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        using var context = new Coursa4Context();
                        var employee = context.Employees.Find(employeeId);
                        if (employee != null)
                        {
                            DeleteEmployeePhoto(employeeId);

                            context.Employees.Remove(employee);
                            context.SaveChanges();

                            LoadData();
                            MessageBox.Show("Сотрудник успешно удален", "Успех",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при удалении сотрудника: {ex.Message}", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void DeleteEmployeePhoto(int employeeId)
        {
            try
            {
                var photosDir = Path.Combine(Application.StartupPath, "EmployeePhotos");

                var possibleExtensions = new[] { ".jpg", ".jpeg", ".png", ".bmp" };

                foreach (var extension in possibleExtensions)
                {
                    var photoPath = Path.Combine(photosDir, $"employee_{employeeId}{extension}");
                    if (File.Exists(photoPath))
                    {
                        File.Delete(photoPath);
                        Console.WriteLine($"Удалено фото: {photoPath}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении фото сотрудника: {ex.Message}", "Ошибка",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private Image LoadEmployeePhoto(int employeeId)
        {
            try
            {
                var photosDir = Path.Combine(Application.StartupPath, "EmployeePhotos");

                if (!Directory.Exists(photosDir))
                    return null;

                var possibleExtensions = new[] { ".jpg", ".jpeg", ".png", ".bmp" };

                foreach (var extension in possibleExtensions)
                {
                    var photoPath = Path.Combine(photosDir, $"employee_{employeeId}{extension}");
                    if (File.Exists(photoPath))
                    {
                        using (var originalImage = Image.FromFile(photoPath))
                        {
                            // Создаем копию изображения для DataGridView
                            var resizedImage = new Bitmap(60, 60);
                            using (var graphics = Graphics.FromImage(resizedImage))
                            {
                                graphics.DrawImage(originalImage, 0, 0, 60, 60);
                            }
                            return resizedImage;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при загрузке фото сотрудника {employeeId}: {ex.Message}");
            }

            return null; // Возвращаем null если фото нет
        }
        public override void LoadData()
        {
            try
            {
                using var context = new Coursa4Context();
                var employees = context.Employees
                    .Include(e => e.Orders)
                    .AsNoTracking()
                    .ToList();

                DataGridView.Rows.Clear();

                foreach (var employee in employees)
                {
                    var employeePhoto = LoadEmployeePhoto(employee.Id);

                    DataGridView.Rows.Add(
                        employeePhoto, // Фото (может быть null)
                        employee.Id,
                        employee.FirstName,
                        employee.LastName,
                        employee.Specialization,
                        employee.Status,
                        employee.Orders.Count(o => o.Status != "Завершен" && o.Status != "Отменен")
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке сотрудников: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
