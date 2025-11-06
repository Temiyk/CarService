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
    public partial class AddService : Form
    {
        public AddService()
        {
            InitializeComponent();
        }

        private void buttonAddService_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxServiceName.Text))
            {
                MessageBox.Show("Введите название услуги");
                textBoxServiceName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxServicePrice.Text))
            {
                MessageBox.Show("Введите стоимость услуги");
                textBoxServicePrice.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxSpecialization.Text))
            {
                MessageBox.Show("Введите требуемую специализацию");
                textBoxSpecialization.Focus();
                return;
            }

            // Проверка корректности цены
            if (!decimal.TryParse(textBoxServicePrice.Text, out decimal price) || price <= 0)
            {
                MessageBox.Show("Введите корректную стоимость (положительное число)");
                textBoxServicePrice.Focus();
                textBoxServicePrice.SelectAll();
                return;
            }

            try
            {
                using var context = new Coursa4Context();

                var existingService = context.Services
                    .FirstOrDefault(s => s.Name.ToLower() == textBoxServiceName.Text.Trim().ToLower());

                if (existingService != null)
                {
                    var result = MessageBox.Show(
                        $"Услуга с названием \"{textBoxServiceName.Text}\" уже существует.\nХотите создать ещё одну?",
                        "Подтверждение",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result == DialogResult.No)
                        return;
                }
                var service = new Service
                {
                    Name = textBoxServiceName.Text.Trim(),
                    Description = string.IsNullOrWhiteSpace(textBoxServiceDescription.Text)
                        ? null
                        : textBoxServiceDescription.Text.Trim(),
                    Price = price,
                    RequiredSpecialization = textBoxSpecialization.Text.Trim()
                };

                context.Services.Add(service);
                context.SaveChanges();

                MessageBox.Show("Услуга успешно добавлена!", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                var dialogResult = MessageBox.Show(
                    "Хотите добавить ещё одну услугу?",
                    "Добавление услуги",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (dialogResult == DialogResult.Yes)
                {
                    ClearForm();
                }
                else
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении услуги:\n{ex.Message}", "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void ClearForm()
        {
            textBoxServiceName.Clear();
            textBoxServiceDescription.Clear();
            textBoxServicePrice.Clear();
            textBoxSpecialization.Clear();
            textBoxServiceName.Focus();
        }

    }
}
