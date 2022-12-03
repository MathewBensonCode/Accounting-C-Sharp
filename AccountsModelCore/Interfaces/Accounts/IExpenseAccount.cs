using AccountLib.Model.TradeItems;

namespace AccountLib.Interfaces.Accounts
{
    public interface IExpenseAccount : IAccount
    {
        int TradeItemId { get; set; }
        TradeItem TradeItem { get; set; }
    }
}
