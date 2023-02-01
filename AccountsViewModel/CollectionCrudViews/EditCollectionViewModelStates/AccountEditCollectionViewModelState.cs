using AccountsModelCore.Classes.Accounts;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CommandViewModelFactories;
using AccountsViewModel.Repositories.Interfaces;

namespace AccountsViewModel.CollectionCrudViews.EditCollectionViewModelStates
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
