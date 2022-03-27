using BankingSystem.UserAut;
using BankingSystem.Loading;
using BankingSystem.AboutClient;

namespace BankingSystem.BankManagement
{
    internal class Manager : Operator
    {
        public readonly Dictionary<string, Client> ClientsDict = new();
        private readonly Dictionary<string, User> Users = new();
        public Manager(string Login, string Password, string Id, string Bank) : base(Login, Password, Id, Bank)
        {
        }
        public void GetClientsData()
        {
            CopyAll<string, Client>(ClientsDict, "ClientsDataToRegistr");
            CopyAll<string, User>(Users, "UsersDataToRegistr");
        }

        public void CopyAll<K, T>(Dictionary<K, T> dictOut, string fileName)
        {
            Load<K, T> load = new(this.Bank, fileName);
            load.LoadFromFile();
            try
            {
                foreach (var k in load.Information.Keys)
                {
                    dictOut.Add(k, load.Information[k]);
                }
            }
            catch (ArgumentException) { }
        }
        public string? GetClient(string key)
        {
            return ClientsDict[key].Id + " ФИО " + ClientsDict[key].Surname + " " + ClientsDict[key].Name + " " + ClientsDict[key].PName
                + " Почта: " + ClientsDict[key].Email + " Паспорт: " + ClientsDict[key].Pasport + " Телефон: " + ClientsDict[key].PhoneNumber;
        }
        public void AddClient(string id)
        {
            ClientsDict[id].Send("ClientsData");
            string login = ClientsDict[id].Email;
            Users[login].Send("UsersData", login);

            Users.Remove(login);
            ClientsDict.Remove(id);
        }
        public void RemoveClient(string id)
        {
            Users.Remove(ClientsDict[id].Email);
            ClientsDict.Remove(id);
        }
        public void SendBack()
        {
            CopyAllBack<string, Client>(ClientsDict, "ClientsDataToRegistr");
            CopyAllBack<string, User>(Users, "UsersDataToRegistr");
        }
        public void CopyAllBack<K, T>(Dictionary<K, T> dictOut, string fileName)
        {
            Load<K, T> load = new(this.Bank, fileName);
            try
            {
                foreach (var k in dictOut.Keys)
                {
                    load.Information.Add(k, dictOut[k]);
                }
                load.LoadToFile();
            }
            catch (ArgumentException) { }
        }
    }
}
