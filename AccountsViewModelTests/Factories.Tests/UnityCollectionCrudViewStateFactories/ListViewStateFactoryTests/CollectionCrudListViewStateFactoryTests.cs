using Accounts.Repositories;
using AutoFixture.Xunit2;
using Moq;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CollectionCrudViewStateFactories;
using AccountsViewModel.Factories.Unity.CollectionCrudViewStateFactories;
using AccountsViewModel.Xunit.Tests.autofixtureattributes;
using Unity;
using Unity.Resolution;
using Xunit;

namespace AccountsViewModel.Xunit.Tests.Factories.Tests.UnityCollectionCrudViewStateFactories.ListViewStateFactories
{
    abstract public class UnityCollectionCrudListViewStateFactoryTests<T> where T: class
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
            [Frozen]Mock<IRepository<T>> repository,
            [Frozen]Mock<IEntityCollectionViewModel<T>> collectionvm,
            [Frozen]Mock<IUnityContainer> container,
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
