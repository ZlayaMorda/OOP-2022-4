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

        public Company(string Id, string CompanyType, string LegalName, string PayersNumber, string BankIdCode, string JurAdress)
        {
            this.Id = Id;
            this.CompanyType = CompanyType;
            this.LegalName = LegalName;
            this.PayersNumber = PayersNumber;
            this.BankIdCode = BankIdCode;
            this.JurAdress = JurAdress;
        }
        public void CreateId(string Id, int num, string Bank)
        {
            if (num < 10)
            {
                IdCase(Id, "000", num, Bank);
            }
            else if (num < 100)
            {
                IdCase(Id, "00", num, Bank);
            }
            else if (num < 1000)
            {
                IdCase(Id, "0", num, Bank);
            }
        }

        private void IdCase(string Id, string zero, int num, string Bank)
        {
            this.Id = Id + zero + Convert.ToString(num) + Bank;
        }
    }
}
