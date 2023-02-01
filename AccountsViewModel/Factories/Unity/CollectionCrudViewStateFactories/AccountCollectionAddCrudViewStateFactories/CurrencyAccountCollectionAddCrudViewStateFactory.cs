using AccountsModelCore.Classes.Accounts;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CollectionCrudViewStateFactories;
using AccountsViewModel.Repositories.Interfaces;
using Unity;

namespace AccountsViewModel.Factories.Unity.CollectionCrudViewStateFactories.AccountCollectionAddCrudViewStateFactories
{
    public class CurrencyAccountAddCollectionViewModelStateFactory
        : CollectionCrudAddViewStateFactory<CurrencyAccount>, ICollectionCrudAddViewStateFactory<Account>
    {
        public CurrencyAccountAddCollectionViewModelStateFactory(IUnityContainer container) : base(container)
        {
        }

        public ICollectionAddViewModelState<Account> CreateEntityAddViewState(ICollectionListViewModelState<Account> liststate, IRepository<Account> repository, IEntityCollectionViewModel<Account> collectionViewModel)
        {
            return CreateEntityAddViewState(liststate as ICollectionListViewModelState<CurrencyAccount>, repository as IRepository<CurrencyAccount>, collectionViewModel as IEntityCollectionViewModel<CurrencyAccount>) as ICollectionAddViewModelState<Account>;
        }
    }
}
