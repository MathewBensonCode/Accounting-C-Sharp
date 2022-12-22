using System.Collections.Generic;
using System.Windows.Input;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.CommandViewModels.CollectionCommands;
using AccountsViewModel.EntityViewModels.Interfaces;
using AccountsViewModel.Repositories.Interfaces;
using AccountsViewModelTests.AutofixtureAttributes;
using AutoFixture.Xunit2;
using Moq;
using Xunit;

namespace AccountsViewModelTests.CommandViewModelTests.CollectionCrudTests.SaveNewToRepositoryCommandTests
{
    public abstract class SaveNewEntityToRepositoryCommandTests<T> where T : class, new()
    {

        [Theory, AutoCatalogData]
        public void ShouldBeOfTypeICommand(
            SaveNewToRepositoryCommand<T> sut
            )
        {
            _ = Assert.IsAssignableFrom<ICommand>(sut);
        }

        [Theory, AutoCatalogData]
        public void ShouldAddNewEntityToCollection(
            [Frozen] Mock<T> entity,
            [Frozen] Mock<IEntityViewModel<T>> entityvm,
            [Frozen] Mock<IRepository<T>> repository,
            [Frozen] Mock<ICollectionAddViewModelState<T>> addstate,
            [Frozen] Mock<IEntityCollectionViewModel<T>> collectionviewmodel,
            SaveNewToRepositoryCommand<T> sut
            )
        {
            addstate.Setup(a => a.EntityViewModel).Returns(entityvm.Object);
            collectionviewmodel.Setup(a => a.CollectionViewState).Returns(addstate.Object);
            entityvm.Setup(a => a.Entity).Returns(entity.Object);
            sut.Execute();
            repository.Verify(a => a.AddSingle(entity.Object));
        }

        [Theory, AutoCatalogData]
        public void ShouldAddNewEntityViewModelToViewModelCollection(
            [Frozen] Mock<IEntityViewModel<T>> entityvm,
            [Frozen] Mock<ICollectionAddViewModelState<T>> addstate,
            [Frozen] Mock<IEntityCollectionViewModel<T>> collectionviewmodel,
            [Frozen] Mock<IList<IEntityViewModel<T>>> viewModelCollection,
            [Frozen] Mock<ICollectionListViewModelState<T>> collectionViewState,
            SaveNewToRepositoryCommand<T> sut
            )
        {
            addstate.Setup(a => a.EntityViewModel).Returns(entityvm.Object);
            collectionviewmodel.Setup(a => a.CollectionViewState).Returns(addstate.Object);
            collectionViewState.Setup(a => a.EntityCollection).Returns(viewModelCollection.Object);
            sut.Execute();
            viewModelCollection.Verify(a => a.Add(entityvm.Object));
        }

        [Theory, AutoCatalogData]
        public void ShouldReturnToListViewAfterExecution(
            [Frozen] Mock<IEntityViewModel<T>> entityvm,
            [Frozen] Mock<IEntityCollectionViewModel<T>> entityCollectionViewModel,
            [Frozen] Mock<ICollectionListViewModelState<T>> collectionViewState,
            [Frozen] Mock<ICollectionAddViewModelState<T>> addstate,
            [Frozen] Mock<IEntityCollectionViewModel<T>> collectionviewmodel,
            SaveNewToRepositoryCommand<T> sut
            )
        {
            addstate.Setup(a => a.EntityViewModel).Returns(entityvm.Object);
            collectionviewmodel.Setup(a => a.CollectionViewState).Returns(addstate.Object);
            sut.Execute();
            entityCollectionViewModel.VerifySet(a => a.CollectionViewState = collectionViewState.Object);
        }

        [Theory, AutoCatalogData]
        public void ShouldNotExecuteUnlessValidationPasses(
             Mock<IEntityViewModel<T>> entityvm,
            [Frozen] Mock<ICollectionAddViewModelState<T>> addviewstate,
            SaveNewToRepositoryCommand<T> sut)
        {
            entityvm.Setup(a => a.HasErrors).Returns(false);
            entityvm.Setup(a => a.HasChanged).Returns(true);
            addviewstate.Setup(a => a.EntityViewModel).Returns(entityvm.Object);
            Assert.True(sut.CanExecute());
        }

        [Theory, AutoCatalogData]
        public void ShouldNotExecuteIfEntityViewModelHasErrors(
            Mock<IEntityViewModel<T>> entityvm,
            [Frozen] Mock<ICollectionAddViewModelState<T>> addviewstate,
            SaveNewToRepositoryCommand<T> sut
            )
        {
            entityvm.Setup(a => a.HasErrors).Returns(true);
            addviewstate.Setup(a => a.EntityViewModel).Returns(entityvm.Object);
            Assert.False(sut.CanExecute());
        }

        [Theory, AutoCatalogData]
        public void ShouldNotExecuteIfEntityHasNotChanged(
             Mock<IEntityViewModel<T>> entityvm,
            [Frozen] Mock<ICollectionAddViewModelState<T>> addviewstate,
            SaveNewToRepositoryCommand<T> sut
            )
        {
            entityvm.Setup(a => a.HasChanged).Returns(false);
            entityvm.Setup(a => a.HasErrors).Returns(false);
            addviewstate.Setup(a => a.EntityViewModel).Returns(entityvm.Object);
            Assert.False(sut.CanExecute());
        }
    }
}
