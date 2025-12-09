using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using coursa4.Data;
using Microsoft.EntityFrameworkCore;

namespace coursa4
{
    public partial class ReportDetailsForm : Form
    {
        private int orderId;

        public ReportDetailsForm(int orderId)
        {
            InitializeComponent();
            this.orderId = orderId;
        }

        private void buttonOpenFile_Click(object sender, EventArgs e)
        {
            try
            {
                string reportsFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reports");
                string filePath = Path.Combine(reportsFolder, $"{orderId}.docx");

                if (File.Exists(filePath))
                {
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = filePath,
                        UseShellExecute = true
                    });
                }
                else
                {
                    MessageBox.Show("Файл не найден", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при открытии файла: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ReportDetailsForm_Load(object sender, EventArgs e)
        {
            LoadOrderDetails();
        }
        private void LoadOrderDetails()
        {
            try
            {
                using var context = new Coursa4Context();
                var order = context.Orders
                    .Include(o => o.Client)
                    .Include(o => o.Vehicle)
                    .Include(o => o.Services)
                    .Include(o => o.Employees)
                    .FirstOrDefault(o => o.Id == orderId);

                if (order != null)
                {
                    // Заголовок
                    labelOrderId.Text = $"Отчет по заказу №{order.Id}";

                    // Основная информация
                    labelClientValue.Text = $"{order.Client?.LastName} {order.Client?.FirstName}";
                    labelVehicleValue.Text = $"{order.Vehicle?.Brand} {order.Vehicle?.Model} ({order.Vehicle?.Year})";
                    labelAcceptDateValue.Text = order.AcceptionDate.ToString("dd.MM.yyyy");
                    labelCompleteDateValue.Text = order.ActualCompletionDate?.ToString("dd.MM.yyyy") ?? "Не завершен";
                    labelPriceValue.Text = order.Price.ToString("C2");

                    // Услуги
                    listBoxServices.Items.Clear();
                    if (order.Services != null)
                    {
                        foreach (var service in order.Services)
                        {
                            listBoxServices.Items.Add($"• {service.Name} - {service.Price:C2}");
                            if (!string.IsNullOrEmpty(service.Description))
                            {
                                listBoxServices.Items.Add($"  Описание: {service.Description}");
                            }
                        }
                    }

                    // Сотрудники
                    listBoxEmployees.Items.Clear();
                    if (order.Employees != null)
                    {
                        foreach (var employee in order.Employees)
                        {
                            listBoxEmployees.Items.Add($"{employee.LastName} {employee.FirstName}");
                            listBoxEmployees.Items.Add($"  Специализация: {employee.Specialization}");
                            listBoxEmployees.Items.Add($"  Статус: {employee.Status}");
                            listBoxEmployees.Items.Add(""); // Пустая строка для разделения
                        }
                    }

                    // Информация о файле
                    string reportsFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reports");
                    string filePath = Path.Combine(reportsFolder, $"{orderId}.docx");

                    if (File.Exists(filePath))
                    {
                        var fileInfo = new FileInfo(filePath);
                        labelFileInfo.Text = $"Файл: {orderId}.docx ({fileInfo.Length / 1024} КБ)";
                        buttonOpenFile.Enabled = true;
                    }
                    else
                    {
                        labelFileInfo.Text = "Файл отчета не найден";
                        buttonOpenFile.Enabled = false;
                    }
                }
                else
                {
                    MessageBox.Show("Заказ не найден", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
