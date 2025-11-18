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
using System.Configuration;

namespace coursa4.UserControls
{
    public partial class OrdersControl : BaseListControl
    {
        private List<Order> orders;
        public OrdersControl()
        {
            InitializeComponent();
            LoadData();
        }
        protected override void buttonAdd_Click(object sender, EventArgs e)
        {
            var addOrderForm = new AddOrder();
            if (addOrderForm.ShowDialog() == DialogResult.OK)
            {
                LoadData();
                SearchFilter.ClearSearch();
                return;
            }
        }
        protected override void buttonEdit_Click(object sender, EventArgs e)
        {
            if (DataGridView.SelectedRows.Count > 0)
            {

                try
                {
                    //var orderId =
                    //
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при открытии формы редактирования: {ex.Message}", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else {
                MessageBox.Show("Выберите заказ для редактирования", "Информация",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        protected override void buttonUpdate_Click(object sender, EventArgs e)
        {
            LoadData();
            SearchFilter.ResetAll();
        }
        protected override void buttonDelete_Click(object sender, EventArgs e)
        {
            if (DataGridView.SelectedRows.Count > 0)
            {
                try
                {
                    var result = MessageBox.Show($"Вы уверены, что хотите удалить данный заказ?",
                    "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes) {
                        
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при открытии формы удаления: {ex.Message}", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Выберите заказ для редактирования", "Информация",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public override void LoadData()
        {
            try 
            {
                using var context = new Coursa4Context();
            }
            catch(Exception ex) {
                MessageBox.Show($"Ошибка при загрузке заказов: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            // дописываем orders = context.Orders; 
        }
    }
}
