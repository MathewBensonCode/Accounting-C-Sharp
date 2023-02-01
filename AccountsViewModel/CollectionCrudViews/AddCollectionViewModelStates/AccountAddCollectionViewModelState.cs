using AccountsModelCore.Classes.Accounts;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CommandViewModelFactories;
using AccountsViewModel.Repositories.Interfaces;

namespace AccountsViewModel.CollectionCrudViews.AddCollectionViewModelStates
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
