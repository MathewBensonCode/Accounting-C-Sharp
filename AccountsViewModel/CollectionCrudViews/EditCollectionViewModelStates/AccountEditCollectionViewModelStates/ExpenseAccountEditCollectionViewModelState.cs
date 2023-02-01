using AccountsModelCore.Classes.Accounts;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CommandViewModelFactories;
using AccountsViewModel.Repositories.Interfaces;

namespace AccountsViewModel.CollectionCrudViews.EditCollectionViewModelStates.AccountEditCollectionViewModelStates
{
    public class ExpenseAccountEditCollectionViewModelState
        : EditEntityInCollectionViewModelState<ExpenseAccount>, ICollectionEditViewModelState<ExpenseAccount>
    {
        public ExpenseAccountEditCollectionViewModelState(
            ICollectionListViewModelState<ExpenseAccount> listViewModelState,
            IRepository<ExpenseAccount> repository,
            IEntityCollectionViewModel<ExpenseAccount> collectionViewModel,
            ICommandViewModelFactory<ExpenseAccount> commandFactory
            ) : base(listViewModelState, repository, collectionViewModel, commandFactory)
        {
        }
    }
}
