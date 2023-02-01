using System.Collections.Generic;
using AccountsModelCore.Classes.Transactions;
using AccountsModelCore.Interfaces;
using AccountsModelCore.Interfaces.Accounts;

namespace AccountsModelCore.Classes.Accounts
{
    public abstract class Account : IAccount, IDbModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Transaction> Debits { get; set; }

        public virtual ICollection<Transaction> Credits { get; set; }
    }
}
