using BankingSystem.Loading;

namespace BankingSystem.AboutClient
{
    internal class Client
    {
        public string Surname { get; }
        public string Name { get; }
        public string PName { get; }
        public string PhoneNumber { get; }
        public string Email { get; }
        public string ClientBank { get; }
        public string Id { get; set; }
        public string Pasport { get; }

        public Client(string Surname, string Name, string PName, string PhoneNumber,
            string Email, string ClientBank, string Pasport, string Id)
        {

            this.Surname = Surname;
            this.Name = Name;
            this.PName = PName;
            this.PhoneNumber = PhoneNumber;
            this.Email = Email;
            this.ClientBank = ClientBank;
            this.Pasport = Pasport;
            this.Id = Id;
        }

        public void Send(string fileName)
        {
            Load<string, Client> loadCl = new(this.ClientBank, fileName);
            loadCl.AddToFile(this, this.Id);
        }
    }
}
