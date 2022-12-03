using AccountLib.Model.Accounts;
using Accounts.Repositories;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CollectionCrudViewStateFactories;
using Unity;

namespace AccountsViewModel.Factories.Unity.CollectionCrudViewStateFactories
{
    public class LiabilityAccountEditCollectionViewModelStateFactory
        : CollectionCrudEditViewStateFactory<LiabilityAccount>, ICollectionCrudEditViewStateFactory<Account>
    {
        public LiabilityAccountEditCollectionViewModelStateFactory(IUnityContainer container) : base(container)
        {
        }

        public ICollectionEditViewModelState<Account> CreateEntityEditView(IEntityCollectionViewModel<Account> collectionViewModel, IRepository<Account> repository, ICollectionListViewModelState<Account> listViewModelState)
        {
            return base.CreateEntityEditView(collectionViewModel as IEntityCollectionViewModel<LiabilityAccount>, repository as IRepository<LiabilityAccount>, listViewModelState as ICollectionListViewModelState<LiabilityAccount>) as ICollectionEditViewModelState<Account>;
        }
    }
}
