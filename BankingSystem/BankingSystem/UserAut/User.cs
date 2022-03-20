using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem
{
    public class User
    {
        public string? Login { get; }
        public string? Password { get; }
        public string? ID { get; }

        public User(string login, string password, string num)
        {
            Login = login;
            Password = password;
            ID = num;
        }
    }
}
