using System.Windows.Input;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.CommandViewModels.CollectionCommands;
using AccountsViewModel.EntityViewModels.Interfaces;
using AccountsViewModel.Services.Interfaces;
using AccountsViewModelTests.AutofixtureAttributes;
using AutoFixture.Xunit2;
using Moq;
using Xunit;

namespace AccountsViewModelTests.CommandViewModelTests.CollectionCrudTests.SaveEditToCollectionCommandTests
{
    public abstract class SaveEditToCollectionCommandTests<T> where T : class
    {
        [Theory, AutoCatalogData]
        public void ShouldBeOfTypeICommand(
            SaveEditedEntityCommand<T> sut
            )
        {
            Assert.IsAssignableFrom<ICommand>(sut);
        }

        [Theory, AutoCatalogData]
        public void ShouldCopyValuesFromEditedEntityToOriginalEntity(
            Mock<IEntityViewModel<T>> editEntityViewModel,
            Mock<IEntityViewModel<T>> currentEntityViewModel,
            [Frozen] Mock<ICollectionEditViewModelState<T>> editViewModelState,
            [Frozen] Mock<ICollectionListViewModelState<T>> listViewModelState,
            [Frozen] Mock<IViewModelCopyService<T>> copyService,
            SaveEditedEntityCommand<T> sut
            )
        {
            editViewModelState.Setup(a => a.EntityViewModel).Returns(editEntityViewModel.Object);
            listViewModelState.Setup(a => a.EntityViewModel).Returns(currentEntityViewModel.Object);
            sut.Execute();
            copyService.Verify(c => c.CopyEntityViewModel(editEntityViewModel.Object, currentEntityViewModel.Object), Times.Once);
        }

        [Theory, AutoCatalogData]
        public void ShouldChangeToListViewModelState(
            [Frozen] Mock<IEntityCollectionViewModel<T>> collectionViewModel,
            [Frozen] Mock<ICollectionListViewModelState<T>> listViewModelState,
            SaveEditedEntityCommand<T> sut
            )
        {
            sut.Execute();
            collectionViewModel.VerifySet(a => a.CollectionViewState = listViewModelState.Object);
        }
    }
}
