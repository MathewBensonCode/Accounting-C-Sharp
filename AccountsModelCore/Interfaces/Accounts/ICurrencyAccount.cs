using AccountsModelCore.Classes;

namespace AccountsModelCore.Interfaces.Accounts

{
    public interface ICurrencyAccount : IAccount
    {
        Country Country { get; set; }
    }
}
