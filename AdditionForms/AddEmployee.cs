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
    public partial class AddEmployee : Form
    {
        public AddEmployee()
        {
            InitializeComponent();
        }

        private void buttonAddEmployee_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxEmloyeeLN.Text) || string.IsNullOrWhiteSpace(textBoxEmployeeFN.Text) || string.IsNullOrWhiteSpace(textBox2.Text)) {
                MessageBox.Show("Заполните обязательные поля: Имя, Фамилия, Специализация");
                return;
            }

            try 
            {
                using var context = new Coursa4Context();
                var employee = new Employee()
                {
                    FirstName = textBoxEmployeeFN.Text,
                    LastName = textBoxEmloyeeLN.Text,
                    Specialization = textBox2.Text,
                };

                context.Employees.Add(employee);
                context.SaveChanges();
                MessageBox.Show("Сотрудник успешно добавлен!");
            }
            catch(Exception ex) 
            {
                MessageBox.Show($"Ошибка при добавлении сотрудника: {ex.Message}");
            }
        }
    }
}
