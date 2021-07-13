using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Manager.Orders
{
    /// <summary>
    /// Логика взаимодействия для OrderWindow.xaml
    /// </summary>
    public partial class OrderCustumer : Window
    {
        Order order;
        ApplicationContext db;

        public OrderCustumer()
        {
            InitializeComponent();
        }
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
        private int get_Customer_id(string name, string tel, string email)
        {
            using (db = new ApplicationContext())
            {
                Customer customer = db.Customers.Where(cust => cust.Name == name && cust.Tel == tel && cust.Email == email).FirstOrDefault();

                return customer.id;
            }
        }
        private string Communication_Method_by_id(int id)
        {
            using (db = new ApplicationContext())
            {
                Customer customer = db.Customers.Where(cust => cust.id == id).FirstOrDefault();
                return customer.CommunicationMethod;
            }

        }
        private void buttonExit_Click(object sender, RoutedEventArgs e)
        {
            using (db = new ApplicationContext())
            {
                int customer_id = Convert.ToInt32(textBoxCustomerID.Text);
                Order info = db.Orders.Where(t => t.CustomerId == customer_id).FirstOrDefault(); 
                OrdersList ordersList = new OrdersList();
                ordersList.Show();
                db.Orders.Where(t => t.CustomerId == customer_id).Load();
                ordersList.gridOrders.ItemsSource = db.Orders.Local.ToBindingList();
                Hide();
            }
           
        }

        private void buttonSaveOrder_Click(object sender, RoutedEventArgs e)
        {
            DateTime date_out = (DateTime)datePickerOut.SelectedDate;
            string order_composition = textBoxComment.Text;
            string delivery_method = comboboxDelivery.Text;
            string communication_method = Communication_Method_by_id(Convert.ToInt32(textBoxCustomerID.Text));
            double order_amount = Convert.ToDouble(textBoxOrderCost.Text);
            double delivery_amount = Convert.ToDouble(textBoxDeliveryCost.Text);
            double prepayment = Convert.ToDouble(textBoxPrepay.Text);
            double cake_price = Convert.ToDouble(textBoxCakePrice.Text);
            double total_price = Convert.ToDouble(textBoxTotalPrice.Text);
            string celebration = comboboCelebration.Text;
            DateTime date_in = (DateTime)datePickerIn.SelectedDate;
            int customer_id = Convert.ToInt32(textBoxCustomerID.Text);
            order = new Order(date_out, order_composition, delivery_method, communication_method, order_amount, delivery_amount, prepayment, cake_price, total_price, celebration, date_in, customer_id);
            using (var db = new ApplicationContext())
            {
                db.Orders.Add(order);
                db.SaveChanges();
                MessageBox.Show($"Заказ\n{order.id}\n- успешно зарегистрирован");
                UserCabinet userCabinet = new UserCabinet();
                userCabinet.Show();
                Hide();
            }
        }
        
    }
}
