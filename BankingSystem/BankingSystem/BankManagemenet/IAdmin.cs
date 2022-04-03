using BankingSystem.UserAut;
namespace BankingSystem.BankManagement
{
    internal interface IAdmin
    {
        public string Id { get; set; }
        public Bank Bank { get; set; }

        public void Show(ListBox list, string choose);
        public void Approve(ListBox list, string choose);
        public void Deny(ListBox list, string choose);
        public void Add(IUser user);
    }
}
