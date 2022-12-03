using AccountLib.Model.Accounts;
using Accounts.Repositories;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CommandViewModelFactories;

namespace AccountsViewModel.CollectionCrudViews
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
