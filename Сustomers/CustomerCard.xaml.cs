using System;
using System.Windows;
using System.Linq;
using Manager.Exceptions;
using System.Windows.Controls;
using Manager.Collections;
using System.Windows.Input;

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
            string communication = comboCommunication.Text.Trim();
            string comments = textBoxComment.Text.Trim();
            Customer new_customer = new Customer(name, tel, email, communication, comments);
            if (new_customer.Name != null && new_customer.Tel != null && new_customer.Email != null)
            {
                using (db = new ApplicationContext())
                {
                    try
                    {
                        if (db.Customers.FirstOrDefault(customer => customer.Tel == tel) == null)
                        {
                            db.Customers.Add(new_customer);
                            db.SaveChanges();
                            MessageBox.Show($"Клиент\n{new_customer.Name}\n- успешно зарегистрирован");
                        }
                        else throw new MyRegistertNameException($"Клиент\n{ new_customer.Name }\nс данным номера телефона {new_customer.Tel} - уже зарегистрирован в системе");
                    }
                    catch (MyRegistertNameException ex) 
                    {
                        Console.WriteLine(ex.Message);
                    }
                    
                    textBoxName.Clear();
                    textBoxTel.Clear();
                    textBoxEmail.Clear();
                    textBoxComment.Clear();
                    textBoxName.Focus();
                }
            }
            else MessageBox.Show($"Регистрация пользователя\n{new_customer}\n- не прошла");
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            UserCabinet userCabinet = new UserCabinet();
            userCabinet.Show();
            Hide();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void textBoxName_GotFocus(object sender, RoutedEventArgs e)
        {
            InputLanguageManager.SetInputLanguage(textBoxName, new System.Globalization.CultureInfo("en_US"));
        }

        private void textBoxEmail_GotFocus(object sender, RoutedEventArgs e)
        {
            InputLanguageManager.SetInputLanguage(textBoxEmail, new System.Globalization.CultureInfo("en_US"));
        }

        private void textBoxComment_GotFocus(object sender, RoutedEventArgs e)
        {
            InputLanguageManager.SetInputLanguage(textBoxComment, new System.Globalization.CultureInfo("ru-RU"));
        }
    }
}
