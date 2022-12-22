using System.Collections.Generic;
using AccountsViewModel.Factories.Interfaces.RepositoryFactories;
using AccountsViewModel.Factories.Unity.RepositoryFactories;
using AccountsViewModel.Repositories.Interfaces;
using AccountsViewModelTests.AutofixtureAttributes;
using AutoFixture.Xunit2;
using Moq;
using Unity;
using Unity.Resolution;
using Xunit;

namespace AccountsViewModelTests.Factories.Tests.UnityRepositoryFactoryTests
{
    public abstract class UnityRepositoryFactoryTests<T> where T : class
    {
        [Theory, AutoCatalogData]
        public void ShouldImplementIRepositoryFactory(
            RepositoryFactory<T> sut
            )
        {
            Assert.IsAssignableFrom<IRepositoryFactory<T>>(sut);
        }

        [Theory, AutoCatalogData]
        public void ShouldCreateDefaultRepository(
            [Frozen] Mock<IUnityContainer> container,
            Mock<IRepository<T>> repository,
            RepositoryFactory<T> sut
            )
        {
            container.Setup(a => a.Resolve(typeof(IRepository<T>), null, null)).Returns(repository.Object);
            Assert.Equal(repository.Object, sut.CreateDefaultRepository());
        }

        [Theory, AutoCatalogData]
        public void ShouldCreateChildRepositoryForCollection(
            [Frozen] Mock<IUnityContainer> container,
            Mock<ICollection<T>> collection,
            Mock<IRepository<T>> repository,
            RepositoryFactory<T> sut
            )
        {
            container.Setup(a => a.Resolve(typeof(IRepository<T>), "childcollection",
                new ResolverOverride[]
                {
                    new ParameterOverride("collection", collection.Object)
                })).Returns(repository.Object);

            Assert.Equal(repository.Object, sut.CreateRepositoryForCollection(collection.Object));
        }
    }
}
