using AccountLib.Model.Accounts;
using Accounts.Repositories;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CollectionCrudViewStateFactories;
using Unity;

namespace AccountsViewModel.Factories.Unity.CollectionCrudViewStateFactories
{
    public class AssetAccountEditCollectionViewModelStateFactory
        : CollectionCrudEditViewStateFactory<AssetAccount>, ICollectionCrudEditViewStateFactory<Account>
    {
        public AssetAccountEditCollectionViewModelStateFactory(IUnityContainer container) : base(container)
        {
        }

        public ICollectionEditViewModelState<Account> CreateEntityEditView(IEntityCollectionViewModel<Account> collectionViewModel, IRepository<Account> repository, ICollectionListViewModelState<Account> listViewModelState)
        {
            return base.CreateEntityEditView(collectionViewModel as IEntityCollectionViewModel<AssetAccount>, repository as IRepository<AssetAccount>, listViewModelState as ICollectionListViewModelState<AssetAccount>) as ICollectionEditViewModelState<Account>;
        }
    }
}
