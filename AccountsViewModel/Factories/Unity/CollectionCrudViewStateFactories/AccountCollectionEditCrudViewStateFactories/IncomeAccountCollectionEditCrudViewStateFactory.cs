using AccountsModelCore.Classes.Accounts;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CollectionCrudViewStateFactories;
using AccountsViewModel.Repositories.Interfaces;
using Unity;

namespace AccountsViewModel.Factories.Unity.CollectionCrudViewStateFactories.AccountCollectionEditCrudViewStateFactories
{
    public class IncomeAccountEditCollectionViewModelStateFactory
        : CollectionCrudEditViewStateFactory<IncomeAccount>, ICollectionCrudEditViewStateFactory<Account>
    {
        public IncomeAccountEditCollectionViewModelStateFactory(IUnityContainer container) : base(container)
        {
        }

        public ICollectionEditViewModelState<Account> CreateEntityEditView(IEntityCollectionViewModel<Account> collectionViewModel, IRepository<Account> repository, ICollectionListViewModelState<Account> listViewModelState)
        {
            return CreateEntityEditView(collectionViewModel as IEntityCollectionViewModel<IncomeAccount>, repository as IRepository<IncomeAccount>, listViewModelState as ICollectionListViewModelState<IncomeAccount>) as ICollectionEditViewModelState<Account>;
        }
    }
}
