using AccountLib.Model.Accounts;
using Accounts.Repositories;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CollectionCrudViewStateFactories;

namespace AccountsViewModel.CollectionViewModels.AccountCollectionViewModels
{
    public class CapitalAccountCollectionViewModel
        : EntityCollectionViewModel<CapitalAccount>, IEntityCollectionViewModel<Account>
    {
        public CapitalAccountCollectionViewModel(
            IRepository<CapitalAccount> repository,
            ICollectionCrudListViewStateFactory<CapitalAccount> viewstatefactory
            ) : base(repository, viewstatefactory)
        {
        }

        ICollectionViewModelState<Account> IEntityCollectionViewModel<Account>.CollectionViewState
        {
            get => base.CollectionViewState as ICollectionViewModelState<Account>;
            set
            {
                base.CollectionViewState = value as ICollectionViewModelState<CapitalAccount>;
            }
        }
    }
}
