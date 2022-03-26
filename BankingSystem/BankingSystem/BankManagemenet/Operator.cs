using BankingSystem.UserAut;

namespace BankingSystem.BankManagement
{
    internal class Operator : User
    {
        public Operator(string Login, string Password, string Id, string Bank) : base(Login, Password, Id, Bank)
        {
        }
    }
}
