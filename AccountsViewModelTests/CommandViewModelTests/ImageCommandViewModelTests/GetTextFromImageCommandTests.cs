using System.Windows.Input;
using AccountsViewModel.CommandViewModels.ImageCommands;
using AccountsViewModel.EntityViewModels.Interfaces;
using AccountsViewModelTests.AutofixtureAttributes;
using AutoFixture.Xunit2;
using ImageServices.Services.Interfaces;
using Moq;
using Xunit;

namespace AccountsViewModelTests.CommandViewModelTests.ImageCommandViewModelTests
{
    public class GetTextFromImageCommandTests
    {
        [Theory, AutoCatalogData]
        public void ShouldImplementICommand(
                GetTextFromImageCommand sut)
        {
            _ = Assert.IsAssignableFrom<ICommand>(sut);
        }

        [Theory, AutoCatalogData]
        public void ShouldGetTextFromImageViewModelUsingGetTextFromImageService(
                [Frozen] Mock<IGetTextFromImageServices> gettextfromimageservice,
                [Frozen] Mock<IDocumentImageViewModel> imagevm,
                string text,
                GetTextFromImageCommand sut)
        {
            _ = imagevm.Setup(a => a.Path).Returns(text);
            sut.Execute();
            gettextfromimageservice.Verify(a => a.GetTextFromImageUsingTesseract(text), Times.Once);
        }

        [Theory, AutoCatalogData]
        public void ShouldSetTextPropertyOfImageViewModelFromImageText(
                [Frozen] Mock<IGetTextFromImageServices> gettextfromimageservice,
                [Frozen] Mock<IDocumentImageViewModel> imagevm,
                string text,
                GetTextFromImageCommand sut)
        {
            _ = gettextfromimageservice.Setup(a => a.GetTextFromImageUsingTesseract(It.IsAny<string>())).Returns(text);
            sut.Execute();
            imagevm.VerifySet(a => a.SourceDocumentText = text);
        }
    }
}
