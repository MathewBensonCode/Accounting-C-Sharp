using AccountsModelCore.Classes.Accounts;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CollectionCrudViewStateFactories;
using AccountsViewModel.Repositories.Interfaces;
using Unity;

namespace AccountsViewModel.Factories.Unity.CollectionCrudViewStateFactories.AccountCollectionListCrudViewStateFactories
{
    public class IncomeAccountListCollectionViewModelStateFactory
        : CollectionCrudListViewStateFactory<IncomeAccount>, ICollectionCrudListViewStateFactory<Account>
    {
        public IncomeAccountListCollectionViewModelStateFactory(IUnityContainer container) : base(container)
        {
        }

        public ICollectionListViewModelState<Account> CreateEntityListView(IEntityCollectionViewModel<Account> collectionvm, IRepository<Account> repository)
        {
            return CreateEntityListView(collectionvm as IEntityCollectionViewModel<IncomeAccount>, repository as IRepository<IncomeAccount>) as ICollectionListViewModelState<Account>;
        }
    }
}
