using AccountsModelCore.Classes.Accounts;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CollectionCrudViewStateFactories;
using AccountsViewModel.Repositories.Interfaces;
using Unity;

namespace AccountsViewModel.Factories.Unity.CollectionCrudViewStateFactories.AccountCollectionAddCrudViewStateFactories
{
    public class LiabilityAccountAddCollectionViewModelStateFactory
        : CollectionCrudAddViewStateFactory<LiabilityAccount>, ICollectionCrudAddViewStateFactory<Account>
    {
        public LiabilityAccountAddCollectionViewModelStateFactory(IUnityContainer container) : base(container)
        {
        }

        public ICollectionAddViewModelState<Account> CreateEntityAddViewState(ICollectionListViewModelState<Account> liststate, IRepository<Account> repository, IEntityCollectionViewModel<Account> collectionViewModel)
        {
            return CreateEntityAddViewState(liststate as ICollectionListViewModelState<LiabilityAccount>, repository as IRepository<LiabilityAccount>, collectionViewModel as IEntityCollectionViewModel<LiabilityAccount>) as ICollectionAddViewModelState<Account>;
        }
    }
}
