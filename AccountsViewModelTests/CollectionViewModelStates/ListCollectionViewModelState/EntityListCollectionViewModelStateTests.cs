using System.Collections.Generic;
using AccountsViewModel.CollectionCrudViews;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.CommandViewModels.Interfaces;
using AccountsViewModel.EntityViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CollectionCrudViewStateFactories;
using AccountsViewModel.Factories.Interfaces.CommandViewModelFactories;
using AccountsViewModel.Repositories.Interfaces;
using AccountsViewModel.Services.Interfaces;
using Moq;
using Prism.Commands;
using Xunit;

namespace AccountsViewModelTests.CollectionViewModelStates.ListCollectionViewModelState
{

    public abstract class EntityListCollectionViewModelStateTests<T> where T : class
    {
        private readonly Mock<IRepository<T>> repository;
        private readonly Mock<ICollection<IEntityViewModel<T>>> collection;
        private readonly Mock<ICommandViewModelFactory<T>> commandfactory;
        private readonly Mock<ICollectionCrudAddViewStateFactory<T>> addviewstatefactory;
        private readonly Mock<ICollectionCrudEditViewStateFactory<T>> editviewstatefactory;
        private readonly Mock<IEntityCollectionViewModel<T>> entitycollectionviewmodel;
        private readonly Mock<IViewModelCollectionCreationService<T>> vmcreationservice;
        private readonly Mock<ICommandViewModel> commandviewmodel;
        private readonly Mock<ICommandViewModel> paramcommandviewmodel;
        private readonly Mock<ICollectionAddViewModelState<T>> addviewmodelstate;
        private readonly Mock<ICollectionEditViewModelState<T>> editviewmodelstate;
        private readonly Mock<IEntityViewModel<T>> entityviewmodel;

        private readonly DelegateCommand command;
        private readonly DelegateCommand<string> stringparamcommand;

        protected EntityListCollectionViewModelState<T> Sut { get; set; }

        public EntityListCollectionViewModelStateTests()
        {
            repository = new Mock<IRepository<T>>();
            collection = new Mock<ICollection<IEntityViewModel<T>>>();
            commandfactory = new Mock<ICommandViewModelFactory<T>>();
            addviewstatefactory = new Mock<ICollectionCrudAddViewStateFactory<T>>();
            editviewstatefactory = new Mock<ICollectionCrudEditViewStateFactory<T>>();
            entitycollectionviewmodel = new Mock<IEntityCollectionViewModel<T>>();
            vmcreationservice = new Mock<IViewModelCollectionCreationService<T>>();
            commandviewmodel = new Mock<ICommandViewModel>();
            paramcommandviewmodel = new Mock<ICommandViewModel>();
            addviewmodelstate = new Mock<ICollectionAddViewModelState<T>>();
            editviewmodelstate = new Mock<ICollectionEditViewModelState<T>>();
            entityviewmodel = new Mock<IEntityViewModel<T>>();

            _ = repository.As<ISaveRepository>().Setup(a => a.SaveRepository());
            _ = collection.As<IEnumerable<T>>().Setup(a => a.GetEnumerator());

            _ = addviewstatefactory.Setup(a => a.CreateEntityAddViewState(It.IsAny<ICollectionListViewModelState<T>>(), It.IsAny<IRepository<T>>(), It.IsAny<IEntityCollectionViewModel<T>>()))
               .Returns(addviewmodelstate.Object);
            _ = editviewstatefactory.Setup(a => a.CreateEntityEditView(It.IsAny<IEntityCollectionViewModel<T>>(), It.IsAny<IRepository<T>>(), It.IsAny<ICollectionListViewModelState<T>>()))
                .Returns(editviewmodelstate.Object);

            command = new DelegateCommand(() => { });
            stringparamcommand = new DelegateCommand<string>((x) => { });

            _ = commandviewmodel.Setup(a => a.Command)
                .Returns(command);

            _ = paramcommandviewmodel.Setup(a => a.Command)
                .Returns(stringparamcommand);

            _ = commandfactory.Setup(a => a.CreateSelectAddViewCommand(
                addviewmodelstate.Object,
                entitycollectionviewmodel.Object
                ))
                .Returns(commandviewmodel.Object);

            _ = commandfactory.Setup(a => a.CreateDeleteCurrentCommand(
                It.IsAny<ICollectionListViewModelState<T>>(),
                It.IsAny<IRepository<T>>()
                ))
                .Returns(commandviewmodel.Object);

            _ = commandfactory.Setup(a => a.CreateSelectEditViewCommand(
                It.IsAny<ICollectionEditViewModelState<T>>(),
                It.IsAny<IEntityCollectionViewModel<T>>(),
                It.IsAny<ICollectionListViewModelState<T>>()
                ))
                .Returns(paramcommandviewmodel.Object);

            _ = commandfactory.Setup(a => a.CreateNextPageCommand(
                It.IsAny<ICollectionListViewModelState<T>>(),
                It.IsAny<IRepository<T>>()
                ))
                .Returns(commandviewmodel.Object);

            _ = commandfactory.Setup(a => a.CreatePreviousPageCommand(
                It.IsAny<ICollectionListViewModelState<T>>(),
                It.IsAny<IRepository<T>>()
                ))
                .Returns(commandviewmodel.Object);

            _ = commandfactory.Setup(a => a.CreateGoToBeginningCommmand(
                It.IsAny<ICollectionListViewModelState<T>>(),
                It.IsAny<IRepository<T>>()
                ))
                .Returns(commandviewmodel.Object);

            _ = commandfactory.Setup(a => a.CreateGoToEndCommand(
                It.IsAny<ICollectionListViewModelState<T>>(),
                It.IsAny<IRepository<T>>()
                ))
                .Returns(commandviewmodel.Object);

            Sut = new EntityListCollectionViewModelState<T>(
                repository.Object,
                collection.Object,
                commandfactory.Object,
                addviewstatefactory.Object,
                editviewstatefactory.Object,
                entitycollectionviewmodel.Object,
                vmcreationservice.Object
                );
        }

