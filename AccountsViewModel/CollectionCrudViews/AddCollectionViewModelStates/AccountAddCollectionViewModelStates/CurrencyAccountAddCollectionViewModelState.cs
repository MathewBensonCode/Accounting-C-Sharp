using AccountsModelCore.Classes.Accounts;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CommandViewModelFactories;
using AccountsViewModel.Repositories.Interfaces;

namespace AccountsViewModel.CollectionCrudViews.AddCollectionViewModelStates.AccountAddCollectionViewModelStates
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
