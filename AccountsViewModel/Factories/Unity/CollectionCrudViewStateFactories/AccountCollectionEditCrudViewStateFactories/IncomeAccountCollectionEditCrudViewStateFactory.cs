using AccountLib.Model.Accounts;
using Accounts.Repositories;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CollectionCrudViewStateFactories;
using Unity;

namespace AccountsViewModel.Factories.Unity.CollectionCrudViewStateFactories
{
    public class IncomeAccountEditCollectionViewModelStateFactory
        : CollectionCrudEditViewStateFactory<IncomeAccount>, ICollectionCrudEditViewStateFactory<Account>
    {
        public IncomeAccountEditCollectionViewModelStateFactory(IUnityContainer container) : base(container)
        {
        }

        public ICollectionEditViewModelState<Account> CreateEntityEditView(IEntityCollectionViewModel<Account> collectionViewModel, IRepository<Account> repository, ICollectionListViewModelState<Account> listViewModelState)
        {
            return base.CreateEntityEditView(collectionViewModel as IEntityCollectionViewModel<IncomeAccount>, repository as IRepository<IncomeAccount>, listViewModelState as ICollectionListViewModelState<IncomeAccount>) as ICollectionEditViewModelState<Account>;
        }
    }
}
