using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.AboutClient
{
    internal interface ICompany
    {
        public string CompanyType { get; set; }
        public string LegalName { get; set; }
        public string PayersNumber { get; set; }
        public string BankIdCode { get; set; }
        public string JurAdress { get; set; }
    }
}
