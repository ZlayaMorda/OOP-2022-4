using BankingSystem.Loading;
using BankingSystem.AllAccount;
using System.Text.Json.Serialization;

namespace BankingSystem.AboutClient
{
    internal class Client
    {
        public Dictionary<string, Account> AccountsDict { get; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string PName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string ClientBank { get; set; }
        public string Id { get; set; }
        public string Pasport { get; set; }

        public Client(string ClientBank, string Id, string Surname = "", string Name = "", string PName = "", 
            string PhoneNumber = "", string Email = "", string Pasport = "", Dictionary<string, Account> ?AccountsDict = null)
        {

            this.Surname = Surname;
            this.Name = Name;
            this.PName = PName;
            this.PhoneNumber = PhoneNumber;
            this.Email = Email;
            this.ClientBank = ClientBank;
            this.Pasport = Pasport;
            this.Id = Id;
            if(AccountsDict != null)
            {
                this.AccountsDict = new();
                CopyAccounts(AccountsDict);
            }
            else
            {
                this.AccountsDict = new();
            }
        }

        public void Send(string fileName)
        {
            Load<string, Client> loadCl = new(this.ClientBank, fileName);
            loadCl.AddToFile(this, this.Id);
        }
        public void LoadToFile(string idAcc)
        {
            Load<string, Client> loadCl = new(this.ClientBank, "ClientsData");
            loadCl.LoadFromFile();
            loadCl.Information[this.Id].AccountsDict[idAcc].State = AccountsDict[idAcc].State;
            loadCl.Information[this.Id].AccountsDict[idAcc].Sum = AccountsDict[idAcc].Sum;
            loadCl.LoadToFile();
        }
        public void LoadClient()
        {
            Load<string, Client> loadCl = new(this.ClientBank, "ClientsData");
            loadCl.LoadFromFile();
            Client temp = loadCl.Information[this.Id];
            try
            {
                if(temp.AccountsDict.Count != 0)
                {
                    CopyAccounts(temp.AccountsDict);
                }
                this.Surname = temp.Surname;
                this.Name = temp.Name;
                this.PName = temp.PName;
                this.PhoneNumber = temp.PhoneNumber;
                this.Email = temp.Email;
                this.ClientBank = temp.ClientBank;
                this.Pasport = temp.Pasport;
                this.Id = temp.Id;
            }
            catch (ArgumentException) { }
        }
        public Account? CreateAccount(string Bank)
        {
            Account temp = new("", "0", true);
            int num = -1;
            for(int i = 0; i < 10000; i++)
            {
                temp.CreateId(this.Id, i, Bank);
                if (AccountsDict.ContainsKey(temp.Id))
                {
                    continue;
                }
                else 
                { 
                    num = i;
                    break;
                }
            }
            if(num != -1)
            {
                return temp;
            }
            else
            {
                MessageBox.Show("Недопустимое количество счетов");
                return null;
            }
            
        }

        public void AddAccount(Account acc)
        {
            AccountsDict.Add(acc.Id, acc);
        }
        public void CopyAccounts(Dictionary<string, Account> temp)
        {
            foreach (var key in temp.Keys)
            {
                this.AccountsDict.Add(key, temp[key]);
            }
        }

        public string GetAccString(string key)
        {
            if (AccountsDict[key].State)
            {
                return "Номер счета: " + this.AccountsDict[key].Id + "  Сумма: " + this.AccountsDict[key].Sum + "   Заморожен: " + "нет";
            }
            else
            {
                return "Номер счета: " + this.AccountsDict[key].Id + "  Сумма: " + this.AccountsDict[key].Sum + "   Заморожен: " + "да";
            }
        }
    }
}
