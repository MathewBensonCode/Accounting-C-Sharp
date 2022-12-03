using AccountLib.Model.Transactions;
using AccountLib.Interfaces.Accounts;
using AccountLib.Interfaces.SourceDocuments;
using AccountsViewModel.CollectionViewModels.Interfaces;

namespace AccountsViewModel.Factories.Interfaces.CollectionViewModelFactories
{
    public interface ITransactionCollectionViewModelFactory :
        ICollectionViewModelFactory<Transaction>
    {
        ITransactionCollectionViewModel GetDebitsCollectionViewModelForAccount(IAccount account);
        ITransactionCollectionViewModel GetCreditsCollectionViewModelForAccount(IAccount account);
        ITransactionCollectionViewModel GetTransactionCollectionViewModelForSourceDocument(ISourceDocument sourceDocument);
    }
}
