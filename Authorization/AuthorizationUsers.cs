using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Manager.Authorization
{
    class AuthorizationUsers: User
    {
        public bool StatusUser { get;}

        ApplicationContext db;

        public AuthorizationUsers() { }

        public AuthorizationUsers(string login, string pass) :
            base(login, pass)
        {
            StatusUser = AuthorizationUser(login, pass);
        }
        
        private bool AuthorizationUser(string login, string pass)
        {
            using (db = new ApplicationContext())
            {
                if (db.Users.Where(user => user.Login == login && user.Pass == pass).FirstOrDefault() == null)
                {
                    MessageBox.Show($"Пользователь с таким логином\n{ login } и паролем {pass}\nв системе не зарегестрирован");
                    return false;
                }
                else return true;
            }
        }
    }
}
