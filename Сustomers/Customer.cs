using Manager.Checking;

namespace Manager
{
    public class Customer:CheckNames
    {
        public int id { get; set; }
        private string name;
        private string tel;
        private string email;
        private string communication_method;
        private string comments;
        public string Name { get { return name; } set { name = value; } }
        public string Tel { get { return tel; } set { tel = value; } }
        public string Email { get { return email; } set { email = value; } }
        public string CommunicationMethod { get {return communication_method; } set { communication_method = value; } }
        public string Comments { get { return comments; } set { comments = value; } }

        public Customer() { }
        public Customer(string name, string tel, string email = null, string communication_method = null, string comments = null)
        {
            this.name = CreateName(name);
            this.tel = CreateTel(tel);
            this.email = CreateEmail(email);
            this.communication_method = communication_method;
            this.comments = comments;
        }

        public override string ToString()
        {
            return $"Логин {Name}\nТелефон {Tel}\nПочта {Email}\nСпособ связи{CommunicationMethod}\nКомментарии{Comments}";
        }
    }
}
