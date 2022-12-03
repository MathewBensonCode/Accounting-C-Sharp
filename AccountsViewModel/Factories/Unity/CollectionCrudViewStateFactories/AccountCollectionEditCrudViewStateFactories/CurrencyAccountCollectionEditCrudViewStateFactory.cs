using AccountLib.Model.Accounts;
using Accounts.Repositories;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CollectionCrudViewStateFactories;
using Unity;

namespace AccountsViewModel.Factories.Unity.CollectionCrudViewStateFactories
{
    public class CurrencyAccountEditCollectionViewModelStateFactory
        : CollectionCrudEditViewStateFactory<CurrencyAccount>, ICollectionCrudEditViewStateFactory<Account>
    {
        public CurrencyAccountEditCollectionViewModelStateFactory(IUnityContainer container) : base(container)
        {
        }

        public ICollectionEditViewModelState<Account> CreateEntityEditView(IEntityCollectionViewModel<Account> collectionViewModel, IRepository<Account> repository, ICollectionListViewModelState<Account> listViewModelState)
        {
            return base.CreateEntityEditView(collectionViewModel as IEntityCollectionViewModel<CurrencyAccount>, repository as IRepository<CurrencyAccount>, listViewModelState as ICollectionListViewModelState<CurrencyAccount>) as ICollectionEditViewModelState<Account>;
        }
    }
}
