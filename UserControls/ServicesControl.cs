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
    public partial class ServicesControl : BaseListControl
    {
        private List<Service> services;
        private List<Service> filteredServices;

        public ServicesControl()
        {
            InitializeComponent();
            SetupDataGridViewColumns();
            SetupSearchFilter();
            LoadData();
        }
        private void SetupDataGridViewColumns() {
            DataGridView.Columns.Clear();

            DataGridView.Columns.Add("Id", "ID");
            DataGridView.Columns.Add("Name", "Название услуги");
            DataGridView.Columns.Add("Description", "Описание");
            DataGridView.Columns.Add("Price", "Стоимость");
            DataGridView.Columns.Add("RequiredSpecialization", "Требуемая специализация");

            DataGridView.Columns["Id"].Visible = false;
            DataGridView.Columns["Name"].Width = 150;
            DataGridView.Columns["Description"].Width = 300;
            DataGridView.Columns["Price"].Width = 100;
            DataGridView.Columns["RequiredSpecialization"].Width = 200;

            DataGridView.Columns["Price"].DefaultCellStyle.Format = "C2";
            DataGridView.Columns["Price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DataGridView.Columns["Description"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            DataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }
        public override void LoadData()
        {
            try
            {
                using var context = new Coursa4Context();
                services = context.Services.ToList();

                if (services.Count == 0)
                {
                    MessageBox.Show("В базе данных отсутствуют услуги. Добавьте их, чтобы заполнить таблицу", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                filteredServices = new List<Service>(services);
                DisplayServices();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке услуг: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DisplayServices()
        {
            DataGridView.Rows.Clear();

            foreach (var service in filteredServices)
            {
                DataGridView.Rows.Add(
                    service.Id,
                    service.Name ?? "",
                    service.Description ?? "",
                    service.Price,
                    service.RequiredSpecialization ?? ""
                );
            }
            DataGridView.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders);
        }
        protected override void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var addServiceForm = new AddService();
                if (addServiceForm.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                    SearchFilter.ClearSearch();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при открытии формы добавления: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        protected override void buttonEdit_Click(object sender, EventArgs e)
        {
            if (DataGridView.SelectedRows.Count > 0)
            {
                var serviceId = (int)DataGridView.SelectedRows[0].Cells["Id"].Value;
                var serviceName = DataGridView.SelectedRows[0].Cells["Name"].Value.ToString();

                var editServiceForm = new EditService(serviceId);
            }
            else
            {
                MessageBox.Show("Выберите услугу для редактирования", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        protected override void buttonDelete_Click(object sender, EventArgs e)
        {
            if (DataGridView.SelectedRows.Count > 0)
            {
                var serviceId = (int)DataGridView.SelectedRows[0].Cells["Id"].Value;
                var serviceName = DataGridView.SelectedRows[0].Cells["Name"].Value.ToString();

                var result = MessageBox.Show($"Вы уверены, что хотите удалить услугу:\n\"{serviceName}\"?",
                    "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    DeleteService(serviceId);
                }
            }
            else
            {
                MessageBox.Show("Выберите услугу для удаления", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void DeleteService(int serviceId)
        {
            try
            {
                using var context = new Coursa4Context();
                var service = context.Services.Find(serviceId);

                if (service != null)
                {
                    context.Services.Remove(service);
                    context.SaveChanges();

                    LoadData();
                    MessageBox.Show("Услуга успешно удалена", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении услуги: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        protected override void buttonUpdate_Click(object sender, EventArgs e)
        {
            LoadData();
            SearchFilter.ResetAll();
        }
        public void SetupSearchFilter() { }
    }
}
