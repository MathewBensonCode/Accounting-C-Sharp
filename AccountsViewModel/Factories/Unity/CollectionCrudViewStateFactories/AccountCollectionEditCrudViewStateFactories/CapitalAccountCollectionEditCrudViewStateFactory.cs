using AccountLib.Model.Accounts;
using Accounts.Repositories;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CollectionCrudViewStateFactories;
using Unity;

namespace AccountsViewModel.Factories.Unity.CollectionCrudViewStateFactories
{
    public class CapitalAccountEditCollectionViewModelStateFactory
        : CollectionCrudEditViewStateFactory<CapitalAccount>, ICollectionCrudEditViewStateFactory<Account>
    {
        public CapitalAccountEditCollectionViewModelStateFactory(IUnityContainer container) : base(container)
        {
        }

        public ICollectionEditViewModelState<Account> CreateEntityEditView(IEntityCollectionViewModel<Account> collectionViewModel, IRepository<Account> repository, ICollectionListViewModelState<Account> listViewModelState)
        {
            return base.CreateEntityEditView(collectionViewModel as IEntityCollectionViewModel<CapitalAccount>, repository as IRepository<CapitalAccount>, listViewModelState as ICollectionListViewModelState<CapitalAccount>) as ICollectionEditViewModelState<Account>;
        }
    }
}
