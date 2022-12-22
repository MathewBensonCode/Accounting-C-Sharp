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

namespace AccountsViewModelTests.CollectionViewModelStates.AddCollectionViewModelState
{
    public abstract class AddNewEntityToCollectionViewModelTests<T> where T : class
    {
        protected Mock<ICollectionListViewModelState<T>> ListViewModelState { get; private set; }
        protected Mock<IRepository<T>> Repository { get; private set; }
        protected Mock<IEntityCollectionViewModel<T>> CollectionViewModel { get; private set; }
        protected Mock<ICommandViewModelFactory<T>> Commandfactory { get; private set; }
        protected Mock<ICommandViewModel> Commandvm { get; private set; }
        protected DelegateCommand Command { get; private set; }

        protected AddNewEntityToCollectionViewModelState<T> Sut { get; set; }

        public AddNewEntityToCollectionViewModelTests()
        {
            ListViewModelState = new Mock<ICollectionListViewModelState<T>>();
            Repository = new Mock<IRepository<T>>();
            CollectionViewModel = new Mock<IEntityCollectionViewModel<T>>();
            Commandfactory = new Mock<ICommandViewModelFactory<T>>();
            Commandvm = new Mock<ICommandViewModel>();
            Command = new DelegateCommand(() => { });

            _ = Commandvm.Setup(a => a.Command).Returns(Command);

            _ = Commandfactory.Setup(a => a.CreateSaveNewCommand(
                It.IsAny<ICollectionAddViewModelState<T>>(),
                It.IsAny<ICollectionListViewModelState<T>>(),
                It.IsAny<IRepository<T>>(),
                It.IsAny<IEntityCollectionViewModel<T>>())).Returns(Commandvm.Object);

            _ = Commandfactory.Setup(a => a.CreateCancelAddNewEditCommand(
                It.IsAny<ICollectionListViewModelState<T>>(),
                It.IsAny<IEntityCollectionViewModel<T>>())).Returns(Commandvm.Object);

            Sut = new AddNewEntityToCollectionViewModelState<T>(
                ListViewModelState.Object,
                Repository.Object,
                CollectionViewModel.Object,
                Commandfactory.Object
                );
        }

        [Fact]
        public void ShouldHaveACommandPropertyThatAddsNewEntityToCollection()
        {
            var entity = new Mock<IEntityViewModel<T>>();
            Sut.EntityViewModel = entity.Object;
            _ = Assert.IsAssignableFrom<ICommandViewModel>(Sut.SaveCommand);
        }

        [Fact]
        public void ShouldHaveACommandPropertyThatCancelsTheAddProcess()
        {
            Assert.IsAssignableFrom<ICommandViewModel>(Sut.CancelCommand);
        }

    }
}
