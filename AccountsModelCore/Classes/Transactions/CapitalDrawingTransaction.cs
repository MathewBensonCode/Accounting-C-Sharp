using System;
using AccountLib.Interfaces.Transactions;
using AccountLib.Model.Accounts;

namespace AccountLib.Model.Transactions
{
    public class CapitalDrawingTransaction :
        Transaction, ICapitalDrawingTransaction
    {
        public override Account DebitAccount
        {
            get
            {
                return base.DebitAccount;
            }

            set
            {
                if (value is CapitalAccount)
                    base.DebitAccount = value;

                else
                    throw new ArgumentException("Invalid Account Type, Capital Account Excpected");
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
