using AccountsModelCore.Interfaces.TradeItems;

namespace AccountsModelCore.Classes.TradeItems
{
    public class SubTradeItem : TradeItem, ISubTradeItem
    {
        public int TradeItemId { get; set; }
        public virtual TradeItem ParentTradeItem { get; set; }
    }
}
