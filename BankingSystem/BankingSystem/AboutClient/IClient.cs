using BankingSystem.UserAut;

namespace BankingSystem.AboutClient
{
    internal interface IClient : IUser
    {
        public string? Surname { get; set; }
        public string? Name { get; set; }
        public string? PName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? PasportNum { get; set; }
    }

    internal interface Copy1OfIClient : Copy1OfIUser
    {
        public string? Surname { get; set; }
        public string? Name { get; set; }
        public string? PName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? PasportNum { get; set; }
    }

    internal interface CopyOfIClient : CopyOfIUser
    {
        public string? Surname { get; set; }
        public string? Name { get; set; }
        public string? PName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? PasportNum { get; set; }
    }
}
