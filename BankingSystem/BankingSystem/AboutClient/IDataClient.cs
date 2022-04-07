using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.AboutClient
{
    internal interface IDataClient
    {
        public string HomeId { get;}
        public string AlienId { get; set; } 
        public string Sum { get; }
        public string Nature { get; }
        public string? Currency { get; }
        public string? ToReg { get; }
        public string? Month { get; }
    }
}
