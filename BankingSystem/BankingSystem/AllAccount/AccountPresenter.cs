using BankingSystem.Loading;
using BankingSystem.AboutClient;

namespace BankingSystem.AllAccount
{
    internal class AccountPresenter
    {
        readonly public Dictionary<string, Account> accounts = new();

        public static void Send(Account acc, string Bank)
        {
            Load<string, Account> load = new(Bank, "AccountsToRegistr");
            load.LoadFromFile();
            int num = Int32.Parse(acc.Id.Substring(36,4));
            while(load.Information.ContainsKey(acc.Id))
            {
                num++;
                acc.CreateId(acc.Id.Substring(0, 36), num, acc.Id[40].ToString());
            }

            load.Information.Add(acc.Id, acc);
            load.LoadToFile();
        }

        public void GetFromFile(string Bank)
        {
            Load<string, Account> load = new(Bank, "AccountsToRegistr");
            load.LoadFromFile();
            foreach(var key in load.Information.Keys)
            {
                this.accounts.Add(key, load.Information[key]);
            }
        }
        public void RemoveAccount(string Bank, string id)
        {
            accounts.Remove(id);
            Load<string, Account> load = new(Bank, "AccountsToRegistr");
            load.LoadFromFile();
            load.Information.Remove(id);
            load.LoadToFile();
        }
        public void Add(string Bank, string id)
        {
            Logs logs = new(Bank);
            Load<string, Client> load = new(Bank, "ClientsData");
            load.LoadFromFile();
            if(load.Information.ContainsKey(id.Substring(0,36)))
            {
                load.Information[id.Substring(0, 36)].AddAccount(accounts[id]);
                load.LoadToFile();
                logs.AddLogModif(id, "создан");
            }
            RemoveAccount(Bank, id);
        }

        public string GetAccount(string id)
        {
            return accounts[id].Id + "Валюта: " + accounts[id].Currency;
        }
    }
}
