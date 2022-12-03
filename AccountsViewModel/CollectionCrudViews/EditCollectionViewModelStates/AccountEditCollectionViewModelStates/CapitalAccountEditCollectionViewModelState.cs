using AccountLib.Model.Accounts;
using Accounts.Repositories;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CommandViewModelFactories;

namespace AccountsViewModel.CollectionCrudViews
{
    public class CapitalAccountEditCollectionViewModelState
        : EditEntityInCollectionViewModelState<CapitalAccount>, ICollectionEditViewModelState<CapitalAccount>
    {
        public CapitalAccountEditCollectionViewModelState(
            ICollectionListViewModelState<CapitalAccount> listViewModelState,
            IRepository<CapitalAccount> repository,
            IEntityCollectionViewModel<CapitalAccount> collectionViewModel,
            ICommandViewModelFactory<CapitalAccount> commandFactory
            ) : base(listViewModelState, repository, collectionViewModel, commandFactory)
        {
        }
    }
}
