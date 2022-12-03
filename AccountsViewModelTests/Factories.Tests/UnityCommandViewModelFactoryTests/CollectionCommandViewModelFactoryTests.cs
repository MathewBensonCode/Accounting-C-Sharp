using Accounts.Repositories;
using AutoFixture.Xunit2;
using Moq;
using System.Windows.Input;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.CommandViewModels.CollectionCommands.Interfaces;
using AccountsViewModel.Factories.Interfaces.CommandViewModelFactories;
using AccountsViewModel.Factories.Unity.CommandViewModelFactories;
using AccountsViewModel.Xunit.Tests.autofixtureattributes;
using Unity;
using Unity.Resolution;
using Xunit;

namespace AccountsViewModel.Xunit.Tests.Factories.Tests.UnityCommandViewModelFactoryTests
{
    public abstract class CollectionCommandViewModelFactoryTests<T> where T:class
    {
        [Theory, AutoCatalogData]
        public void ShouldBeOfTypeICommandViewModelFactory(
            CollectionCommandViewModelFactory<T> sut
            )
        {
            Assert.IsAssignableFrom<ICommandViewModelFactory<T>>(sut);
        }

        [Theory, AutoCatalogData]
        public void ShouldCreateASelectAddViewCommandUsingUnity(
            [Frozen]Mock<IUnityContainer> container,
            [Frozen]Mock<ICollectionAddViewModelState<T>> addstate,
            [Frozen]Mock<IEntityCollectionViewModel<T>> collectionviewmodel,
            [Frozen]Mock<ICommandViewModel> commandvm,
            Mock<ICommand> command,
            CollectionCommandViewModelFactory<T> sut
            )
        {
            container.Setup(a => a.Resolve(typeof(ICommand), typeof(T)+"SelectAddViewCommand",
                new ResolverOverride[]
                {
                    new ParameterOverride("addState", addstate.Object),
                    new ParameterOverride("collectionViewModel", collectionviewmodel.Object)
                }
                )).Returns(command.Object);

            container.Setup(a => a.Resolve(typeof(ICommandViewModel), null,
                new ResolverOverride[]
                {
                    new ParameterOverride("command", command.Object)
                }
                )).Returns(commandvm.Object);

            
            Assert.IsAssignableFrom<ICommandViewModel>(sut.CreateSelectAddViewCommand(addstate.Object, collectionviewmodel.Object));
        }

        [Theory, AutoCatalogData]
        public void ShouldCreateASelectEditViewCommandUsingUnity(
           [Frozen]Mock<IUnityContainer> container,
           [Frozen]Mock<ICollectionEditViewModelState<T>> editstate,
           [Frozen]Mock<ICollectionListViewModelState<T>> liststate,
           [Frozen]Mock<IEntityCollectionViewModel<T>> collectionviewmodel,
           [Frozen]Mock<ICommandViewModel> commandvm,
           Mock<ICommand> command,
           CollectionCommandViewModelFactory<T> sut
           )
        {
            container.Setup(a => a.Resolve(typeof(ICommand), typeof(T)+"SelectEditViewCommand",
                new ResolverOverride[]
                {
                    new ParameterOverride("editState", editstate.Object),
                    new ParameterOverride("collectionViewModel", collectionviewmodel.Object),
                    new ParameterOverride("listViewState", liststate.Object)
                }
                )).Returns(command.Object);

            container.Setup(a => a.Resolve(typeof(ICommandViewModel), null,
                new ResolverOverride[]
                {
                    new ParameterOverride("command", command.Object)
                }
                )).Returns(commandvm.Object);


            Assert.IsAssignableFrom<ICommandViewModel>(sut.CreateSelectEditViewCommand(editstate.Object, collectionviewmodel.Object, liststate.Object));
        }

        [Theory, AutoCatalogData]
        public void ShouldCreateASaveNewCommandUsingUnity(
           [Frozen]Mock<IUnityContainer> container,
           [Frozen]Mock<ICollectionAddViewModelState<T>> addstate,
           [Frozen]Mock<ICollectionListViewModelState<T>> liststate,
           [Frozen]Mock<IEntityCollectionViewModel<T>> collectionviewmodel,
           [Frozen]Mock<IRepository<T>> repository,
           [Frozen]Mock<ICommandViewModel> commandvm,
           Mock<ICommand> command,
           CollectionCommandViewModelFactory<T> sut
           )
        {
            container.Setup(a => a.Resolve(typeof(ICommand), "SaveNewCommand",
                new ResolverOverride[]
                {
                    new ParameterOverride("addViewState", addstate),
                    new ParameterOverride("listViewState", liststate.Object),
                    new ParameterOverride("collectionViewModel", collectionviewmodel.Object),
                    new ParameterOverride("repository", repository.Object)
                }
                )).Returns(command.Object);

            container.Setup(a => a.Resolve(typeof(ICommandViewModel), null,
                new ResolverOverride[]
                {
                    new ParameterOverride("command", command.Object)
                }
                )).Returns(commandvm.Object);


            Assert.IsAssignableFrom<ICommandViewModel>(sut.CreateSaveNewCommand(addstate.Object, liststate.Object, repository.Object, collectionviewmodel.Object));
        }

