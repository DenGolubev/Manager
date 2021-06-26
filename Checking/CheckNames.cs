using Manager.Exceptions;
using System.Text.RegularExpressions;
using System.Windows;

namespace Manager.Checking
{
    public class CheckNames
    {
        private string login_mask = @"^[A-Za-z]+$";
        private string pass_mask = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[^a-zA-Z0-9])\S{1,16}$";
        private string email_mask = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
        private string tel_mask = @"^((8|\+7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}$";

        public string CreateName(string name)
        {
            try
            {
                if (!Regex.IsMatch(name, login_mask)) throw new LoginExeption("Вы ввели логин который не соответствует шаблону!");
            }
            catch(LoginExeption ex)
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
                if (!Regex.IsMatch(pass, pass_mask)) throw new PassException("Вы ввели пароль который не соответствует шаблону!");
            }
            catch(PassException ex)
            {
                MessageBox.Show(ex.Message);
                pass = null;
            }
            return pass;
        }

        public string CreateEmail(string email)
        {
            try
            {
                if (!Regex.IsMatch(email, email_mask)) throw new EmailException("Вы ввели email который не соответствует шаблону!");
            }
            catch (EmailException ex)
            {
                MessageBox.Show(ex.Message);
                email = null;
            }
            return email;
        }

        public string CreateTel(string tel)
        {
            try
            {
                if (!Regex.IsMatch(tel, tel_mask)) throw new TelException("Вы ввели номер телефона который не соответствует шаблону!");
            }
            catch (EmailException ex)
            {
                MessageBox.Show(ex.Message);
                tel = null;
            }
            return tel;
        }
    }
}
