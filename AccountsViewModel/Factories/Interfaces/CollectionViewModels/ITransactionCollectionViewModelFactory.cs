using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsModelCore.Classes.Transactions;
using AccountsModelCore.Interfaces.SourceDocuments;
using AccountsModelCore.Interfaces.Accounts;

namespace AccountsViewModel.Factories.Interfaces.CollectionViewModels
{
    public interface ITransactionCollectionViewModelFactory
    {
        IEntityCollectionViewModel<Transaction> CreateDebitsViewModelForAccount(IAccount account);
        IEntityCollectionViewModel<Transaction> CreateCreditsViewModelForAccount(IAccount account);
        IEntityCollectionViewModel<Transaction> CreateTransactionCollectionViewModelForSourcedocument(ISourceDocument sourceDocument);
    }
}
