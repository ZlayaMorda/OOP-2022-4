using BankingSystem.AllAccount;
namespace BankingSystem.AboutClient
{
    internal class DataClientPresenter
    {
        IDataClient clientView;
        Client client;
        public Bank Bank { get; }

        public DataClientPresenter(Bank Bank, string id)
        {
            this.Bank = Bank;
            client = new(Bank.Name, id);
            client.LoadClient();
        }
        public void GetView(IDataClient view)
        {
            clientView = view;
        }

        public Account GetAcc()
        {
            return client.CreateAccount(this.Bank.GetIdNum());
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
        public void Freeze(IDataClient data)
        {
            GetView(data);
            if (clientView.Nature == "Счета" && clientView.HomeId != "")
            {
                if (client.AccountsDict[clientView.HomeId].State)
                {
                    client.AccountsDict[clientView.HomeId].State = false;
                }
                else
                {
                    client.AccountsDict[clientView.HomeId].State = true;
                }
                client.LoadToFile(clientView.HomeId);
            }
        }

        public void ChangeAccSum(IDataClient data, bool sign)
        {
            GetView(data);
            if (client.AccountsDict[data.HomeId].State == true)
            {
                if (clientView.Nature == "Счета" && clientView.HomeId != "" && clientView.Sum != "")
                {
                    client.AccountsDict[clientView.HomeId].AddMoney(clientView.Sum, sign);
                    clientView.Sum = "";
                    client.LoadToFile(clientView.HomeId);
                }
                else
                {
                    MessageBox.Show("Введите сумму и выберите счет");
                }
            }
            else
            {
                MessageBox.Show("Счет заморожен");
            }
            
        }

        public void Transfer(IDataClient data)
        {
            GetView(data);
            if (client.AccountsDict[data.HomeId].State == true)
            {
                string AlienAccId = clientView.AlienId;
                if (AlienAccId.Length == 41 && clientView.Nature == "Счета" && clientView.HomeId != "" && clientView.Sum != "")
                {
                    if (AlienAccId.Substring(0, 36) != client.Id)
                    {
                        Client alineClient = new(Bank.GetName(AlienAccId[40].ToString()), AlienAccId.Substring(0, 36));
                        alineClient.LoadClient();
                        if (alineClient.AccountsDict[AlienAccId].State == true)
                        {
                            alineClient.AccountsDict[AlienAccId].AddMoney(clientView.Sum, true);
                            alineClient.LoadToFile(AlienAccId);
                            ChangeAccSum(data, false);
                        }
                        else { MessageBox.Show("Счет заморожен"); }
                    }
                    else
                    {
                        if (client.AccountsDict[AlienAccId].State == true)
                        {
                            client.AccountsDict[clientView.AlienId].AddMoney(clientView.Sum, true);
                            client.LoadToFile(AlienAccId);
                            ChangeAccSum(data, false);
                        }
                        else { MessageBox.Show("Счет заморожен"); }
                    }
                }
                else
                {
                    MessageBox.Show("Введите сумму и выберите счет");
                }
            }
            else
            {
                MessageBox.Show("Счет заморожен");
            }
        }
    }
}
