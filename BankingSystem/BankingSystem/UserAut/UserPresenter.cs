using BankingSystem.Loading;

namespace UserAut
{
    public class UserPresenter
    {
        readonly IUser? UserView;
        readonly string CurrentPath = Directory.GetCurrentDirectory().ToString();

        public UserPresenter(IUser view)
        {
            if (view.Bank != null && !string.IsNullOrEmpty(view.LoginText) && !string.IsNullOrEmpty(view.PasswordText))
            {
                UserView = view;
            }
            else
            {
                UserView = null;
            }
        }

        public void FindUser()
        {
            if (UserView != null)
            {
                try
                {
                    Load<string, User> Load = new($"{CurrentPath}/{UserView.Bank}/{UserView.Bank}UsersData");
                    Load.LoadFromFile();
                    if (Load.Users.ContainsKey(UserView.LoginText))
                    {
                        User temp;
                        Load.Users.TryGetValue(UserView.LoginText, out temp);
                        UserView.Message = $"Welcome {temp.Id}, your bank {UserView.Bank}";
                    }
                    else
                    {
                        UserView.Message = "There are no users with this login or password";
                    }
                }
                catch (NullReferenceException) { UserView.Message = "Пожалуйста, заполните все поля"; }
            }
            else
            {
                MessageBox.Show("Введите данные");
            }
        }

        public void AddUser()
        {
            if (UserView != null)
            {
                try
                {
                    Load<string, User> Load = new($"{CurrentPath}/{UserView.Bank}/{UserView.Bank}UsersData");
                    Load.LoadFromFile();
                    Load.Users.Add(UserView.LoginText, new User(UserView.LoginText, UserView.PasswordText, "17467182"));
                    Load.LoadToFile();
                }
                catch (NullReferenceException) { UserView.Message = "Пожалуйста, заполните все поля"; }
            }
            else
            {
                MessageBox.Show("Введите данные");
            }
        }
    }

}
