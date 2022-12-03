using AccountLib.Model.Accounts;
using Accounts.Repositories;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CommandViewModelFactories;

namespace AccountsViewModel.CollectionCrudViews
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
