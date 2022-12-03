using AccountLib.Model.Accounts;
using Accounts.Repositories;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CollectionCrudViewStateFactories;
using Unity;

namespace AccountsViewModel.Factories.Unity.CollectionCrudViewStateFactories
{
    public class AssetAccountListCollectionViewModelStateFactory
        : CollectionCrudListViewStateFactory<AssetAccount>, ICollectionCrudListViewStateFactory<Account>
    {
        public AssetAccountListCollectionViewModelStateFactory(IUnityContainer container) : base(container)
        {
        }

        public ICollectionListViewModelState<Account> CreateEntityListView(IEntityCollectionViewModel<Account> collectionvm, IRepository<Account> repository)
        {
           return base.CreateEntityListView(collectionvm as IEntityCollectionViewModel<AssetAccount>, repository as IRepository<AssetAccount>) as ICollectionListViewModelState<Account>;
        }
    }
}
