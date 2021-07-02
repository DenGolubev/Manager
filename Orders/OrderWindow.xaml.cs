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
        public OrderWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            textBoxName.Text = UserCabinet.SelectedCustomer.Name;
            textBoxTelefon.Text = UserCabinet.SelectedCustomer.Tel;
            textBox_Email.Text = UserCabinet.SelectedCustomer.Email;
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
    }
}
