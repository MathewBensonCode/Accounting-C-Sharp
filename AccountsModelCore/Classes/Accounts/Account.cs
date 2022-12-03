using System.Collections.Generic;
using AccountLib.Interfaces;
using AccountLib.Interfaces.Accounts;
using AccountLib.Model.Transactions;

namespace AccountLib.Model.Accounts
{
    public abstract class Account : IAccount, IDbModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Transaction> Debits { get; set; }

        public virtual ICollection<Transaction> Credits { get; set; }
    }
}
