using Xunit;
using Moq;
using AccountsViewModel.Factories.Interfaces.ColectionViewModelFactories;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountLib.Model.BusinessEntities;
using AccountsViewModel.EntityViewModels.Classes.BusinessEntities;
using AccountsViewModel.EntityViewModels.Classes;
using AccountsModelCore.Interfaces.BusinessEntities;

namespace AccountsViewModelTests.EntityViewModel.Tests.BusinessEntities
{
    public class RegisteredBusinessViewModelTests :
        BusinessEntityViewModelTests
    {
        private readonly RegisteredBusinessEntityViewModel registeredbusinessViewModelSut;
        private readonly Mock<IBusinessEntityChildCollectionViewModelFactory> Businessentitychildcollectionviewmodelfactory;
        private readonly IRegisteredBusiness registeredbusiness;
        protected override BusinessEntityViewModel BusinessEntityViewModelSut { get; set; }
        protected override EntityViewModel<BusinessEntity> Sut { get; set; }
        protected override BusinessEntity Entity { get; set; }

        public RegisteredBusinessViewModelTests()
        {
            Businessentitychildcollectionviewmodelfactory = new Mock<IBusinessEntityChildCollectionViewModelFactory>();
            Entity = new RegisteredBusiness();
            registeredbusiness = (RegisteredBusiness)Entity;

            registeredbusinessViewModelSut = new RegisteredBusinessEntityViewModel(
                registeredbusiness,
                CountryViewModelFactory.Object,
                Businessentitychildcollectionviewmodelfactory.Object,
                BusinessEntitySourceDocumentTypeViewModelFactory.Object,
                SourceDocumentChildCollectionViewModelFactory.Object,
                Countryrepository.Object,
                ErrorCollection.Object
                );

            BusinessEntityViewModelSut = registeredbusinessViewModelSut;
            Sut = BusinessEntityViewModelSut;
        }

        [Fact]
        public void ShouldInheritFromBusinessEntityViewModel()
        {
            _ = Assert.IsAssignableFrom<BusinessEntityViewModel>(registeredbusinessViewModelSut);
        }

        [Fact]
        public void EntityPropertyShouldBeOfTypeIRegisteredBusiness()
        {
            _ = Assert.IsAssignableFrom<IRegisteredBusiness>(registeredbusinessViewModelSut.Entity);
        }

        [Fact]
        public void ShouldHaveARegisteredOwnersCollectionViewModelProperty()
        {
            var registered_owners = new Mock<IEntityCollectionViewModel<BusinessEntity>>();
            _ = Businessentitychildcollectionviewmodelfactory.Setup(a => a.GetOwnersOfRegisteredBusiness(It.IsAny<IRegisteredBusiness>())).Returns(registered_owners.Object);
            _ = Assert.IsAssignableFrom<IEntityCollectionViewModel<BusinessEntity>>(registeredbusinessViewModelSut.RegisteredOwners);
        }
    }
}
