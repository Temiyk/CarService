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
                Width = 80,
                ImageLayout = DataGridViewImageCellLayout.Zoom
            };
            DataGridView.Columns.Add(photoColumn);

            DataGridView.Columns.Add("Id", "ID");
            DataGridView.Columns.Add("FirstName", "Имя");
            DataGridView.Columns.Add("LastName", "Фамилия");
            DataGridView.Columns.Add("Specialization", "Специализация");
            DataGridView.Columns.Add("Status", "Статус");
            DataGridView.Columns.Add("CurrentOrders", "Текущий заказ");

            DataGridView.Columns["Id"].Visible = false;
            DataGridView.Columns["FirstName"].Width = 120;
            DataGridView.Columns["LastName"].Width = 120;
            DataGridView.Columns["Specialization"].Width = 150;
            DataGridView.Columns["Status"].Width = 100;
            DataGridView.Columns["CurrentOrders"].Width = 100;

            DataGridView.Columns["CurrentOrders"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DataGridView.Columns["Status"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            DataGridView.Columns["CurrentOrders"].HeaderText = "Активный заказы";
        }
        private void SetupSearchFilter()
        {
            string[] filterOptions = { "Все", "Имя", "Фамилия", "Специализация", "Статус" };
            string[] sortOptions = { "Имя", "Фамилия", "Специализация", "Статус", "Активные заказы" };

            SearchFilter.SetFilterOptions(filterOptions);
            SearchFilter.SetSortOptions(sortOptions);
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
                            // Удаляем фото из папки
                            DeleteEmployeePhoto(employeeId);

                            // Удаляем сотрудника из БД
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
                    DataGridView.Rows.Add(
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
