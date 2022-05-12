using BankingSystem.AllAccount;
namespace BankingSystem.AboutClient
{
    internal class DataClientPresenter
    {
        private IDataClient clientView;
        public readonly Client client;
        public Bank Bank { get; }
        private readonly Logs logs;
        public DataClientPresenter(Bank Bank, string id)
        {
            this.Bank = Bank;
            client = new(Bank.Name, id);
            client.LoadClient();
            logs = new Logs(Bank.Name);
        }
        public void GetView(IDataClient view)
        {
            clientView = view;
        }

        public Account? GetAcc(IDataClient data)
        {
            GetView(data);
            if (clientView.Currency != null)
            {
                return client.CreateAccount(this.Bank.GetIdNum(), clientView.Currency);
            }
            else 
            {
                MessageBox.Show("Выберите валюту");
                return null;
            }
        }
        public Credit? GetCredit(IDataClient data, bool MinusOrPlus, float Bank)
        {
            GetView(data);
            if (clientView.HomeId != "" && clientView.Month != null && clientView.ToReg != null && clientView.Sum != "")
            {
                return client.CreateCredit(data, Bank, MinusOrPlus);
            }
            else
            {
                MessageBox.Show("Заполните все поля");
                return null;
            }
        }

        public void SendToApprove(IDataClient data)
        {
            try
            {
                if (data.ToReg == "Открыть счет")
                {
                    AccountPresenter.Send(GetAcc(data), Bank.Name);
                }
                else if(data.ToReg == "Получить кредит")
                {
                    CreditPresenter.SendToApprove(GetCredit(data, false, Bank.BankCredits[data.Month]), Bank.Name);
                }
                else if(data.ToReg == "Сделать вклад")
                {
                    CreditPresenter.SendToApprove(GetCredit(data, true, Bank.BankCredits[data.Month]), Bank.Name);
                }
                else if(data.ToReg == "Получить рассрочку")
                {
                    CreditPresenter.SendToApprove(GetCredit(data, false, 0), Bank.Name);
                }
            }
            catch (NullReferenceException) { }
        }
        public void FillTheBox(ListBox listBoxInfo, IDataClient data)
        {
            GetView(data);
            if (clientView.Nature == "Счета")
            {
                foreach (var key in client.AccountsDict.Keys)
                {
                    listBoxInfo.Items.Add(client.GetAccString(key));
              
                }
            }
            else if(clientView.Nature == "Кредиты")
            {
                foreach (var key in client.CreditsDict.Keys)
                {
                    if (!client.CreditsDict[key].MinusOrPlus && client.CreditsDict[key].Percent != 0)
                    {
                        listBoxInfo.Items.Add(client.GetCreditString(key));
                    }
                }
            }
            else if(clientView.Nature == "Вклады")
            {
                foreach (var key in client.CreditsDict.Keys)
                {
                    if (client.CreditsDict[key].MinusOrPlus && client.CreditsDict[key].Percent != 0)
                    {
                        listBoxInfo.Items.Add(client.GetCreditString(key));
                    }
                }
            }
            else if (clientView.Nature == "Рассрочки")
            {
                foreach (var key in client.CreditsDict.Keys)
                {
                    if (!client.CreditsDict[key].MinusOrPlus && client.CreditsDict[key].Percent == 0)
                    {
                        listBoxInfo.Items.Add(client.GetCreditString(key));
                    }
                }
            }
            else if (clientView.Nature == "Зарплаты")
            {
                foreach (var key in client.CreditsDict.Keys)
                {
                    if (client.CreditsDict[key].MinusOrPlus && client.CreditsDict[key].Percent == 0)
                    {
                        listBoxInfo.Items.Add(client.GetCreditString(key));
                    }
                }
            }
        }
        public void RemoveAcc(IDataClient data)
        {
            GetView(data);
            if (clientView.Nature == "Счета" && clientView.HomeId != "" && client.AccountsDict[clientView.HomeId].Sum == "0")
            {
                client.AccountsDict.Remove(clientView.HomeId);
                client.LoadToFile(clientView.HomeId);
                logs.AddLogModif(clientView.HomeId, "удален");
            }
            else { MessageBox.Show("Выберите необходимый счет или выведите сумму со счета"); }
        }
        public void Freeze(IDataClient data)
        {
            GetView(data);
            if (clientView.Nature == "Счета" && clientView.HomeId != "")
            {
                if (client.AccountsDict[clientView.HomeId].State)
                {
                    client.AccountsDict[clientView.HomeId].State = false;
                    logs.AddLogModif(clientView.HomeId, "заморожен");
                }
                else
                {
                    client.AccountsDict[clientView.HomeId].State = true;
                    logs.AddLogModif(clientView.HomeId, "разморожен");
                }
                client.LoadToFile(clientView.HomeId);
            }
        }

