using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.AllAccount
{
    internal class Company
    {
        public string Id { get; set; }
        public string CompanyType { get; set; }
        public string LegalName { get; set; }
        public string PayersNumber { get; set; }
        public string BankIdCode { get; set; }
        public string JurAdress { get; set; }
        public bool IsPayable { get; set; }
        public Dictionary<string, Credit> PayDict { get; set; }

        public Company(string Id, string CompanyType, string LegalName, string PayersNumber, string BankIdCode, string JurAdress, Dictionary<string, Credit>? PayDict = null, bool isPayable = false)
        {
            this.Id = Id;
            this.CompanyType = CompanyType;
            this.LegalName = LegalName;
            this.PayersNumber = PayersNumber;
            this.BankIdCode = BankIdCode;
            this.JurAdress = JurAdress;
            this.IsPayable = isPayable;
            if (PayDict == null)
            {
                this.PayDict = new();
            }
            else
            {
                this.PayDict = new();
                CopyPay(PayDict);
            }
            IsPayable = isPayable;
 
        }
        public void CreateId(string Id, int num, string Bank)
        {
            if (num < 10)
            {
                IdCase(Id, "00", num, Bank);
            }
            else if (num < 100)
            {
                IdCase(Id, "0", num, Bank);
            }
            else if (num < 1000)
            {
                IdCase(Id, "", num, Bank);
            }
        }

        private void IdCase(string Id, string zero, int num, string Bank)
        {
            this.Id = Id + zero + Convert.ToString(num) + Bank;
        }
        public void CopyPay(Dictionary<string, Credit> temp)
        {
            foreach (var key in temp.Keys)
            {
                this.PayDict.Add(key, temp[key]);
            }
        }
    }
}
