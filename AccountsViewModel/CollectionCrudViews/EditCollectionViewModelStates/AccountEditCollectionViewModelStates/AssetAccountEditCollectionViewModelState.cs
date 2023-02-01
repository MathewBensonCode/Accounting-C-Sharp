using AccountsModelCore.Classes.Accounts;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CommandViewModelFactories;
using AccountsViewModel.Repositories.Interfaces;

namespace AccountsViewModel.CollectionCrudViews.EditCollectionViewModelStates.AccountEditCollectionViewModelStates
{
    public class AssetAccountEditCollectionViewModelState
        : EditEntityInCollectionViewModelState<AssetAccount>, ICollectionEditViewModelState<AssetAccount>
    {
        public AssetAccountEditCollectionViewModelState(
            ICollectionListViewModelState<AssetAccount> listViewModelState,
            IRepository<AssetAccount> repository,
            IEntityCollectionViewModel<AssetAccount> collectionViewModel,
            ICommandViewModelFactory<AssetAccount> commandFactory
            ) : base(listViewModelState, repository, collectionViewModel, commandFactory)
        {
        }
    }
}
