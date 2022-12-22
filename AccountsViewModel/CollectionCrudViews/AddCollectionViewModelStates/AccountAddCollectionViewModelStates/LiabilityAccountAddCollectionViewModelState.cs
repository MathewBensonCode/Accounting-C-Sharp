using AccountsModelCore.Classes.Accounts;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CommandViewModelFactories;
using AccountsViewModel.Repositories.Interfaces;

namespace AccountsViewModel.CollectionCrudViews.AddCollectionViewModelStates.AccountAddCollectionViewModelStates
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
