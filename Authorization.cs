using coursa4.Testrer;

namespace coursa4
{
    public partial class Authorization : Form
    {
        public Authorization()
        {
            InitializeComponent();
        }

        private void buttonAuth_Click(object sender, EventArgs e)
        {
            try
            {
                DBTester.TestDatabase();
                MessageBox.Show("Тестирование завершено! Проверьте консоль для результатов.", "Тест БД",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при тестировании БД: {ex.Message}", "Ошибка",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
