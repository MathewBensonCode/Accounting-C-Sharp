using System.Windows.Input;
using AccountsViewModel.CommandViewModels.ImageCommands;
using Xunit;
using AccountsViewModel.Xunit.Tests.autofixtureattributes;
using AutoFixture.Xunit2;
using Moq;
using AccountsViewModelsCore.Services.Interfaces;
using AccountsViewModel.EntityViewModels.Interfaces;

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
