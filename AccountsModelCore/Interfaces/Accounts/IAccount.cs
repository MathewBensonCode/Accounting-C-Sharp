using System.Collections.Generic;
using AccountLib.Model.Transactions;

namespace AccountLib.Interfaces.Accounts
{
    public interface IAccount
       : IDbModel
    {
        string Name { get; set; }
        ICollection<Transaction> Debits { get; set; }
        ICollection<Transaction> Credits { get; set; }
    }
}
