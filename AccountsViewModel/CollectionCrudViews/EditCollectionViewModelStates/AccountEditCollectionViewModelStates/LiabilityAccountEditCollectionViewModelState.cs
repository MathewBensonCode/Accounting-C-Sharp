using AccountLib.Model.Accounts;
using Accounts.Repositories;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CommandViewModelFactories;

namespace AccountsViewModel.CollectionCrudViews
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
