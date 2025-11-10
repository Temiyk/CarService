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
                if (changePasswordForm.ShowDialog() == DialogResult.OK) { 
                    
                }


                this.Show();
            }
        }
    }
}
