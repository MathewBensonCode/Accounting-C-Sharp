using AccountLib.Model;
using AccountLib.Model.BusinessEntities;
using Accounts.Repositories;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CommandViewModelFactories;

namespace AccountsViewModel.CollectionCrudViews
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
            SaveCommand = CommandFactory.CreateSaveNewCommand(this as ICollectionAddViewModelState<BusinessEntity>, ListViewModelState, Repository, CollectionViewModel);
        }
    }
}
