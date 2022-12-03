using AccountLib.Model.Accounts;
using Accounts.Repositories;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CommandViewModelFactories;

namespace AccountsViewModel.CollectionCrudViews
{
    public class CurrencyAccountAddCollectionViewModelState
        : AddNewEntityToCollectionViewModelState<CurrencyAccount>, ICollectionAddViewModelState<CurrencyAccount>
    {
        public CurrencyAccountAddCollectionViewModelState(
            ICollectionListViewModelState<CurrencyAccount> listViewModelState,
            IRepository<CurrencyAccount> repository,
            IEntityCollectionViewModel<CurrencyAccount> collectionViewModel,
            ICommandViewModelFactory<CurrencyAccount> commandfactory
            ) : base(listViewModelState, repository, collectionViewModel, commandfactory)
        {
        }
    }
}
