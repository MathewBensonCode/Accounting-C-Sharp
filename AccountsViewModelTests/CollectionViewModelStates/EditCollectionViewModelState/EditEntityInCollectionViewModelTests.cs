using AccountsViewModel.CollectionCrudViews;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.CommandViewModels.Interfaces;
using AccountsViewModel.EntityViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CommandViewModelFactories;
using AccountsViewModel.Repositories.Interfaces;
using Moq;
using Prism.Commands;
using Xunit;

namespace AccountsViewModelTests.CollectionViewModelStates.EditCollectionViewModelState
{
    public abstract class EditEntityInCollectionViewModelTests<T> where T : class
    {
        private readonly Mock<ICollectionListViewModelState<T>> listcollectionviewmodelstate;
        private readonly Mock<IRepository<T>> repository;
        private readonly Mock<IEntityCollectionViewModel<T>> collectionviewmodel;
        private readonly Mock<ICommandViewModelFactory<T>> commandfactory;
        private readonly Mock<ICommandViewModel> commandviewmodel;
        private readonly DelegateCommand command;

        private readonly Mock<IEntityViewModel<T>> editEntity;

        private readonly EditEntityInCollectionViewModelState<T> sut;

        public EditEntityInCollectionViewModelTests()
        {
            listcollectionviewmodelstate = new Mock<ICollectionListViewModelState<T>>();
            repository = new Mock<IRepository<T>>();
            collectionviewmodel = new Mock<IEntityCollectionViewModel<T>>();
            commandfactory = new Mock<ICommandViewModelFactory<T>>();
            editEntity = new Mock<IEntityViewModel<T>>();

            command = new DelegateCommand(() => { });

            commandviewmodel = new Mock<ICommandViewModel>();

            _ = commandviewmodel.Setup(a => a.Command)
                .Returns(command);

            _ = commandfactory.Setup(a => a.CreateSaveEditCommand(
                It.IsAny<ICollectionEditViewModelState<T>>(),
                It.IsAny<ICollectionListViewModelState<T>>(),
                It.IsAny<IRepository<T>>(),
                It.IsAny<IEntityCollectionViewModel<T>>()
                ))
                .Returns(commandviewmodel.Object);

            _ = commandfactory.Setup(a => a.CreateCancelAddNewEditCommand(
                It.IsAny<ICollectionListViewModelState<T>>(),
                It.IsAny<IEntityCollectionViewModel<T>>()
                ))
                .Returns(commandviewmodel.Object);

            sut = new EditEntityInCollectionViewModelState<T>(
                listcollectionviewmodelstate.Object,
                repository.Object,
                collectionviewmodel.Object,
                commandfactory.Object
                )
            {
                EntityViewModel = editEntity.Object
            };
        }

        [Fact]
        public void ShouldHaveAPropertyWithTheEntityToBeEdited()
        {
            _ = Assert.IsAssignableFrom<IEntityViewModel<T>>(sut.EntityViewModel);
        }

        [Fact]
        public void ShouldHaveAPropertyWithTheCommandToSaveTheEdit()
        {
            _ = Assert.IsAssignableFrom<ICommandViewModel>(sut.SaveCommand);
        }

        [Fact]
        public void ShouldHaveAPropertyWithCommandToCancelTheEdit()
        {
            _ = Assert.IsAssignableFrom<ICommandViewModel>(sut.CancelCommand);
        }
    }
}
