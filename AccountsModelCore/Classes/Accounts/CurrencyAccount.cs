using AccountsModelCore.Interfaces.Accounts;

namespace AccountsModelCore.Classes.Accounts
{
    public class CurrencyAccount
        : AssetAccount, ICurrencyAccount
    {
        public virtual Country Country { get; set; }
    }
}
