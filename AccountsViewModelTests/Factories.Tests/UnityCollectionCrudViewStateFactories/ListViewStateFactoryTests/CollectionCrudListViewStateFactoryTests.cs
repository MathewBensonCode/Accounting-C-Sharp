using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CollectionCrudViewStateFactories;
using AccountsViewModel.Factories.Unity.CollectionCrudViewStateFactories;
using AccountsViewModel.Repositories.Interfaces;
using AccountsViewModelTests.AutofixtureAttributes;
using AutoFixture.Xunit2;
using Moq;
using Unity;
using Unity.Resolution;
using Xunit;

namespace AccountsViewModelTests.Factories.Tests.UnityCollectionCrudViewStateFactories.ListViewStateFactoryTests
{
    public abstract class UnityCollectionCrudListViewStateFactoryTests<T> where T : class
    {
        [Theory, AutoCatalogData]
        public void ShouldBeOfTypeICollectionCrudListViewStateFactory(
            CollectionCrudListViewStateFactory<T> sut
            )
        {
            Assert.IsAssignableFrom<ICollectionCrudListViewStateFactory<T>>(sut);
        }

        [Theory, AutoCatalogData]
        public void ShouldCreateACollectionListViewStateEntityUsingUnity(
            [Frozen] Mock<IRepository<T>> repository,
            [Frozen] Mock<IEntityCollectionViewModel<T>> collectionvm,
            [Frozen] Mock<IUnityContainer> container,
            Mock<ICollectionListViewModelState<T>> liststate,
            CollectionCrudListViewStateFactory<T> sut
            )
        {
            container.Setup(a => a.Resolve(typeof(ICollectionListViewModelState<T>), null,
                new ResolverOverride[]
                {
                    new ParameterOverride("repository", repository.Object),
                    new ParameterOverride("entityCollectionViewModel", collectionvm.Object),
                }
                )).Returns(liststate.Object);
            sut.CreateEntityListView(collectionvm.Object, repository.Object);

            Assert.IsAssignableFrom<ICollectionListViewModelState<T>>(
                sut.CreateEntityListView(collectionvm.Object, repository.Object));

        }

    }
}
