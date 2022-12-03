using AccountLib.Model.Accounts;
using Accounts.Repositories;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CommandViewModelFactories;

namespace AccountsViewModel.CollectionCrudViews
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
