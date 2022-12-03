using AccountLib.Interfaces.Accounts;
using AccountLib.Model.TradeItems;

namespace AccountLib.Model.Accounts
{
    public class TradeItemAssetAccount : AssetAccount, ITradeItemAssetAccount
    {
        public int TradeItemId { get; set; }
        public virtual TradeItem TradeItemAsset { get; set; }
    }
}
