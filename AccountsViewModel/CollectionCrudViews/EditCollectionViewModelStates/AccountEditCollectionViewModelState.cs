using AccountLib.Model.Accounts;
using Accounts.Repositories;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CommandViewModelFactories;

namespace AccountsViewModel.CollectionCrudViews
{
    public class AccountEditCollectionViewModelState
        : EditEntityInCollectionViewModelState<Account>, ICollectionEditViewModelState<Account>
    {
        public AccountEditCollectionViewModelState(
            ICollectionListViewModelState<Account> listViewModelState,
            IRepository<Account> repository,
            IEntityCollectionViewModel<Account> collectionViewModel,
            ICommandViewModelFactory<Account> commandFactory) : base(listViewModelState, repository, collectionViewModel, commandFactory)
        {
        }
    }
}
