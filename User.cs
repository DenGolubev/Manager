using Manager.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace Manager
{
    class User
    {
        public int id { get; set; }
        private string login;
        private string pass;
        private string email;
        private string login_mask = @"^[A-Za-z]+$";
        private string pass_mask = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[^a-zA-Z0-9])\S{1,16}$";
        private string email_mask = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
        public string Login { get { return login; } set { login = value; } }
        public string Pass { get { return pass; } set { pass = value; } }
        public string Email { get { return email; } set { email = value; } }

        public User() { }

        public User(string login, string pass, string email)
        {
            try
            {
                this.login = CreateName(login); ;
            }
            catch (LoginExeption ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {
                this.pass = CreatePass(pass);
            }
            catch (PassException ex)
            {
                MessageBox.Show(ex.Message);
            }
           
            try
            {
                this.email = CreateEmail(email); ;
            }
            catch (EmailException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private string CreateName(string name)
        {
            if (!Regex.IsMatch(name, login_mask))
            {
                throw new LoginExeption("Вы ввели логин который не соответствует шаблону!");
            }
            return name;
        }

        private string CreatePass(string pass)
        {
            if (!Regex.IsMatch(pass, pass_mask))
            {
                throw new PassException("Вы ввели пароль который не соответствует шаблону!");
            }

            return pass;
        }

        private string CreateEmail(string email)
        {
            if (!Regex.IsMatch(email, email_mask))
            {
                throw new EmailException("Вы ввели email который не соответствует шаблону!");
            }

            return email;
        }

        public override string ToString()
        {
            return $"Логин {Login}\nПароль 1 {Pass}\nПочта {Email}";
        }
    }
}
