using AccountsModelCore.Classes.Accounts;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CommandViewModelFactories;
using AccountsViewModel.Repositories.Interfaces;

namespace AccountsViewModel.CollectionCrudViews.AddCollectionViewModelStates.AccountAddCollectionViewModelStates
{
    public class IncomeAccountAddCollectionViewModelState
        : AddNewEntityToCollectionViewModelState<IncomeAccount>, ICollectionAddViewModelState<IncomeAccount>
    {
        public IncomeAccountAddCollectionViewModelState(
            ICollectionListViewModelState<IncomeAccount> listViewModelState,
            IRepository<IncomeAccount> repository,
            IEntityCollectionViewModel<IncomeAccount> collectionViewModel,
            ICommandViewModelFactory<IncomeAccount> commandfactory
            ) : base(listViewModelState, repository, collectionViewModel, commandfactory)
        {
        }
    }
}
