using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AccountLib.Model;
using Accounts.Repositories;
using AccountsModelCore.Interfaces.BusinessEntities;
using AccountsViewModel.EntityViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CollectionViewModelFactories;
using AccountsViewModel.Factories.Interfaces.ViewModelFactories;

namespace AccountsViewModel.EntityViewModels.Classes.BusinessEntities
{
    public class PersonBusinessEntityViewModel :
        BusinessEntityViewModel, IPersonBusinessEntityViewModel
    {
        private readonly IPerson _person;

        public PersonBusinessEntityViewModel(
            IPerson entity,
            ICountryViewModelFactory countryViewModelFactory,
            ISourceDocumentChildCollectionViewModelFactory sourceDocumentCollectionViewModelFactory,
            IBusinessEntitySourceDocumentTypeChildCollectionViewModelFactory businessEntitySourceDocumentTypeChildCollectionViewModelFactory,
            IRepository<Country> countryrepository,
            IDictionary<string, List<string>> errors
        ) :
        base(
            entity,
            countryViewModelFactory,
            sourceDocumentCollectionViewModelFactory,
            businessEntitySourceDocumentTypeChildCollectionViewModelFactory,
            countryrepository,
            errors
            )
        {
            _person = Entity as IPerson;
        }

        [Required]
        public string FirstName
        {
            get => _person.FirstName;
            set
            {
                (Entity as IPerson).FirstName = value;
                RaisePropertyChanged();
            }
        }

        [Required]
        public string LastName
        {
            get => _person.LastName;
            set
            {
                _person.LastName = value;
                RaisePropertyChanged();
            }
        }

        public override string Name => FirstName + LastName;

        public DateTime? DateOfBirth
        {
            get => _person.DateOfBirth;
            set
            {
                if (_person.DateOfBirth != value)
                {
                    _person.DateOfBirth = value.Value;
                    RaisePropertyChanged();
                }
            }
        }

        public int Gender
        {
            get => _person.Gender;
            set
            {
                if (_person.Gender != value)
                {
                    _person.Gender = value;
                    RaisePropertyChanged();
                }
            }
        }
    }
}