        [Theory, AutoCatalogData]
        public void ShouldCreateASaveEditCommandUsingUnity(
          [Frozen]Mock<IUnityContainer> container,
          [Frozen]Mock<ICollectionEditViewModelState<T>> editstate,
          [Frozen]Mock<ICollectionListViewModelState<T>> liststate,
          [Frozen]Mock<IEntityCollectionViewModel<T>> collectionviewmodel,
          [Frozen]Mock<ICommandViewModel> commandvm,
          [Frozen]Mock<IRepository<T>> repository,
          Mock<ICommand> command,
          CollectionCommandViewModelFactory<T> sut
          )
        {
            container.Setup(a => a.Resolve(typeof(ICommand), "SaveEditCommand",
                new ResolverOverride[]
                {
                    new ParameterOverride("editViewState", editstate.Object),
                    new ParameterOverride("listViewState", liststate.Object),
                    new ParameterOverride("collectionViewModel", collectionviewmodel.Object),
                    new ParameterOverride("repository", repository.Object)
                }
                )).Returns(command.Object);

            container.Setup(a => a.Resolve(typeof(ICommandViewModel), null,
                new ResolverOverride[]
                {
                    new ParameterOverride("command", command.Object)
                }
                )).Returns(commandvm.Object);


            Assert.IsAssignableFrom<ICommandViewModel>(sut.CreateSaveEditCommand(editstate.Object, liststate.Object, repository.Object, collectionviewmodel.Object));
        }

        [Theory, AutoCatalogData]
        public void ShouldCreateACommandToCancelAddOrEditUsingUnity(
          [Frozen]Mock<IUnityContainer> container,
          [Frozen]Mock<ICollectionListViewModelState<T>> liststate,
          [Frozen]Mock<IEntityCollectionViewModel<T>> collectionviewmodel,
          [Frozen]Mock<ICommandViewModel> commandvm,
          Mock<ICommand> command,
          CollectionCommandViewModelFactory<T> sut
          )
        {
            container.Setup(a => a.Resolve(typeof(ICommand), "CancelAddNewEditCommand",
                new ResolverOverride[]
                {
                    new ParameterOverride("listViewState", liststate.Object),
                    new ParameterOverride("collectionViewModel", collectionviewmodel.Object),
                }
                )).Returns(command.Object);

            container.Setup(a => a.Resolve(typeof(ICommandViewModel), null,
                new ResolverOverride[]
                {
                    new ParameterOverride("command", command.Object)
                }
                )).Returns(commandvm.Object);


            Assert.IsAssignableFrom<ICommandViewModel>(sut.CreateCancelAddNewEditCommand(liststate.Object, collectionviewmodel.Object));
        }

        [Theory, AutoCatalogData]
        public void ShouldCreateACommandToDeleteCurrentEntityUsingUnity(
          [Frozen]Mock<IUnityContainer> container,
          [Frozen]Mock<IRepository<T>> repository,
          [Frozen]Mock<ICollectionListViewModelState<T>> liststate,
          [Frozen]Mock<ICommandViewModel> commandvm,
          Mock<ICommand> command,
          CollectionCommandViewModelFactory<T> sut
          )
        {
            container.Setup(a => a.Resolve(typeof(ICommand), "DeleteCurrentCommand",
                new ResolverOverride[]
                {
                    new ParameterOverride("listViewState", liststate.Object),
                    new ParameterOverride("repository", repository.Object),
                }
                )).Returns(command.Object);

            container.Setup(a => a.Resolve(typeof(ICommandViewModel), null,
                new ResolverOverride[]
                {
                    new ParameterOverride("command", command.Object)
                }
                )).Returns(commandvm.Object);


            Assert.IsAssignableFrom<ICommandViewModel>(sut.CreateDeleteCurrentCommand(liststate.Object, repository.Object));
        }

