using BankingSystem.UserAut;

namespace BankingSystem.AboutClient
{
    public interface IClient : IUser
    {
        public string? Surname { get; set; }
        public string? Name { get; set; }
        public string? PName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? PasportNum { get; set; }
        //public string? Email { get; set; }
        //public string? ClientBank { get; }
    }
}
