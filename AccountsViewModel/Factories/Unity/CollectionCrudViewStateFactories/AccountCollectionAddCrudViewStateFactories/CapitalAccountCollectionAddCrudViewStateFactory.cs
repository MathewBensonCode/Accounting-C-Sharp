using AccountsModelCore.Classes.Accounts;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CollectionCrudViewStateFactories;
using AccountsViewModel.Repositories.Interfaces;
using Unity;

namespace AccountsViewModel.Factories.Unity.CollectionCrudViewStateFactories.AccountCollectionAddCrudViewStateFactories
{
    public class CapitalAccountAddCollectionViewModelStateFactory
        : CollectionCrudAddViewStateFactory<CapitalAccount>, ICollectionCrudAddViewStateFactory<Account>
    {
        public CapitalAccountAddCollectionViewModelStateFactory(IUnityContainer container) : base(container)
        {
        }

        public ICollectionAddViewModelState<Account> CreateEntityAddViewState(ICollectionListViewModelState<Account> liststate, IRepository<Account> repository, IEntityCollectionViewModel<Account> collectionViewModel)
        {
            return CreateEntityAddViewState(liststate as ICollectionListViewModelState<CapitalAccount>, repository as IRepository<CapitalAccount>, collectionViewModel as IEntityCollectionViewModel<CapitalAccount>) as ICollectionAddViewModelState<Account>;
        }
    }
}
