using System;
using System.Collections.Generic;
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
    public partial class OrderWindow : Window
    {
        Order order;

        public OrderWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            textBoxName.Text = UserCabinet.SelectedCustomer.Name;
            textBoxTelefon.Text = UserCabinet.SelectedCustomer.Tel;
            textBox_Email.Text = UserCabinet.SelectedCustomer.Email;
            textBoxCustomerID.Text = Convert.ToString(get_Customer_id(textBoxName.Text, textBoxTelefon.Text, textBox_Email.Text));
        }
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void textBox_Email_GotFocus(object sender, RoutedEventArgs e)
        {
            InputLanguageManager.SetInputLanguage(textBox_Email, new System.Globalization.CultureInfo("en_US"));
        }

        private void textBoxComment_GotFocus(object sender, RoutedEventArgs e)
        {
            InputLanguageManager.SetInputLanguage(textBox_Email, new System.Globalization.CultureInfo("ru-RU"));
        }

        private void buttonExit_Click(object sender, RoutedEventArgs e)
        {
            UserCabinet cabinet = new UserCabinet();
            cabinet.Show();
            Hide();
        }

        private int get_Customer_id(string name, string tel, string email) 
        {
            using (var db = new ApplicationContext())
            {
                Customer customer = db.Customers.Where(cust => cust.Name == name && cust.Tel == tel && cust.Email == email).FirstOrDefault();

                return customer.id;
            }
        }

        private string Communication_Method_by_id(int id)
        {
            using (var db = new ApplicationContext())
            {
                Customer customer = db.Customers.Where(cust => cust.id == id).FirstOrDefault();
                return customer.CommunicationMethod;
            }
            
        }

        private void buttonSetOrder_Click(object sender, RoutedEventArgs e)
        {
            bool status = false;
            //if (radioBattonNotReady.IsChecked == true) status = false;
            //else if (radioBattonReady.IsChecked == true) status = true;

            DateTime date_out = (DateTime)datePickerOut.SelectedDate;
            string order_composition = textBoxComment.Text;
            string delivery_method = comboboxDelivery.Text;
            string communication_method = Communication_Method_by_id(Convert.ToInt32(textBoxCustomerID.Text));
            double order_amount = Convert.ToDouble(textBoxOrderCost.Text);
            double delivery_amount = Convert.ToDouble(textBoxDeliveryCost.Text);
            double prepayment = Convert.ToDouble(textBoxPrepay.Text);
            string celebration = comboboCelebration.Text;
            DateTime date_in = (DateTime)datePickerIn.SelectedDate;
            int customer_id = Convert.ToInt32(textBoxCustomerID.Text);
            order = new Order(status, date_out, order_composition, delivery_method, communication_method, order_amount, delivery_amount, prepayment, celebration, date_in, customer_id);

            using (var db = new ApplicationContext())
            {
                db.Orders.Add(order);
                db.SaveChanges();
            }
        }
    }
}
