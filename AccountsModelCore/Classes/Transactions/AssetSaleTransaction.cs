using AccountLib.Interfaces.Transactions;
using AccountLib.Model.Accounts;
using System;

namespace AccountLib.Model.Transactions
{
    public class AssetSaleTransaction :
        Transaction, IAssetSaleTransaction
    {
        public override Account CreditAccount
        {
            get
            {
                return base.CreditAccount;
            }

            set
            {
                if (value is TradeItemAssetAccount)
                    base.CreditAccount = value;

                else
                    throw new ArgumentException("Invalid Account type, Trade Item Asset Account Type Expected");
            }
        }

        public override Account DebitAccount
        {
            get
            {
                return base.DebitAccount;
            }

            set
            {
                if (value is CurrencyAccount)
                    base.DebitAccount = value;

                else
                    throw new ArgumentException("Invalid Account type, Currency Account Type Expected");
            }
        }
    }
}
