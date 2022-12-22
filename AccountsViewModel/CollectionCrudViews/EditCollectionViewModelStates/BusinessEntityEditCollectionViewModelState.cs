using AccountLib.Model.BusinessEntities;
using AccountsModelCore.Classes;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CommandViewModelFactories;
using AccountsViewModel.Repositories.Interfaces;

namespace AccountsViewModel.CollectionCrudViews.EditCollectionViewModelStates
{
    public class BusinessEntityEditCollectionViewModelState
        : BusinessEntityAddEditCollectionViewModelState, ICollectionEditViewModelState<BusinessEntity>
    {
        public BusinessEntityEditCollectionViewModelState(
            ICollectionListViewModelState<BusinessEntity> listViewModelState,
            IRepository<BusinessEntity> repository,
            IRepository<Country> countryrepository,
            IEntityCollectionViewModel<BusinessEntity> collectionViewModel,
            ICommandViewModelFactory<BusinessEntity> commandFactory
            ) : base(listViewModelState, repository, countryrepository, collectionViewModel, commandFactory)
        {
        }

        protected override void CreateSaveCommand()
        {
            SaveCommand = CommandFactory.CreateSaveEditCommand(this, ListViewModelState, Repository, CollectionViewModel);
        }
    }
}
