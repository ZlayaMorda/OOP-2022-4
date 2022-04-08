using BankingSystem.Loading;
using BankingSystem.AllAccount;
namespace BankingSystem.AboutClient
{
    internal class CompanyPresenter
    {
        //ICompany CompanyViewer { get; set; }
        Client? cl { get; set; }
        Bank Bank { get; set; }
        public Dictionary<string, Company> CompanyDict { get; set; }
        public CompanyPresenter(Bank Bank, Client? cl = null)
        {
            if(cl != null)
            {
                this.cl = cl;
            }
            else
            {
                this.cl = null;
            }
            this.Bank = Bank;
            this.CompanyDict = new();
        }
        public void SendToReg(ICompany comp)
        {
            Load<string, Company> load = new(Bank.Name, "CompanyToRegistr");
            load.LoadFromFile();

            Company temp = new("", comp.CompanyType, comp.LegalName, comp.PayersNumber, comp.BankIdCode, comp.JurAdress);
            for (int i = 0; i < 1000; i++)
            {
                temp.CreateId(cl.Id, i, Bank.GetIdNum());
                if (cl.CompanyDict.ContainsKey(temp.Id) || load.Information.ContainsKey(temp.Id))
                {
                    continue;
                }
                else
                {
                    break;
                }
            }
            load.Information.Add(temp.Id, temp);
            load.LoadToFile();
            comp.BankIdCode = "";
            comp.JurAdress = "";
            comp.PayersNumber = "";
            comp.LegalName = "";
            comp.CompanyType = "";
        }

        public void GetFromFile()
        {
            Load<string, Company> load = new(Bank.Name, "CompanyToRegistr");
            load.LoadFromFile();
            foreach(var key in load.Information.Keys)
            {
                CompanyDict.Add(key, load.Information[key]);
            }
        }

        public string GetCompanyString(Company comp)
        {
            return comp.Id + "  Тип: " + comp.CompanyType + "  Юридическое название: " + comp.LegalName + "  УНП: " + comp.PayersNumber +
                "  БИК: " + comp.BankIdCode + "  Юридический адрес: " + comp.JurAdress;
        }

    }
}
