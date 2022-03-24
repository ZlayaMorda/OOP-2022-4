using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BankingSystem.AboutClient
{
    public class Client
    {
        public string? Surname { get; }
        public string? Name { get; }
        public string? PName { get; }
        public string? PhoneNumber { get; }
        public string? Email { get; }
        public string? ClientBank { get; }
        public string? Id { get; }

        public Client(string Surname, string Name, string PName, string PhoneNumber,
            string Email, string ClientBank, string Id)
        {

            this.Surname = Surname;
            this.Name = Name;
            this.PName = PName;
            this.PhoneNumber = Check(PhoneNumber, @"\+\d{12}");
            this.Email = Check(Email, "[.\\-_a-z0-9]+@([a-z0-9][\\-a-z0-9]+\\.)+[a-z]{2,6}");
            this.ClientBank = ClientBank;
            this.Id = Id;
        }

        private static string Check(string input, string reg)
        {
            Match isMatch = Regex.Match(input, reg, RegexOptions.IgnoreCase);
            if (isMatch != null)
            {
                return input;
            }
            else { return null; }
        }

    }
}