        public bool ChangeAccSum(IDataClient data, bool sign)
        {
            GetView(data);
            try
            {
                if (client.AccountsDict[data.HomeId].State == true)
                {
                    if (clientView.Nature == "Счета" && clientView.HomeId != "" && clientView.Sum != "")
                    {
                        client.AccountsDict[clientView.HomeId].AddMoney(clientView.Sum, sign);
                        client.LoadToFile(clientView.HomeId);
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Введите сумму и выберите счет");
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Счет заморожен");
                    return false;
                }
            }
            catch (KeyNotFoundException) { MessageBox.Show("Выберите счет"); return false; }
            
        }
        public bool CheckDeposit(Client cl, string id)
        {
            foreach (var temp in cl.CreditsDict.Values)
            {
                if(temp.IdAcc == id && temp.MinusOrPlus == true && temp.Percent != 0)
                {
                    return false;
                }
            }
            return true;
        }
        public void PlusSum(IDataClient data)
        {
            if (CheckDeposit(client, data.HomeId))
            {
                if (ChangeAccSum(data, true))
                {
                    logs.AddLogChanges(data.HomeId, data.Sum, true, client.AccountsDict[clientView.HomeId].Currency);
                }
            }
            else { MessageBox.Show("Невозможно изменить сумму вклада"); }
        }

        public void MinusSum(IDataClient data)
        {
            if (CheckDeposit(client, data.HomeId))
            {
                if (ChangeAccSum(data, false))
                {
                    logs.AddLogChanges(data.HomeId, data.Sum, false, client.AccountsDict[clientView.HomeId].Currency);
                }
            }
            else { MessageBox.Show("Невозможно изменить сумму вклада"); }
        }

        public void Transfer(IDataClient data)
        {
            GetView(data);
            if (CheckDeposit(client, data.HomeId))
            {
                try
                {
                    if (client.AccountsDict[clientView.HomeId].State == true)
                    {
                        string AlienAccId = clientView.AlienId;
                        if (AlienAccId.Length == 41 && clientView.Nature == "Счета" && clientView.HomeId != "" && clientView.Sum != "")
                        {
                            if (AlienAccId.Substring(0, 36) != client.Id)
                            {
                                Client alienClient = new(Bank.GetName(AlienAccId[40].ToString()), AlienAccId.Substring(0, 36));
                                alienClient.LoadClient();
                                if (CheckDeposit(alienClient, data.AlienId))
                                {
                                    TransferSum(alienClient, AlienAccId);
                                }
                                else { MessageBox.Show("Невозможно изменить сумму вклада"); }
                            }
                            else
                            {
                                TransferSum(client, AlienAccId);
                            }
                        }
                        else { MessageBox.Show("Введите сумму и выберите счет"); }
                    }
                    else { MessageBox.Show("Счет заморожен"); }
                }
                catch { }
            }
            else { MessageBox.Show("Невозможно изменить сумму вклада"); }
        }

        public void TransferSum(Client alienClient, string AlienAccId)
        {
            if (alienClient.AccountsDict[AlienAccId].State == true)
            {
                alienClient.AccountsDict[AlienAccId].AddMoney(clientView.Sum, true, Currency(alienClient, AlienAccId, out string currency));
                alienClient.LoadToFile(AlienAccId);
                ChangeAccSum(clientView, false);
                logs.AddLogTrans(clientView, currency);
            }
            else { MessageBox.Show("Счет заморожен"); }
        }
        public float Currency(Client alienClient, string AlienAccId, out string currency)
        {
            if (alienClient.AccountsDict[AlienAccId].Currency != client.AccountsDict[clientView.HomeId].Currency)
            {
                currency = client.AccountsDict[clientView.HomeId].Currency + "-" + alienClient.AccountsDict[AlienAccId].Currency;
                return Bank.GetCurrency(alienClient.ClientBank, currency);
            }
            else
            {
                currency = client.AccountsDict[clientView.HomeId].Currency + "-" + client.AccountsDict[clientView.HomeId].Currency;
                return 1; 
            }
        }

        internal Bank Bank1
        {
            get => default;
            set
            {
            }
        }

        internal CopyOfClient CopyOfClient
        {
            get => default;
            set
            {
            }
        }

        public FormClient.FormClient FormClient
        {
            get => default;
            set
            {
            }
        }

        public FormClient.FormClient FormClient1
        {
            get => default;
            set
            {
            }
        }

        internal Loading.Load<object, object> Load
        {
            get => default;
            set
            {
            }
        }
    }
}
