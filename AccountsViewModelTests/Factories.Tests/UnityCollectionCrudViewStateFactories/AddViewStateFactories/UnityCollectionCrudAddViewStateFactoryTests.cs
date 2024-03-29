﻿using AccountsViewModel.CollectionCrudViews.Interfaces;
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

namespace AccountsViewModelTests.Factories.Tests.UnityCollectionCrudViewStateFactories.AddViewStateFactories
{
    public abstract class UnityCollectionCrudAddViewStateFactoryTests<T> where T : class
    {
        [Theory, AutoCatalogData]
        public void ShouldBeOfTypeICollectionCrudAddViewStateFactory(
            CollectionCrudAddViewStateFactory<T> sut
            )
        {
            Assert.IsAssignableFrom<ICollectionCrudAddViewStateFactory<T>>(sut);
        }

        [Theory, AutoCatalogData]
        public void ShouldCreateACollectionAddViewStateEntityUsingUnity(
            [Frozen] Mock<IUnityContainer> container,
            [Frozen] Mock<IEntityCollectionViewModel<T>> collectionvm,
            [Frozen] Mock<IRepository<T>> repository,
            [Frozen] Mock<ICollectionListViewModelState<T>> liststate,
            [Frozen] Mock<ICollectionAddViewModelState<T>> addstate,
            CollectionCrudAddViewStateFactory<T> sut
            )
        {
            container.Setup(a => a.Resolve(typeof(ICollectionAddViewModelState<T>), null,
                new ResolverOverride[]
                {
                    new ParameterOverride("listViewModelState", liststate.Object),
                    new ParameterOverride("collectionViewModel", collectionvm.Object),
                    new ParameterOverride("repository", repository.Object)
                }
                )).Returns(addstate.Object);

            Assert.IsAssignableFrom<ICollectionAddViewModelState<T>>(
                sut.CreateEntityAddViewState(
                    liststate.Object,
                    repository.Object,
                    collectionvm.Object)
                    );
        }

    }
}
