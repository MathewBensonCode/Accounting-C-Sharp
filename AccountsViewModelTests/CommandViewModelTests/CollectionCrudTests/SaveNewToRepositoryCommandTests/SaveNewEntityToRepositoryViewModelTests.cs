using System.Collections.Generic;
using System.Windows.Input;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.CommandViewModels.CollectionCommands;
using AccountsViewModel.EntityViewModels.Interfaces;
using AccountsViewModel.Repositories.Interfaces;
using Moq;
using Xunit;

namespace AccountsViewModelTests.CommandViewModelTests.CollectionCrudTests.SaveNewToRepositoryCommandTests
{
    public abstract class SaveNewEntityToRepositoryCommandTests<T> where T : class, new()
    {
        protected SaveNewToRepositoryCommand<T> Sut { get; }

        protected T Entity { get; }

        protected Mock<IEntityViewModel<T>> Entityvm { get; }

        protected Mock<IRepository<T>> Repository { get; }

        protected Mock<ISaveRepository> Saverepository { get; }

        protected Mock<ICollectionAddViewModelState<T>> Addstate { get; }

        protected Mock<IEntityCollectionViewModel<T>> Collectionviewmodel { get; }

        protected Mock<ICollectionListViewModelState<T>> Liststate { get; }

        protected Mock<ICollection<IEntityViewModel<T>>> Viewmodelcollection { get; }

        public SaveNewEntityToRepositoryCommandTests()
        {
            Entity = new T();
            Entityvm = new Mock<IEntityViewModel<T>>();
            Repository = new Mock<IRepository<T>>();
            Saverepository = Repository.As<ISaveRepository>();
            Addstate = new Mock<ICollectionAddViewModelState<T>>();
            Liststate = new Mock<ICollectionListViewModelState<T>>();
            Collectionviewmodel = new Mock<IEntityCollectionViewModel<T>>();
            Viewmodelcollection = new Mock<ICollection<IEntityViewModel<T>>>();

            Addstate.Setup(a => a.EntityViewModel).Returns(Entityvm.Object);
            Liststate.Setup(a => a.EntityCollection).Returns(Viewmodelcollection.Object);
            Collectionviewmodel.Setup(a => a.CollectionViewState).Returns(Addstate.Object);
            Entityvm.Setup(a => a.Entity).Returns(Entity);

            Sut = new SaveNewToRepositoryCommand<T>(
                    Collectionviewmodel.Object,
                    Addstate.Object,
                    Liststate.Object,
                    Repository.Object);
        }

        [Fact]
        public void ShouldBeOfTypeICommand()
        {
            _ = Assert.IsAssignableFrom<ICommand>(Sut);
        }

        [Fact]
        public void ShouldAddNewEntityToCollection()
        {
            Sut.Execute();
            Repository.Verify(a => a.AddSingle(Entity));
        }

        [Fact]
        public void ShouldAddNewEntityViewModelToViewModelCollection()
        {
            Addstate.Setup(a => a.EntityViewModel).Returns(Entityvm.Object);
            Collectionviewmodel.Setup(a => a.CollectionViewState).Returns(Addstate.Object);
            Sut.Execute();
            Viewmodelcollection.Verify(a => a.Add(Entityvm.Object));
        }

        [Fact]
        public void ShouldReturnToListViewAfterExecution()
        {
            Addstate.Setup(a => a.EntityViewModel).Returns(Entityvm.Object);
            Collectionviewmodel.Setup(a => a.CollectionViewState).Returns(Addstate.Object);
            Sut.Execute();
            Collectionviewmodel.VerifySet(a => a.CollectionViewState = Liststate.Object);
        }

        [Fact]
        public void ShouldNotExecuteUnlessValidationPasses()
        {
            Entityvm.Setup(a => a.HasErrors).Returns(false);
            Entityvm.Setup(a => a.HasChanged).Returns(true);
            Addstate.Setup(a => a.EntityViewModel).Returns(Entityvm.Object);
            Assert.True(Sut.CanExecute());
        }

        [Fact]
        public void ShouldNotExecuteIfEntityViewModelHasErrors()
        {
            Entityvm.Setup(a => a.HasErrors).Returns(true);
            Addstate.Setup(a => a.EntityViewModel).Returns(Entityvm.Object);
            Assert.False(Sut.CanExecute());
        }

        [Fact]
        public void ShouldNotExecuteIfEntityHasNotChanged()
        {
            Entityvm.Setup(a => a.HasChanged).Returns(false);
            Entityvm.Setup(a => a.HasErrors).Returns(false);
            Addstate.Setup(a => a.EntityViewModel).Returns(Entityvm.Object);
            Assert.False(Sut.CanExecute());
        }
    }
}
