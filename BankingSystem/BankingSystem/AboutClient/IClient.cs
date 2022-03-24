using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.AboutClient
{
    public interface IClient
    {
        public string? Surname { get; set; }
        public string? Name { get; set; }
        public string? PName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? ClientBank { get; }
    }
}
