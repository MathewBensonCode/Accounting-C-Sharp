using System.Collections.Generic;
using AccountsModelCore.Classes.Accounts;
using AccountsModelCore.Classes.Transactions;

namespace AccountsViewModel.Factories.Interfaces.TransactionAccountSelectionLists
{
    public interface ITransactionAccountSelectionListFactory<T> where T : Transaction
    {
        ICollection<Account> DebitAccountSelectionList { get; }
        ICollection<Account> CreditAccountSelectionList { get; }
    }
}
