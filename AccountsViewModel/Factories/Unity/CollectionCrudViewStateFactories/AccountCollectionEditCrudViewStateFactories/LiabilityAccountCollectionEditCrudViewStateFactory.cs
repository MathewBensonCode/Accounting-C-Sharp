using AccountsModelCore.Classes.Accounts;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CollectionCrudViewStateFactories;
using AccountsViewModel.Repositories.Interfaces;
using Unity;

namespace AccountsViewModel.Factories.Unity.CollectionCrudViewStateFactories.AccountCollectionEditCrudViewStateFactories
{
    public class LiabilityAccountEditCollectionViewModelStateFactory
        : CollectionCrudEditViewStateFactory<LiabilityAccount>, ICollectionCrudEditViewStateFactory<Account>
    {
        public LiabilityAccountEditCollectionViewModelStateFactory(IUnityContainer container) : base(container)
        {
        }

        public ICollectionEditViewModelState<Account> CreateEntityEditView(IEntityCollectionViewModel<Account> collectionViewModel, IRepository<Account> repository, ICollectionListViewModelState<Account> listViewModelState)
        {
            return CreateEntityEditView(collectionViewModel as IEntityCollectionViewModel<LiabilityAccount>, repository as IRepository<LiabilityAccount>, listViewModelState as ICollectionListViewModelState<LiabilityAccount>) as ICollectionEditViewModelState<Account>;
        }
    }
}
