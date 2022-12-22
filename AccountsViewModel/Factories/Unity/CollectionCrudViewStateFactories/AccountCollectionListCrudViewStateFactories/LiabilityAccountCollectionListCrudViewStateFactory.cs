using AccountsModelCore.Classes.Accounts;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CollectionCrudViewStateFactories;
using AccountsViewModel.Repositories.Interfaces;
using Unity;

namespace AccountsViewModel.Factories.Unity.CollectionCrudViewStateFactories.AccountCollectionListCrudViewStateFactories
{
    public class LiabilityAccountListCollectionViewModelStateFactory
        : CollectionCrudListViewStateFactory<LiabilityAccount>, ICollectionCrudListViewStateFactory<Account>
    {
        public LiabilityAccountListCollectionViewModelStateFactory(IUnityContainer container) : base(container)
        {
        }

        public ICollectionListViewModelState<Account> CreateEntityListView(IEntityCollectionViewModel<Account> collectionvm, IRepository<Account> repository)
        {
            return CreateEntityListView(collectionvm as IEntityCollectionViewModel<LiabilityAccount>, repository as IRepository<LiabilityAccount>) as ICollectionListViewModelState<Account>;
        }
    }
}
