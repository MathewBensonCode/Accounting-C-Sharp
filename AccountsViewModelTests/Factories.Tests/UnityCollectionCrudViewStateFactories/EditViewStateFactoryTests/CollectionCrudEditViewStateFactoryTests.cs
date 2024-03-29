﻿using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Factories.Unity.CollectionCrudViewStateFactories;
using AccountsViewModel.Repositories.Interfaces;
using AccountsViewModelTests.AutofixtureAttributes;
using AutoFixture.Xunit2;
using Moq;
using Unity;
using Unity.Resolution;
using Xunit;

namespace AccountsViewModelTests.Factories.Tests.UnityCollectionCrudViewStateFactories.EditViewStateFactoryTests
{
    public abstract class UnityCollectionCrudEditViewStateFactoryTests<T> where T : class
    {

        [Theory, AutoCatalogData]
        public void ShouldCreateACollectionEditViewStateEntityUsingUnity(
           [Frozen] Mock<IUnityContainer> container,
           [Frozen] Mock<IEntityCollectionViewModel<T>> collectionvm,
           [Frozen] Mock<IRepository<T>> repository,
           Mock<ICollectionListViewModelState<T>> liststate,
           Mock<ICollectionEditViewModelState<T>> editstate,
           CollectionCrudEditViewStateFactory<T> sut
           )
        {
            container.Setup(a => a.Resolve(typeof(ICollectionEditViewModelState<T>), null,
                new ResolverOverride[]
                {
                    new ParameterOverride("collectionViewModel", collectionvm.Object),
                    new ParameterOverride("repository", repository.Object),
                    new ParameterOverride("listViewModelState", liststate.Object)
                }
                )).Returns(editstate.Object);

            Assert.IsAssignableFrom<ICollectionEditViewModelState<T>>(
                sut.CreateEntityEditView(collectionvm.Object, repository.Object, liststate.Object));

        }

    }
}
