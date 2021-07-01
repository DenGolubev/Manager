using Manager.Exceptions;
using System.Text.RegularExpressions;
using System.Windows;

namespace Manager.Checking
{
    public class CheckNames
    {
        private string login_mask = @"[^0-9]+$";
        private string pass_mask = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[^a-zA-Z0-9])\S{1,16}$";
        private string email_mask = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
        private string tel_mask = @"^((8|\+7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}$";

        public string CreateName(string name)
        {
            try
            {
                if (!Regex.IsMatch(name, login_mask)) throw new MyRegistertNameException(name, string.Format($"Вы ввели логин {name} который не соответствует шаблону!"));
            }
            catch(MyRegistertNameException ex)
            {
                MessageBox.Show(ex.Message);
                name = null;
            }
            return name;
        }

        public string CreatePass(string pass)
        {
            try
            {
                if (!Regex.IsMatch(pass, pass_mask)) throw new MyRegistertNameException(pass, string.Format($"Вы ввели пароль {pass} который не соответствует шаблону!"));
            }
            catch(MyRegistertNameException ex)
            {
                MessageBox.Show(ex.Message);
                pass = null;
            }
            return pass;
        }

        public string CreateEmail(string email)
        {
            if(email != null)
            {
                try
                {
                    if (!Regex.IsMatch(email, email_mask)) throw new MyRegistertNameException(email, string.Format($"Вы ввели email {email} который не соответствует шаблону!"));
                }
                catch (MyRegistertNameException ex)
                {
                    MessageBox.Show(ex.Message);
                    email = null;
                }
            }
            else
            {
                MessageBox.Show("Вы не ввели email клиента");
            }
           
            return email;
        }

        public string CreateTel(string tel)
        {
            try
            {
                if (!Regex.IsMatch(tel, tel_mask)) throw new MyRegistertNameException(tel, string.Format($"Вы ввели номер телефона {tel} который не соответствует шаблону!"));
            }
            catch (MyRegistertNameException ex)
            {
                MessageBox.Show(ex.Message);
                tel = null;
            }
            return tel;
        }
    }
}
