using coursa4.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static coursa4.Program;
using coursa4;

namespace coursa4
{
    public partial class ChangePassword : Form
    {
        private int currentUserId;
        public ChangePassword(int userId)
        {
            currentUserId = userId;
            InitializeComponent();
        }

        private void buttonCompletePassChange_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxOldPassword.Text))
            {
                MessageBox.Show("Введите старый пароль!",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                textBoxOldPassword.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxNewPassword.Text))
            {
                MessageBox.Show("Введите новый пароль!",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                textBoxNewPassword.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxNewPasswordRep.Text))
            {
                MessageBox.Show("Повторите новый пароль!",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                textBoxNewPasswordRep.Focus();
                return;
            }

            if (textBoxNewPassword.Text.Length < 6)
            {
                MessageBox.Show("Новый пароль должен содержать минимум 6 символов!",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                textBoxNewPassword.Focus();
                return;
            }

            if (textBoxNewPassword.Text != textBoxNewPasswordRep.Text)
            {
                MessageBox.Show("Новые пароли не совпадают!",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                textBoxNewPassword.Focus();
                textBoxNewPasswordRep.Clear();
                return;
            }

            if (textBoxOldPassword.Text == textBoxNewPassword.Text)
            {
                MessageBox.Show("Новый пароль должен отличаться от старого!",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                textBoxNewPassword.Focus();
                return;
            }

            try
            {
                using (var context = new Coursa4Context())
                {
                    // Находим текущего пользователя
                    var user = context.UserAccounts
                        .FirstOrDefault(u => u.Id == currentUserId);

                    if (user == null)
                    {
                        MessageBox.Show("Пользователь не найден!",
                            "Ошибка",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }

                    string oldPasswordHash = Authorization.GetHash(textBoxOldPassword.Text.Trim());
                    if (user.PasswordHash != oldPasswordHash)
                    {
                        MessageBox.Show("Старый пароль неверен!",
                            "Ошибка",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        textBoxOldPassword.Focus();
                        textBoxOldPassword.Clear();
                        return;
                    }

                    // Обновляем пароль, используя метод из Authorization
                    user.PasswordHash = Authorization.GetHash(textBoxNewPassword.Text.Trim());
                    context.SaveChanges();

                    MessageBox.Show("Пароль успешно изменен!",
                        "Успех",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при смене пароля: {ex.Message}",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
