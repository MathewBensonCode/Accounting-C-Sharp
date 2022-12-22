using AccountsModelCore.Classes.Accounts;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CollectionCrudViewStateFactories;
using AccountsViewModel.Repositories.Interfaces;
using Unity;

namespace AccountsViewModel.Factories.Unity.CollectionCrudViewStateFactories.AccountCollectionEditCrudViewStateFactories
{
    public class CurrencyAccountEditCollectionViewModelStateFactory
        : CollectionCrudEditViewStateFactory<CurrencyAccount>, ICollectionCrudEditViewStateFactory<Account>
    {
        public CurrencyAccountEditCollectionViewModelStateFactory(IUnityContainer container) : base(container)
        {
        }

        public ICollectionEditViewModelState<Account> CreateEntityEditView(IEntityCollectionViewModel<Account> collectionViewModel, IRepository<Account> repository, ICollectionListViewModelState<Account> listViewModelState)
        {
            return CreateEntityEditView(collectionViewModel as IEntityCollectionViewModel<CurrencyAccount>, repository as IRepository<CurrencyAccount>, listViewModelState as ICollectionListViewModelState<CurrencyAccount>) as ICollectionEditViewModelState<Account>;
        }
    }
}
