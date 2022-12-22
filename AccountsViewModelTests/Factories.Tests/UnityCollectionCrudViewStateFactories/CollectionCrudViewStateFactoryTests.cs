using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Factories.Unity.CollectionCrudViewStateFactories;
using AccountsViewModel.Repositories.Interfaces;
using AccountsViewModelTests.AutofixtureAttributes;
using AutoFixture.Xunit2;
using Moq;
using Unity;
using Unity.Resolution;
using Xunit;

namespace AccountsViewModelTests.Factories.Tests.UnityCollectionCrudViewStateFactories
{
    public abstract class UnityCollectionCrudViewStateFactoryTests<T> where T : class
    {
        [Theory, AutoCatalogData]
        public void ShouldCreateACollectionListViewStateEntityUsingUnity(
            [Frozen] Mock<IRepository<T>> repository,
            [Frozen] Mock<IEntityCollectionViewModel<T>> collectionvm,
            [Frozen] Mock<IUnityContainer> container,
            CollectionCrudViewStateFactory<T> sut
            )
        {
            sut.CreateEntityListView(collectionvm.Object, repository.Object);
            container.Verify(a => a.Resolve(typeof(ICollectionListViewModelState<T>), null,
                new ResolverOverride[]
                {
                    new ParameterOverride("repository", repository.Object),
                    new ParameterOverride("collection", collectionvm.Object)
                }
                ));

        }

    }
}
