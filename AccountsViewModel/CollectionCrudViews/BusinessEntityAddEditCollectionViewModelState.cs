using System.Collections.Generic;
using AccountLib.Model.BusinessEntities;
using AccountsModelCore.Classes;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CommandViewModelFactories;
using AccountsViewModel.Repositories.Interfaces;

namespace AccountsViewModel.CollectionCrudViews
{
    public abstract class BusinessEntityAddEditCollectionViewModelState
        : AddEditEntityCollectionViewModelState<BusinessEntity>, IBusinessEntityAddEditCollectionViewModelState
    {
        private readonly IRepository<Country> _countryRepository;

        public BusinessEntityAddEditCollectionViewModelState(
                ICollectionListViewModelState<BusinessEntity> listViewModelState,
                IRepository<BusinessEntity> repository,
                IRepository<Country> countryrepository,
                IEntityCollectionViewModel<BusinessEntity> collectionViewModel,
                ICommandViewModelFactory<BusinessEntity> commandfactory
                )
            : base(listViewModelState, repository, collectionViewModel, commandfactory)
        {
            _countryRepository = countryrepository;
        }

        public IEnumerable<Country> CountryList => _countryRepository.GetAll();
    }
}
