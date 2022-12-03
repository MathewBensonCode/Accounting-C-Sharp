using AccountsViewModel.Factories.Interfaces.ColectionViewModelFactories;
using AccountsViewModel.Factories.Unity.CollectionViewModelFactories;
using AccountsViewModel.Xunit.Tests.autofixtureattributes;
using Xunit;

namespace AccountsViewModel.Xunit.Tests.Factories.Tests.UnityCollectionViewModelTests.UnityChildCollectionViewModelFactoryTests
{
    public class BusinessEntityChildCollectionViewModelFactoryTests
    {
        [Theory, AutoCatalogData]
        public void ShouldImplementIBusinessEntityChileCollectionViewModelFactory(
            BusinessEntityChildCollectionViewModelFactory sut
            )
        {
            Assert.IsAssignableFrom<IBusinessEntityChildCollectionViewModelFactory>(sut);
        }
    }
}
