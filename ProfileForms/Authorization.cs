using System.Drawing.Text;
using coursa4.Data;
using coursa4.Models;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure.Internal;

namespace coursa4
{
    public partial class Authorization : Form
    {
        private List<UserAccount> users = new List<UserAccount>();
        public Authorization()
        {
            InitializeComponent();
            LoadUsers();
        }
        public static string GetHash(string s)
        {
            long sum = 0;
            for (int i = 0; i < s.Length; i++)
            {
                sum += ((int)s[i]) * ((int)s[i]) * 3 / (i + 1);
            }
            sum *= sum;
            return sum.ToString();
        }
        public void LoadUsers()
        {
            using var context = new Coursa4Context();
            users = context.UserAccounts.ToList();
        }

        private void buttonAuth_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxAuthLogin.Text))
            {
                MessageBox.Show("Логин не может быть пустым!",
                    "Повторите ввод",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                textBoxAuthLogin.Focus();
                return;
            }
            else if (string.IsNullOrWhiteSpace(textBoxPassAuth.Text))
            {
                MessageBox.Show("Пароль не может быть пустым!",
                    "Повторите ввод",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                textBoxPassAuth.Focus();
                return;
            }

            var user = users.FirstOrDefault(u =>
            u.Login == textBoxAuthLogin.Text.Trim() &&
            u.PasswordHash == GetHash(textBoxPassAuth.Text));

            if (user != null)
            {
                MessageBox.Show($"Добро пожаловать, {user.Name}", "Успешный вход",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                Program.CurrentUser.SetUser(user.Id, user.Name);
                this.Hide();
                new MainMenu().Show();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void buttonRegistration_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (var regForm = new Registration())
            {
                if (regForm.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Теперь вы можете войти с вашими данными",
                        "Успешная регистрация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            this.Show();
            LoadUsers();
        }
    }
}
