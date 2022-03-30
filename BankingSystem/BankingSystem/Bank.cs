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

        internal Bank(string Name)
        {
            this.Name = Name;
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
    }
}
