using AccountLib.Model.Accounts;
using Accounts.Repositories;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CollectionCrudViewStateFactories;
using Unity;

namespace AccountsViewModel.Factories.Unity.CollectionCrudViewStateFactories
{
    public class LiabilityAccountAddCollectionViewModelStateFactory
        : CollectionCrudAddViewStateFactory<LiabilityAccount>, ICollectionCrudAddViewStateFactory<Account>
    {
        public LiabilityAccountAddCollectionViewModelStateFactory(IUnityContainer container) : base(container)
        {
        }

        public ICollectionAddViewModelState<Account> CreateEntityAddViewState(ICollectionListViewModelState<Account> liststate, IRepository<Account> repository, IEntityCollectionViewModel<Account> collectionViewModel)
        {
            return base.CreateEntityAddViewState(liststate as ICollectionListViewModelState<LiabilityAccount>, repository as IRepository<LiabilityAccount>, collectionViewModel as IEntityCollectionViewModel<LiabilityAccount>) as ICollectionAddViewModelState<Account>;
        }
    }
}
