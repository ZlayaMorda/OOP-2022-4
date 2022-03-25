

namespace BankingSystem.UserAut
{
    public interface IUser
    {
        string? LoginText { get; set; }
        string? PasswordText { get; set; }
        string? Message { get;  set; }
        string? Bank { get; }

    }
}
