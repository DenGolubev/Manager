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
        List<User> users = null;
        public UserCabinet()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (db = new ApplicationContext())
            {
                users = db.Users.ToList();
            }


        }
    }
}
