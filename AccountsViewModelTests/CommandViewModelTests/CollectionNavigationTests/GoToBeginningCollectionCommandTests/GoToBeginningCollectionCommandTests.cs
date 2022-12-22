using System.Windows.Input;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CommandViewModels.NavigationCommands;
using AccountsViewModel.Repositories.Interfaces;
using AccountsViewModelTests.AutofixtureAttributes;
using AutoFixture.Xunit2;
using Moq;
using Xunit;

namespace AccountsViewModelTests.CommandViewModelTests.CollectionNavigationTests.GoToBeginningCollectionCommandTests
{
    public abstract class GoToBeginningCollectionCommandTests<T> where T : class
    {
        [Theory, AutoCatalogData]
        public void ShouldImplementICommandInterface(
            GoToBeginningCollectionCommand<T> sut
            )
        {
            Assert.IsAssignableFrom<ICommand>(sut);
        }

        [Theory, AutoCatalogData]
        public void ShouldNavigateCollectionToFirstPage(
            [Frozen] Mock<IRepository<T>> repository,
            [Frozen] Mock<ICollectionListViewModelState<T>> listcollectionview,
            GoToBeginningCollectionCommand<T> sut
            )
        {
            repository.Setup(a => a.Count).Returns(20);
            repository.Setup(a => a.GetPageSize()).Returns(4);
            sut.Execute();
            listcollectionview.VerifySet(a => a.CurrentPage = 1);
        }

        [Theory, AutoCatalogData]
        public void ShouldNotExecuteIfPagesNotMoreThanOne(
            [Frozen] Mock<IRepository<T>> repository,
            [Frozen] Mock<ICollectionListViewModelState<T>> listcollectionviewmodel,
            GoToBeginningCollectionCommand<T> sut
            )
        {
            repository.Setup(a => a.Count).Returns(10);
            repository.Setup(a => a.GetPageSize()).Returns(20);
            listcollectionviewmodel.Setup(a => a.CurrentPage).Returns(1);
            Assert.False(sut.CanExecute());
        }

        [Theory, AutoCatalogData]
        public void ShouldNotExecuteIfCurrentPageIsAlreadyAtBeginning(
            [Frozen] Mock<IRepository<T>> repository,
            [Frozen] Mock<ICollectionListViewModelState<T>> listcollectionviewmodelstate,
            GoToBeginningCollectionCommand<T> sut
            )
        {
            repository.Setup(a => a.Count).Returns(10);
            repository.Setup(a => a.GetPageSize()).Returns(5);
            listcollectionviewmodelstate.Setup(a => a.CurrentPage).Returns(1);
            Assert.False(sut.CanExecute());
        }

    }

}
