using AccountsModelCore.Classes.Accounts;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CollectionCrudViewStateFactories;
using AccountsViewModel.Repositories.Interfaces;

namespace AccountsViewModel.CollectionViewModels.AccountCollectionViewModels
{
    public class ExpenseAccountCollectionViewModel
        : EntityCollectionViewModel<ExpenseAccount>, IEntityCollectionViewModel<Account>
    {
        public ExpenseAccountCollectionViewModel(
            IRepository<ExpenseAccount> repository,
            ICollectionCrudListViewStateFactory<ExpenseAccount> viewstatefactory
            ) : base(repository, viewstatefactory)
        {
        }

        ICollectionViewModelState<Account> IEntityCollectionViewModel<Account>.CollectionViewState
        {
            get => CollectionViewState as ICollectionViewModelState<Account>;
            set => CollectionViewState = value as ICollectionViewModelState<ExpenseAccount>;
        }
    }
}
