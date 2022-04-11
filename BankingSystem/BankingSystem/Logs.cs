using BankingSystem.Loading;
using BankingSystem.AboutClient;
using BankingSystem.AllAccount;

namespace BankingSystem
{
    internal class Logs
    {
        private Load<string, string> load;
        public Logs(string BankName)
        {
            load = new(BankName, "Logs");
            load.LoadFromFile();
        }
        public void Reload()
        {
            load.LoadFromFile();
        }
        internal AccLogTrans AccLogTrans
        {
            get => default;
            set
            {
            }
        }

        internal AccLogModif AccLogModif
        {
            get => default;
            set
            {
            }
        }

        internal Load<object, object> Load
        {
            get => default;
            set
            {
            }
        }

        internal Registration Registration
        {
            get => default;
            set
            {
            }
        }

        public void AddLogTrans(IDataClient data, string currency)
        {
            AccLogTrans log = new(data.HomeId, data.AlienId, data.Sum, currency);
            load.AddToFile(log.GetTransString(), CreateKey(load, "Acc0"));
        }

        public void AddLogChanges(string HomeId, string Sum, bool changes, string Currency)
        {
            AccLogTrans log = new(HomeId, changes, Sum, Currency);
            load.AddToFile(log.GetTransString(), CreateKey(load, "Acc0"));
        }

        public void AddLogModif(string HomeId, string State)
        {
            AccLogModif log = new(HomeId, State);
            load.AddToFile(log.GetModifString(), CreateKey(load, "Acc0"));
        }

        public void AddUserReg(string Id, string UserType, bool state)
        {
            Registration log = new(Id, UserType, state);
            load.AddToFile(log.GetRegString(), CreateKey(load, "Reg0"));
        }
        public void AddCreditLog(bool state, Credit cr)
        {
            CreditLog log = new(state, cr);
            load.AddToFile(log.GetCreditString(), CreateKey(load, "Cre0"));
        }

        public void FillLog(ListBox listBox, string choose)
        {
            load.LoadFromFile();
            foreach (var key in load.Information.Keys)
            {
                if (key.IndexOf("Acc") != -1 && choose == "Логи движений по счетам")
                {
                    listBox.Items.Add(load.Information[key]);
                }
                else if (key.IndexOf("Reg") != -1 && choose == "Логи регистрации")
                {
                    listBox.Items.Add(load.Information[key]);
                }
                else if (key.IndexOf("Cre") != -1 && choose == "Логи кредитов, вкладов, зарплат, рассрочек")
                {
                    listBox.Items.Add(load.Information[key]);
                }
            }
        }

        private static string CreateKey(Load<string, string> load, string key)
        {
            load.LoadFromFile();
            int i = 0;
            while (load.Information.ContainsKey(key))
            {
                i++;
                key = key.Substring(0, 3) + i.ToString();
            }
            return key;
        }
        public void ChangeStr(string str)
        {
            foreach (var key in load.Information.Keys)
            {
                if (key.IndexOf("Acc") != -1 && load.Information[key] == str)
                {
                    load.Information[key] += "canceled";
                    load.LoadToFile();
                }
            }
        }

        internal CreditLog CreditLog
        {
            get => default;
            set
            {
            }
        }
    }
    internal class AccLogTrans
    {
        private string HomeId { get; set; }
        private string? AlienId { get; set; }
        private string Sum { get; set; }
        private string Currency { get; set; }
        private DateTime? Date { get; set; }

