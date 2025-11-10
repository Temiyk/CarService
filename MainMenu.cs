using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace coursa4
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
            labelWelcome.Text = $"Добро пожаловать, {Program.CurrentUser.Name}";
        }

        private void buttonClients_Click(object sender, EventArgs e)
        {

        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {

        }

        private void buttonVehicles_Click(object sender, EventArgs e)
        {

        }

        private void buttonOrders_Click(object sender, EventArgs e)
        {

        }

        private void buttonEmployees_Click(object sender, EventArgs e)
        {

        }

        private void buttonServices_Click(object sender, EventArgs e)
        {

        }

        private void buttonReports_Click(object sender, EventArgs e)
        {

        }

        private void buttonChangePassword_Click(object sender, EventArgs e)
        {
            using var changePasswordForm = new ChangePassword();
            {
                this.Hide();
                if (changePasswordForm.ShowDialog() == DialogResult.OK)
                {

                }
                this.Show();
            }
        }

        private void timerDateTime_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            labelDate.Text = $"Дата: {dt.ToString().Substring(0, 10)}";
            labelTime.Text = $"Время: {dt.ToString().Substring(11)}";
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Вы уверены, что хотите выйти?", "Подтвердите выход", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes) { 
                Application.Exit();
            }
        }
    }
}
