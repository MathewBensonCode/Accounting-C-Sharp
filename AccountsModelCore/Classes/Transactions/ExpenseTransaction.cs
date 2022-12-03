using AccountLib.Interfaces.Transactions;
using AccountLib.Model.Accounts;
using System;

namespace AccountLib.Model.Transactions
{
    public class ExpenseTransaction :
        Transaction, IExpenseTransaction
    {
        public override Account DebitAccount
        {
            get
            {
                return base.DebitAccount;
            }

            set
            {
                if (value is ExpenseAccount)
                    base.DebitAccount = value;

                else
                    throw new ArgumentException("Invalid Account Type, Expense Account Expected");
            }
        }

        public override Account CreditAccount
        {
            get
            {
                return base.CreditAccount;
            }

            set
            {
                if (value is CurrencyAccount)
                    base.CreditAccount = value;

                else
                    throw new ArgumentException("Invalid Account Type, Currency Account Expected");
            }
        }
    }
}
