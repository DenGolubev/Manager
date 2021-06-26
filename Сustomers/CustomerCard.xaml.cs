using System;
using System.Windows;

namespace Manager.Сustomers
{
    /// <summary>
    /// Логика взаимодействия для CustomerCard.xaml
    /// </summary>
    public partial class CustomerCard : Window
    {
        ApplicationContext db;
        public CustomerCard()
        {
            InitializeComponent();
        }

        private void Button_Reg_Cust_Click(object sender, RoutedEventArgs e)
        {
            string name = textBoxName.Text.Trim();
            string tel = textBoxTel.Text.Trim();
            string email = textBoxEmail.Text.Trim().ToLower();
            Customer new_customer = new Customer(name, tel, email);
            if (new_customer.Name != null && new_customer.Tel != null && new_customer.Email != null)
            {
                try
                {
                    using (db = new ApplicationContext())
                    {
                        db.Customers.Add(new_customer);
                        db.SaveChanges();
                        MessageBox.Show($"Пользователь\n{new_customer.Name}\n- успешно зарегистрирован");
                        textBoxName.Clear();
                        textBoxTel.Clear();
                        textBoxEmail.Clear();
                        textBoxName.Focus();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            else MessageBox.Show($"Регистрация пользователя\n{new_customer}\n- не прошла");
        }
    }
}
