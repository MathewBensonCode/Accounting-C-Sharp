using System.Windows.Input;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CommandViewModels.NavigationCommands;
using AccountsViewModel.Repositories.Interfaces;
using AccountsViewModelTests.AutofixtureAttributes;
using AutoFixture.Xunit2;
using Moq;
using Xunit;

namespace AccountsViewModelTests.CommandViewModelTests.CollectionNavigationTests.NextPageCollectionCommandTests
{
    public abstract class NextPageCollectionCommandTests<T> where T : class
    {
        [Theory, AutoCatalogData]
        public void ShouldImplementICommandInterface(
            NextPageCollectionCommand<T> sut
            )
        {
            Assert.IsAssignableFrom<ICommand>(sut);
        }

        [Theory, AutoCatalogData]
        public void ShouldMoveCollectionToTheNextPageWhenExecuted(
            [Frozen] Mock<IRepository<T>> repository,
            [Frozen] Mock<ICollectionListViewModelState<T>> listcollectionviewmodelstate,
            NextPageCollectionCommand<T> sut
            )
        {
            repository.Setup(a => a.Count).Returns(30);
            repository.Setup(a => a.GetPageSize()).Returns(5);
            listcollectionviewmodelstate.SetupProperty(a => a.CurrentPage);
            listcollectionviewmodelstate.Object.CurrentPage = 3;
            sut.Execute();
            Assert.Equal(4, listcollectionviewmodelstate.Object.CurrentPage);
        }

        [Theory, AutoCatalogData]
        public void ShouldNotExecuteIfOnlyOnePage(
            [Frozen] Mock<IRepository<T>> repository,
            [Frozen] Mock<ICollectionListViewModelState<T>> listcollectionviewmodelstate,
            NextPageCollectionCommand<T> sut
            )
        {
            repository.Setup(a => a.Count).Returns(10);
            repository.Setup(a => a.GetPageSize()).Returns(8);
            listcollectionviewmodelstate.SetupProperty(a => a.CurrentPage);
            listcollectionviewmodelstate.Object.CurrentPage = 1;
            Assert.False(sut.CanExecute());
        }

        [Theory, AutoCatalogData]
        public void ShouldNotExecuteIfAlreadyOnLastPage(
            [Frozen] Mock<IRepository<T>> repository,
            [Frozen] Mock<ICollectionListViewModelState<T>> listcollectionviewmodelstate,
            NextPageCollectionCommand<T> sut
            )
        {
            repository.Setup(a => a.Count).Returns(20);
            repository.Setup(a => a.GetPageSize()).Returns(4);
            listcollectionviewmodelstate.Setup(a => a.CurrentPage).Returns(5);
            Assert.False(sut.CanExecute());
        }

    }
}
