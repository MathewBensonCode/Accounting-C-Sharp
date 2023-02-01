using System.Windows.Input;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.CommandViewModels.CollectionCommands;
using Moq;
using Xunit;

namespace AccountsViewModelTests.CommandViewModelTests.CollectionCrudTests.CancelAddNewToCollectionCommandTests
{
    public abstract class CancelAddNewEntityToCollectionCommandTests<T> where T : class
    {
        private Mock<IEntityCollectionViewModel<T>> CollectionViewModel { get; set; }
        private Mock<ICollectionListViewModelState<T>> ListViewState { get; set; }
        protected CancelAddNewAndEditCommand<T> Sut { get; set; }

        public CancelAddNewEntityToCollectionCommandTests()
        {
            CollectionViewModel = new Mock<IEntityCollectionViewModel<T>>();
            ListViewState = new Mock<ICollectionListViewModelState<T>>();
            Sut = new CancelAddNewAndEditCommand<T>(
                CollectionViewModel.Object,
                ListViewState.Object
               );
        }

        [Fact]
        public void ShouldBeOfTypeICommand()
        {
            Assert.IsAssignableFrom<ICommand>(Sut);
        }

        [Fact]
        public void ShouldReturnCollectionViewModelToListState()
        {
            Sut.Execute();
            CollectionViewModel.VerifySet(a => a.CollectionViewState = ListViewState.Object);
        }
    }
}
