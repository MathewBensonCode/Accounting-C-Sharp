using AccountsModelCore.Classes.Accounts;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CommandViewModelFactories;
using AccountsViewModel.Repositories.Interfaces;

namespace AccountsViewModel.CollectionCrudViews.EditCollectionViewModelStates.AccountEditCollectionViewModelStates
{
    public class CurrencyAccountEditCollectionViewModelState
        : EditEntityInCollectionViewModelState<CurrencyAccount>, ICollectionEditViewModelState<CurrencyAccount>
    {
        public CurrencyAccountEditCollectionViewModelState(
            ICollectionListViewModelState<CurrencyAccount> listViewModelState,
            IRepository<CurrencyAccount> repository,
            IEntityCollectionViewModel<CurrencyAccount> collectionViewModel,
            ICommandViewModelFactory<CurrencyAccount> commandFactory
            ) : base(listViewModelState, repository, collectionViewModel, commandFactory)
        {
        }
    }
}
