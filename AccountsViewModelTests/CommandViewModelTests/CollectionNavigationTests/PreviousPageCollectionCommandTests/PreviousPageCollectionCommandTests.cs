using System.Windows.Input;
using Accounts.Repositories;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CommandViewModels.NavigationCommands;
using AccountsViewModel.Xunit.Tests.autofixtureattributes;
using AutoFixture.Xunit2;
using Moq;
using Xunit;

namespace AccountsViewModelTests.CommandViewModelTests.CollectionNavigationTests.PreviousPageCollectionCommandTests
{
    public abstract class PreviousPageCollectionCommandTests<T> where T : class
    {
        [Theory, AutoCatalogData]
        public void ShouldImplementICommandInterface(
            PreviousPageCollectionCommand<T> sut
            )
        {
            Assert.IsAssignableFrom<ICommand>(sut);
        }

        [Theory, AutoCatalogData]
        public void ShouldGoToPreviousPageWhenExecuted(
            [Frozen] Mock<IRepository<T>> repository,
            [Frozen] Mock<ICollectionListViewModelState<T>> listcollectionviewmodelstate,
            PreviousPageCollectionCommand<T> sut
            )
        {
            repository.Setup(a => a.Count).Returns(20);
            repository.Setup(a => a.GetPageSize()).Returns(5);
            listcollectionviewmodelstate.SetupProperty(a => a.CurrentPage);
            listcollectionviewmodelstate.Object.CurrentPage = 3;
            sut.Execute();
            Assert.Equal(2, listcollectionviewmodelstate.Object.CurrentPage);
        }

        [Theory, AutoCatalogData]
        public void ShouldNotExecuteWhenOnFirstPage(
            [Frozen] Mock<IRepository<T>> repository,
            [Frozen] Mock<ICollectionListViewModelState<T>> collectionlistviewmodelstate,
            PreviousPageCollectionCommand<T> sut
            )
        {
            repository.Setup(a => a.Count).Returns(10);
            repository.Setup(a => a.GetPageSize()).Returns(2);
            collectionlistviewmodelstate.SetupProperty(a => a.CurrentPage);
            collectionlistviewmodelstate.Object.CurrentPage = 1;
            Assert.False(sut.CanExecute());
        }

    }
}
