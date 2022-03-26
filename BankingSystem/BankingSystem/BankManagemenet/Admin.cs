using BankingSystem.UserAut;

namespace BankingSystem.BankManagement
{
    internal class Admin : User
    {
        public string AdminBank;
        public Admin(string Login, string Password, string Id, string AdminBank) : base(Login, Password, Id)
        {
            this.AdminBank = AdminBank;
        }

        public void AddOperatore(Operator oper) 
        { 
                    
        }
        public void AddManager() { }
    }
}
