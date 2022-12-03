using AccountLib.Model.Accounts;
using Accounts.Repositories;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CommandViewModelFactories;

namespace AccountsViewModel.CollectionCrudViews
{
    public class LiabilityAccountAddCollectionViewModelState
        : AddNewEntityToCollectionViewModelState<LiabilityAccount>, ICollectionAddViewModelState<LiabilityAccount>
    {
        public LiabilityAccountAddCollectionViewModelState(
            ICollectionListViewModelState<LiabilityAccount> listViewModelState,
            IRepository<LiabilityAccount> repository,
            IEntityCollectionViewModel<LiabilityAccount> collectionViewModel,
            ICommandViewModelFactory<LiabilityAccount> commandfactory
            ) : base(listViewModelState, repository, collectionViewModel, commandfactory)
        {
        }
    }
}
