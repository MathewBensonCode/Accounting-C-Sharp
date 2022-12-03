using AccountLib.Model;
using AccountLib.Model.BusinessEntities;
using Accounts.Repositories;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CommandViewModelFactories;

namespace AccountsViewModel.CollectionCrudViews
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
            SaveCommand = CommandFactory.CreateSaveEditCommand(this as ICollectionEditViewModelState<BusinessEntity>, ListViewModelState, Repository, CollectionViewModel);
        }
    }
}
