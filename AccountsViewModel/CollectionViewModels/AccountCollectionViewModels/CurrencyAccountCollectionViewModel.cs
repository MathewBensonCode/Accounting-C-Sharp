using AccountsModelCore.Classes.Accounts;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CollectionCrudViewStateFactories;
using AccountsViewModel.Repositories.Interfaces;

namespace AccountsViewModel.CollectionViewModels.AccountCollectionViewModels
{
    public class CurrencyAccountCollectionViewModel
        : EntityCollectionViewModel<CurrencyAccount>, IEntityCollectionViewModel<Account>
    {
        public CurrencyAccountCollectionViewModel(
            IRepository<CurrencyAccount> repository,
            ICollectionCrudListViewStateFactory<CurrencyAccount> viewstatefactory
            ) : base(repository, viewstatefactory)
        {
        }

        ICollectionViewModelState<Account> IEntityCollectionViewModel<Account>.CollectionViewState
        {
            get => CollectionViewState as ICollectionViewModelState<Account>;
            set => CollectionViewState = value as ICollectionViewModelState<CurrencyAccount>;
        }
    }
}
