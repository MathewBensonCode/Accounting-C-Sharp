using AccountsModelCore.Classes.Accounts;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CollectionCrudViewStateFactories;
using AccountsViewModel.Repositories.Interfaces;
using Unity;

namespace AccountsViewModel.Factories.Unity.CollectionCrudViewStateFactories.AccountCollectionEditCrudViewStateFactories
{
    public class ExpenseAccountEditCollectionViewModelStateFactory
        : CollectionCrudEditViewStateFactory<ExpenseAccount>, ICollectionCrudEditViewStateFactory<Account>
    {
        public ExpenseAccountEditCollectionViewModelStateFactory(IUnityContainer container) : base(container)
        {
        }

        public ICollectionEditViewModelState<Account> CreateEntityEditView(IEntityCollectionViewModel<Account> collectionViewModel, IRepository<Account> repository, ICollectionListViewModelState<Account> listViewModelState)
        {
            return CreateEntityEditView(collectionViewModel as IEntityCollectionViewModel<ExpenseAccount>, repository as IRepository<ExpenseAccount>, listViewModelState as ICollectionListViewModelState<ExpenseAccount>) as ICollectionEditViewModelState<Account>;
        }
    }
}
