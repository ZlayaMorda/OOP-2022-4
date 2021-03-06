

namespace BankingSystem.UserAut
{
    internal interface IUser
    {
        string? LoginText { get; set; }
        string? PasswordText { get; set; }
        string? Message { get;  set; }
        string? Bank { get; }
        string? Member { get; }

    }

    internal interface Copy1OfIUser
    {
        string? LoginText { get; set; }
        string? PasswordText { get; set; }
        string? Message { get; set; }
        string? Bank { get; }
        string? Member { get; }

    }

    internal interface CopyOfIUser
    {
        string? LoginText { get; set; }
        string? PasswordText { get; set; }
        string? Message { get; set; }
        string? Bank { get; }
        string? Member { get; }

    }
}
