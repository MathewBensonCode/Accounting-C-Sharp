using AccountsModelCore.Classes.Accounts;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CollectionCrudViewStateFactories;
using AccountsViewModel.Repositories.Interfaces;

namespace AccountsViewModel.CollectionViewModels.AccountCollectionViewModels
{
    public class LiabilityAccountCollectionViewModel
        : EntityCollectionViewModel<LiabilityAccount>, IEntityCollectionViewModel<Account>
    {
        public LiabilityAccountCollectionViewModel(
            IRepository<LiabilityAccount> repository,
            ICollectionCrudListViewStateFactory<LiabilityAccount> viewstatefactory
            ) : base(repository, viewstatefactory)
        {
        }

        ICollectionViewModelState<Account> IEntityCollectionViewModel<Account>.CollectionViewState
        {
            get => CollectionViewState as ICollectionViewModelState<Account>;
            set => CollectionViewState = value as ICollectionViewModelState<LiabilityAccount>;
        }
    }
}
