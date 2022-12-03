using AccountLib.Interfaces.Accounts;
using AccountLib.Model.TradeItems;

namespace AccountLib.Model.Accounts
{
    public class ExpenseAccount : Account, IExpenseAccount
    {
        public int TradeItemId { get; set; }
        public virtual TradeItem TradeItem { get; set; }
    }
}
