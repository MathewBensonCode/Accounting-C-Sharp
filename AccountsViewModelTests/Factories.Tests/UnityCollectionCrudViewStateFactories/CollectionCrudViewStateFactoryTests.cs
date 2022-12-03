using Accounts.Repositories;
using AutoFixture.Xunit2;
using Moq;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Factories.Unity.CollectionCrudViewStateFactories;
using AccountsViewModel.Xunit.Tests.autofixtureattributes;
using Unity;
using Unity.Resolution;
using Xunit;

namespace AccountsViewModel.Xunit.Tests.Factories.Tests.UnityCollectionCrudViewStateFactories
{
    abstract public class UnityCollectionCrudViewStateFactoryTests<T> where T: class
    {
        [Theory, AutoCatalogData]
        public void ShouldCreateACollectionListViewStateEntityUsingUnity(
            [Frozen]Mock<IRepository<T>> repository,
            [Frozen]Mock<IEntityCollectionViewModel<T>> collectionvm,
            [Frozen]Mock<IUnityContainer> container,
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
