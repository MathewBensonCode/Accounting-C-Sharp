using AccountsModelCore.Classes.TradeItems;

namespace AccountsModelCore.Interfaces.Accounts
{
    public interface IIncomeAccount : IAccount
    {
        int TradeItemId { get; set; }
        TradeItem TradeItem { get; set; }
    }
}
