using BankingSystem.Loading;
using BankingSystem.BankManagement;

namespace BankingSystem.UserAut
{
    internal class UserPresenter
    {
        readonly IUser? UserView;

        public UserPresenter(IUser view)
        {
            if (view.Bank != null && !string.IsNullOrEmpty(view.LoginText) && !string.IsNullOrEmpty(view.PasswordText) && view.Member != null)
            {
                UserView = view;
            }
            else
            {
                UserView = null;
            }
        }

        public string FindUser()
        {
            if (UserView != null)
            {
                try
                {
                    User user = new(UserView.LoginText, UserView.PasswordText, "", UserView.Bank);
                    return user.Find(UserView.Member);
                }
                catch { return null; }
            }
            else
            {
                MessageBox.Show("Введите данные");
                return null;
            }
        }
        public void AddAdmin()
        {
            Admin admin = new(UserView.LoginText, UserView.PasswordText, "", UserView.Bank);
            admin.CreateId("adm");
            admin.Send($"Management", admin.Login);
        }
    }

}
