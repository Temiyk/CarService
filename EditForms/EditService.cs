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
    public partial class EditService : Form
    {
        private Service service;
        private int serviceId;
        public EditService(int serciceId)
        {
            InitializeComponent();
            this.serviceId = serciceId;
            LoadServiceData();
        }
        private void LoadServiceData() {
            try {
                using var context = new Coursa4Context();
                service = context.Services.Find(serviceId);

                if (service != null)
                {
                    textBoxServiceName.Text = service.Name;
                    textBoxServiceDescription.Text = service.Description;
                    textBoxServicePrice.Text = service.Price.ToString();
                    textBoxSpecialization.Text = service.RequiredSpecialization;
                }
                else {
                    MessageBox.Show("Услуга не найдена!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex) {
                MessageBox.Show($"Ошибка при загрузке данных {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool ValidateInput() {
            if (string.IsNullOrWhiteSpace(textBoxServiceName.Text) || textBoxServiceName.Text.Length < 5) {
                MessageBox.Show("Название услуги должно содержать минимум 5 символов", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxServiceName.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(textBoxServiceDescription.Text)) {
                MessageBox.Show("Введите описание услуги", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxServiceDescription.Focus();
                return false;
            }
            if (!decimal.TryParse(textBoxServicePrice.Text, out decimal price) || price <= 0)
            {
                MessageBox.Show("Введите корректную стоимость (положительное число)", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxServicePrice.Focus();
                textBoxServicePrice.SelectAll();
                return false;
            }
            if (string.IsNullOrEmpty(textBoxSpecialization.Text) || textBoxSpecialization.Text.Length < 5)
            {
                MessageBox.Show("Требуемая специализация должна содержать минимум 5 символов", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxSpecialization.Focus();
                return false;
            }
            return true;
        }

        private void buttonApplyServiceChanges_Click(object sender, EventArgs e)
        {
            if (ValidateInput()) {
                SaveServiceChanges();
            }
        }
        private void SaveServiceChanges()
        {
            try
            {
                using var context = new Coursa4Context();
                var existingService = context.Services.Find(serviceId);

                if (existingService != null)
                {
                    var nameExists = context.Services.Any(c => c.Name == textBoxServiceName.Text.Trim());
                    if (nameExists)
                    {
                        MessageBox.Show("Сервис с таким названием уже существует!", "Ошибка",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    existingService.Name = textBoxServiceName.Text.Trim();
                    existingService.Price = decimal.Parse(textBoxServicePrice.Text);
                    existingService.RequiredSpecialization = textBoxSpecialization.Text.Trim();
                    existingService.Description = textBoxServiceDescription.Text.Trim();

                    context.SaveChanges();
                    MessageBox.Show("Данные услуги успешно обновлены!", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