        [Theory, AutoCatalogData]
        public void ShouldCreateACommandToNavigateToTheBeginningUsingUnity(
          [Frozen]Mock<IUnityContainer> container,
          [Frozen]Mock<IRepository<T>> repository,
          [Frozen]Mock<ICollectionListViewModelState<T>> liststate,
          [Frozen]Mock<ICommandViewModel> commandvm,
          Mock<ICommand> command,
          CollectionCommandViewModelFactory<T> sut
          )
        {
            container.Setup(a => a.Resolve(typeof(ICommand), "GoToBeginningCommand",
                new ResolverOverride[]
                {
                    new ParameterOverride("listViewState", liststate.Object),
                    new ParameterOverride("repository", repository.Object),
                }
                )).Returns(command.Object);

            container.Setup(a => a.Resolve(typeof(ICommandViewModel), null,
                new ResolverOverride[]
                {
                    new ParameterOverride("command", command.Object)
                }
                )).Returns(commandvm.Object);


            Assert.IsAssignableFrom<ICommandViewModel>(sut.CreateGoToBeginningCommmand(liststate.Object, repository.Object));
        }

        [Theory, AutoCatalogData]
        public void ShouldCreateACommandToNavigateToTheEndUsingUnity(
          [Frozen]Mock<IUnityContainer> container,
          [Frozen]Mock<IRepository<T>> repository,
          [Frozen]Mock<ICollectionListViewModelState<T>> liststate,
          [Frozen]Mock<ICommandViewModel> commandvm,
          Mock<ICommand> command,
          CollectionCommandViewModelFactory<T> sut
          )
        {
            container.Setup(a => a.Resolve(typeof(ICommand), "GoToEndCommand",
                new ResolverOverride[]
                {
                    new ParameterOverride("listViewState", liststate.Object),
                    new ParameterOverride("repository", repository.Object),
                }
                )).Returns(command.Object);

            container.Setup(a => a.Resolve(typeof(ICommandViewModel), null,
                new ResolverOverride[]
                {
                    new ParameterOverride("command", command.Object)
                }
                )).Returns(commandvm.Object);


            Assert.IsAssignableFrom<ICommandViewModel>(sut.CreateGoToEndCommand(liststate.Object, repository.Object));
        }

        [Theory, AutoCatalogData]
        public void ShouldCreateACommandToNavigateToTheNextPageUsingUnity(
          [Frozen]Mock<IUnityContainer> container,
          [Frozen]Mock<IRepository<T>> repository,
          [Frozen]Mock<ICollectionListViewModelState<T>> liststate,
          [Frozen]Mock<ICommandViewModel> commandvm,
          Mock<ICommand> command,
          CollectionCommandViewModelFactory<T> sut
          )
        {
            container.Setup(a => a.Resolve(typeof(ICommand), "NextPageCommand",
                new ResolverOverride[]
                {
                    new ParameterOverride("listViewState", liststate.Object),
                    new ParameterOverride("repository", repository.Object),
                }
                )).Returns(command.Object);

            container.Setup(a => a.Resolve(typeof(ICommandViewModel), null,
                new ResolverOverride[]
                {
                    new ParameterOverride("command", command.Object)
                }
                )).Returns(commandvm.Object);


            Assert.IsAssignableFrom<ICommandViewModel>(sut.CreateNextPageCommand(liststate.Object, repository.Object));
        }

        [Theory, AutoCatalogData]
        public void ShouldCreateACommandToNavigateToThePreviousPageUsingUnity(
          [Frozen]Mock<IUnityContainer> container,
          [Frozen]Mock<IRepository<T>> repository,
          [Frozen]Mock<ICollectionListViewModelState<T>> liststate,
          [Frozen]Mock<ICommandViewModel> commandvm,
          Mock<ICommand> command,
          CollectionCommandViewModelFactory<T> sut
          )
        {
            container.Setup(a => a.Resolve(typeof(ICommand), "PreviousPageCommand",
                new ResolverOverride[]
                {
                    new ParameterOverride("listViewState", liststate.Object),
                    new ParameterOverride("repository", repository.Object),
                }
                )).Returns(command.Object);

            container.Setup(a => a.Resolve(typeof(ICommandViewModel), null,
                new ResolverOverride[]
                {
                    new ParameterOverride("command", command.Object)
                }
                )).Returns(commandvm.Object);


            Assert.IsAssignableFrom<ICommandViewModel>(sut.CreatePreviousPageCommand(liststate.Object, repository.Object));
        }







    }
}
