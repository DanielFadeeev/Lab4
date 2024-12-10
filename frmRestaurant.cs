using System.Windows.Forms;

namespace Lab4
{
    public partial class frmRestaurant : Form
    {
        public frmRestaurant()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, System.EventArgs e)
        {
            if (lstMenu.SelectedItem != null) // Проверяем, что выбрано блюдо
            {
                lstZakaz.Items.Add(lstMenu.SelectedItem.ToString()); // Добавляем в заказ
            }
            else
            {
                MessageBox.Show("Выберите блюдо из меню!", "Ошибка");
            }
        }

        private void btnRemove_Click(object sender, System.EventArgs e)
        {
            if (lstZakaz.SelectedItem != null)
            {
                lstZakaz.Items.Remove(lstZakaz.SelectedItem);
            }
            else
            {
                MessageBox.Show("Выберите блюдо для удаления из заказа!", "Ошибка");
            }
        }

        private void btnOk_Click(object sender, System.EventArgs e)
        {
            if (lstZakaz.Items.Count > 0)
            {
                double total = 0;

                foreach (string item in lstZakaz.Items)
                {
                    string[] parts = item.Split('-'); // Разделяем строку (название - цена)
                    if (parts.Length > 1 && double.TryParse(parts[1], out double price))
                    {
                        total += price;
                    }
                }

                MessageBox.Show($"Приятного аппетита! Сумма заказа: {total} руб.", "Ресторан");
                this.Close();
            }
            else
            {
                MessageBox.Show("Ваш заказ пуст!", "Ошибка");
            }
        }

        private void btnAddToMenu_Click(object sender, System.EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtNewDish.Text)) // Проверяем, что текст не пустой
            {
                lstMenu.Items.Add(txtNewDish.Text); // Добавляем новое блюдо в меню
                txtNewDish.Clear(); // Очищаем поле ввода
            }
            else
            {
                MessageBox.Show("Введите название блюда!", "Ошибка");
            }
        }

        private void btnClearOrder_Click(object sender, System.EventArgs e)
        {
            lstZakaz.Items.Clear();
        }
    }
}
