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
    public partial class AddClient : Form
    {
        public AddClient()
        {
            InitializeComponent();
        }

        private void buttonCompleteAdding_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxClientFN.Text) || string.IsNullOrWhiteSpace(textBoxClientLN.Text) || string.IsNullOrWhiteSpace(textBoxPhoneNumber.Text))
            {
                MessageBox.Show("Заполните обязательные поля: Имя, Фамилия, Телефон");
                return;
            }


            try {
                using var context = new Coursa4Context();
                var client = new Client
                {
                    FirstName = textBoxClientFN.Text,
                    LastName = textBoxClientLN.Text,
                    PhoneNumber = textBoxPhoneNumber.Text,
                    Email = string.IsNullOrWhiteSpace(textBoxEMail.Text) ? null : textBoxEMail.Text,
                };

                context.Clients.Add(client);
                context.SaveChanges();
                MessageBox.Show("Клиент успешно добвален!");
                this.Close();
            }
            catch (Exception ex) { 
                MessageBox.Show($"Ошибка при добавлении клиента: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
