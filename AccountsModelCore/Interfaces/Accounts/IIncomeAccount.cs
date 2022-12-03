using AccountLib.Model.TradeItems;

namespace AccountLib.Interfaces.Accounts
{
    public interface IIncomeAccount : IAccount
    {
        int TradeItemId { get; set; }
        TradeItem TradeItem { get; set; }
    }
}
