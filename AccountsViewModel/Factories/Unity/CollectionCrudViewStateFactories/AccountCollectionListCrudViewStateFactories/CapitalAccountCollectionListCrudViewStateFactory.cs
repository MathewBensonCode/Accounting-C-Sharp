using AccountLib.Model.Accounts;
using Accounts.Repositories;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CollectionCrudViewStateFactories;
using Unity;

namespace AccountsViewModel.Factories.Unity.CollectionCrudViewStateFactories
{
    public class CapitalAccountListCollectionViewModelStateFactory
        : CollectionCrudListViewStateFactory<CapitalAccount>, ICollectionCrudListViewStateFactory<Account>
    {
        public CapitalAccountListCollectionViewModelStateFactory(IUnityContainer container) : base(container)
        {
        }

        public ICollectionListViewModelState<Account> CreateEntityListView(IEntityCollectionViewModel<Account> collectionvm, IRepository<Account> repository)
        {
           return base.CreateEntityListView(collectionvm as IEntityCollectionViewModel<CapitalAccount>, repository as IRepository<CapitalAccount>) as ICollectionListViewModelState<Account>;
        }
    }
}
