using AccountLib.Model.Transactions;
using AccountLib.Interfaces.Accounts;
using AccountLib.Interfaces.SourceDocuments;
using AccountsViewModel.CollectionViewModels.Interfaces;

namespace AccountsViewModel.Factories.Interfaces.CollectionViewModelFactories
{
    public interface ITransactionChildCollectionViewModelFactory
    {
        IEntityCollectionViewModel<Transaction> GetDebitsCollectionViewModelForAccount(IAccount account);
        IEntityCollectionViewModel<Transaction> GetCreditsCollectionViewModelForAccount(IAccount account);
        IEntityCollectionViewModel<Transaction> GetTransactionCollectionViewModelForSourceDocument(ISourceDocument sourceDocument);
    }
}
