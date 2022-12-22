using AccountsModelCore.Classes.Accounts;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CommandViewModelFactories;
using AccountsViewModel.Repositories.Interfaces;

namespace AccountsViewModel.CollectionCrudViews.EditCollectionViewModelStates.AccountEditCollectionViewModelStates
{
    public class IncomeAccountEditCollectionViewModelState
        : EditEntityInCollectionViewModelState<IncomeAccount>, ICollectionEditViewModelState<IncomeAccount>
    {
        public IncomeAccountEditCollectionViewModelState(
            ICollectionListViewModelState<IncomeAccount> listViewModelState,
            IRepository<IncomeAccount> repository,
            IEntityCollectionViewModel<IncomeAccount> collectionViewModel,
            ICommandViewModelFactory<IncomeAccount> commandFactory
            ) : base(listViewModelState, repository, collectionViewModel, commandFactory)
        {
        }
    }
}
