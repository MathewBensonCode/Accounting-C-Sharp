using AccountLib.Model.TradeItems;

namespace AccountLib.Interfaces.TradeItems
{
    public interface ISubTradeItem
    {
        int TradeItemId { get; set; }
        TradeItem ParentTradeItem { get; set; }
    }
}
