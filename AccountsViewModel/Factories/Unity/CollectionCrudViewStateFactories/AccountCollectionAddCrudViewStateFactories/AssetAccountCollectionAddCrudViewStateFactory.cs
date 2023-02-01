using AccountsModelCore.Classes.Accounts;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CollectionCrudViewStateFactories;
using AccountsViewModel.Repositories.Interfaces;
using Unity;

namespace AccountsViewModel.Factories.Unity.CollectionCrudViewStateFactories.AccountCollectionAddCrudViewStateFactories
{
    public class AssetAccountAddCollectionViewModelStateFactory
        : CollectionCrudAddViewStateFactory<AssetAccount>, ICollectionCrudAddViewStateFactory<Account>
    {
        public AssetAccountAddCollectionViewModelStateFactory(IUnityContainer container) : base(container)
        {
        }

        public ICollectionAddViewModelState<Account> CreateEntityAddViewState(ICollectionListViewModelState<Account> liststate, IRepository<Account> repository, IEntityCollectionViewModel<Account> collectionViewModel)
        {
            return CreateEntityAddViewState(liststate as ICollectionListViewModelState<AssetAccount>, repository as IRepository<AssetAccount>, collectionViewModel as IEntityCollectionViewModel<AssetAccount>) as ICollectionAddViewModelState<Account>;
        }
    }
}
