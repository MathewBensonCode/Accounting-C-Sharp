using AccountLib.Model.Accounts;
using Accounts.Repositories;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CollectionCrudViewStateFactories;
using Unity;

namespace AccountsViewModel.Factories.Unity.CollectionCrudViewStateFactories
{
    public class LiabilityAccountListCollectionViewModelStateFactory
        : CollectionCrudListViewStateFactory<LiabilityAccount>, ICollectionCrudListViewStateFactory<Account>
    {
        public LiabilityAccountListCollectionViewModelStateFactory(IUnityContainer container) : base(container)
        {
        }

        public ICollectionListViewModelState<Account> CreateEntityListView(IEntityCollectionViewModel<Account> collectionvm, IRepository<Account> repository)
        {
           return base.CreateEntityListView(collectionvm as IEntityCollectionViewModel<LiabilityAccount>, repository as IRepository<LiabilityAccount>) as ICollectionListViewModelState<Account>;
        }
    }
}
