using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsModelCore.Classes.Transactions;
using AccountsModelCore.Interfaces.SourceDocuments;
using AccountsModelCore.Interfaces.Accounts;

namespace AccountsViewModel.Factories.Interfaces.CollectionViewModelFactories
{
    public interface ITransactionChildCollectionViewModelFactory
    {
        IEntityCollectionViewModel<Transaction> GetDebitsCollectionViewModelForAccount(IAccount account);
        IEntityCollectionViewModel<Transaction> GetCreditsCollectionViewModelForAccount(IAccount account);
        IEntityCollectionViewModel<Transaction> GetTransactionCollectionViewModelForSourceDocument(ISourceDocument sourceDocument);
    }
}
