using Accounts.Repositories;
using Moq;
using System.Windows.Input;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.CommandViewModels.CollectionCommands;
using AccountsViewModel.EntityViewModels;
using AccountsViewModel.Repositories.Interfaces;
using AccountsViewModel.Services.Interfaces;
using Xunit;

namespace AccountsViewModel.Xunit.Tests.CommandViewModelTests.CollectionCrudTests.SaveEditToCollectionCommandTests
{
    abstract public class SaveEditToRepositoryCommandTests<T> where T : class
    {
        Mock<IEntityViewModel<T>> editEntityViewModel;
        Mock<IEntityViewModel<T>> currentEntityViewModel;
        Mock<ICollectionEditViewModelState<T>> editViewModelState;
        Mock<ICollectionListViewModelState<T>> listViewModelState;
        Mock<IViewModelCopyService<T>> copyService;
        Mock<IEntityCollectionViewModel<T>> collectionViewModel;
        Mock<IRepository<T>> repository;
        Mock<ISaveRepository> saveRepository;

        SaveEditedEntityCommand<T> sut;

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
