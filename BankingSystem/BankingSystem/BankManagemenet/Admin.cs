using BankingSystem.UserAut;

namespace BankingSystem.BankManagement
{
    internal class Admin : Manager
    {
        public Admin(string Id, Bank Bank) : base(Id, Bank)
        {
        }
        public override void Add(IUser user)
        {
            try
            {
                UserPresenter presenter = new(user);
                presenter.AddManager(user.Member, logs);
            }
            catch (NullReferenceException) { MessageBox.Show("Заполните все поля"); }
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
                else if(choose == "Логи движений по счетам" || choose == "Логи регистрации" || choose == "Логи кредитов, вкладов, зарплат, рассрочек")
                {
                    logs.FillLog(listBoxInfo, choose);
                }
            }
            catch (NullReferenceException) { }
        }
    }
}
