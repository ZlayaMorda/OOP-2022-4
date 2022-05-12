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

        internal Login.Form1 Form1
        {
            get => default;
            set
            {
            }
        }

        internal User User
        {
            get => default;
            set
            {
            }
        }

        internal Load<object, object> Load
        {
            get => default;
            set
            {
            }
        }

        public string? FindUser()
        {
            if (UserView != null)
            {
                try
                {
                    User user = new(UserView.LoginText, UserView.PasswordText, "", UserView.Bank);
                    string tempId = user.Find(UserView.Member);
                    if(tempId == null) { UserView.Message = "Такого пользователя не существует"; }
                    return tempId;
                }
                catch { return null; }
            }
            else
            {
                MessageBox.Show("Введите данные");
                return null;
            }
        }
        public void AddManager(string WhichOne, Logs logs)
        {
            try
            {
                User admin = new(UserView.LoginText, UserView.PasswordText, "", UserView.Bank);
                admin.CreateId(WhichOne);
                admin.Send($"Management", admin.Login);
                UserView.Message = $"{WhichOne} добавлен";
                logs.AddUserReg(admin.Id, WhichOne, true);
            }
            catch (NullReferenceException){ MessageBox.Show("Введите данные"); }
            catch (System.ArgumentException) { UserView.Message = $"{WhichOne} существует"; }
        }
        public void OpenForm(string? id)
        {
            if (id != null)
            {
                string substr = id.Substring(0, 4);
                if (substr != "3333")
                {
                    FormManagement.FormManagement f = new(UserView.Bank, substr);
                    f.ShowDialog();
                }
                else
                {
                    FormClient.FormClient f = new(UserView.Bank, id);
                    f.ShowDialog();
                }
            }
        }
    }

}
