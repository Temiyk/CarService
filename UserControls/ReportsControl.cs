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
using DocumentFormat.OpenXml.Packaging;
using coursa4.Data;
using Microsoft.EntityFrameworkCore;

namespace coursa4.UserControls
{
    public partial class ReportsControl : BaseListControl
    {
        private List<ReportInfo> reports;
        private Button buttonOpenFile;
        private Button buttonDeleteFile;
        public ReportsControl()
        {
            InitializeComponent();
            ReconfigureExistingControls();
            AddCustomButtons();
            SetupDataGridViewColumns();
            LoadData();
            DataGridView.SelectionChanged += DataGridView_SelectionChanged;
            DataGridView.CellDoubleClick += DataGridView_CellDoubleClick;
            SearchFilter.SearchApplied += SearchFilter_SearchApplied;
        }

        private void ReconfigureExistingControls()
        {
            buttonAdd.Visible = false;
            buttonEdit.Text = "Просмотреть";
            buttonEdit.Location = new Point(10, 10);
            buttonEdit.Width = 100;
            buttonDelete.Text = "Удалить отчёт";
            buttonDelete.Location = new Point(120, 10);
            buttonDelete.Width = 120;
            buttonUpdate.Location = new Point(250, 10);
            buttonUpdate.Width = 100;
            DataGridView.Dock = DockStyle.Fill;
        }

        private void AddCustomButtons()
        {

            buttonOpenFile = new Button
            {
                Text = "Открыть файл",
                BackColor = Color.DodgerBlue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(120, 30),
                Location = new Point(360, 10),
                Enabled = false
            };
            buttonOpenFile.Click += buttonOpenFile_Click;

            var buttonInfo = new Button
            {
                Text = "Инфо",
                BackColor = Color.Goldenrod,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(80, 30),
                Location = new Point(490, 10)
            };
            buttonInfo.Click += (s, e) => MessageBox.Show(
                "Отчеты создаются автоматически при завершении заказов.\n" +
                "Файлы сохраняются в папке Reports в формате .docx",
                "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);

            var buttonExport = new Button
            {
                Text = "Экспорт...",
                BackColor = Color.Purple,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(100, 30),
                Location = new Point(580, 10)
            };
            buttonExport.Click += ButtonExport_Click;

            foreach (Control control in this.Controls)
            {
                if (control is Panel panel && panel.BackColor == Color.LightGray)
                {
                    panel.Controls.Add(buttonOpenFile);
                    panel.Controls.Add(buttonInfo);
                    panel.Controls.Add(buttonExport);
                    break;
                }
            }
        }

        private void SetupDataGridViewColumns()
        {
            DataGridView.Columns.Clear();

            // Добавляем столбцы
            DataGridView.Columns.Add("Id", "ID заказа");
            DataGridView.Columns.Add("FileName", "Имя файла");
            DataGridView.Columns.Add("CreationDate", "Дата создания");
            DataGridView.Columns.Add("FileSize", "Размер (КБ)");
            DataGridView.Columns.Add("FilePath", "Путь к файлу");

            // Настраиваем ширину
            DataGridView.Columns["Id"].Width = 80;
            DataGridView.Columns["FileName"].Width = 200;
            DataGridView.Columns["CreationDate"].Width = 120;
            DataGridView.Columns["FileSize"].Width = 80;
            DataGridView.Columns["FilePath"].Visible = false;

            // Настраиваем стиль
            DataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DataGridView.ReadOnly = true;
            DataGridView.AllowUserToAddRows = false;
            DataGridView.AllowUserToDeleteRows = false;
            DataGridView.RowHeadersVisible = false;
            DataGridView.BackgroundColor = Color.White;
        }

        private void DataGridView_SelectionChanged(object sender, EventArgs e)
        {
            bool hasSelection = DataGridView.SelectedRows.Count > 0;
            buttonEdit.Enabled = hasSelection;      
            buttonDelete.Enabled = hasSelection;    
            if (buttonOpenFile != null)
                buttonOpenFile.Enabled = hasSelection; 
        }

        private void DataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                ViewReportDetails();
            }
        }

        private void buttonOpenFile_Click(object sender, EventArgs e)
        {
            OpenSelectedReportFile();
        }

