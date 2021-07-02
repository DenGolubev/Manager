using Manager.Exceptions;
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

namespace Manager
{
    /// <summary>
    /// Логика взаимодействия для AuthUsers.xaml
    /// </summary>
    public partial class AuthUsers : Window
    {
        User auth_user { get; set; }
        ApplicationContext db;
        public AuthUsers()
        {
            InitializeComponent();
        }

        private void Button_Auth_Click(object sender, RoutedEventArgs e)
        {

            string login = textBoxLogin.Text.Trim();
            string pass = passBox.Password.Trim();

            if (!string.IsNullOrEmpty(login) && !string.IsNullOrEmpty(pass))
            {
                try
                {
                    using (db = new ApplicationContext())
                    {
                        if (db.Users.Where(user => user.Login == login && user.Pass == pass).FirstOrDefault() == null) 
                        {
                            throw new ArgumentNullException($"Пользователь с таким логином\n{ login } и паролем {pass}\nв системе не зарегестрирован");
                        }
                        else auth_user = db.Users.Where(user => user.Login == login && user.Pass == pass).FirstOrDefault();
                    }
                }
                catch (ArgumentNullException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            
            if(auth_user != null)
            {
                UserCabinet cabinet = new UserCabinet();
                cabinet.Show();
                Hide();
            }
            else MessageBox.Show($"Авторизация пользователя\n{login} - не прошла");
        }

        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            Hide();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Button_Exit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void textBoxLogin_GotFocus(object sender, RoutedEventArgs e)
        {
            InputLanguageManager.SetInputLanguage(textBoxLogin, new System.Globalization.CultureInfo("en_US"));
        }

        private void passBox_GotFocus(object sender, RoutedEventArgs e)
        {
            InputLanguageManager.SetInputLanguage(passBox, new System.Globalization.CultureInfo("en_US"));
        }
    }
}
