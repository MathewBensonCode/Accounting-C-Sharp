using AccountLib.Model.Accounts;
using Accounts.Repositories;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CollectionCrudViewStateFactories;
using Unity;

namespace AccountsViewModel.Factories.Unity.CollectionCrudViewStateFactories
{
    public class IncomeAccountListCollectionViewModelStateFactory
        : CollectionCrudListViewStateFactory<IncomeAccount>, ICollectionCrudListViewStateFactory<Account>
    {
        public IncomeAccountListCollectionViewModelStateFactory(IUnityContainer container) : base(container)
        {
        }

        public ICollectionListViewModelState<Account> CreateEntityListView(IEntityCollectionViewModel<Account> collectionvm, IRepository<Account> repository)
        {
           return base.CreateEntityListView(collectionvm as IEntityCollectionViewModel<IncomeAccount>, repository as IRepository<IncomeAccount>) as ICollectionListViewModelState<Account>;
        }
    }
}
