using BankingSystem.Loading;
using BankingSystem.AboutClient;

namespace BankingSystem.AllAccount
{
    internal class CreditPresenter
    {
        public readonly Dictionary<string, Credit> CreditsDict = new();

        public static void SendToApprove(Credit cr, string Bank)
        {
            Load<string, Credit> load = new(Bank, "CreditsToRegistr");
            load.LoadFromFile();

            load.Information.Add(cr.IdAcc, cr);
            load.LoadToFile();
        }

        public string GetCreditString(string id)
        {
            if(!CreditsDict[id].MinusOrPlus)
            {
                return "Кредит:  " + CreditsDict[id].IdAcc + "    Месяцев: " + CreditsDict[id].Data + "   Сумма: " + CreditsDict[id].CreditSum;
            }
            else
            {
                return "Вклад:   " + CreditsDict[id].IdAcc + "    Месяцев: " + CreditsDict[id].Data + "   Сумма: " + CreditsDict[id].CreditSum;
            }
        }
        
        public void GetFromFile(string Bank)
        {
            Load<string, Credit> load = new(Bank, "CreditsToRegistr");
            load.LoadFromFile();
            foreach (var key in load.Information.Keys)
            {
                this.CreditsDict.Add(key, load.Information[key]);
            }
        }

        public void RemoveCredit(string Bank, string id)
        {
            CreditsDict.Remove(id);
            Load<string, Credit> load = new(Bank, "CreditsToRegistr");
            load.LoadFromFile();
            load.Information.Remove(id);
            load.LoadToFile();
        }
        public void Add(string Bank, string id)
        {
            //Logs logs = new(Bank);
            Load<string, Client> load = new(Bank, "ClientsData");
            load.LoadFromFile();
            if (load.Information.ContainsKey(id.Substring(0, 36)))
            {
                load.Information[id.Substring(0, 36)].AddCredit(CreditsDict[id]);
                load.LoadToFile();
                //logs.AddLogModif(id, "создан");
            }
            RemoveCredit(Bank, id);
        }
    }
}
