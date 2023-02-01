using AccountsModelCore.Classes.TradeItems;
using AccountsModelCore.Interfaces.Accounts;

namespace AccountsModelCore.Classes.Accounts
{
    public class ExpenseAccount : Account, IExpenseAccount
    {
        public int TradeItemId { get; set; }
        public virtual TradeItem TradeItem { get; set; }
    }
}
