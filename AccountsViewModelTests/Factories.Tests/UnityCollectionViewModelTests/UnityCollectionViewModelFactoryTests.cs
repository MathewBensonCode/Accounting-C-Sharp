﻿using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Factories.Unity.CollectionViewModelFactories;
using AccountsViewModelTests.AutofixtureAttributes;
using AutoFixture.Xunit2;
using Moq;
using Unity;
using Xunit;

namespace AccountsViewModelTests.Factories.Tests.UnityCollectionViewModelTests
{
    public abstract class UnityCollectionViewModelFactoryTests<T>
        where T : class
    {
        [Theory, AutoCatalogData]
        public void ShouldCreateNewCollectionViewModelUsingUnityContainer(
             Mock<IEntityCollectionViewModel<T>> collection,
            [Frozen] Mock<IUnityContainer> container,
            UnityCollectionViewModelFactory<T> sut
            )
        {
            container.Setup(a => a.Resolve(typeof(IEntityCollectionViewModel<T>), null)).Returns(collection.Object);
            Assert.IsAssignableFrom<IEntityCollectionViewModel<T>>(sut.CreateNewCollectionViewModel());
        }

    }
}
