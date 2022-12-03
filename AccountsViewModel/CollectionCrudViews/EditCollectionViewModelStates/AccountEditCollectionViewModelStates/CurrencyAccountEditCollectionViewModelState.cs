using AccountLib.Model.Accounts;
using Accounts.Repositories;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CommandViewModelFactories;

namespace AccountsViewModel.CollectionCrudViews
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
