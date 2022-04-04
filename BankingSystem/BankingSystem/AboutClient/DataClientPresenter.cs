﻿using BankingSystem.AllAccount;
namespace BankingSystem.AboutClient
{
    internal class DataClientPresenter
    {
        private IDataClient clientView;
        private readonly Client client;
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
                        client.AccountsDict[clientView.HomeId].AddMoney(logs, clientView.Sum, sign);
                        client.LoadToFile(clientView.HomeId);
                        //logs.AddLogChanges(clientView, sign, Bank.Name, client.AccountsDict[data.HomeId].Currency);
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
        public void PlusSum(IDataClient data)
        {
            if(ChangeAccSum(data, true))
            {
                logs.AddLogChanges(data.HomeId, data.Sum, true, client.AccountsDict[clientView.HomeId].Currency);
            }
        }

        public void MinusSum(IDataClient data)
        {
            if (ChangeAccSum(data, false))
            {
                logs.AddLogChanges(data.HomeId, data.Sum, false, client.AccountsDict[clientView.HomeId].Currency);
            }
        }

        public void Transfer(IDataClient data)
        {
            GetView(data);
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

                            TransferSum(alienClient, AlienAccId);
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

        public void TransferSum(Client alienClient, string AlienAccId)
        {
            if (alienClient.AccountsDict[AlienAccId].State == true)
            {
                alienClient.AccountsDict[AlienAccId].AddMoney(logs, clientView.Sum, true, Currency(alienClient, AlienAccId, out string currency));
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
    }
}
