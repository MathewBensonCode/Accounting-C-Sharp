using AutoFixture.Xunit2;
using Moq;
using System.Windows.Input;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.CommandViewModels.CollectionCommands;
using Xunit;

namespace AccountsViewModelTests.CommandViewModelTests.CollectionCrudTests.CancelAddNewToCollectionCommandTests
{
    public abstract class CancelAddNewEntityToCollectionCommandTests<T> where T : class
    {
        Mock<IEntityCollectionViewModel<T>> collectionViewModel { get; set; }
        Mock<ICollectionListViewModelState<T>> listViewState { get; set; }
        protected CancelAddNewAndEditCommand<T> sut { get; set; }

        public CancelAddNewEntityToCollectionCommandTests()
        {
            collectionViewModel = new Mock<IEntityCollectionViewModel<T>>();
            listViewState = new Mock<ICollectionListViewModelState<T>>();
            sut = new CancelAddNewAndEditCommand<T>(
                collectionViewModel.Object,
                listViewState.Object
               );
        }

        [Fact]
        public void ShouldBeOfTypeICommand()
        {
            Assert.IsAssignableFrom<ICommand>(sut);
        }

        [Fact]
        public void ShouldReturnCollectionViewModelToListState()
        {
            sut.Execute();
            collectionViewModel.VerifySet(a => a.CollectionViewState = listViewState.Object);
        }
    }
}