        public AccLogTrans(string HomeId, string AlienId, string Sum, string Currency, DateTime? Date = null)
        {
            this.HomeId = HomeId;
            this.AlienId = AlienId;
            this.Sum = Sum;
            this.Currency = Currency;
            if (Date == null)
            {
                this.Date = DateTime.Now;
            }
            else
            {
                this.Date = Date;
            }
        }
        public AccLogTrans(string HomeId, bool sign, string Sum, string Currency, DateTime? Date = null)
        {
            this.HomeId = HomeId;
            this.Sum = Sum;
            if (sign) { this.AlienId = "положили"; }
            else { this.AlienId = "сняли"; }
            this.Currency = Currency;
            if (Date == null)
            {
                this.Date = DateTime.Now;
            }
            else
            {
                this.Date = Date;
            }
        }
        public string GetTransString()
        {
            if (AlienId == "положили" || AlienId == "сняли")
            {
                return Date.ToString() + "  cчет: " + HomeId + "  " + AlienId + "  сумму: " + Sum + " " + Currency;
            }
            else
            {
                return Date.ToString() + "  c: " + HomeId + "  на: " + AlienId + "  сумму: " + Sum + "  " + Currency;
            }
        }
    }

    internal class AccLogModif
    {
        private string HomeId { get; set; }
        private DateTime? Date { get; set; }
        private string State { get; set; }

        public AccLogModif(string HomeId, string State, DateTime? Date = null)
        {
            if (Date == null)
            {
                this.Date = DateTime.Now;
            }
            else
            {
                this.Date = Date;
            }
            this.HomeId = HomeId;
            this.State = State;
        }

        public string GetModifString()
        {
            return Date.ToString() + "  счет " + HomeId + "  " + State;
        }
    }
    internal class Registration
    {
        private string Id { get; set; }
        private DateTime? Date { get; set; }
        private string UserType { get; set; }
        private string state { get; set; }
        internal Registration(string Id, string UserType, bool reg, DateTime? Date = null)
        {
            if (Date == null)
            {
                this.Date = DateTime.Now;
            }
            else
            {
                this.Date = Date;
            }
            this.Id = Id;
            this.UserType = UserType;
            if (reg)
            {
                state = " Зарегестрирован в банке, ID";
            }
            else
            {
                state = " Отказано в регистрации в банке, ID";
            }
        }
        internal string GetRegString()
        {
            return Date.ToString() + "Пользователь " + this.UserType + this.state + this.Id;
        }
    }

    internal class CreditLog
    {
        private string AccId { get; set; }
        private DateTime? Date { get; set; }
        private bool MinusOrPlus { get; set; }
        private float percent { get; set; }
        private string Monthes { get; set; }
        private string Sum { get; set; }
        private string State { get; set; }
        internal CreditLog(bool state, Credit credit, DateTime ?Date = null)
        {
            if (Date == null)
            {
                this.Date = DateTime.Now;
            }
            else
            {
                this.Date = Date;
            }
            this.AccId = credit.IdAcc;
            this.MinusOrPlus = credit.MinusOrPlus;
            this.percent = credit.Percent;
            this.Monthes = credit.Data;
            this.Sum = credit.CreditSum;
            if (state) { this.State = " Одобрили "; }
            else { this.State = " Не одобрили "; }
        }
        internal string GetCreditString()
        {
            if(this.MinusOrPlus == false && this.percent != 0)
            {
                return this.Date + this.State + "Кредит " + "Под процент: " + this.percent.ToString() + " На месяцы: " +
                    this.Monthes + " Сумма: " + this.Sum + " Счет: " + this.AccId;
            }
            else if(this.MinusOrPlus == true && this.percent != 0)
            {
                return this.Date + this.State + "Вклад " + "Под процент: " + this.percent.ToString() + " На месяцы: " +
                    this.Monthes + " Сумма: " + this.Sum + " Счет: " + this.AccId;
            }
            if (this.MinusOrPlus == false && this.percent == 0)
            {
                return this.Date + this.State + "Рассрочку " + "Под процент: " + this.percent.ToString() + " На месяцы: " +
                    this.Monthes + " Сумма: " + this.Sum + " Счет: " + this.AccId;
            }
            else if (this.MinusOrPlus == true && this.percent == 0)
            {
                return this.Date + this.State + "Зарплату " + "Под процент: " + this.percent.ToString() + " На месяцы: " +
                    this.Monthes + " Сумма: " + this.Sum + " Счет: " + this.AccId;
            }
            else { return ""; }
        }
    }
}
