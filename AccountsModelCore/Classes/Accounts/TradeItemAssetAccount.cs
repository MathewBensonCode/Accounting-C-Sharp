using AccountsModelCore.Classes.TradeItems;
using AccountsModelCore.Interfaces.Accounts;

namespace AccountsModelCore.Classes.Accounts
{
    public class TradeItemAssetAccount : AssetAccount, ITradeItemAssetAccount
    {
        public int TradeItemId { get; set; }
        public virtual TradeItem TradeItemAsset { get; set; }
    }
}
