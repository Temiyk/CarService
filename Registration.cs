using coursa4.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using coursa4;


namespace coursa4.Data
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }
        public static int GetHash(string s)
        {
            long sum = 0;
            for (int i = 0; i < s.Length; i++)
            {
                sum += ((int)s[i]) * ((int)s[i]) * 3 / (i + 1);
            }
            sum *= sum;
            return (int)sum;
        }
        private void buttonRegistrationComplete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxNewUserName.Text) || textBoxNewUserName.Text.Length < 2)
            {
                MessageBox.Show("Имя должно содержать минимум 2 символа!",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxNewUserName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxNewUserLogin.Text) || textBoxNewUserLogin.Text.Length < 4)
            {
                MessageBox.Show("Логин должен содержать минимум 4 символа!",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxNewUserLogin.Focus();
                return;
            }

            try
            {
                using var context = new Coursa4Context();

                if (context.UserAccounts.Any(u => u.Login == textBoxNewUserLogin.Text.Trim()))
                {
                    MessageBox.Show("Пользователь с таким логином уже существует!",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (textBoxNewUserPass.Text.Trim() != textBoxNewUserPassRep.Text.Trim()) {
                    MessageBox.Show("Пароли не совпадают!",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var newUser = new UserAccount
                {
                    Name = textBoxNewUserName.Text.Trim(),
                    Login = textBoxNewUserLogin.Text.Trim(),
                    PasswordHash = GetHash(textBoxNewUserPass.Text.Trim()),
                };

                context.UserAccounts.Add(newUser);
                context.SaveChanges();

                MessageBox.Show("Регистрация прошла успешно!", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при регистрации: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
