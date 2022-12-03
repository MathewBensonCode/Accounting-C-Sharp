using Moq;
using System.Windows.Input;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CommandViewModels.CollectionCommands.Interfaces;
using AccountsViewModel.EntityViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CommandViewModelFactories;
using AccountsViewModel.Factories.Unity.CommandViewModelFactories;
using Unity;
using Unity.Resolution;
using Xunit;

namespace AccountsViewModel.Xunit.Tests.Factories.Tests.UnityCommandViewModelFactoryTests
{
    public class SourceDocumentViewModelCommandFactoryTests
    {
        UnitySourceDocumentCollectionAddEditViewModelStateCommandFactory sut;
        Mock<ICommand> command;
        Mock<ISourceDocumentViewModel> sourcedocumentvm;
        Mock<IUnityContainer> container;

        public SourceDocumentViewModelCommandFactoryTests()
        {
            command = new Mock<ICommand>();
            container = new Mock<IUnityContainer>();
            sourcedocumentvm = new Mock<ISourceDocumentViewModel>();


            sut = new UnitySourceDocumentCollectionAddEditViewModelStateCommandFactory(
                container.Object
                );
        }

        [Fact]
        public void ShouldImplementISourceDocumentViewModelCommandFactory()
        {
            Assert.IsAssignableFrom<ISourceDocumentCollectionAddEditViewModelStateCommandFactory>(sut);
        }

        [Fact]
        public void ShouldCreateTheReadDataFromImageTextCommandUsingUnity()
        {

            container.Setup(a => a.Resolve(typeof(ICommand), "ReadDataFromImageTextCommand", new ResolverOverride[]
                       {
                            new ParameterOverride("sourceDocumentViewModel", sourcedocumentvm.Object)
                       }
                       )).Returns(command.Object);
            sut.CreateReadFromImageTextCommand(It.IsAny<ISourceDocumentCollectionAddEditViewModelState>());
            container.Verify(a => a.Resolve(typeof(ICommandViewModel), null,
                        new ResolverOverride[]
                        {
                        new ParameterOverride("command", command.Object)
                        }
                        ));

        }

    }
}
