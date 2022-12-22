using AccountLib.Model.BusinessEntities;
using AccountsModelCore.Classes;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CommandViewModelFactories;
using AccountsViewModel.Repositories.Interfaces;

namespace AccountsViewModel.CollectionCrudViews.AddCollectionViewModelStates
{
    public class BusinessEntityAddCollectionViewModelState
        : BusinessEntityAddEditCollectionViewModelState, ICollectionAddViewModelState<BusinessEntity>
    {

        public BusinessEntityAddCollectionViewModelState(
            ICollectionListViewModelState<BusinessEntity> listViewModelState,
            IRepository<BusinessEntity> repository,
            IRepository<Country> countryrepository,
            IEntityCollectionViewModel<BusinessEntity> collectionViewModel,
            ICommandViewModelFactory<BusinessEntity> commandfactory
            ) : base(listViewModelState, repository, countryrepository, collectionViewModel, commandfactory)
        {
        }

        protected override void CreateSaveCommand()
        {
            SaveCommand = CommandFactory.CreateSaveNewCommand(this, ListViewModelState, Repository, CollectionViewModel);
        }
    }
}
