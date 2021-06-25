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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Manager
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ApplicationContext db;
        public MainWindow()
        {
            InitializeComponent();
           
        }

        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {
            string login = textBoxLogin.Text.Trim();
            string pass = passBox.Password.Trim();
            string pass_reply = passBox_reply.Password.Trim();
            string email = textBoxEmail.Text.Trim().ToLower();
            User new_user = new User(login, pass, email);
            if (new_user.Login != null && new_user.Pass != null && new_user.Email != null) 
            {
                if (pass.Equals(pass_reply))
                {
                    try
                    {
                        using (db = new ApplicationContext())
                        {
                            db.Users.Add(new_user);
                            db.SaveChanges();
                            MessageBox.Show($"Пользователь\n{new_user.Login}\n- успешно зарегистрирован");
                            textBoxLogin.Clear();
                            passBox.Clear();
                            passBox_reply.Clear();
                            textBoxEmail.Clear();
                            textBoxLogin.Focus();
                        }
                        
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else MessageBox.Show($"Пароли:\n{pass}\n{pass_reply}\nне совпадают");



            }
            else MessageBox.Show($"Регистрация пользователя\n{new_user}\n- не прошла");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            textBoxLogin.Focus();
        }
    }
}
