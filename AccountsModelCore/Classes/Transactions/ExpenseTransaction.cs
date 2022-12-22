using System;
using AccountsModelCore.Classes.Accounts;
using AccountsModelCore.Interfaces.Transactions;

namespace AccountsModelCore.Classes.Transactions
{
    public class ExpenseTransaction :
        Transaction, IExpenseTransaction
    {
        public override Account DebitAccount
        {
            get => base.DebitAccount;

            set => base.DebitAccount = value is ExpenseAccount ? value : throw new ArgumentException("Invalid Account Type, Expense Account Expected");
        }

        public override Account CreditAccount
        {
            get => base.CreditAccount;

            set => base.CreditAccount = value is CurrencyAccount ? value : throw new ArgumentException("Invalid Account Type, Currency Account Expected");
        }
    }
}
