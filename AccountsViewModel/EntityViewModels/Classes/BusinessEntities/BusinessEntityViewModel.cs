using System.Collections.Generic;
using AccountLib.Model.BusinessEntities;
using AccountsModelCore.Classes;
using AccountsModelCore.Interfaces.BusinessEntities;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.EntityViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CollectionViewModelFactories;
using AccountsViewModel.Factories.Interfaces.ViewModelFactories;
using AccountsViewModel.Repositories.Interfaces;

namespace AccountsViewModel.EntityViewModels.Classes.BusinessEntities
{
    public class BusinessEntityViewModel : EntityViewModel<BusinessEntity>, IBusinessEntityViewModel
    {
        private readonly ICountryViewModelFactory _countryViewModelFactory;
        protected IBusinessEntitySourceDocumentTypeChildCollectionViewModelFactory _businessEntitySourceDocumentTypeChildCollectionViewModelFactory;
        private readonly IRepository<Country> _countryrepository;
        private ICountryViewModel _countryviewmodel;

        public BusinessEntityViewModel(
            IBusinessEntity entity,
            ICountryViewModelFactory countryViewModelFactory,
            ISourceDocumentChildCollectionViewModelFactory sourceDocumentCollectionViewModelFactory,
            IBusinessEntitySourceDocumentTypeChildCollectionViewModelFactory businessEntitySourceDocumentTypeViewModelFactory,
            IRepository<Country> countryrepository,
            IDictionary<string, List<string>> errors
            )
        : base(entity as BusinessEntity, errors)
        {
            _countryViewModelFactory = countryViewModelFactory;
            SourceDocumentCollectionViewModelFactory = sourceDocumentCollectionViewModelFactory;
            _businessEntitySourceDocumentTypeChildCollectionViewModelFactory = businessEntitySourceDocumentTypeViewModelFactory;
            _countryrepository = countryrepository;
        }

        public virtual string Name
        {
            get => Entity.Name;

            set
            {
                if (Entity.Name != value)
                {
                    Entity.Name = value;
                    RaisePropertyChanged();
                }
            }
        }

        public int CountryId
        {
            get => Entity.CountryId;

            set
            {
                if (Entity.CountryId != value)
                {
                    Entity.CountryId = value;
                    RaisePropertyChanged();
                }
            }
        }

        public ICountryViewModel CountryViewModel
        {
            get
            {
                if (_countryviewmodel == null)
                {
                    _countryviewmodel = _countryViewModelFactory.CreateCountryViewModelFromBusinessEntity(Entity);
                }

                return _countryviewmodel;
            }
        }

        public IEnumerable<Country> CountryList => _countryrepository.GetAll();

        public IEntityCollectionViewModel<BusinessEntitySourceDocumentType> BusinessEntitySourceDocumentTypes
        {
            get
            {
                if (BusinessEntitySourceDocumentTypeCollectionViewModel == null)
                {
                    BusinessEntitySourceDocumentTypeCollectionViewModel = _businessEntitySourceDocumentTypeChildCollectionViewModelFactory.GetBusinessEntitySourceDocumentTypeCollectionViewModelForBusinessEntity(Entity);
                }

                return BusinessEntitySourceDocumentTypeCollectionViewModel;
            }
        }

        public string BusinessEntityNameRegex
        {
            get => Entity.BusinessEntityNameRegex;

            set
            {
                Entity.BusinessEntityNameRegex = value;
                RaisePropertyChanged();
            }
        }

        public ISourceDocumentChildCollectionViewModelFactory SourceDocumentCollectionViewModelFactory { get; }

        public IEntityCollectionViewModel<BusinessEntitySourceDocumentType> BusinessEntitySourceDocumentTypeCollectionViewModel { get; set; }
    }
}
