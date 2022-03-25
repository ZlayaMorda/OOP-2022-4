using System.Text.RegularExpressions;
using BankingSystem.Loading;
using BankingSystem.UserAut;

namespace BankingSystem.AboutClient
{
    public class ClientPresenter
    {
        readonly IClient? ClientView;
        readonly string CurrentPath = Directory.GetCurrentDirectory().ToString() + @"\..\..\..";

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
        public bool SendToApprove()
        {
            if (ClientView != null)
            {
                try
                {
                    string str = "";
                    Client ClientToAdd = new(ClientView.Surname, ClientView.Name, ClientView.PName, ClientView.PhoneNumber,
                        ClientView.LoginText, ClientView.Bank, ClientView.PasportNum, str);
                    ClientToAdd.CreateId();
                    Send("ClientsDataToRegistr", ClientToAdd, ClientToAdd.Id);
                    MessageBox.Show(ClientToAdd.Id);
                    User UserToAdd = new(ClientView.LoginText, ClientView.PasswordText, ClientToAdd.Id);
                    Send("UsersDataToRegistr", UserToAdd, UserToAdd.Login);
                    ClientView.Message = "Ваша форма отправлена";
                    return true;
                }
                catch { return false; }
            }
            else
            {
                MessageBox.Show("Введите верно данные");
                return false;
            }
        }
        private void Send<T>(string path, T temp, string key)
        {
            Load<string, T> Load = new($"{CurrentPath}/{ClientView.Bank}/{ClientView.Bank}{path}");
            Load.LoadFromFile();
            string ides = "";
            foreach (var t in Load.Information)
            {
                ides += t.Key + "\n";
            }
            MessageBox.Show(ides);
            Load.Information.Add(key, temp);
            Load.LoadToFile();
        }
    }
}
