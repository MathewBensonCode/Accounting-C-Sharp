using Moq;
using AccountsViewModel.Factories.Unity.ViewModelFactories;
using Unity.Resolution;
using Xunit;
using AccountLib.Model.BusinessEntities;
using AccountsViewModel.EntityViewModels.Interfaces;
using AccountsModelCore.Classes;

namespace AccountsViewModelTests.Factories.Tests.UnityViewModelTests
{
    public class CountryViewModelFactoryTests :
        UnityViewModelFactoryTests<Country>
    {
        protected override UnityViewModelFactory<Country> Sut { get; set; }
        private readonly CountryUnityViewModelFactory sut;
        private readonly Mock<BusinessEntity> businessEntity;

        public CountryViewModelFactoryTests()
        {
            businessEntity = new Mock<BusinessEntity>();
            sut = new CountryUnityViewModelFactory(
                Repository.Object,
                Container.Object
                );
            Sut = sut;
        }

        [Fact]
        public void ShouldCreateCountryViewModelFromBusinessEntity()
        {
            sut.CreateCountryViewModelFromBusinessEntity(businessEntity.Object);
            Container.Verify(a => a.Resolve(typeof(IEntityViewModel<Country>), null,
                new ResolverOverride[] { new ParameterOverride("entity", businessEntity.Object) }));
        }
    }

}
