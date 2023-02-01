using System.Windows.Input;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.CommandViewModels.CollectionCommands;
using AccountsViewModel.EntityViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.ViewModelFactories;
using AccountsViewModelTests.AutofixtureAttributes;
using AutoFixture.Xunit2;
using Moq;
using Xunit;

namespace AccountsViewModelTests.CommandViewModelTests.CollectionCrudTests.SelectAddNewCommandTests
{
    public abstract class SelectAddNewCommandTests<T> where T : class
    {
        [Theory, AutoCatalogData]
        public void ShouldImplementICommandInterface(
            SelectAddViewCommand<T> sut
            )
        {
            Assert.IsAssignableFrom<ICommand>(sut);
        }

        [Theory, AutoCatalogData]
        public void ShouldSetAddViewToCollectionViewModel(
            [Frozen] Mock<IEntityCollectionViewModel<T>> collectionViewModel,
            [Frozen] Mock<ICollectionAddViewModelState<T>> addviewmodelstate,
            SelectAddViewCommand<T> sut
            )
        {
            sut.Execute(typeof(T).ToString());
            collectionViewModel.VerifySet(a => a.CollectionViewState = addviewmodelstate.Object);
        }

        [Theory, AutoCatalogData]
        public void ShouldAddNewEntityToAddViewModel(
            [Frozen] Mock<IEntityViewModel<T>> entityvm,
            [Frozen] Mock<ICollectionAddViewModelState<T>> addViewModelState,
            [Frozen] Mock<IViewModelFactory<T>> viewModelFactory,
            SelectAddViewCommand<T> sut
            )
        {
            viewModelFactory.Setup(a => a.CreateViewModelForNewEntity(It.IsAny<string>()))
                .Returns(entityvm.Object);

            sut.Execute(typeof(T).ToString());
            addViewModelState.VerifySet(a => a.EntityViewModel = entityvm.Object);
        }
    }
}
