using AccountLib.Interfaces.TradeItems;

namespace AccountLib.Model.TradeItems
{
    public class SubTradeItem : TradeItem, ISubTradeItem
    {
        public int TradeItemId { get; set; }
        public virtual TradeItem ParentTradeItem { get; set; }
    }
}
