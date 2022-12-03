using AccountLib.Model.Accounts;
using Accounts.Repositories;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CollectionCrudViewStateFactories;
using Unity;

namespace AccountsViewModel.Factories.Unity.CollectionCrudViewStateFactories
{
    public class ExpenseAccountEditCollectionViewModelStateFactory
        : CollectionCrudEditViewStateFactory<ExpenseAccount>, ICollectionCrudEditViewStateFactory<Account>
    {
        public ExpenseAccountEditCollectionViewModelStateFactory(IUnityContainer container) : base(container)
        {
        }

        public ICollectionEditViewModelState<Account> CreateEntityEditView(IEntityCollectionViewModel<Account> collectionViewModel, IRepository<Account> repository, ICollectionListViewModelState<Account> listViewModelState)
        {
            return base.CreateEntityEditView(collectionViewModel as IEntityCollectionViewModel<ExpenseAccount>, repository as IRepository<ExpenseAccount>, listViewModelState as ICollectionListViewModelState<ExpenseAccount>) as ICollectionEditViewModelState<Account>;
        }
    }
}
