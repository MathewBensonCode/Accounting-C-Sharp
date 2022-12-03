using Accounts.Repositories;
using AutoFixture.Xunit2;
using Moq;
using System.Windows.Input;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CommandViewModels.NavigationCommands;
using AccountsViewModel.Xunit.Tests.autofixtureattributes;
using Xunit;

namespace AccountsViewModelTests.CommandViewModelTests.CollectionNavigationTests.GoToEndCollectionCommandTests
{
    public abstract class GoToEndCollectionCommandTests<T> where T : class
    {
        [Theory, AutoCatalogData]
        public void ShouldImplementICommandInterface(
            GoToEndCollectionCommand<T> sut
            )
        {
            Assert.IsAssignableFrom<ICommand>(sut);
        }

        [Theory, AutoCatalogData]
        public void ShouldSetCurrentPageToBeLastPossiblePage(
            [Frozen] Mock<IRepository<T>> repository,
            [Frozen] Mock<ICollectionListViewModelState<T>> listcollectionviewmodelstate,
            GoToEndCollectionCommand<T> sut
            )
        {
            repository.Setup(a => a.Count).Returns(30);
            repository.Setup(a => a.GetPageSize()).Returns(5);
            sut.Execute();
            listcollectionviewmodelstate.VerifySet(a => a.CurrentPage = 6);
        }

        [Theory, AutoCatalogData]
        public void ShouldNotSetCurrentPageIfTheLastPageIsFirstPage(
            [Frozen] Mock<IRepository<T>> repository,
            [Frozen] Mock<ICollectionListViewModelState<T>> listcollectionviewmodelstate,
            GoToEndCollectionCommand<T> sut
            )
        {
            repository.Setup(a => a.Count).Returns(5);
            repository.Setup(a => a.GetPageSize()).Returns(10);
            listcollectionviewmodelstate.Setup(a => a.CurrentPage).Returns(1);
            Assert.False(sut.CanExecute());
        }

        [Theory, AutoCatalogData]
        public void ShouldNotExecuteIfAlreadyOnTheLastPage(
            [Frozen] Mock<IRepository<T>> repository,
            [Frozen] Mock<ICollectionListViewModelState<T>> listcollectionviewmodelstate,
            GoToEndCollectionCommand<T> sut
            )
        {
            repository.Setup(a => a.Count).Returns(30);
            repository.Setup(a => a.GetPageSize()).Returns(5);
            listcollectionviewmodelstate.Setup(a => a.CurrentPage).Returns(6);
            Assert.False(sut.CanExecute());

        }

    }
}
