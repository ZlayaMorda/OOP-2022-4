using System.Text.RegularExpressions;
using BankingSystem.Loading;
using BankingSystem.UserAut;
using System.Configuration;

namespace BankingSystem.AboutClient
{
    internal class ClientPresenter
    {
        readonly IClient? ClientView;

        public ClientPresenter(IClient view)
        {
            if (Check(view.PhoneNumber, @"\+\d{12}") && Check(view.LoginText, "[.\\-_a-z0-9]+@([a-z0-9][\\-a-z0-9]+\\.)+[a-z]{2,6}")
                && !string.IsNullOrEmpty(view.Name) && !string.IsNullOrEmpty(view.Surname) && !string.IsNullOrEmpty(view.PName)
                && !string.IsNullOrEmpty(view.Bank) && !string.IsNullOrEmpty(view.PasswordText)
                && Check(view.PasportNum, @"(AB)|(BM)|(HB)|(KH)|(MP)|(MC)|(KB)|(PP)|(SP)|(DP)\d{7}}"))
            {
                ClientView = view;
            }
            else
            {
                ClientView = null;
            }
        }

        internal Authorization.FormAuthorization FormAuthorization
        {
            get => default;
            set
            {
            }
        }

        internal Client Client
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

        private static bool Check(string input, string reg)
        {
            if (string.IsNullOrEmpty(input)) { return false; }
            Match isMatch = Regex.Match(input, reg, RegexOptions.IgnoreCase);
            if (isMatch != null)
            {
                return true;
            }
            else { return false; }
        }
        public bool IsExist()
        {
            Load<string, User> loadUs = new(ClientView.Bank, "UsersData");
            loadUs.LoadFromFile();
            Load<string, Client> loadCl = new(ClientView.Bank, "ClientsData");
            loadCl.LoadFromFile();
            bool pasportExist = false;
            foreach(var key in loadCl.Information.Keys)
            {
                if(loadCl.Information[key].Pasport == ClientView.PasportNum)
                {
                    pasportExist = true;
                    break;
                }
            }
            if (loadUs.Information.ContainsKey(ClientView.LoginText) || pasportExist)
            {
                return false;
            }
            else { return true; }
        }
        public bool SendToApprove()
        {
            if (ClientView != null)
            {
                if (IsExist())
                {
                    try
                    {
                        User UserToAdd = new(ClientView.LoginText, ClientView.PasswordText, "", ClientView.Bank);
                        UserToAdd.CreateId("Клиент");
                        Client ClientToAdd = new(ClientView.Bank, UserToAdd.Id, ClientView.Surname, ClientView.Name, ClientView.PName, ClientView.PhoneNumber,
                            ClientView.LoginText, ClientView.PasportNum);
                        MessageBox.Show(ClientToAdd.Id);

                        ClientToAdd.Send("ClientsDataToRegistr");
                        UserToAdd.Send("UsersDataToRegistr", UserToAdd.Login);

                        ClientView.Message = "Ваша форма отправлена";
                        return true;
                    }
                    catch { return false; }
                }
                else { MessageBox.Show("Такой пользователь уже существует"); return false; }
            }
            else
            {
                MessageBox.Show("Введите верно данные");
                return false;
            }
        }
    }
}
