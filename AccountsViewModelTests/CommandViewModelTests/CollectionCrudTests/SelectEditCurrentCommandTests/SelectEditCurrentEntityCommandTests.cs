using System.Windows.Input;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.CommandViewModels.CollectionCommands;
using AccountsViewModel.EntityViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.ViewModelFactories;
using AccountsViewModel.Services.Interfaces;
using AccountsViewModelTests.AutofixtureAttributes;
using AutoFixture.Xunit2;
using Moq;
using Xunit;

namespace AccountsViewModelTests.CommandViewModelTests.CollectionCrudTests.SelectEditCurrentCommandTests
{
    public abstract class SelectEditCurrentEntityCommandTests<T>
        where T : class, new()
    {
        [Theory, AutoCatalogData]
        public void ShouldBeOfTypeICommand(
            SelectEditViewCommand<T> sut
            )
        {
            Assert.IsAssignableFrom<ICommand>(sut);
        }

        [Theory, AutoCatalogData]
        public void ShouldSetEditViewToCollectionViewModel(
            [Frozen] Mock<IEntityCollectionViewModel<T>> collectionvm,
            [Frozen] Mock<ICollectionEditViewModelState<T>> editviewstate,
            SelectEditViewCommand<T> sut
            )
        {
            sut.Execute(null);
            collectionvm.VerifySet(a => a.CollectionViewState = editviewstate.Object);
        }

        [Theory, AutoCatalogData]
        public void ShouldSetTheEntityViewModelToBeANewEntity(
            Mock<IEntityViewModel<T>> NewEntity,
            [Frozen] Mock<IViewModelFactory<T>> viewModelFactory,
            [Frozen] Mock<ICollectionEditViewModelState<T>> editViewState,
            SelectEditViewCommand<T> sut
            )
        {
            viewModelFactory.Setup(a => a.CreateViewModelForNewEntity(null))
             .Returns(NewEntity.Object);
            sut.Execute(null);
            editViewState.VerifySet(a => a.EntityViewModel = NewEntity.Object);
        }

        [Theory, AutoCatalogData]
        public void ShouldCopyValuesFromCurrentEntityToTheEditEntity(
            Mock<IEntityViewModel<T>> listviewstateentity,
            Mock<IEntityViewModel<T>> NewEntity,
            [Frozen] Mock<IViewModelFactory<T>> viewModelFactory,
            [Frozen] Mock<ICollectionListViewModelState<T>> listviewstate,
            [Frozen] Mock<ICollectionEditViewModelState<T>> editviewstate,
            [Frozen] Mock<IViewModelCopyService<T>> viewModelCopyService,
            SelectEditViewCommand<T> sut
            )
        {
            viewModelFactory.Setup(a => a.CreateViewModelForNewEntity(null))
           .Returns(NewEntity.Object);
            listviewstate.Setup(l => l.EntityViewModel).Returns(listviewstateentity.Object);
            editviewstate.SetupProperty(a => a.EntityViewModel);
            sut.Execute(null);
            viewModelCopyService.Verify(a => a.CopyEntityViewModel(listviewstateentity.Object, NewEntity.Object), Times.Once);
        }

        [Theory, AutoCatalogData]
        public void ShouldNotExecuteIfCurrentEntityIsNull(
            [Frozen] Mock<ICollectionListViewModelState<T>> collectionviewstate,
            SelectEditViewCommand<T> sut
            )
        {
            collectionviewstate.Setup(a => a.EntityViewModel)
                .Returns<IEntityViewModel<T>>(null);
            Assert.False(sut.CanExecute(null));

        }

        //[Theory, AutoCatalogData]
        //public void ShouldCreateEditViewUsingFactory(
        //    [Frozen]Mock<ICollectionCrudEditViewStateFactory<T>> viewStateFactory,
        //    SelectEditViewCommand<T> sut
        //    )
        //{

        //    sut.Execute();

        //}

    }
}
