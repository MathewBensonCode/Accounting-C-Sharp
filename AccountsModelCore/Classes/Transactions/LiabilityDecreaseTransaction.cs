using System;
using AccountsModelCore.Classes.Accounts;
using AccountsModelCore.Interfaces.Transactions;

namespace AccountsModelCore.Classes.Transactions
{
    public class LiabilityDecreaseTransaction :
        Transaction, ILiabilityDecreaseTransaction
    {
        public override Account DebitAccount
        {
            get => base.DebitAccount;

            set => base.DebitAccount = value is LiabilityAccount ? value : throw new ArgumentException("Invalid Account Type, Liability Account Expected");
        }

        public override Account CreditAccount
        {
            get => base.CreditAccount;

            set => base.CreditAccount = value is CurrencyAccount ? value : throw new ArgumentException("Invalid Account Type, Currency Account Expected");
        }
    }
}
