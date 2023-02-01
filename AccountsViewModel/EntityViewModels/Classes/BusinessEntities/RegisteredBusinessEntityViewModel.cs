using System.Collections.Generic;
using AccountLib.Model.BusinessEntities;
using AccountsModelCore.Classes;
using AccountsModelCore.Interfaces.BusinessEntities;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CollectionViewModelFactories;
using AccountsViewModel.Factories.Interfaces.ViewModelFactories;
using AccountsViewModel.Repositories.Interfaces;

namespace AccountsViewModel.EntityViewModels.Classes.BusinessEntities
{
    public class RegisteredBusinessEntityViewModel :
        BusinessEntityViewModel
    {
        private readonly IBusinessEntityChildCollectionViewModelFactory _businessEntityChildCollectionViewModelFactory;

        public RegisteredBusinessEntityViewModel(
            IRegisteredBusiness entity,
            ICountryViewModelFactory countryViewModelFactory,
            IBusinessEntityChildCollectionViewModelFactory businessentitychildcollectionviewmodelfactory,
            IBusinessEntitySourceDocumentTypeChildCollectionViewModelFactory businessEntitySourceDocumentTypeChildCollectionViewModelFactory,
            ISourceDocumentChildCollectionViewModelFactory sourceDocumentCollectionViewModelFactory,
            IRepository<Country> countryrepository,
            IDictionary<string, List<string>> errors) :
        base(
            entity,
            countryViewModelFactory,
            sourceDocumentCollectionViewModelFactory,
            businessEntitySourceDocumentTypeChildCollectionViewModelFactory,
            countryrepository,
            errors
            )
        {
            _businessEntityChildCollectionViewModelFactory = businessentitychildcollectionviewmodelfactory;
        }

        public IEntityCollectionViewModel<BusinessEntity> RegisteredOwners => _businessEntityChildCollectionViewModelFactory.GetOwnersOfRegisteredBusiness(Entity as IRegisteredBusiness);

    }
}
