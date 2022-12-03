using AccountLib.Interfaces.Accounts;
using AccountLib.Model.TradeItems;

namespace AccountLib.Model.Accounts
{
    public class IncomeAccount : Account, IIncomeAccount

    {
        public int TradeItemId { get; set; }
        public virtual TradeItem TradeItem { get; set; }
    }
}
