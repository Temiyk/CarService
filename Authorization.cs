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
        private void LoadUsers() { 
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
            }

            if (string.IsNullOrWhiteSpace(textBoxPassAuth.Text))
            {
                MessageBox.Show("Пароль не может быть пустым!",
                    "Повторите ввод",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            foreach (var user in users) {
                if ((user.Login == (textBoxAuthLogin.Text).ToString().Trim()) && user.PasswordHash == GetHash(textBoxPassAuth.Text))
                {
                    MessageBox.Show("Успешный вход",
                    $"Добро пожаловать, {user.Name}",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                }
                else 
                {
                    MessageBox.Show("Повторите ввод",
                    "Неверный логин или пароль!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }

        }

    }
}
