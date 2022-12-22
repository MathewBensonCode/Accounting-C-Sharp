using System.Collections.Generic;
using AccountsModelCore.Classes.Transactions;

namespace AccountsModelCore.Interfaces.Accounts
{
    public interface IAccount
       : IDbModel
    {
        string Name { get; set; }
        ICollection<Transaction> Debits { get; set; }
        ICollection<Transaction> Credits { get; set; }
    }
}
