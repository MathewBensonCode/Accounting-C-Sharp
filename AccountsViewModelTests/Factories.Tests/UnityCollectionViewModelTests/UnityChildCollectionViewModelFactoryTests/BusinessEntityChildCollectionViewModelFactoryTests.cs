using AccountsViewModel.Factories.Interfaces.CollectionViewModelFactories;
using AccountsViewModel.Factories.Unity.CollectionViewModelFactories;
using AccountsViewModelTests.AutofixtureAttributes;
using Xunit;

namespace AccountsViewModelTests.Factories.Tests.UnityCollectionViewModelTests.UnityChildCollectionViewModelFactoryTests
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
