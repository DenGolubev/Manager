using Manager.Checking;

namespace Manager
{
    class User: CheckNames
    {
        public int id { get; set; }
        private string login;
        private string pass;
        private string email;
        public string Login { get { return login; } set { login = value; } }
        public string Pass { get { return pass; } set { pass = value; } }
        public string Email { get { return email; } set { email = value; } }
        
        public User() { }
        public User(string login, string pass) 
        {
            this.login = CreateName(login);
            this.pass = CreatePass(pass);
        }

        public User(string login, string pass, string email)
        {
            this.login = CreateName(login);
            this.pass = CreatePass(pass);
            this.email = CreateEmail(email);
            
        }

        public override string ToString()
        {
            return $"Логин {Login}\nПароль 1 {Pass}\nПочта {Email}";
        }
    }
}
