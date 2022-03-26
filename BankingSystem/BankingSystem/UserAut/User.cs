using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BankingSystem.UserAut
{
    internal class User
    {
        public string? Login { get; }
        public string? Password { get; }
        public string Id { get; set; }

        public User(string Login, string Password, string Id)
        {
            this.Login = Login;
            this.Password = Password;
            this.Id = Id;
        }

        public void CreateId(string user)
        {
            switch(user)
            {
                case "cl":
                    {
                        IdCase("1111");
                        break;
                    }
                case "op":
                    {
                        IdCase("2222");
                        break;
                    }
                case "man":
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


    }
}
