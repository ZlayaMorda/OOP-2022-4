using BankingSystem.UserAut;

namespace BankingSystem.BankManagement
{
    internal class Operator : User
    {
        public string EmplBank { get; set; }
        public Operator(string Login, string Password, string Id, string EmplBank) : base(Login, Password, Id)
        {
            this.EmplBank = EmplBank;
        }
    }
}
