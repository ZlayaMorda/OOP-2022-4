using BankingSystem.UserAut;
using BankingSystem.Loading;
using BankingSystem.AboutClient;

namespace BankingSystem.BankManagement
{
    internal class Manager : Operator
    {
        public readonly Dictionary<string, Client> ClientsDict = new();
        private readonly Dictionary<string, User> Users = new();
        public Manager(string Id, Bank Bank) : base(Id, Bank)
        {
        }

        public override void Show(ListBox listBoxInfo, string choose)
        {
            try
            {
                if (choose == "Заявки на авторизацию")
                {
                    GetClientsData();
                    foreach (var key in ClientsDict.Keys)
                    {
                        listBoxInfo.Items.Add(GetClient(key));
                    }
                }
                else if (choose == "Заявки на открытие счета")
                {
                    ShowAcc(listBoxInfo);
                }
                else if (choose == "Логи движений по счетам")
                {
                    logs.FillLog(listBoxInfo, choose);
                }
            }
            catch (NullReferenceException) { }
        }

        public override void Approve(ListBox listBoxInfo, string choose)
        {
            try
            {
                if (choose == "Заявки на авторизацию")
                {
                    foreach (int num in listBoxInfo.SelectedIndices)
                    {
                        AddClient(listBoxInfo.Items[num].ToString().Substring(0, 36));
                    }
                    SendBack();
                }
                else if (choose == "Заявки на открытие счета")
                {
                    ApproveAcc(listBoxInfo);
                }
            }
            catch (NullReferenceException) { }
        }

        public override void Deny(ListBox listBoxInfo, string choose)
        {
            try
            {
                if (choose == "Заявки на авторизацию")
                {
                    foreach (int num in listBoxInfo.SelectedIndices)
                    {
                        RemoveCl(listBoxInfo.Items[num].ToString().Substring(0, 36));
                    }
                    SendBack();
                }
                else if (choose == "Заявки на открытие счета")
                {
                    DenyAcc(listBoxInfo);
                }
            }
            catch (NullReferenceException) { }
        }
        public void GetClientsData()
        {
            CopyAll<string, Client>(ClientsDict, "ClientsDataToRegistr");
            CopyAll<string, User>(Users, "UsersDataToRegistr");
        }

        public void CopyAll<K, T>(Dictionary<K, T> dictOut, string fileName)
        {
            Load<K, T> load = new(this.Bank.Name, fileName);
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
            logs.AddUserReg(id, "Клиент", true);
            Users.Remove(login);
            ClientsDict.Remove(id);
        }
        public void RemoveClient(string id)
        {
            Users.Remove(ClientsDict[id].Email);
            ClientsDict.Remove(id);
        }
        public void RemoveCl(string id)
        {
            RemoveClient(id);
            logs.AddUserReg(id, "Клиент", false);
        }
        public void SendBack()
        {
            CopyAllBack<string, Client>(ClientsDict, "ClientsDataToRegistr");
            CopyAllBack<string, User>(Users, "UsersDataToRegistr");
        }
        public void CopyAllBack<K, T>(Dictionary<K, T> dictOut, string fileName)
        {
            Load<K, T> load = new(this.Bank.Name, fileName);
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
