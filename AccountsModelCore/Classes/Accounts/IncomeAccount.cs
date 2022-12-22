using AccountsModelCore.Classes.TradeItems;
using AccountsModelCore.Interfaces.Accounts;

namespace AccountsModelCore.Classes.Accounts
{
    public class IncomeAccount : Account, IIncomeAccount

    {
        public int TradeItemId { get; set; }
        public virtual TradeItem TradeItem { get; set; }
    }
}
