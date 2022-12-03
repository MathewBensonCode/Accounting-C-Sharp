using AccountLib.Interfaces.Accounts;
using AccountLib.Interfaces.SourceDocuments;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountLib.Model.Transactions;

namespace AccountsViewModel.Factories.Interfaces.CollectionViewModels
{
    public interface ITransactionCollectionViewModelFactory
    {
        IEntityCollectionViewModel<Transaction> CreateDebitsViewModelForAccount(IAccount account);
        IEntityCollectionViewModel<Transaction> CreateCreditsViewModelForAccount(IAccount account);
        IEntityCollectionViewModel<Transaction> CreateTransactionCollectionViewModelForSourcedocument(ISourceDocument sourceDocument);
    }
}
