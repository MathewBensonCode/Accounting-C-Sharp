using AccountLib.Interfaces.Accounts;

namespace AccountLib.Model.Accounts
{
    public class CurrencyAccount
        : AssetAccount, ICurrencyAccount
    {
        public virtual Country Country { get; set; }
    }
}
