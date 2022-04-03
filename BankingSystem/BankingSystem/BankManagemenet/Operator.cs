using BankingSystem.AllAccount;
using BankingSystem.UserAut;

namespace BankingSystem.BankManagement
{
    internal class Operator : IAdmin
    {
        public string Id { get; set; }
        public Bank Bank { get; set; }

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
                    logs.FillLog(listBoxInfo);
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
        public virtual void Add(IUser user) { MessageBox.Show("Доступ ограничен"); }
    }
}
