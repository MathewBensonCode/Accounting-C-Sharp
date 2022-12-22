using AccountsModelCore.Classes.Accounts;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CollectionCrudViewStateFactories;
using AccountsViewModel.Repositories.Interfaces;
using Unity;

namespace AccountsViewModel.Factories.Unity.CollectionCrudViewStateFactories.AccountCollectionEditCrudViewStateFactories
{
    public class AssetAccountEditCollectionViewModelStateFactory
        : CollectionCrudEditViewStateFactory<AssetAccount>, ICollectionCrudEditViewStateFactory<Account>
    {
        public AssetAccountEditCollectionViewModelStateFactory(IUnityContainer container) : base(container)
        {
        }

        public ICollectionEditViewModelState<Account> CreateEntityEditView(IEntityCollectionViewModel<Account> collectionViewModel, IRepository<Account> repository, ICollectionListViewModelState<Account> listViewModelState)
        {
            return CreateEntityEditView(collectionViewModel as IEntityCollectionViewModel<AssetAccount>, repository as IRepository<AssetAccount>, listViewModelState as ICollectionListViewModelState<AssetAccount>) as ICollectionEditViewModelState<Account>;
        }
    }
}
