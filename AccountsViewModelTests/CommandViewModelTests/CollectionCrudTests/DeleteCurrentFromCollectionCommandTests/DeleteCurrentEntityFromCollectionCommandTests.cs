using Accounts.Repositories;
using AutoFixture.Xunit2;
using Moq;
using System.Collections.Generic;
using System.Windows.Input;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CommandViewModels.CollectionCommands;
using AccountsViewModel.EntityViewModels;
using AccountsViewModel.Xunit.Tests.autofixtureattributes;
using Xunit;

namespace AccountsViewModelTests.CommandViewModelTests.CollectionCrudTests.DeleteCurrentFromCollectionCommandTests
{
    public abstract class DeleteCurrentEntityFromCollectionCommandTests<T> where T : class
    {
        [Theory, AutoCatalogData]
        public void ShouldBeOfTypeICommand(
        DeleteCurrentEntityFromCollectionCommand<T> sut
            )
        {
            Assert.IsAssignableFrom<ICommand>(sut);
        }

        [Theory, AutoCatalogData]
        public void ShouldRemoveCurrentEntityFromRepositoryWhenCommandExecuted(
            [Frozen] Mock<T> entity,
            [Frozen] Mock<IEntityViewModel<T>> entityvm,
            [Frozen] Mock<IRepository<T>> repository,
            [Frozen] Mock<ICollectionListViewModelState<T>> listcollectionviewstate,
            DeleteCurrentEntityFromCollectionCommand<T> sut
            )
        {
            entityvm.Setup(a => a.Entity).Returns(entity.Object);
            listcollectionviewstate.Setup(a => a.EntityViewModel).Returns(entityvm.Object);
            repository.Setup(a => a.Contains(entity.Object)).Returns(true);
            sut.Execute();
            repository.Verify(a => a.RemoveSingle(entity.Object));
        }

        [Theory, AutoCatalogData]
        public void ShouldOnlyRemoveFromRepositoryIfItExistsInRepository(
            [Frozen] Mock<T> entity,
            [Frozen] Mock<IEntityViewModel<T>> entityvm,
            [Frozen] Mock<IRepository<T>> repository,
            [Frozen] Mock<ICollectionListViewModelState<T>> listcollectionviewstate,
            DeleteCurrentEntityFromCollectionCommand<T> sut
            )
        {
            entityvm.Setup(a => a.Entity).Returns(entity.Object);
            repository.Setup(a => a.Contains(entity.Object)).Returns(false);
            listcollectionviewstate.Setup(a => a.EntityViewModel).Returns(entityvm.Object);
            sut.Execute();
            repository.Verify(a => a.RemoveSingle(entity.Object), Times.Never);
        }

        [Theory, AutoCatalogData]
        public void ShouldRemoveCurrentEntityViewModelFromViewModelCollection(
            [Frozen] Mock<T> entity,
            [Frozen] Mock<IEntityViewModel<T>> entityvm,
            [Frozen] Mock<IRepository<T>> repository,
            [Frozen] Mock<ICollectionListViewModelState<T>> collectionviewstate,
            [Frozen] Mock<IList<IEntityViewModel<T>>> viewmodelcollection,
            DeleteCurrentEntityFromCollectionCommand<T> sut
            )
        {
            entityvm.Setup(a => a.Entity).Returns(entity.Object);
            collectionviewstate.Setup(a => a.EntityCollection).Returns(viewmodelcollection.Object);
            collectionviewstate.Setup(a => a.EntityViewModel).Returns(entityvm.Object);
            repository.Setup(a => a.Contains(entity.Object)).Returns(false);

            sut.Execute();
            viewmodelcollection.Verify(b => b.Remove(entityvm.Object));
        }

        [Theory, AutoCatalogData]
        public void ShouldNotExecuteIfCurrentEntityIsNull(
            [Frozen] Mock<ICollectionListViewModelState<T>> collectionviewstate,
            DeleteCurrentEntityFromCollectionCommand<T> sut
            )
        {
            collectionviewstate.Setup(a => a.EntityViewModel)
                .Returns<IEntityViewModel<T>>(null);
            Assert.False(sut.CanExecute());

        }

        [Theory, AutoCatalogData]
        public void ShouldSetCurrentEntityToNullAfterExecution(
            [Frozen] Mock<ICollectionListViewModelState<T>> collectionviewstate,
            DeleteCurrentEntityFromCollectionCommand<T> sut
            )
        {
            sut.Execute();
            collectionviewstate.VerifySet(a => a.EntityViewModel = null);
        }



    }
}
