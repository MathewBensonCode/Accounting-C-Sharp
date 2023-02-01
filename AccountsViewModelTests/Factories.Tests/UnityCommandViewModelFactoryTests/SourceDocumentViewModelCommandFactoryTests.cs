using System.Windows.Input;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CommandViewModels.Interfaces;
using AccountsViewModel.EntityViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CommandViewModelFactories;
using AccountsViewModel.Factories.Unity.CommandViewModelFactories;
using Moq;
using Unity;
using Unity.Resolution;
using Xunit;

namespace AccountsViewModelTests.Factories.Tests.UnityCommandViewModelFactoryTests
{
    public class SourceDocumentViewModelCommandFactoryTests
    {
        private readonly UnitySourceDocumentCollectionAddEditViewModelStateCommandFactory sut;
        private readonly Mock<ICommand> command;
        private readonly Mock<ISourceDocumentViewModel> sourcedocumentvm;
        private readonly Mock<IUnityContainer> container;

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
