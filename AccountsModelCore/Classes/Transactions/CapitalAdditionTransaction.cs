﻿using System;
using AccountLib.Interfaces.Transactions;
using AccountLib.Model.Accounts;

namespace AccountLib.Model.Transactions
{
    public class CapitalAdditionTransaction :
        Transaction, ICapitalAdditionTransaction
    {
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
                    throw new ArgumentException("Invalid Account Type, Currency Account Expected");
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
                if (value is CapitalAccount)
                    base.CreditAccount = value;

                else
                    throw new ArgumentException("Invalid Account Type, Capital Account Expected");
            }
        }
    }
}