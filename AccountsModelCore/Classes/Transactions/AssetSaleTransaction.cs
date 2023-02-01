using AccountsModelCore.Classes.Accounts;
using AccountsModelCore.Interfaces.Transactions;
using System;

namespace AccountsModelCore.Classes.Transactions
{
    public class AssetSaleTransaction :
        Transaction, IAssetSaleTransaction
    {
        public override Account CreditAccount
        {
            get => base.CreditAccount;

            set => base.CreditAccount = value is TradeItemAssetAccount
                    ? value
                    : throw new ArgumentException("Invalid Account type, Trade Item Asset Account Type Expected");
        }

        public override Account DebitAccount
        {
            get => base.DebitAccount;

            set => base.DebitAccount = value is CurrencyAccount ? value : throw new ArgumentException("Invalid Account type, Currency Account Type Expected");
        }
    }
}
