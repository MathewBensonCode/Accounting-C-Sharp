using AccountsModelCore.Classes.Accounts;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CommandViewModelFactories;
using AccountsViewModel.Repositories.Interfaces;

namespace AccountsViewModel.CollectionCrudViews.AddCollectionViewModelStates.AccountAddCollectionViewModelStates
{
    public class CapitalAccountAddCollectionViewModelState
        : AddNewEntityToCollectionViewModelState<CapitalAccount>, ICollectionAddViewModelState<CapitalAccount>
    {
        public CapitalAccountAddCollectionViewModelState(
            ICollectionListViewModelState<CapitalAccount> listViewModelState,
            IRepository<CapitalAccount> repository,
            IEntityCollectionViewModel<CapitalAccount> collectionViewModel,
            ICommandViewModelFactory<CapitalAccount> commandfactory
            ) : base(listViewModelState, repository, collectionViewModel, commandfactory)
        {
        }
    }
}
