using Manager.Checking;

namespace Manager
{
    public class Customer:CheckNames
    {
        public int id { get; set; }
        private string name;
        private string tel;
        private string email;
        public string Name { get { return name; } set { name = value; } }
        public string Tel { get { return tel; } set { tel = value; } }
        public string Email { get { return email; } set { email = value; } }

        public Customer() { }

        public Customer(string name, string tel, string email)
        {
            this.name = CreateName(name);
            this.tel = CreateTel(tel);
            this.email = CreateEmail(email);

        }

        public override string ToString()
        {
            return $"Логин {Name}\nТелефон {Tel}\nПочта {Email}";
        }
    }
}
