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
    public class GetImageFromFileCommandTests
    {

        [Theory, AutoCatalogData]
        public void ShouldImplementICommand(
                GetImageFromFileCommand sut)
        {
            Assert.IsAssignableFrom<ICommand>(sut);
        }

        [Theory, AutoCatalogData]
        public void ShouldGetPathForImageUsingIGetFileFromCommand(
                [Frozen] Mock<IGetImageFromFileService> imagefileservice,
                GetImageFromFileCommand sut)
        {
            sut.Execute();
            imagefileservice.Verify(a => a.GetImagePathFromDialog());
        }

        [Theory, AutoCatalogData]
        public void ShouldSetThePathOnTheImageViewModelWithPathFromPathService(
                [Frozen] Mock<IGetImageFromFileService> imagefileservice,
                string path,
                [Frozen] Mock<IDocumentImageViewModel> imagevm,
                GetImageFromFileCommand sut)
        {
            imagefileservice.Setup(a => a.GetImagePathFromDialog()).Returns(path);
            sut.Execute();
            imagevm.VerifySet(a => a.Path = path);
        }
    }
}
