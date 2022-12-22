using AccountsModelCore.Classes.Accounts;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CommandViewModelFactories;
using AccountsViewModel.Repositories.Interfaces;

namespace AccountsViewModel.CollectionCrudViews.EditCollectionViewModelStates.AccountEditCollectionViewModelStates
{
    public class CapitalAccountEditCollectionViewModelState
        : EditEntityInCollectionViewModelState<CapitalAccount>, ICollectionEditViewModelState<CapitalAccount>
    {
        public CapitalAccountEditCollectionViewModelState(
            ICollectionListViewModelState<CapitalAccount> listViewModelState,
            IRepository<CapitalAccount> repository,
            IEntityCollectionViewModel<CapitalAccount> collectionViewModel,
            ICommandViewModelFactory<CapitalAccount> commandFactory
            ) : base(listViewModelState, repository, collectionViewModel, commandFactory)
        {
        }
    }
}
