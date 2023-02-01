using AccountsModelCore.Classes.Transactions;
using AccountsViewModel.Factories.Interfaces.CollectionCrudViewStateFactories;
using AccountsViewModel.Repositories.Interfaces;

namespace AccountsViewModel.CollectionViewModels
{
    public class TransactionCollectionViewModel
        : EntityCollectionViewModel<Transaction>
    {
        public TransactionCollectionViewModel(
            IRepository<Transaction> repository,
            ICollectionCrudListViewStateFactory<Transaction> viewstatefactory
            ) : base(repository, viewstatefactory)
        {
        }
    }
}
