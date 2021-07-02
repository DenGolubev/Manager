using Manager.Orders;
using Manager.Сustomers;
using System;
using System.Windows.Input;
using System.Windows.Controls;
using System.Linq;
using System.Windows;

namespace Manager
{
    /// <summary>
    /// Логика взаимодействия для UserCabinet.xaml
    /// </summary>
    public partial class UserCabinet : Window
    {
        ApplicationContext db;
        public static Customer SelectedCustomer { get; private set; }

        public UserCabinet()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            new UserCabinet();
            CustomersList_Loaded();
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

        private void CustomersList_Loaded()
        {
            using (db = new ApplicationContext())
            {
                CustomersList.ItemsSource = db.Customers.ToList();
            }
        }

        private void CustomersList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            OrderWindow orderWindow = new OrderWindow();
            var selected_customer = (Customer)CustomersList.SelectedItem;
            if (selected_customer != null)
            {
                SelectedCustomer = selected_customer;
                orderWindow.Show();
                Hide();
            }
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
    }
}
