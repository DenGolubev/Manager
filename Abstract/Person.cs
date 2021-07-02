using Manager.Checking;

namespace Manager.Abstract
{
    public abstract class Person
    {
        public string Login { get; set; }
        public string Pass { get; set; }
        public string Email { get; set; }
        public string Tel { get; set; }
        public string CommunicationMethod { get; set; }
        public string Comments { get; set; }

        public Person(string login, string pass, string email)
        {
            Login = CheckNames.CreateName(login);
            Pass = CheckNames.CreatePass(pass);
            Email = CheckNames.CreateEmail(email);
        }

        public Person(string login, string tel, string email, string communication_method = null, string comments = null)
        {
            Login = CheckNames.CreateName(login);
            Tel = CheckNames.CreateTel(tel);
            Email = CheckNames.CreateEmail(email);
            CommunicationMethod = communication_method;
            Comments = comments;
        }

    }
}
