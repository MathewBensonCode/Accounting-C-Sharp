using AccountsModelCore.Classes.TradeItems;

namespace AccountsModelCore.Interfaces.TradeItems
{
    public interface ISubTradeItem
    {
        int TradeItemId { get; set; }
        TradeItem ParentTradeItem { get; set; }
    }
}
