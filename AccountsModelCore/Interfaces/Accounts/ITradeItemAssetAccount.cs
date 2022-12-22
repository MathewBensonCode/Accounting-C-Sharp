using AccountsModelCore.Classes.TradeItems;

namespace AccountsModelCore.Interfaces.Accounts
{
    public interface ITradeItemAssetAccount : IAccount
    {
        int TradeItemId { get; set; }
        TradeItem TradeItemAsset { get; set; }
    }
}
