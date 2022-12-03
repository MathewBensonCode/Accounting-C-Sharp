using AccountLib.Model.Accounts;
using AccountLib.Model.Transactions;
using System.Collections.Generic;

namespace AccountsViewModel.Factories.Interfaces.TransactionAccountSelectionLists
{
    public interface ITransactionAccountSelectionListFactory<T> where T:Transaction
    {
        ICollection<Account> DebitAccountSelectionList { get; }
        ICollection<Account> CreditAccountSelectionList { get; }
    }
}
