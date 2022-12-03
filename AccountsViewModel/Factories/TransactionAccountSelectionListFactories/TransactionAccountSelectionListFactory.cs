using System.Collections.Generic;
using AccountLib.Model.Accounts;
using AccountLib.Model.Transactions;
using AccountsViewModel.Factories.Interfaces.TransactionAccountSelectionLists;

namespace AccountsViewModel.Factories.TransactionAccountSelectionListFactories
{
    public abstract class TransactionAccountSelectionListFactory<T>
        : ITransactionAccountSelectionListFactory<T>
        where T : Transaction
    {
        public abstract ICollection<Account> DebitAccountSelectionList { get; }

        public abstract ICollection<Account> CreditAccountSelectionList { get; }
    }
}
