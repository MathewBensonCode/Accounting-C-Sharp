using AccountsModelCore.Classes.TradeItems;

namespace AccountsModelCore.Interfaces.Accounts
{
    public interface IExpenseAccount : IAccount
    {
        int TradeItemId { get; set; }
        TradeItem TradeItem { get; set; }
    }
}
