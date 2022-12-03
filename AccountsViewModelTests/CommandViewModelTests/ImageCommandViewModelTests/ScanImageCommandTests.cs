using System.Windows.Input;
using AccountsViewModel.CommandViewModels.ImageCommands;
using Xunit;
using AccountsViewModel.Xunit.Tests.autofixtureattributes;
using Moq;
using Unity;
using AccountsViewModelsCore.Services.Interfaces;
using AccountsViewModel.EntityViewModels;
using AutoFixture.Xunit2;
using AccountsViewModel.EntityViewModels.Interfaces;
using AccountsModelCore.Classes.DocumentImages;

namespace AccountsViewModelTests.CommandViewModelTests.ImageCommandViewModelTests
{
    public class ScanImageCommandTests
    {
        [Theory, AutoCatalogData]
        public void ShouldBeAnICommand(
                ScanImageCommand sut)
        {
            _ = Assert.IsAssignableFrom<ICommand>(sut);
        }

        [Theory, AutoCatalogData]
        public void ShouldUseImagePathServiceToGetNewImageFolderName(
            [Frozen] Mock<IUnityContainer> container,
            [Frozen] Mock<ICreateImageService> imagecreator,
            [Frozen] Mock<IImagePathService> pathservice,
            [Frozen] Mock<IDocumentImageViewModel> imageentity,
            string teststring,
            ScanImageCommand sut)
        {
            _ = container.Setup(a => a.Resolve(typeof(IEntityViewModel<DocumentImage>), null)).Returns(imageentity.Object);
            _ = pathservice.Setup(a => a.GetFolderPathForNewImage()).Returns(teststring);
            sut.Execute();
            imagecreator.Verify(a => a.CreateImageInFolderWithFilename(teststring, It.IsAny<string>()), Times.Once);
        }

        [Theory, AutoCatalogData]
        public void ShouldUseImagePathServiceToGetNewImageFileName(
                [Frozen] Mock<IUnityContainer> container,
                [Frozen] Mock<ICreateImageService> imagecreator,
                [Frozen] Mock<IImagePathService> pathservice,
                [Frozen] Mock<IDocumentImageViewModel> imageentity,
                string teststring,
                ScanImageCommand sut
                )
        {
            _ = container.Setup(a => a.Resolve(typeof(IEntityViewModel<DocumentImage>), null)).Returns(imageentity.Object);
            _ = pathservice.Setup(a => a.GetFileNameForNewImage()).Returns(teststring);
            sut.Execute();
            imagecreator.Verify(a => a.CreateImageInFolderWithFilename(It.IsAny<string>(), teststring), Times.Once);
        }

        [Theory, AutoCatalogData]
        public void ShouldCreateFullPathForImageUsingImagePathService(
                [Frozen] Mock<IUnityContainer> container,
                [Frozen] Mock<IImagePathService> pathservice,
                [Frozen] Mock<IDocumentImageViewModel> imageentity,
                string teststring,
                ScanImageCommand sut)
        {
            _ = container.Setup(a => a.Resolve(typeof(IEntityViewModel<DocumentImage>), null)).Returns(imageentity.Object);
            _ = pathservice.Setup(a => a.GetFullPath(It.IsAny<string>(), It.IsAny<string>())).Returns(teststring);
            sut.Execute();
            imageentity.VerifySet(a => a.Path = teststring);
        }

        [Theory, AutoCatalogData]
        public void ShouldUseFolderNameAndFileNameToCreateFullPath(
                [Frozen] Mock<IUnityContainer> container,
                [Frozen] Mock<IDocumentImageViewModel> imageentity,
                string foldername,
                string filename,
                [Frozen] Mock<IImagePathService> pathservice,
                ScanImageCommand sut)
        {
            _ = container.Setup(a => a.Resolve(typeof(IEntityViewModel<DocumentImage>), null)).Returns(imageentity.Object);
            _ = pathservice.Setup(a => a.GetFolderPathForNewImage()).Returns(foldername);
            _ = pathservice.Setup(a => a.GetFileNameForNewImage()).Returns(filename);
            sut.Execute();
            pathservice.Verify(a => a.GetFullPath(foldername, filename), Times.Once);
        }

    }
}
