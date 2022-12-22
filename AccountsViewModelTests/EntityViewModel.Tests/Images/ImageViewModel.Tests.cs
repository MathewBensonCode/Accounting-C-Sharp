using AccountsModelCore.Classes.DocumentImages;
using AccountsModelCore.Interfaces.Images;
using AccountsViewModel.CommandViewModels.Interfaces;
using AccountsViewModel.EntityViewModels.Classes;
using AccountsViewModel.EntityViewModels.Classes.DocumentImages;
using AccountsViewModel.EntityViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CommandViewModelFactories;
using AccountsViewModel.Factories.Interfaces.ViewModelFactories;
using Moq;
using Xunit;

namespace AccountsViewModelTests.EntityViewModel.Tests.Images
{
    public class DocumentImageViewModelTests
        : EntityViewModelTests<DocumentImage>
    {
        private readonly IDocumentImage documentimage;
        private readonly Mock<ISourceDocumentViewModelFactory> SourceDocumentViewModelFactory;
        private readonly Mock<IImageViewModelCommandFactory> Commandfactory;
        private readonly Mock<ICommandViewModel> command;
        private readonly string TestString;
        private readonly int TestId;
        protected override EntityViewModel<DocumentImage> Sut { get; set; }
        protected override DocumentImage Entity { get; set; }

        private readonly DocumentImageViewModel sut;
        private readonly Mock<ISourceDocumentViewModel> sourcedocumentviewmodel;

        public DocumentImageViewModelTests()
        {
            TestId = 2;
            TestString = "teststring";
            Entity = new DocumentImage();
            documentimage = Entity;
            SourceDocumentViewModelFactory = new Mock<ISourceDocumentViewModelFactory>();
            Commandfactory = new Mock<IImageViewModelCommandFactory>();
            command = new Mock<ICommandViewModel>();
            sourcedocumentviewmodel = new Mock<ISourceDocumentViewModel>();

            _ = Commandfactory.Setup(a => a.CreateGetImageFromFileCommand(It.IsAny<IDocumentImageViewModel>())).Returns(command.Object);
            _ = Commandfactory.Setup(a => a.CreateScanImageCommand(It.IsAny<IDocumentImageViewModel>())).Returns(command.Object);
            _ = Commandfactory.Setup(a => a.CreateGetTextFromImageCommand(It.IsAny<IDocumentImageViewModel>())).Returns(command.Object);

            _ = SourceDocumentViewModelFactory.Setup(a => a.CreateSourceDocumentViewModelForImage(documentimage)).Returns(sourcedocumentviewmodel.Object);

            documentimage.Path = TestString;
            documentimage.SourceDocumentId = TestId;
            documentimage.SourceDocumentText = TestString;

            sut = new DocumentImageViewModel(
                documentimage,
                SourceDocumentViewModelFactory.Object,
                Commandfactory.Object,
                ErrorCollection.Object
                );

            Sut = sut;
        }

        [Fact]
        public void GetsUnderlyingPathThroughPathProperty()
        {
            Assert.Equal(TestString, sut.Path);
        }

        [Fact]
        public void SetsUnderlyingPathWhenPathPropertySet()
        {
            sut.Path = TestString;
            Assert.Equal(TestString, documentimage.Path);
        }

        [Fact]
        public void RaisesPropertyChangedWhenPathPropertySet()
        {
            Assert.PropertyChanged(sut, "Path", () => { sut.Path = TestString; });
        }

        [Fact]
        public void GetsUnderlyingSourceDocumentIdThroughSourceDocumentIdProperty()
        {
            Assert.Equal(TestId, sut.SourceDocumentId);
        }

        [Fact]
        public void SetsUnderlyingSourceDocumentIdWhenSourceDocumentIdPropertySet()
        {
            sut.SourceDocumentId = TestId;
            Assert.Equal(TestId, documentimage.SourceDocumentId);
        }

        [Fact]
        public void RaisesPropertyChangedEventWhenSourceDocumentIdPropertySet()
        {
            Assert.PropertyChanged(sut, "SourceDocumentId", () => { sut.SourceDocumentId = TestId; });
        }

        [Fact]
        public void GetsUnderlyingSourceDocumentTextThroughSourceDocumentTextProperty()
        {
            Assert.Equal(sut.SourceDocumentText, TestString);
        }

        [Fact]
        public void SetsUnderlyingSourceDocumentTextThroughSourceDocumentTextProperty()
        {
            sut.SourceDocumentText = TestString;
            Assert.Equal(documentimage.SourceDocumentText, TestString);
        }

        [Fact]
        public void RaisesPropertyChangedEventWhenSourceDocumentTextPropertySet()
        {
            Assert.PropertyChanged(sut, "SourceDocumentText", () => { sut.SourceDocumentText = TestString; });
        }

        [Fact]
        public void SourceDocumentPropertyShouldNotBeNull()
        {
            Assert.NotNull(sut.SourceDocumentViewModel);
        }

        [Fact]
        public void ShouldHaveACommandThatCreatesAnImageByScanning()

        {
            _ = Assert.IsAssignableFrom<ICommandViewModel>(sut.ScanImageCommand);
        }

        [Fact]
        public void ShouldCreateImageScanCommandFromIImageScanCommandViewModelFactory()
        {
            Assert.Equal(command.Object, sut.ScanImageCommand);
        }

        [Fact]
        public void ShouldHaveACommandThatGetsAnImageFromAFile()
        {
            _ = Assert.IsAssignableFrom<ICommandViewModel>(sut.GetImageFromFileCommand);
        }

        [Fact]
        public void ShouldHaveACommandThatGetsTextFromAnImage()
        {
            _ = Assert.IsAssignableFrom<ICommandViewModel>(sut.GetTextFromImageCommand);
        }

        [Fact]
        public void ShouldCreateGetFromFileCommandFromIImageScanCommandViewModelFactory()
        {
            Assert.Equal(command.Object, sut.GetImageFromFileCommand);
        }

        [Fact]
        public void ShouldCreateGetTextFromImageCommandFromIImageScanCommandViewModelFactory()
        {
            Assert.Equal(command.Object, sut.GetTextFromImageCommand);
        }
    }
}
