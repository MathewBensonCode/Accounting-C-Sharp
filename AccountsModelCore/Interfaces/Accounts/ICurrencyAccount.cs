using AccountLib.Model;

namespace AccountLib.Interfaces.Accounts

{
    public interface ICurrencyAccount : IAccount
    {
        Country Country { get; set; }
    }
}
