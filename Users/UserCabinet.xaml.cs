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
                OrderCustumer orderCustumer = new OrderCustumer();
                orderCustumer.textBoxName.Text = customer.Name;
                orderCustumer.textBoxTelefon.Text = customer.Tel;
                orderCustumer.textBox_Email.Text = customer.Email;
                orderCustumer.textBoxCustomerID.Text = Convert.ToString(customer.id);
                orderCustumer.Show();
                Hide();
            }
                
        }

        private void buttonOrderCard_Click(object sender, RoutedEventArgs e)
        {
            using (db = new ApplicationContext())
            {
                if (gridCustomers.SelectedItems.Count > 0)
                {
                    for (int i = 0; i < gridCustomers.SelectedItems.Count; i++)
                    {
                        Customer customer = gridCustomers.SelectedItems[i] as Customer;
                        Order info = db.Orders.Where(t => t.CustomerId == customer.id).FirstOrDefault();
                        if (info != null)
                        {
                            OrdersList ordersList = new OrdersList();
                            ordersList.Show();
                            db.Orders.Where(t => t.CustomerId == customer.id).Load();
                            ordersList.gridOrders.ItemsSource = db.Orders.Local.ToBindingList();
                            Hide();
                        }
                        else MessageBox.Show("Заказов не найдено");
                    }
                }
                else MessageBox.Show("Не выбран покупатель");
            }
        }

        private void buttonAllOrderCard_Click(object sender, RoutedEventArgs e)
        {
            using (db = new ApplicationContext())
            {
                OrdersList ordersList = new OrdersList();
                ordersList.Show();
                db.Orders.Load();
                ordersList.gridOrders.ItemsSource = db.Orders.Local.ToBindingList();
                Hide();
            }
             
        }
    }
}
