using AccountLib.Model.Accounts;
using Accounts.Repositories;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CommandViewModelFactories;

namespace AccountsViewModel.CollectionCrudViews
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
