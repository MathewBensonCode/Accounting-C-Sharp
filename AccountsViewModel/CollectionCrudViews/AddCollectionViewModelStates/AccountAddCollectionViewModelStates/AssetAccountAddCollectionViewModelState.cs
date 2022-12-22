using AccountsModelCore.Classes.Accounts;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CommandViewModelFactories;
using AccountsViewModel.Repositories.Interfaces;

namespace AccountsViewModel.CollectionCrudViews.AddCollectionViewModelStates.AccountAddCollectionViewModelStates
{
    public class AssetAccountAddCollectionViewModelState
        : AddNewEntityToCollectionViewModelState<AssetAccount>, ICollectionAddViewModelState<AssetAccount>
    {
        public AssetAccountAddCollectionViewModelState(
            ICollectionListViewModelState<AssetAccount> listViewModelState,
            IRepository<AssetAccount> repository,
            IEntityCollectionViewModel<AssetAccount> collectionViewModel,
            ICommandViewModelFactory<AssetAccount> commandfactory
            ) : base(listViewModelState, repository, collectionViewModel, commandfactory)
        {
        }
    }
}
