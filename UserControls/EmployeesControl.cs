using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using coursa4.Models;
using coursa4.Data;

namespace coursa4.UserControls
{
    public partial class EmployeesControl : BaseListControl
    {
        public EmployeesControl()
        {
            InitializeComponent();
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
    }
}
