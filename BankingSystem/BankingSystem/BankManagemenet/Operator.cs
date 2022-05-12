using BankingSystem.AllAccount;
using BankingSystem.UserAut;
using BankingSystem.AboutClient;

namespace BankingSystem.BankManagement
{
    internal class Operator : IAdmin
    {
        public string Id { get; set; }
        public Bank Bank { get; set; }

        protected CompanyPresenter? companyPresenter;
        internal Loading.Load<object, object> Load
        {
            get => default;
            set
            {
            }
        }

        AccountPresenter? acc;
        protected Logs logs;

        public Operator(string Id, Bank Bank)
        {
            this.Id = Id;
            this.Bank = Bank;
            logs = new(Bank.Name);
        }
        public virtual void Show(ListBox listBoxInfo, string choose)
        {
            try
            {
                if (choose == "Заявки на авторизацию")
                {
                    MessageBox.Show("Доступ ограничен");
                }
                else if (choose == "Заявки на открытие счета")
                {
                    ShowAcc(listBoxInfo);
                }
                else if (choose == "Логи движений по счетам")
                {
                    logs.FillLog(listBoxInfo, choose);
                }
                else if (choose == "Заявки на зарплатный проект")
                {
                    ShowComp(listBoxInfo, "PayProjectRegistr");
                }
            }
            catch (NullReferenceException) { }
        }

        public virtual void Approve(ListBox listBoxInfo, string choose)
        {
            try
            {
                if (choose == "Заявки на авторизацию")
                {
                    MessageBox.Show("Доступ ограничен");
                }
                else if (choose == "Заявки на открытие счета")
                {
                    ApproveAcc(listBoxInfo);
                }
                else if (choose == "Заявки на зарплатный проект")
                {
                    ApprovePayProject(listBoxInfo);
                }

            }
            catch (NullReferenceException) { }
        }

        public virtual void Deny(ListBox listBoxInfo, string choose)
        {
            try
            {
                if (choose == "Заявки на авторизацию")
                {
                    MessageBox.Show("Доступ ограничен");
                }
                else if (choose == "Заявки на открытие счета")
                {
                    DenyAcc(listBoxInfo);
                }
                else if (choose == "Заявки на зарплатный проект")
                {
                    DenyPayProject(listBoxInfo);
                }
                else if(choose == "Логи движений по счетам")
                {
                    CancelAcc(listBoxInfo);
                    Show(listBoxInfo, choose);
                }
            }
            catch (NullReferenceException) { }
        }
        protected void ShowAcc(ListBox listBoxInfo) 
        {
            acc = new();
            acc.GetFromFile(Bank.Name);
            foreach (var key in acc.accounts.Keys)
            {
                listBoxInfo.Items.Add(acc.GetAccount(key));
            }
        }
        protected void ApproveAcc(ListBox listBoxInfo) 
        {
            if (listBoxInfo.SelectedIndices.Count != 0)
            {
                foreach (int num in listBoxInfo.SelectedIndices)
                {
                    acc.Add(Bank.Name, listBoxInfo.Items[num].ToString().Substring(0, 41));
                }
            }
            else
            {
                MessageBox.Show("Выберите элемент");
            }
        }
        protected void DenyAcc(ListBox listBoxInfo)
        {
            if (listBoxInfo.SelectedIndices.Count != 0)
            {
                foreach (int num in listBoxInfo.SelectedIndices)
                {
                    acc.RemoveAccount(Bank.Name, listBoxInfo.Items[num].ToString().Substring(0, 41));
                    logs.AddLogModif(listBoxInfo.Items[num].ToString().Substring(0, 41), "не одобрен");
                }
            }
            else
            {
                MessageBox.Show("Выберите элемент");
            }
        }
        protected void CancelAcc(ListBox listBoxInfo)
        {
            if(listBoxInfo.SelectedIndices.Count == 1)
            {
                string str = listBoxInfo.SelectedItem.ToString();
                string kek = str.Substring(21, 2);
                if (str.Substring(21, 2) == "c:" && str.Substring(str.Length - 8, 8) != "canceled")
                {
                    GetTrans TransData = new(str, Bank);
                    TransData.RevertSum();
                    DataClientPresenter dataClientPresenter = new(Bank, TransData.AlienId.Substring(0, 36));
                    dataClientPresenter.Transfer(TransData);
                    logs.Reload();
                    logs.ChangeStr(str);
                }
            }
            else
            {
                MessageBox.Show("Выберите один перевод");
            }
        }
        public virtual void Add(IUser user) { MessageBox.Show("Доступ ограничен"); }

