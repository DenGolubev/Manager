using Manager.Сustomers;
using System.Collections.Generic;
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

        private void Window_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
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
    }
}
