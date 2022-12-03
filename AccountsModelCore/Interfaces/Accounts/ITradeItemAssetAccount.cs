using AccountLib.Model.TradeItems;

namespace AccountLib.Interfaces.Accounts
{
    public interface ITradeItemAssetAccount : IAccount
    {
        int TradeItemId { get; set; }
        TradeItem TradeItemAsset { get; set; }
    }
}
