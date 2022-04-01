using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem
{
    internal class Bank
    {
        public string Name { get; set; }

        public Dictionary<string, float> AlphaBankCurrency = new()
        {
            ["BYN-USD"] = 2.97f,
            ["USD-BYN"] = 1 / 2.83f,
            ["BYN-EUR"] = 3.31f,
            ["EUR-BYN"] = 1 / 3.12f,
            ["EUR-USD"] = 1 / 1.09f,
            ["USD-EUR"] = 1.13f,
        };

        public Dictionary<string, float> BSBBankCurrency = new()
        {
            ["BYN-USD"] = 2.94f,
            ["USD-BYN"] = 1 / 2.9f,
            ["BYN-EUR"] = 3.29f,
            ["EUR-BYN"] = 1 / 3.22f,
            ["EUR-USD"] = 1 / 1.1f,
            ["USD-EUR"] = 1.15f,
        };

        public Dictionary<string, float> BelarusBankCurrency = new()
        {
            ["BYN-USD"] = 2.95f,
            ["USD-BYN"] = 1 / 2.89f,
            ["BYN-EUR"] = 3.3f,
            ["EUR-BYN"] = 1 / 3.2f,
            ["EUR-USD"] = 1 / 1.1f,
            ["USD-EUR"] = 1.14f,
        };

        internal Bank(string Name)
        {
            this.Name = Name;
        }

        public float GetCurrency(string Name, string key)
        {
            if (Name == "Alpha Bank")
            {
                return AlphaBankCurrency[key];
            }
            else if (Name == "BSB Bank")
            {
                return BSBBankCurrency[key];
            }
            else if (Name == "Belarus Bank")
            {
                return BelarusBankCurrency[key];
            }
            else
            {
                return 0;
            }
        }

        public string GetIdNum()
        {
            if (this.Name == "Alpha Bank")
            {
                return "0";
            }
            else if (this.Name == "BSB Bank")
            {
                return "1";
            }
            else if (this.Name == "Belarus Bank")
            {
                return "2";
            }
            else
            {
                return "";
            }
        }
        public string GetName(string num)
        {
            if(num == "0")
            {
                return "Alpha Bank";
            }
            else if(num == "1")
            {
                return "BSB Bank";
            }
            else if(num == "2")
            {
                return "Belarus Bank";
            }
            else
            {
                return "";
            }
        }
    }
}
