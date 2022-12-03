using AccountLib.Model.Accounts;
using Accounts.Repositories;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CollectionCrudViewStateFactories;
using Unity;

namespace AccountsViewModel.Factories.Unity.CollectionCrudViewStateFactories
{
    public class CapitalAccountAddCollectionViewModelStateFactory
        : CollectionCrudAddViewStateFactory<CapitalAccount>, ICollectionCrudAddViewStateFactory<Account>
    {
        public CapitalAccountAddCollectionViewModelStateFactory(IUnityContainer container) : base(container)
        {
        }

        public ICollectionAddViewModelState<Account> CreateEntityAddViewState(ICollectionListViewModelState<Account> liststate, IRepository<Account> repository, IEntityCollectionViewModel<Account> collectionViewModel)
        {
            return base.CreateEntityAddViewState(liststate as ICollectionListViewModelState<CapitalAccount>, repository as IRepository<CapitalAccount>, collectionViewModel as IEntityCollectionViewModel<CapitalAccount>) as ICollectionAddViewModelState<Account>;
        }
    }
}