        [Fact]
        public void ShouldHaveAPropertyWithCollectionOfViewModels()
        {
            _ = Assert.IsAssignableFrom<ICollection<IEntityViewModel<T>>>(Sut.EntityCollection);
        }

        [Fact]
        public void ShouldHaveAPropertyWithTheCurrentEntitySelectedOnTheUI()
        {
            Sut.EntityViewModel = entityviewmodel.Object;
            _ = Assert.IsAssignableFrom<IEntityViewModel<T>>(Sut.EntityViewModel);
        }

        [Fact]
        public void ShouldHaveAPropertyWithTheCountOfTheUnderlyingCollection()
        {
            _ = Assert.IsAssignableFrom<int>(Sut.Count);
        }

        [Fact]
        public void CountPropertyShouldReceiveValuesFromRepository()
        {
            int a = Sut.Count;
            repository.VerifyGet(r => r.Count);
        }

        [Fact]
        public void ShouldHaveAPropertyWithACommandToSelectTheAddViewToTheCollection()
        {
            _ = Assert.IsAssignableFrom<ICommandViewModel>(Sut.AddNewCommand);
        }

        [Fact]
        public void ShouldHaveAPropertyWithACommandToSelectTheEditViewToTheCurrentCollectionItem()
        {
            _ = Assert.IsAssignableFrom<ICommandViewModel>(Sut.EditCurrentCommand);
        }

        [Fact]
        public void ShouldHaveAPropertyWithACommandToLoadNextPage()
        {
            _ = Assert.IsAssignableFrom<ICommandViewModel>(Sut.NextPageCommand);
        }

        [Fact]
        public void ShouldHaveAPropertyWithACommandToLoadPreviousPage()
        {
            _ = Assert.IsAssignableFrom<ICommandViewModel>(Sut.PreviousPageCommand);
        }

        [Fact]
        public void ShouldHaveAPropertyWithACommandToGoToBeginning()
        {
            _ = Assert.IsAssignableFrom<ICommandViewModel>(Sut.GoToBeginningCommand);
        }

        [Fact]
        public void ShouldHaveAPropertyWithACommandToGoToEnd()
        {
            _ = Assert.IsAssignableFrom<ICommandViewModel>(Sut.GoToEndCommand);
        }

        [Fact]
        public void ShouldHaveAPropertyWithTheCurrentPage()
        {
            _ = Assert.IsAssignableFrom<int>(Sut.CurrentPage);
        }

        [Fact]
        public void ShouldHaveAPropertyWithACommandToDeleteTheCurrentEntity()
        {
            _ = Assert.IsAssignableFrom<ICommandViewModel>(Sut.DeleteCurrentCommand);
        }

        [Fact]
        public void ShouldAddCollectionViewModelsFromRepositoryDefaultCollection()
        {
            vmcreationservice.Verify(a => a.CreateViewModelCollectionFromIEnumerable(It.IsAny<ICollection<IEntityViewModel<T>>>(), It.IsAny<IEnumerable<T>>()));
        }

        [Fact]
        public void ShouldGetIEnumerableFromRepositoryWhenPageChanged()
        {
            int pagenumber = 2;
            _ = repository.Setup(a => a.Count).Returns(20);
            _ = repository.Setup(a => a.GetPageSize()).Returns(5);
            Sut.CurrentPage = pagenumber;
            repository.Verify(a => a.GetPageCollection(pagenumber));
        }

        [Fact]
        public void ShouldUpdateCollectionViewWhenPageChanged()
        {
            _ = repository.Setup(a => a.Count).Returns(20);
            _ = repository.Setup(a => a.GetPageSize()).Returns(5);
            _ = repository.Setup(a => a.GetPageCollection(It.IsAny<int>())).Returns(collection.As<IEnumerable<T>>().Object);
            Sut.CurrentPage = 2;
            vmcreationservice.Verify(a => a.CreateViewModelCollectionFromIEnumerable(It.IsAny<ICollection<IEntityViewModel<T>>>(), It.IsAny<IEnumerable<T>>()));
        }

        [Fact]
        public void ShouldRaisePropertyChangedEventWhenCurrentPagePropertyChanged()
        {
            int newpage = 2;
            _ = repository.Setup(a => a.Count).Returns(20);
            _ = repository.Setup(a => a.GetPageSize()).Returns(5);
            Assert.PropertyChanged(Sut, "CurrentPage", () => { Sut.CurrentPage = newpage; });
        }

        [Fact]
        public void ShouldNotChangeCurrentPagePropertyIfPageNotAvailable()
        {
            _ = repository.Setup(a => a.Count).Returns(10);
            _ = repository.Setup(a => a.GetPageSize()).Returns(10);
            Sut.CurrentPage = 2;
            Assert.Equal(1, Sut.CurrentPage);
        }

        [Fact]
        public void ShouldNotChangeCurrentPagePropertyIfValueLessThan1()
        {
            _ = repository.Setup(a => a.Count).Returns(10);
            _ = repository.Setup(a => a.GetPageSize()).Returns(2);
            Sut.CurrentPage = 0;
            Assert.Equal(1, Sut.CurrentPage);
        }

        [Fact]
        public void ShouldRaisePropertyChangedEventWhenCurrentEntityIsSet()
        {
            Assert.PropertyChanged(Sut, "EntityViewModel", () => { Sut.EntityViewModel = entityviewmodel.Object; });
        }
    }
}
