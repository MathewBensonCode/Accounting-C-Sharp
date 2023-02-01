using AccountsModelCore.Classes.Accounts;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CollectionCrudViewStateFactories;
using AccountsViewModel.Repositories.Interfaces;

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
            get => CollectionViewState as ICollectionViewModelState<Account>;
            set => CollectionViewState = value as ICollectionViewModelState<AssetAccount>;
        }
    }
}
