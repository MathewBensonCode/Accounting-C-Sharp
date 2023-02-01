using System;
using AccountsModelCore.Classes.Accounts;
using AccountsModelCore.Interfaces.Transactions;

namespace AccountsModelCore.Classes.Transactions
{
    public class CapitalDrawingTransaction :
        Transaction, ICapitalDrawingTransaction
    {
        public override Account DebitAccount
        {
            get => base.DebitAccount;

            set => base.DebitAccount = value is CapitalAccount ? value : throw new ArgumentException("Invalid Account Type, Capital Account Excpected");
        }

        public override Account CreditAccount
        {
            get => base.CreditAccount;

            set => base.CreditAccount = value is CurrencyAccount ? value : throw new ArgumentException("Invalid Account Type, Currency Account Expected");
        }
    }
}
