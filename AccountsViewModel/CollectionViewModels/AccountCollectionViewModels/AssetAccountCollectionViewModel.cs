using AccountLib.Model.Accounts;
using Accounts.Repositories;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CollectionCrudViewStateFactories;

namespace AccountsViewModel.CollectionViewModels.AccountCollectionViewModels
{
    public class AssetAccountCollectionViewModel
        : EntityCollectionViewModel<AssetAccount>, IEntityCollectionViewModel<Account>
    {
        public AssetAccountCollectionViewModel(
            IRepository<AssetAccount> repository,
            ICollectionCrudListViewStateFactory<AssetAccount> viewstatefactory
            ) : base(repository, viewstatefactory)
        {
        }

        ICollectionViewModelState<Account> IEntityCollectionViewModel<Account>.CollectionViewState
        {
            get => base.CollectionViewState as ICollectionViewModelState<Account>;
            set
            {
                base.CollectionViewState = value as ICollectionViewModelState<AssetAccount>;
            }
        }
    }
}
