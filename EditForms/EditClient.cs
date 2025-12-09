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

namespace coursa4
{
    public partial class EditClient : Form
    {
        private int clientId;
        private Client client;

        public EditClient(int clientId)
        {
            InitializeComponent();
            this.clientId = clientId;
            LoadClientData();
        }

        private void LoadClientData()
        {
            try {
                using var context = new Coursa4Context();
                client = context.Clients.Find(clientId);

                if (client != null)
                {
                    textBoxClientFN.Text = client.FirstName;
                    textBoxClientLN.Text = client.LastName;
                    textBoxEMail.Text = client.Email ?? "";
                    textBoxPhoneNumber.Text = client.PhoneNumber;
                }
                else {
                    MessageBox.Show("Клиент не найден!", "Ошибка редактирования", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch(Exception ex) {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInput() {
            if (string.IsNullOrWhiteSpace(textBoxClientFN.Text) || textBoxClientFN.Text.Length < 2) {
                MessageBox.Show("Имя должно содержать минимум 2 символа!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxClientFN.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(textBoxClientLN.Text) || textBoxClientLN.Text.Length < 2)
            {
                MessageBox.Show("Фамилия должна содержать минимум 2 символа!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxClientLN.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(textBoxPhoneNumber.Text) || textBoxPhoneNumber.Text.Length != 13) {
                MessageBox.Show("Телефон не может быть пустым!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void SaveClientChanges()
        {
            try
            {
                using var context = new Coursa4Context();
                var existingClient = context.Clients.Find(clientId);

                if (existingClient != null)
                {
                    if (existingClient.PhoneNumber != textBoxPhoneNumber.Text.Trim())
                    {
                        var phoneExists = context.Clients
                            .Any(c => c.PhoneNumber == textBoxPhoneNumber.Text.Trim() && c.Id != clientId);

                        if (phoneExists)
                        {
                            MessageBox.Show("Клиент с таким телефоном уже существует!", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }


                    existingClient.FirstName = textBoxClientFN.Text.Trim();
                    existingClient.LastName = textBoxClientLN.Text.Trim();
                    existingClient.PhoneNumber = textBoxPhoneNumber.Text.Trim();
                    existingClient.Email = string.IsNullOrWhiteSpace(textBoxEMail.Text)
                        ? null
                        : textBoxEMail.Text.Trim();

                    context.SaveChanges();

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
        private void buttonApplyChanges_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                SaveClientChanges();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EditClient_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
