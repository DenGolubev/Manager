using Manager.Checking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Manager.Models
{
    abstract class Person: CheckNames
    {
        private string login;
        private string pass;
        private string email;
        private string tel;
        public string Login => login;
        public string Email => email;
        public string Tel => tel;
        public string Pass => pass;

        public Person(string login, string email, string tel)
        {
            this.login = CreateName(login);
            pass = GeneratePass(login, email, tel);
            this.email = CreateEmail(email);
            this.tel = CreateTel(tel);

        }

        public string GeneratePass(string name, string email, string tel)
        {
            string str = name+email+tel;
            var rnd = new Random();
            string pass = null;
            for (int i = 0; i < pass.Length; i++)
            {
                pass += str[rnd.Next(str.Length)];
            }

            if(CreatePass(pass) != null) return pass;
            else
            {
                MessageBox.Show($"Пароль {pass}\nне достаточно сложен");
                return null;
            }
        }

    }
}
