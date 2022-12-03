using AccountLib.Model.Accounts;
using Accounts.Repositories;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CollectionCrudViewStateFactories;
using Unity;

namespace AccountsViewModel.Factories.Unity.CollectionCrudViewStateFactories
{
    public class CurrencyAccountAddCollectionViewModelStateFactory
        : CollectionCrudAddViewStateFactory<CurrencyAccount>, ICollectionCrudAddViewStateFactory<Account>
    {
        public CurrencyAccountAddCollectionViewModelStateFactory(IUnityContainer container) : base(container)
        {
        }

        public ICollectionAddViewModelState<Account> CreateEntityAddViewState(ICollectionListViewModelState<Account> liststate, IRepository<Account> repository, IEntityCollectionViewModel<Account> collectionViewModel)
        {
            return base.CreateEntityAddViewState(liststate as ICollectionListViewModelState<CurrencyAccount>, repository as IRepository<CurrencyAccount>, collectionViewModel as IEntityCollectionViewModel<CurrencyAccount>) as ICollectionAddViewModelState<Account>;
        }
    }
}
