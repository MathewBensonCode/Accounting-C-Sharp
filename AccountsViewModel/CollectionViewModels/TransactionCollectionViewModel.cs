using AccountLib.Model.Transactions;
using Accounts.Repositories;
using AccountsViewModel.Factories.Interfaces.CollectionCrudViewStateFactories;

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
