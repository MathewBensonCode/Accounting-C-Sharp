using System.Windows.Input;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.CommandViewModels.CollectionCommands;
using AccountsViewModel.EntityViewModels.Interfaces;
using AccountsViewModel.Repositories.Interfaces;
using AccountsViewModel.Services.Interfaces;
using Moq;
using Xunit;

namespace AccountsViewModelTests.CommandViewModelTests.CollectionCrudTests.SaveEditToCollectionCommandTests
{
    public abstract class SaveEditToRepositoryCommandTests<T> where T : class
    {
        private readonly Mock<IEntityViewModel<T>> editEntityViewModel;
        private readonly Mock<IEntityViewModel<T>> currentEntityViewModel;
        private readonly Mock<ICollectionEditViewModelState<T>> editViewModelState;
        private readonly Mock<ICollectionListViewModelState<T>> listViewModelState;
        private readonly Mock<IViewModelCopyService<T>> copyService;
        private readonly Mock<IEntityCollectionViewModel<T>> collectionViewModel;
        private readonly Mock<IRepository<T>> repository;
        private readonly Mock<ISaveRepository> saveRepository;
        private readonly SaveEditedEntityCommand<T> sut;

        public SaveEditToRepositoryCommandTests()
        {
            editEntityViewModel = new Mock<IEntityViewModel<T>>();
            currentEntityViewModel = new Mock<IEntityViewModel<T>>();
            editViewModelState = new Mock<ICollectionEditViewModelState<T>>();
            listViewModelState = new Mock<ICollectionListViewModelState<T>>();
            copyService = new Mock<IViewModelCopyService<T>>();
            collectionViewModel = new Mock<IEntityCollectionViewModel<T>>();
            repository = new Mock<IRepository<T>>();
            saveRepository = repository.As<ISaveRepository>();

            editViewModelState.Setup(a => a.EntityViewModel).Returns(editEntityViewModel.Object);
            listViewModelState.Setup(a => a.EntityViewModel).Returns(currentEntityViewModel.Object);

            sut = new SaveEditedEntityCommand<T>(
                editViewModelState.Object,
                listViewModelState.Object,
                copyService.Object,
                collectionViewModel.Object,
                repository.Object
                );
        }

        [Fact]
        public void ShouldBeOfTypeICommand()
        {
            Assert.IsAssignableFrom<ICommand>(sut);
        }

        [Fact]
        public void ShouldCopyValuesFromEditedEntityToOriginalEntity()
        {

            sut.Execute();
            copyService.Verify(c => c.CopyEntityViewModel(editEntityViewModel.Object, currentEntityViewModel.Object), Times.Once);
        }

        [Fact]
        public void ShouldSaveChangesToRepositoryIfRepositoryIsISaveRepository()
        {
            sut.Execute();
            saveRepository.Verify((a) => a.SaveRepository(), Times.Once);
        }

        [Fact]
        public void ShouldChangeToListViewModelState()
        {
            sut.Execute();
            collectionViewModel.VerifySet(a => a.CollectionViewState = listViewModelState.Object);
        }
    }
}
