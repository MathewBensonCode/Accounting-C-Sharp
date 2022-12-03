using AccountLib.Model.Accounts;
using Accounts.Repositories;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CollectionCrudViewStateFactories;
using Unity;

namespace AccountsViewModel.Factories.Unity.CollectionCrudViewStateFactories
{
    public class IncomeAccountAddCollectionViewModelStateFactory
        : CollectionCrudAddViewStateFactory<IncomeAccount>, ICollectionCrudAddViewStateFactory<Account>
    {
        public IncomeAccountAddCollectionViewModelStateFactory(IUnityContainer container) : base(container)
        {
        }

        public ICollectionAddViewModelState<Account> CreateEntityAddViewState(ICollectionListViewModelState<Account> liststate, IRepository<Account> repository, IEntityCollectionViewModel<Account> collectionViewModel)
        {
            return base.CreateEntityAddViewState(liststate as ICollectionListViewModelState<IncomeAccount>, repository as IRepository<IncomeAccount>, collectionViewModel as IEntityCollectionViewModel<IncomeAccount>) as ICollectionAddViewModelState<Account>;
        }
    }
}
