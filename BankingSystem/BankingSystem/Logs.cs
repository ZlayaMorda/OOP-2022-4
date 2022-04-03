using BankingSystem.Loading;
using BankingSystem.AboutClient;

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
        public void AddLogTrans(IDataClient data, string currency)
        {
            AccLogTrans log = new(data.HomeId, data.AlienId, data.Sum, currency);
            load.AddToFile(log.GetTransString(), CreateKey(load, "Trans0"));
        }

        public void AddLogChanges(string HomeId, string Sum, bool changes, string Currency)
        {
            AccLogTrans log = new(HomeId, changes, Sum, Currency);
            load.AddToFile(log.GetTransString(), CreateKey(load, "Trans0"));
        }

        public void AddLogModif(string HomeId, string State)
        {
            AccLogModif log = new(HomeId, State);
            load.AddToFile(log.GetModifSettings(), CreateKey(load, "Modif0"));
        }

        public void FillLog(ListBox listBox)
        {
            foreach(var key in load.Information.Keys)
            {
                if(key.IndexOf("Trans") != -1 || key.IndexOf("Modif") != -1)
                {
                    listBox.Items.Add(load.Information[key]);
                }
            }
        }

        private static string CreateKey(Load<string, string> load, string key)
        { 
            int i = 0;
            while (load.Information.ContainsKey(key))
            {
                i++;
                key = key.Substring(0, 5) + i.ToString();
            }
            return key;
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
            if(Date == null)
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

    internal class AccLogModif : Registration
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

        public string GetModifSettings()
        {
            return Date.ToString() + "  счет " + HomeId + "  " + State;
        }
    }
    internal class Registration
    { }
}