        protected void ShowComp(ListBox listBox, string file)
        {
            companyPresenter = new(Bank);
            companyPresenter.GetFromFile(file);
            foreach (var key in companyPresenter.CompanyDict.Keys)
            {
                listBox.Items.Add(companyPresenter.GetCompanyString(companyPresenter.CompanyDict[key]));
            }
        }
        protected void ApprovePayProject(ListBox listBox)
        {
            if (listBox.SelectedIndices.Count != 0)
            {
                foreach (int num in listBox.SelectedIndices)
                {
                    companyPresenter.AddOrRemovePayProject(listBox.Items[num].ToString().Substring(0, 40), true);
                }
            }
            else
            {
                MessageBox.Show("Выберите элемент");
            }
        }
        protected void DenyPayProject(ListBox listBox)
        {
            if (listBox.SelectedIndices.Count != 0)
            {
                foreach (int num in listBox.SelectedIndices)
                {
                    companyPresenter.AddOrRemovePayProject(listBox.Items[num].ToString().Substring(0, 40), false);
                }
            }
            else
            {
                MessageBox.Show("Выберите элемент");
            }
        }
        protected void DenyCompany(ListBox listBoxInfo, string file)
        {
            if (listBoxInfo.SelectedIndices.Count != 0)
            {
                foreach (int num in listBoxInfo.SelectedIndices)
                {
                    companyPresenter.RemoveCompany(listBoxInfo.Items[num].ToString().Substring(0, 40), file);
                    logs.AddUserReg(listBoxInfo.Items[num].ToString().Substring(0, 40), "Предприятие клиента", false);
                }
            }
            else
            {
                MessageBox.Show("Выберите элемент");
            }
        }
        protected void ApproveComp(ListBox listBox)
        {
            if (listBox.SelectedIndices.Count != 0)
            {
                foreach (int num in listBox.SelectedIndices)
                {
                    companyPresenter.AddCompany(listBox.Items[num].ToString().Substring(0, 40));
                    logs.AddUserReg(listBox.Items[num].ToString().Substring(0, 40), "Предприятие клиента", true);
                }
            }
            else
            {
                MessageBox.Show("Выберите элемент");
            }
        }
    }

    class GetTrans : IDataClient
    {
        public string? HomeId { get; }
        public string? AlienId { get; set; }
        public string? Sum { get; set; }
        public string? Nature { get; }
        public string? Currency { get; set; }
        public string? ToReg { get; }
        public string? Month { get; }
        public Bank Bank { get; }
        public GetTrans(string str, Bank Bank)
        {
            this.HomeId = str.Substring(71, 41);
            this.AlienId = str.Substring(24, 41);
            this.Sum = str.Substring(121, str.Length - 130);
            this.Currency = str.Substring(str.Length - 7, 7);
            this.Bank = Bank;
            this.Nature = "Счета";
        }
        public void RevertSum()
        {
            float num = Convert.ToSingle(this.Sum);
            num = (float)Math.Round(num /= Bank.GetCurrency(Bank.Name, this.Currency), 2);
            this.Sum = num.ToString();
            this.Currency = this.Currency.Substring(7 - 3, 3) + "-" + this.Currency.Substring(0, 3);
        }
    }

}
