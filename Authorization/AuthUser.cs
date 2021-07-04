using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Manager.Authorization
{
    class AuthUser
    {
        private string login;
        private string pass;
        public User User => Authorization(login, pass);

        ApplicationContext db;

        public AuthUser(string login, string pass)
        {
            this.login = login;
            this.pass = pass; 
        }
        private User Authorization(string login, string pass)
        {

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
                        else return db.Users.Where(user => user.Login == login && user.Pass == pass).FirstOrDefault();
                    }
                }
                catch (ArgumentNullException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return null;
        }
        public override string ToString()
        {
            return $"{login}";
        }
    }
}
