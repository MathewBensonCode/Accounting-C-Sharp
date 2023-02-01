using System.Windows.Input;
using AccountsViewModel.CommandViewModels.Interfaces;
using AccountsViewModel.EntityViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CommandViewModelFactories;
using AccountsViewModel.Factories.Unity.CommandViewModelFactories;
using AccountsViewModelTests.AutofixtureAttributes;
using AutoFixture.Xunit2;
using Moq;
using Unity;
using Unity.Resolution;
using Xunit;

namespace AccountsViewModelTests.Factories.Tests.UnityCommandViewModelFactoryTests
{
    public class DocumentImageViewModelCommandFactoryTests
    {
        private readonly Mock<IDocumentImageViewModel> imageviewmodel;

        public DocumentImageViewModelCommandFactoryTests()
        {
            imageviewmodel = new Mock<IDocumentImageViewModel>();
        }

        [Theory, AutoCatalogData]
        public void ShouldImplementIImageViewModelCommandFactory(
            UnityImageViewModelCommandFactory sut)
        {
            Assert.IsAssignableFrom<IImageViewModelCommandFactory>(sut);
        }

        [Theory, AutoCatalogData]
        public void ShouldCreateTheScanCommandUsingUnity(
                [Frozen] Mock<IUnityContainer> container,
                Mock<ICommand> command,
                UnityImageViewModelCommandFactory sut)
        {
            container.Setup(a => a.Resolve(typeof(ICommand), "ScanImageCommand", new ResolverOverride[]
                        {
                    new ParameterOverride("imageViewModel", It.IsAny<IDocumentImageViewModel>())
                        }
                        )).Returns(command.Object);

            sut.CreateScanImageCommand(It.IsAny<IDocumentImageViewModel>());
            container.Verify(a => a.Resolve(typeof(ICommandViewModel), null,
                        new ResolverOverride[]
                        {
                        new ParameterOverride("command", command.Object)
                        }
                        ));

        }

        [Theory, AutoCatalogData]
        public void ShouldCreateTheGetFromFileCommandUsingUnity(
                [Frozen] Mock<IUnityContainer> container,
                Mock<ICommand> command,
                UnityImageViewModelCommandFactory sut)
        {
            container.Setup(a => a.Resolve(typeof(ICommand), "GetFromFileCommand", new ResolverOverride[]
                        {
                    new ParameterOverride("imageViewModel", imageviewmodel.Object)
                        }
                        )).Returns(command.Object);

            sut.CreateGetImageFromFileCommand(imageviewmodel.Object);

            container.Verify(a => a.Resolve(typeof(ICommandViewModel), null,
                        new ResolverOverride[]
                        {
                        new ParameterOverride("command", command.Object)
                        }
                        ));
        }

        [Theory, AutoCatalogData]
        public void ShouldCreateTheGetTextFromImageCommandUsingUnity(
                [Frozen] Mock<IUnityContainer> container,
                Mock<ICommand> command,
                UnityImageViewModelCommandFactory sut)
        {
            container.Setup(a => a.Resolve(typeof(ICommand), "GetTextFromImageCommand", new ResolverOverride[]
                        {
                    new ParameterOverride("imageViewModel", imageviewmodel.Object)
                        }
                        )).Returns(command.Object);
            sut.CreateGetTextFromImageCommand(imageviewmodel.Object);
            container.Verify(a => a.Resolve(typeof(ICommandViewModel), null,
                        new ResolverOverride[]
                        {
                        new ParameterOverride("command", command.Object)
                        }
                        ));
        }
    }
}
