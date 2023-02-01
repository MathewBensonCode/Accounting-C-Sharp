using System;
using AccountsModelCore.Classes.Accounts;
using AccountsModelCore.Interfaces.Transactions;

namespace AccountsModelCore.Classes.Transactions
{
    public class IncomeTransaction :
        Transaction, IIncomeTransaction
    {
        public override Account DebitAccount
        {
            get => base.DebitAccount;

            set => base.DebitAccount = value is CurrencyAccount ? value : throw new ArgumentException("Invalid Account Type, Currency Account Expected");
        }

        public override Account CreditAccount
        {
            get => base.CreditAccount;

            set => base.CreditAccount = value is IncomeAccount ? value : throw new ArgumentException("Invalid Account Type, Income Account Expected");
        }
    }
}
