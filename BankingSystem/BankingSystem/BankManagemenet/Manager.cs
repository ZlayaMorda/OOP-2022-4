using BankingSystem.UserAut;
using BankingSystem.Loading;
using BankingSystem.AboutClient;
using BankingSystem.AllAccount;

namespace BankingSystem.BankManagement
{
    internal class Manager : Operator
    {
        public readonly Dictionary<string, Client> ClientsDict = new();
        private readonly Dictionary<string, User> Users = new();
        private CreditPresenter? creditPresenter;
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
                else if (choose == "Заявки на выдачу кредитов")
                {
                    ShowCredits(listBoxInfo);
                }
                else if (choose == "Заявки на регистрацию предприятия")
                {
                    ShowComp(listBoxInfo, "CompanyToRegistr");
                }
                else if (choose == "Заявки на зарплатный проект")
                {
                    ShowComp(listBoxInfo, "PayProjectRegistr");
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
                else if (choose == "Заявки на выдачу кредитов")
                {
                    ApproveCredit(listBoxInfo);
                }
                else if(choose == "Заявки на регистрацию предприятия")
                {
                    ApproveComp(listBoxInfo);
                }
                else if (choose == "Заявки на зарплатный проект")
                {
                    ApprovePayProject(listBoxInfo);
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
                else if (choose == "Заявки на выдачу кредитов")
                {
                    DenyCredit(listBoxInfo);
                }
                else if (choose == "Заявки на регистрацию предприятия")
                {
                    DenyCompany(listBoxInfo, "CompanyToRegistr");
                }
                else if (choose == "Заявки на зарплатный проект")
                {
                    DenyPayProject(listBoxInfo);
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

        protected void ShowCredits(ListBox listBox)
        {
            creditPresenter = new();
            creditPresenter.GetFromFile(Bank.Name);
            foreach (var key in creditPresenter.CreditsDict.Keys)
            {
                listBox.Items.Add(creditPresenter.GetCreditString(key));
            }
        }
        protected void ApproveCredit(ListBox listBoxInfo)
        {
            if (listBoxInfo.SelectedIndices.Count != 0)
            {
                foreach (int num in listBoxInfo.SelectedIndices)
                {
                    string id = listBoxInfo.Items[num].ToString().Substring(11, 41);
                    if (!creditPresenter.CreditsDict[id].MinusOrPlus)
                    {
                        Load<string, Client> cl = new(Bank.Name, "ClientsData");
                        cl.LoadFromFile();
                        cl.Information[id.Substring(0, 36)].AccountsDict[id].AddMoney(creditPresenter.CreditsDict[id].CreditSum, true);
                        cl.LoadToFile();
                    }
                    //Logs logs = new(Bank.Name);
                    logs.AddCreditLog(true, creditPresenter.CreditsDict[id]);
                    creditPresenter.Add(Bank.Name, id);
                }
            }
            else
            {
                MessageBox.Show("Выберите элемент");
            }
        }
        protected void DenyCredit(ListBox listBoxInfo)
        {
            if (listBoxInfo.SelectedIndices.Count != 0)
            {
                foreach (int num in listBoxInfo.SelectedIndices)
                {
                    logs.AddCreditLog(false, creditPresenter.CreditsDict[listBoxInfo.Items[num].ToString().Substring(11, 41)]);
                    creditPresenter.RemoveCredit(Bank.Name, listBoxInfo.Items[num].ToString().Substring(11, 41));
                    //Logs logs = new(Bank.Name);
                    //logs.AddLogModif(listBoxInfo.Items[num].ToString().Substring(9, 41), "не одобрен");
                }
            }
            else
            {
                MessageBox.Show("Выберите элемент");
            }
        }
    }
}
