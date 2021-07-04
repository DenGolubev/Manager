using Manager.Authorization;
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
using System.Globalization;

namespace Manager
{
    /// <summary>
    /// Логика взаимодействия для AuthUsers.xaml
    /// </summary>
    public partial class AuthUsers : Window
    {
        User auth_user { get; set; }
        AuthUser user;
        public AuthUsers()
        {
            InitializeComponent();
        }

        
        private void buttonAuthorization_Click(object sender, RoutedEventArgs e)
        {
            user = new AuthUser(textBoxLogin.Text, passBox.Password);
            auth_user = user.User;

            if (auth_user != null)
            {
                UserCabinet cabinet = new UserCabinet();
                cabinet.Show();
                Hide();
            }
            else MessageBox.Show($"Авторизация пользователя\n{user} - не прошла");
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
            InputLanguageManager.SetInputLanguage(textBoxLogin, new CultureInfo("en_US"));
        }

        private void passBox_GotFocus(object sender, RoutedEventArgs e)
        {
            InputLanguageManager.SetInputLanguage(passBox, new CultureInfo("en_US"));
        }

        
    }
}
