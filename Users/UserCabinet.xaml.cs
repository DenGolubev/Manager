using Manager.Orders;
using Manager.Сustomers;
using System;
using System.Windows.Input;
using System.Windows.Controls;
using System.Linq;
using System.Windows;
using System.Data.Entity;

namespace Manager
{
    /// <summary>
    /// Логика взаимодействия для UserCabinet.xaml
    /// </summary>
    public partial class UserCabinet : Window
    {
        ApplicationContext db;

        public UserCabinet()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            new UserCabinet();
        }

        private void Button_Add_Customer_Click(object sender, RoutedEventArgs e)
        {
            CustomerCard customerCard = new CustomerCard();
            customerCard.Show();
            Hide();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void buttonExit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void CustomersList_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (e.Delta > 0)
                scroll.LineUp();
            else
                scroll.LineDown();
        }

        private void gridCustomers_Loaded(object sender, RoutedEventArgs e)
        {
            using (db = new ApplicationContext())
            {
                db.Customers.Load();
                gridCustomers.ItemsSource = db.Customers.Local.ToBindingList();
            }
        }

        private void buttonCustomerDelete_Click(object sender, RoutedEventArgs e)
        {
            using (db = new ApplicationContext())
            {
                if (gridCustomers.SelectedItems.Count > 0)
                {
                    for (int i = 0; i < gridCustomers.SelectedItems.Count; i++)
                    {
                        Customer customer = gridCustomers.SelectedItems[i] as Customer;
                        Customer info = db.Customers.Where(t => t.Tel == customer.Tel).FirstOrDefault();
                        if (info != null)
                        {
                            db.Customers.Remove(info);
                        }
                    }
                }
                db.SaveChanges();
                db.Customers.Load();
                gridCustomers.ItemsSource = db.Customers.Local.ToBindingList();
            }
        }

        private void gridCustomers_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Customer customer = null;
            using (db = new ApplicationContext())
            {
                if (gridCustomers.SelectedItems.Count > 0)
                {
                    for (int i = 0; i < gridCustomers.SelectedItems.Count; i++)
                    {
                        customer = gridCustomers.SelectedItems[i] as Customer;
                    }
                }
                OrderWindow orderWindow = new OrderWindow();
                orderWindow.textBoxName.Text = customer.Name;
                orderWindow.textBoxTelefon.Text = customer.Tel;
                orderWindow.textBox_Email.Text = customer.Email;
                orderWindow.textBoxCustomerID.Text = Convert.ToString(customer.id);
                orderWindow.Show();
                Hide();
            }
                
        }
    }
}
