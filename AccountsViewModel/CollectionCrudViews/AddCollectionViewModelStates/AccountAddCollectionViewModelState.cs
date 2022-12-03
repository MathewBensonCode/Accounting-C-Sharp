using AccountLib.Model.Accounts;
using Accounts.Repositories;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CommandViewModelFactories;

namespace AccountsViewModel.CollectionCrudViews
{
    public class AccountAddCollectionViewModelState
        : AddNewEntityToCollectionViewModelState<Account>, ICollectionAddViewModelState<Account>
    {
        public AccountAddCollectionViewModelState(
            ICollectionListViewModelState<Account> listViewModelState,
            IRepository<Account> repository,
            IEntityCollectionViewModel<Account> collectionViewModel,
            ICommandViewModelFactory<Account> commandfactory
            ) : base(listViewModelState, repository, collectionViewModel, commandfactory)
        {
        }
    }
}
