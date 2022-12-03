using Xunit;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountLib.Model.BusinessEntities;
using Moq;
using AccountsViewModel.Factories.Interfaces.ColectionViewModelFactories;
using AccountsViewModel.EntityViewModels.Classes.BusinessEntities;
using AccountsModelCore.Interfaces.BusinessEntities;
using AccountsViewModel.EntityViewModels.Classes;

namespace AccountsViewModelTests.EntityViewModel.Tests.BusinessEntities
{
    public class CompanyBusinessEntityViewModelTests :
        BusinessEntityViewModelTests
    {
        private readonly Mock<IBusinessEntityChildCollectionViewModelFactory> BusinessEntityChildCollectionViewModelFactory;
        private readonly CompanyBusinessEntityViewModel companySut;
        private readonly ICompany company;
        private readonly Mock<IEntityCollectionViewModel<BusinessEntity>> businessentities;
        private readonly Mock<IEntityCollectionViewModel<Person>> personentities;
        protected override EntityViewModel<BusinessEntity> Sut { get; set; }
        protected override BusinessEntityViewModel BusinessEntityViewModelSut { get; set; }
        protected override BusinessEntity Entity { get; set; }

        public CompanyBusinessEntityViewModelTests()
        {
            Entity = new Company();
            company = (ICompany)Entity;
            BusinessEntityChildCollectionViewModelFactory = new Mock<IBusinessEntityChildCollectionViewModelFactory>();
            businessentities = new Mock<IEntityCollectionViewModel<BusinessEntity>>();
            personentities = new Mock<IEntityCollectionViewModel<Person>>();
            _ = BusinessEntityChildCollectionViewModelFactory.Setup(a => a.GetDirectorsCollectionForCompany(It.IsAny<ICompany>())).Returns(personentities.Object);

            companySut = new CompanyBusinessEntityViewModel(
                company,
                CountryViewModelFactory.Object,
                BusinessEntityChildCollectionViewModelFactory.Object,
                BusinessEntitySourceDocumentTypeViewModelFactory.Object,
                SourceDocumentChildCollectionViewModelFactory.Object,
                Countryrepository.Object,
                ErrorCollection.Object
                );

            BusinessEntityViewModelSut = companySut;
            Sut = companySut;
        }

        [Fact]
        public void ShouldInheritFromBusinessEntityViewModel()
        {
            _ = Assert.IsAssignableFrom<BusinessEntityViewModel>(companySut);
        }

        [Fact]
        public void EntityPropertyShouldBeOfTypeICompany()
        {
            _ = Assert.IsAssignableFrom<ICompany>(companySut.Entity);
        }

        [Fact]
        public void ShouldHaveAShareHoldersEntityCollectionViewModelProperty()
        {
            _ = BusinessEntityChildCollectionViewModelFactory.Setup(a => a.GetShareHoldersBusinessEntityCollectionForCompany(It.IsAny<ICompany>())).Returns(businessentities.Object);
            _ = Assert.IsAssignableFrom<IEntityCollectionViewModel<BusinessEntity>>(companySut.ShareHoldersCollectionViewModel);
        }

        [Fact]
        public void ShouldHaveADirectorsEntityCollectionViewModelProperty()
        {
            _ = Assert.IsAssignableFrom<IEntityCollectionViewModel<Person>>(companySut.DirectorsCollectionViewModel);
        }
    }
}
