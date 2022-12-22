using AccountsModelCore.Classes.Accounts;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CommandViewModelFactories;
using AccountsViewModel.Repositories.Interfaces;

namespace AccountsViewModel.CollectionCrudViews.EditCollectionViewModelStates.AccountEditCollectionViewModelStates
{
    public class LiabilityAccountEditCollectionViewModelState
        : EditEntityInCollectionViewModelState<LiabilityAccount>, ICollectionEditViewModelState<LiabilityAccount>
    {
        public LiabilityAccountEditCollectionViewModelState(
            ICollectionListViewModelState<LiabilityAccount> listViewModelState,
            IRepository<LiabilityAccount> repository,
            IEntityCollectionViewModel<LiabilityAccount> collectionViewModel,
            ICommandViewModelFactory<LiabilityAccount> commandFactory
            ) : base(listViewModelState, repository, collectionViewModel, commandFactory)
        {
        }
    }
}
