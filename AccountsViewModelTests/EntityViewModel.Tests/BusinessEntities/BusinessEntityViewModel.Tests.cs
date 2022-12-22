using System.Collections.Generic;
using AccountLib.Model.BusinessEntities;
using AccountsModelCore.Classes;
using AccountsModelCore.Interfaces.BusinessEntities;
using AccountsViewModel.EntityViewModels.Classes.BusinessEntities;
using AccountsViewModel.Factories.Interfaces.CollectionViewModelFactories;
using AccountsViewModel.Factories.Interfaces.ViewModelFactories;
using AccountsViewModel.Repositories.Interfaces;
using Moq;
using Xunit;

namespace AccountsViewModelTests.EntityViewModel.Tests.BusinessEntities
{
    public abstract class BusinessEntityViewModelTests
        : EntityViewModelTests<BusinessEntity>
    {
        private readonly string TestString = "teststring";
        private readonly int TestId = 5;
        protected Mock<ICountryViewModelFactory> CountryViewModelFactory { get; set; }
        protected Mock<ISourceDocumentChildCollectionViewModelFactory> SourceDocumentChildCollectionViewModelFactory { get; set; }
        protected Mock<IBusinessEntitySourceDocumentTypeChildCollectionViewModelFactory> BusinessEntitySourceDocumentTypeViewModelFactory { get; set; }
        protected Mock<IRepository<Country>> Countryrepository { get; set; }
        protected abstract BusinessEntityViewModel BusinessEntityViewModelSut { get; set; }
        protected string Initialnamestring { get; } = "initialname";
        private readonly IEnumerable<Country> countrylist;

        public BusinessEntityViewModelTests()
        {
            countrylist = new List<Country>();
            CountryViewModelFactory = new Mock<ICountryViewModelFactory>();
            SourceDocumentChildCollectionViewModelFactory = new Mock<ISourceDocumentChildCollectionViewModelFactory>();
            BusinessEntitySourceDocumentTypeViewModelFactory = new Mock<IBusinessEntitySourceDocumentTypeChildCollectionViewModelFactory>();
            Countryrepository = new Mock<IRepository<Country>>();
        }

        [Fact]
        public void GetsUnderlyingNameThroughNameProperty()
        {
            Entity.Name = Initialnamestring;
            var name = BusinessEntityViewModelSut.Name;
            Assert.Equal(Initialnamestring, name);
        }

        [Fact]
        public void SetsUnderlyingNameWhenNamePropertySet()
        {
            BusinessEntityViewModelSut.Name = TestString;
            Assert.Equal(TestString, Entity.Name);
        }

        [Fact]
        public void RaisesPropertyChangedEventWhenNamePropertySet()
        {
            Assert.PropertyChanged(BusinessEntityViewModelSut, "Name", () => { BusinessEntityViewModelSut.Name = TestString; });
        }

        [Fact]
        public void GetsUnderlyingCountryIdThroughCountryIdProperty()
        {
            Entity.CountryId = TestId;
            Assert.Equal(TestId, BusinessEntityViewModelSut.CountryId);
        }

        [Fact]
        public void SetsUnderlyingCountryIdWhenCountryIdPropertySet()
        {
            var newid = TestId + 5;
            BusinessEntityViewModelSut.CountryId = newid;
            Assert.Equal(newid, BusinessEntityViewModelSut.CountryId);
        }

        [Fact]
        public void RaisesPropertyChangedEvenWhenCountryIdPropertySet()
        {
            Assert.PropertyChanged(BusinessEntityViewModelSut, "CountryId", () => { BusinessEntityViewModelSut.CountryId = TestId; });
        }

        [Fact]
        public void GetsUnderlyingBusinessEntityNameRegexThroughBusinessEntityNameRegexProperty()
        {
            Entity.BusinessEntityNameRegex = TestString;
            Assert.Equal(TestString, BusinessEntityViewModelSut.BusinessEntityNameRegex);
        }

        [Fact]
        public void SetsUnderlyingBusinessEntityNameRegexWhenBusinessEntityNameRegexPropertySet()
        {
            BusinessEntityViewModelSut.BusinessEntityNameRegex = TestString;
            Assert.Equal(TestString, Entity.BusinessEntityNameRegex);
        }

        [Fact]
        public void RaisesPropertyChangedEventWhenBusinessEntityNameRegexPropertySet()
        {
            Assert.PropertyChanged(BusinessEntityViewModelSut, "BusinessEntityNameRegex", () => { BusinessEntityViewModelSut.BusinessEntityNameRegex = TestString; });
        }

        [Fact]
        public void ShouldHaveAProperyWithListOfCountryNamesForSelection()
        {
            Countryrepository.Setup(a => a.GetAll()).Returns(countrylist);
            Assert.Equal(countrylist, BusinessEntityViewModelSut.CountryList);
        }

        [Fact]
        public void ShouldCreateAChildCollectionOfBusinessEntitySourceDocumentType()
        {
            var temp = BusinessEntityViewModelSut.BusinessEntitySourceDocumentTypes;
            BusinessEntitySourceDocumentTypeViewModelFactory
                .Verify(a => a.GetBusinessEntitySourceDocumentTypeCollectionViewModelForBusinessEntity(It.IsAny<IBusinessEntity>()), Times.AtLeastOnce);
        }
    }
}
