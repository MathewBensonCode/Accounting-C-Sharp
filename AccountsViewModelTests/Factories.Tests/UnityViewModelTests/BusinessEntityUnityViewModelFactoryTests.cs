using AccountLib.Model.BusinessEntities;
using Moq;
using AccountsViewModel.EntityViewModels;
using AccountsViewModel.Factories.Unity.ViewModelFactories;
using Unity.Resolution;
using Xunit;
using AccountsViewModel.EntityViewModels.Classes.BusinessEntities;
using AccountsViewModel.Factories.Interfaces.ViewModelFactories;
using AccountsViewModel.Factories.Interfaces.CollectionViewModelFactories;
using Accounts.Repositories;
using AccountLib.Model;
using System.Collections.Generic;
using AccountsViewModel.Factories.Interfaces.ColectionViewModelFactories;

namespace AccountsViewModelTests.Factories.Tests.UnityViewModelTests
{
    public class BusinessEntityUnityViewModelFactoryTests :
        UnityViewModelFactoryTests<BusinessEntity>
    {
        private readonly PersonBusinessEntityViewModel personbusinessentityviewmodel;
        private readonly RegisteredBusinessEntityViewModel registeredbusinessentityviewmodel;
        private readonly CompanyBusinessEntityViewModel companybusinessentityviewmodel;

        private readonly Person person;
        private readonly RegisteredBusiness registeredbusiness;
        private readonly Company company;

        private readonly BusinessEntityUnityViewModelFactory sut;

        protected override UnityViewModelFactory<BusinessEntity> Sut { get; set; }

        public BusinessEntityUnityViewModelFactoryTests()
        {
            person = new();
            registeredbusiness = new();
            company = new();

            var countryviewmodelfactory = new Mock<ICountryViewModelFactory>();
            var sourcedocumentchildcollectionfactory = new Mock<ISourceDocumentChildCollectionViewModelFactory>();
            var businessentitysourcedocumenttypechildcollectionfactory = new Mock<IBusinessEntitySourceDocumentTypeChildCollectionViewModelFactory>();
            var countryrepository = new Mock<IRepository<Country>>();
            var errorcollection = new Mock<IDictionary<string, List<string>>>();
            var businessentitychildcollectionfactory = new Mock<IBusinessEntityChildCollectionViewModelFactory>();

            personbusinessentityviewmodel = new PersonBusinessEntityViewModel(
                    person,
                    countryviewmodelfactory.Object,
                    sourcedocumentchildcollectionfactory.Object,
                    businessentitysourcedocumenttypechildcollectionfactory.Object,
                    countryrepository.Object,
                    errorcollection.Object
                    );

            registeredbusinessentityviewmodel = new RegisteredBusinessEntityViewModel(
                                registeredbusiness,
                                countryviewmodelfactory.Object,
                                businessentitychildcollectionfactory.Object,
                                businessentitysourcedocumenttypechildcollectionfactory.Object,
                                sourcedocumentchildcollectionfactory.Object,
                                countryrepository.Object,
                                errorcollection.Object
                                );

            companybusinessentityviewmodel = new CompanyBusinessEntityViewModel(
                                company,
                                countryviewmodelfactory.Object,
                                businessentitychildcollectionfactory.Object,
                                businessentitysourcedocumenttypechildcollectionfactory.Object,
                                sourcedocumentchildcollectionfactory.Object,
                                countryrepository.Object,
                                errorcollection.Object
                                );

            sut = new BusinessEntityUnityViewModelFactory(
                Repository.Object,
                Container.Object
                );

            Sut = sut;

            _ = Container.Setup(a => a.Resolve(typeof(IEntityViewModel<BusinessEntity>), "Person",
                new ResolverOverride[]
                {
                    new ParameterOverride("entity", person)
                })).Returns(personbusinessentityviewmodel);

            _ = Container.Setup(a => a.Resolve(typeof(IEntityViewModel<BusinessEntity>), "RegisteredBusiness",
                new ResolverOverride[]
                {
                    new ParameterOverride("entity", registeredbusiness)
                })).Returns(registeredbusinessentityviewmodel);

            _ = Container.Setup(a => a.Resolve(typeof(IEntityViewModel<BusinessEntity>), "Company",
                new ResolverOverride[]
                {
                    new ParameterOverride("entity", company)
                })).Returns(companybusinessentityviewmodel);
            ;

        }

        [Fact]
        public void ShouldImplementUnityViewModelFactory()
        {
            _ = Assert.IsAssignableFrom<UnityViewModelFactory<BusinessEntity>>(sut);
        }

        [Fact]
        public void ShouldCreatePersonViewModelWhenEntityIsPerson()
        {
            var newpersonvm = sut.CreateViewModelFromEntity(person);
            Assert.Same(personbusinessentityviewmodel, newpersonvm);
        }

        [Fact]
        public void ShouldCreatePersonViewModelWhenEntityIsRegisteredBusiness()
        {
            var newregisteredbusinessvm = sut.CreateViewModelFromEntity(registeredbusiness);
            Assert.Same(registeredbusinessentityviewmodel, newregisteredbusinessvm);
        }

        [Fact]
        public void ShouldCreatePersonViewModelWhenEntityIsCompany()
        {
            var newcompanyvm = sut.CreateViewModelFromEntity(company);
            Assert.Same(companybusinessentityviewmodel, newcompanyvm);
        }

        [Fact]
        public void ShouldReturnNullForBaseBusinessEntityCreateViewModelFromEntity()
        {
            var entity = new Mock<BusinessEntity>();
            Assert.Null(sut.CreateViewModelFromEntity(entity.Object));
        }

        [Fact]
        public override void ShouldCreateViewModelFromExistingEntity()
        {
        }

        [Fact]
        public override void ShouldCreateViewmodelFromResolveMethodWithNameParameter()
        {
            //This method is replicated in the other tests in this module
        }

    }
}
