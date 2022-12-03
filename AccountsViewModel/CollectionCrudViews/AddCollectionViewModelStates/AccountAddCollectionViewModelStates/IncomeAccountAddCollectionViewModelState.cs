using AccountLib.Model.Accounts;
using Accounts.Repositories;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CommandViewModelFactories;

namespace AccountsViewModel.CollectionCrudViews
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
