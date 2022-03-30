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

        public void AddSumToTheAcc(IDataClient data)
        {
            GetView(data);
            if(clientView.Nature == "Счета" && clientView.HomeId != "" && clientView.Sum != "")
            {
                client.AccountsDict[clientView.HomeId].AddMoney(clientView.Sum);
                clientView.Sum = "";
                client.LoadToFile(clientView.HomeId);
            }
            else
            {
                MessageBox.Show("Введите сумму и выберите счет");
            }
        }
    }
}
