using Xunit;
using AccountsViewModel.Xunit.Tests.autofixtureattributes;
using AccountsViewModel.Factories.Unity.CommandViewModelFactories;
using AccountsViewModel.Factories.Interfaces.CommandViewModelFactories;
using Moq;
using Unity;
using AutoFixture.Xunit2;
using AccountsViewModel.CommandViewModels.CollectionCommands.Interfaces;
using System.Windows.Input;
using Unity.Resolution;
using AccountsViewModel.EntityViewModels.Interfaces;

namespace AccountsViewModel.Xunit.Tests.Factories.Tests.UnityCommandViewModelFactoryTests
{
    public class DocumentImageViewModelCommandFactoryTests
    {
        Mock<IDocumentImageViewModel> imageviewmodel;

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