        private void ButtonExport_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Функция экспорта в разработке", "Информация",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void buttonDeleteFile_Click(object sender, EventArgs e)
        {
            if (DataGridView.SelectedRows.Count > 0)
            {
                var fileName = DataGridView.SelectedRows[0].Cells["FileName"].Value.ToString();

                var result = MessageBox.Show($"Удалить файл отчета {fileName}?",
                    "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        string filePath = DataGridView.SelectedRows[0].Cells["FilePath"].Value.ToString();

                        if (File.Exists(filePath))
                        {
                            File.Delete(filePath);
                            LoadData();
                            MessageBox.Show("Файл отчета успешно удален", "Успех",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при удалении файла: {ex.Message}", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        public override void LoadData()
        {
            try
            {
                string reportsFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reports");

                if (!Directory.Exists(reportsFolder))
                {
                    Directory.CreateDirectory(reportsFolder);
                    reports = new List<ReportInfo>();
                    DisplayReports();
                    return;
                }

                var reportFiles = Directory.GetFiles(reportsFolder, "*.docx");
                reports = new List<ReportInfo>();

                foreach (var filePath in reportFiles)
                {
                    var fileInfo = new FileInfo(filePath);
                    var fileName = Path.GetFileNameWithoutExtension(filePath);

                    if (int.TryParse(fileName, out int orderId))
                    {
                        reports.Add(new ReportInfo
                        {
                            OrderId = orderId,
                            FilePath = filePath,
                            FileName = Path.GetFileName(filePath),
                            CreationDate = fileInfo.CreationTime,
                            FileSizeKB = fileInfo.Length / 1024
                        });
                    }
                }

                DisplayReports();
                SearchFilter.SetFilterOptions(new[] { "Все", "ID заказа", "Имя файла" });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке отчетов: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayReports()
        {
            DataGridView.Rows.Clear();

            foreach (var report in reports.OrderByDescending(r => r.CreationDate))
            {
                DataGridView.Rows.Add(
                    report.OrderId,
                    report.FileName,
                    report.CreationDate.ToString("dd.MM.yyyy HH:mm"),
                    report.FileSizeKB,
                    report.FilePath
                );
            }
        }

        protected override void buttonEdit_Click(object sender, EventArgs e)
        {
            ViewReportDetails();
        }

        protected override void buttonDelete_Click(object sender, EventArgs e)
        {
            DeleteSelectedReport();
        }

        protected override void buttonUpdate_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        protected override void buttonAdd_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Отчеты создаются автоматически при завершении заказов",
                "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ViewReportDetails()
        {
            if (DataGridView.SelectedRows.Count > 0)
            {
                var orderId = (int)DataGridView.SelectedRows[0].Cells["Id"].Value;
                var reportDetailsForm = new ReportDetailsForm(orderId);
                reportDetailsForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Выберите отчет для просмотра", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void OpenSelectedReportFile()
        {
            if (DataGridView.SelectedRows.Count > 0)
            {
                try
                {
                    string filePath = DataGridView.SelectedRows[0].Cells["FilePath"].Value.ToString();

                    if (File.Exists(filePath))
                    {
                        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                        {
                            FileName = filePath,
                            UseShellExecute = true
                        });
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при открытии файла: {ex.Message}", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void DeleteSelectedReport()
        {
            if (DataGridView.SelectedRows.Count > 0)
            {
                var fileName = DataGridView.SelectedRows[0].Cells["FileName"].Value.ToString();

                var result = MessageBox.Show($"Удалить файл отчета {fileName}?",
                    "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        string filePath = DataGridView.SelectedRows[0].Cells["FilePath"].Value.ToString();

                        if (File.Exists(filePath))
                        {
                            File.Delete(filePath);
                            LoadData();
                            MessageBox.Show("Файл отчета успешно удален", "Успех",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при удалении файла: {ex.Message}", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void SearchFilter_SearchApplied(object sender, EventArgs e)
        {
            ApplyFilter(SearchFilter.SearchText, SearchFilter.FilterBy);
        }
        protected override void ApplyFilter(string searchText, string filterBy)
        {
            if (string.IsNullOrEmpty(searchText))
            {
                DisplayReports();
                return;
            }

            var filteredReports = reports.Where(r =>
            {
                switch (filterBy)
                {
                    case "ID заказа":
                        return r.OrderId.ToString().Contains(searchText);
                    case "Имя файла":
                        return r.FileName.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0;
                    case "Все":
                    default:
                        return r.OrderId.ToString().Contains(searchText) ||
                               r.FileName.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0;
                }
            }).ToList();

            DataGridView.Rows.Clear();
            foreach (var report in filteredReports)
            {
                DataGridView.Rows.Add(
                    report.OrderId,
                    report.FileName,
                    report.CreationDate.ToString("dd.MM.yyyy HH:mm"),
                    report.FileSizeKB,
                    report.FilePath
                );
            }
        }
    }

    public class ReportInfo
    {
        public int OrderId { get; set; }
        public string FilePath { get; set; }
        public string FileName { get; set; }
        public DateTime CreationDate { get; set; }
        public long FileSizeKB { get; set; }
    }
}
