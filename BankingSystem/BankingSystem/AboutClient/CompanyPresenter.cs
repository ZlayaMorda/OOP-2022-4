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

        internal Company Company
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

        public void GetFromFile(string file)
        {
            Load<string, Company> load = new(Bank.Name, file);
            load.LoadFromFile();
            foreach(var key in load.Information.Keys)
            {
                CompanyDict.Add(key, load.Information[key]);
            }
        }

        public void RemoveCompany(string id, string file)
        {
            CompanyDict.Remove(id);
            Load<string, Company> load = new(Bank.Name, file);
            load.LoadFromFile();
            load.Information.Remove(id);
            load.LoadToFile();
        }
        public void AddCompany(string id)
        {
            //Logs logs = new(Bank);
            Load<string, Client> load = new(Bank.Name, "ClientsData");
            load.LoadFromFile();
            if (load.Information.ContainsKey(id.Substring(0, 36)))
            {
                load.Information[id.Substring(0, 36)].CompanyDict.Add(id,this.CompanyDict[id]);
                load.LoadToFile();
                //logs.AddLogModif(id, "создан");
            }
            RemoveCompany(id, "CompanyToRegistr");
        }

        public string GetCompanyString(Company comp)
        {
            return comp.Id + "  Тип: " + comp.CompanyType + "  Юридическое название: " + comp.LegalName + "  УНП: " + comp.PayersNumber +
                "  БИК: " + comp.BankIdCode + "  Юридический адрес: " + comp.JurAdress;
        }
        public void SendPayProject(ISalary CompanyViewer)
        {
            try
            {
                string id = "";
                foreach(var temp in cl.CompanyDict)
                {
                    if(temp.Value.LegalName == CompanyViewer.Company)
                    {
                        id = temp.Value.Id;
                        break;
                    }
                }
                if(!cl.CompanyDict[id].IsPayable)
                {
                    Load<string, Company> load = new(Bank.Name, "PayProjectRegistr");
                    load.LoadFromFile();
                    load.Information.Add(id, cl.CompanyDict[id]);
                    load.LoadToFile();
                }
                else
                {
                    MessageBox.Show("Зарплатный проект уже подтвержден");
                }
                
            }
            catch{ MessageBox.Show("Выберите предприятие"); }
        }
        public void AddOrRemovePayProject(string id, bool state)
        {
            Load<string, Client> load = new(Bank.Name, "ClientsData");
            load.LoadFromFile();
            load.Information[id.Substring(0, 36)].CompanyDict[id].IsPayable = state;
            load.LoadToFile();

            RemoveCompany(id, "PayProjectRegistr");
        }

        public void AddSalary(ISalary data)
        {
            try
            {
                Load<string, Client> load = new(Bank.Name, "ClientsData");
                load.LoadFromFile();
                string id = data.AccId;
                Credit cr;
                if (!load.Information[id.Substring(0, 36)].CreditsDict.ContainsKey(id))
                {
                    if (load.Information[id.Substring(0, 36)].CompanyDict[id].IsPayable)
                    {
                        try
                        {
                            cr = new(true, 0, data.Mounth, data.Sum, id);
                            load.Information[id.Substring(0, 36)].CreditsDict.Add(id, cr);
                            load.LoadToFile();
                        }
                        catch { }
                    }
                    else { MessageBox.Show("Подайте заявку на зарплатный проект"); }
                }
                else
                {
                    MessageBox.Show("Выберите другой счет");
                }
            }
            catch { MessageBox.Show("Заполните все поля"); }
        }

    }
}
