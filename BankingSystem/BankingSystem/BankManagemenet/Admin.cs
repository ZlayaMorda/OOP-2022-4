using BankingSystem.UserAut;

namespace BankingSystem.BankManagement
{
    internal class Admin : Manager
    {
        public Admin(string Id, Bank Bank) : base(Id, Bank)
        {
        }
        public override void Add(IUser user)
        {
            try
            {
                UserPresenter presenter = new(user);
                presenter.AddManager(user.Member);
            }
            catch (NullReferenceException) { MessageBox.Show("Заполните все поля"); }
        }
    }
}
