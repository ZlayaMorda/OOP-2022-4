using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.AboutClient
{
    internal interface ISalary
    {
        public string Company { get;}
        public string AccId { get; set; }
        public string Sum { get; set; }
        public string Mounth { get; set; }
    }
}
