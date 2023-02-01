using AccountsModelCore.Classes.Accounts;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CommandViewModelFactories;
using AccountsViewModel.Repositories.Interfaces;

namespace AccountsViewModel.CollectionCrudViews.AddCollectionViewModelStates.AccountAddCollectionViewModelStates
{
    public class ExpenseAccountAddCollectionViewModelState
        : AddNewEntityToCollectionViewModelState<ExpenseAccount>, ICollectionAddViewModelState<ExpenseAccount>
    {
        public ExpenseAccountAddCollectionViewModelState(
            ICollectionListViewModelState<ExpenseAccount> listViewModelState,
            IRepository<ExpenseAccount> repository,
            IEntityCollectionViewModel<ExpenseAccount> collectionViewModel,
            ICommandViewModelFactory<ExpenseAccount> commandfactory
            ) : base(listViewModelState, repository, collectionViewModel, commandfactory)
        {
        }
    }
}
