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
    public class CompanyBusinessEntityViewModel
        : BusinessEntityViewModel
    {
        private readonly IBusinessEntityChildCollectionViewModelFactory _businessEntityChildCollectionViewModelFactory;

        public CompanyBusinessEntityViewModel(
            ICompany entity,
            ICountryViewModelFactory countryViewModelFactory,
            IBusinessEntityChildCollectionViewModelFactory businessEntityChildCollectionViewModelFactory,
            IBusinessEntitySourceDocumentTypeChildCollectionViewModelFactory businessEntitySourceDocumentTypeChildCollectionViewModelFactory,
            ISourceDocumentChildCollectionViewModelFactory sourceDocumentChildCollectionViewModelFactory,
            IRepository<Country> countryrepository,
            IDictionary<string, List<string>> errors
            ) : base(
                entity as BusinessEntity,
                countryViewModelFactory,
                sourceDocumentChildCollectionViewModelFactory,
                businessEntitySourceDocumentTypeChildCollectionViewModelFactory,
                countryrepository,
                errors)
        {
            _businessEntityChildCollectionViewModelFactory = businessEntityChildCollectionViewModelFactory;
        }

        public IEntityCollectionViewModel<BusinessEntity> ShareHoldersCollectionViewModel => _businessEntityChildCollectionViewModelFactory.GetShareHoldersBusinessEntityCollectionForCompany(Entity as ICompany);

        public IEntityCollectionViewModel<Person> DirectorsCollectionViewModel => _businessEntityChildCollectionViewModelFactory.GetDirectorsCollectionForCompany(Entity as ICompany);
    }
}
