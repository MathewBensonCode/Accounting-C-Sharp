using AccountsModelCore.Classes.Accounts;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CollectionCrudViewStateFactories;
using AccountsViewModel.Repositories.Interfaces;
using Unity;

namespace AccountsViewModel.Factories.Unity.CollectionCrudViewStateFactories.AccountCollectionAddCrudViewStateFactories
{
    public class ExpenseAccountAddCollectionViewModelStateFactory
        : CollectionCrudAddViewStateFactory<ExpenseAccount>, ICollectionCrudAddViewStateFactory<Account>
    {
        public ExpenseAccountAddCollectionViewModelStateFactory(IUnityContainer container) : base(container)
        {
        }

        public ICollectionAddViewModelState<Account> CreateEntityAddViewState(ICollectionListViewModelState<Account> liststate, IRepository<Account> repository, IEntityCollectionViewModel<Account> collectionViewModel)
        {
            return CreateEntityAddViewState(liststate as ICollectionListViewModelState<ExpenseAccount>, repository as IRepository<ExpenseAccount>, collectionViewModel as IEntityCollectionViewModel<ExpenseAccount>) as ICollectionAddViewModelState<Account>;
        }
    }
}
