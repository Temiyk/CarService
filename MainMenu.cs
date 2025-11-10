using coursa4.UserControls;
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
        private ClientsControl clientsControl;
        private UserControl currentControl;
        public MainMenu()
        {
            InitializeComponent();
            labelWelcome.Text = $"Добро пожаловать, {Program.CurrentUser.Name}";
            InitializeControls();
        }
        private void InitializeControls()
        {
            clientsControl = new ClientsControl();


            clientsControl.Dock = DockStyle.Fill;

        }
        private void ShowControl(UserControl control, string title)
        {
            try
            {
                if (currentControl != null)
                {
                    panelContent.Controls.Remove(currentControl);
                    currentControl.Visible = false;
                }

                currentControl = control;

                if (!panelContent.Controls.Contains(control))
                {
                    panelContent.Controls.Add(control);
                }

                control.Visible = true;
                control.BringToFront();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при отображении контрола: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonClients_Click(object sender, EventArgs e)
        {
            ShowControl(clientsControl, "MotorbreathMaster - Клиенты");
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            try
            {
                var result = MessageBox.Show("Вы уверены, что хотите выйти из системы?",
                    "Подтверждение выхода", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    Program.CurrentUser.Clear();
                    this.Hide();
                    var authForm = new Authorization();
                    authForm.Closed += (s, args) => this.Close();
                    authForm.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при выходе из системы: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            try
            {
                var changePasswordForm = new ChangePassword();
                changePasswordForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при открытии формы смены пароля: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (result == DialogResult.Yes)
            {
                Program.CurrentUser.Clear();
                Application.Exit();
            }
        }
    }
}
