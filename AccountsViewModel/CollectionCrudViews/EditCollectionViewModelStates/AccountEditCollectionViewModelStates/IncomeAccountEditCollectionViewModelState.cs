using AccountLib.Model.Accounts;
using Accounts.Repositories;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CommandViewModelFactories;

namespace AccountsViewModel.CollectionCrudViews
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
