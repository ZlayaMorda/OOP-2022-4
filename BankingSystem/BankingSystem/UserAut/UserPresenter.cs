using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserAut
{
    public class UserPresenter
    {
        IUser? UserView;

        public UserPresenter(IUser view)
        {
            this.UserView = view;
        }

        public void FindUser()
        {
            LoadUser<User> Load = new LoadUser<User>("UsersData");
            Load.LoadFromFile();
            try
            {
                if (Load.Users.Count != 0)
                {
                    foreach (User user in Load.Users)
                    {
                        if (user.Login == UserView.LoginText && user.Password == UserView.PasswordText)
                        {
                            UserView.Message = $"Welcome {user.Login}";
                            break;
                        }
                        UserView.Message = "there is no this user with the login or password";
                    }
                }
                else
                {
                    UserView.Message = "there are no users";
                }
            }
            catch (NullReferenceException) { }

        }

        public void AddUser()
        {
            LoadUser<User> Load = new LoadUser<User>("UsersData");
            Load.LoadFromFile();
            Load.Users.Add(new User(UserView.LoginText, UserView.PasswordText, "17467182"));
            Load.LoadToFile();
        }
    }

}
