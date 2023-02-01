using System.Collections.Generic;
using AccountLib.Model.BusinessEntities;
using AccountsModelCore.Classes;
using AccountsViewModel.CollectionCrudViews;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CommandViewModelFactories;
using AccountsViewModel.Repositories.Interfaces;
using Moq;
using Xunit;

namespace AccountsViewModelTests.CollectionViewModelStates
{
    public abstract class BusinessEntityAddEditCollectionViewModelStateTests
    {
        protected Mock<IEnumerable<Country>> Countrylist { get; private set; }
        protected Mock<IRepository<Country>> Countryrepository { get; private set; }
        protected Mock<IRepository<BusinessEntity>> Businessentityrepository { get; private set; }
        protected Mock<ICollectionListViewModelState<BusinessEntity>> Businessentitylistcollectionviewmodelstate { get; private set; }
        protected Mock<IEntityCollectionViewModel<BusinessEntity>> Businessentitycollectionviewmodel { get; private set; }
        protected Mock<ICommandViewModelFactory<BusinessEntity>> Businessentitycommandviewmodelfactory { get; private set; }
        protected abstract BusinessEntityAddEditCollectionViewModelState Sut { get; set; }

        public BusinessEntityAddEditCollectionViewModelStateTests()
        {
            Countrylist = new Mock<IEnumerable<Country>>();
            Countryrepository = new Mock<IRepository<Country>>();
            Businessentityrepository = new Mock<IRepository<BusinessEntity>>();
            Businessentitylistcollectionviewmodelstate = new Mock<ICollectionListViewModelState<BusinessEntity>>();
            _ = Countryrepository.Setup(a => a.GetAll()).Returns(Countrylist.Object);
            Businessentitycollectionviewmodel = new Mock<IEntityCollectionViewModel<BusinessEntity>>();
            Businessentitycommandviewmodelfactory = new Mock<ICommandViewModelFactory<BusinessEntity>>();
        }

        [Fact]
        public void ShouldImplementIBusinessEntityAddEditCollectionViewModelState()
        {
            _ = Assert.IsAssignableFrom<IBusinessEntityAddEditCollectionViewModelState>(Sut);
        }

        [Fact]
        public void ShouldHaveAPropertyWithAListOfCountriesFromTheRepository()
        {
            Assert.Same(Countrylist.Object, Sut.CountryList);
        }
    }
}
