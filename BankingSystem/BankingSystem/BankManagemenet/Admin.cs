using BankingSystem.UserAut;

namespace BankingSystem.BankManagement
{
    internal class Admin : User
    {
        public Admin(string Login, string Password, string Id, string Bank) : base(Login, Password, Id, Bank)
        {
        }

        public void AddOperatore(string Login, string Password, string Bank) 
        {
            Operator oper = new(Login, Password, "", Bank);
            oper.CreateId("op");
            oper.Send("Management", oper.Login);
        }
        public void AddManager(string Login, string Password, string Bank) 
        {
            Manager man = new(Login, Password, "", Bank);
            man.CreateId("mn");
            man.Send("Management", man.Login);
        }
    }
}
