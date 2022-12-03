using AccountLib.Model.Accounts;
using Accounts.Repositories;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CommandViewModelFactories;

namespace AccountsViewModel.CollectionCrudViews
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
