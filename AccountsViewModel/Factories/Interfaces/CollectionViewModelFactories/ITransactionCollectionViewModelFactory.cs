using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsModelCore.Classes.Transactions;
using AccountsModelCore.Interfaces.SourceDocuments;
using AccountsModelCore.Interfaces.Accounts;

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
