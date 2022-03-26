using BankingSystem.Loading;

namespace BankingSystem.UserAut
{
    internal class User
    {
        public string? Login { get; }
        public string? Password { get; }
        public string Id { get; set; }
        public string Bank { get; set; }

        public User(string Login, string Password, string Id, string Bank)
        {
            this.Login = Login;
            this.Password = Password;
            this.Id = Id;
            this.Bank = Bank;
        }

        public void CreateId(string user)
        {
            switch(user)
            {
                case "adm":
                    {
                        IdCase("0000");
                        break;
                    }
                case "op":
                    {
                        IdCase("1111");
                        break;
                    }
                case "mn":
                    {
                        IdCase("2222");
                        break;
                    }
                case "cl":
                    {
                        IdCase("3333");
                        break;
                    }

            }
        }
        private void IdCase(string userNum)
        {
            this.Id = userNum + Guid.NewGuid().ToString("N");
        }

        public void Send(string fileName, string key)
        {
            Load<string, User> loadCl = new(this.Bank, fileName);
            loadCl.AddToFile(this, key);
        }
        public string? Find(string member)
        {
            if (member == "Клиент")
            {
                return SearchAndReturnId("UsersData");
            }
            else
            {
                return SearchAndReturnId("Management");
            }
        }

        public string? SearchAndReturnId(string fileName)
        {
            Load<string, User> loadCl = new(this.Bank, $"{fileName}");
            loadCl.LoadFromFile();
            if (loadCl.Information.ContainsKey(this.Login))
            {
                loadCl.Information.TryGetValue(this.Login, out User temp);
                if (temp.Password == this.Password)
                {
                    this.Id = temp.Id;
                    return temp.Id;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

    }
}
