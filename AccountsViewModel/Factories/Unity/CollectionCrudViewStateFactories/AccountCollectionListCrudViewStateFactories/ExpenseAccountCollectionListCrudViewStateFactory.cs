using AccountsModelCore.Classes.Accounts;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CollectionCrudViewStateFactories;
using AccountsViewModel.Repositories.Interfaces;
using Unity;

namespace AccountsViewModel.Factories.Unity.CollectionCrudViewStateFactories.AccountCollectionListCrudViewStateFactories
{
    public class ExpenseAccountCollectionCrudListViewModelStateFactory
        : CollectionCrudListViewStateFactory<ExpenseAccount>, ICollectionCrudListViewStateFactory<Account>
    {
        public ExpenseAccountCollectionCrudListViewModelStateFactory(IUnityContainer container) : base(container)
        {
        }

        public ICollectionListViewModelState<Account> CreateEntityListView(IEntityCollectionViewModel<Account> collectionvm, IRepository<Account> repository)
        {
            return CreateEntityListView(collectionvm as IEntityCollectionViewModel<ExpenseAccount>, repository as IRepository<ExpenseAccount>) as ICollectionListViewModelState<Account>;
        }
    }
}
