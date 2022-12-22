using AccountLib.Model.SourceDocuments;
using Moq;
using System.Collections.Generic;
using System.Windows.Input;
using AccountsViewModel.CommandViewModels.SourceDocumentCommands;
using AccountsViewModel.EntityViewModels.Interfaces;
using Xunit;
using AccountsViewModel.Services.Interfaces;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsModelCore.Classes.DocumentImages;
using AccountsModelCore.Interfaces;

namespace AccountsViewModelTests.CommandViewModelTests.SourceDocumentCommandViewModelTests
{
    public class ReadDataFromImageTextAddEditViewCommandTests
    {
        private readonly SourceDocument sourcedocument;
        private readonly DocumentImage image;
        private readonly List<DocumentImage> imagecollection;
        private readonly Mock<ISourceDocumentCollectionAddEditViewModelState> sourceDocumentCollectionAddEditViewModelState;
        private readonly Mock<ISourceDocumentViewModel> sourceDocumentViewModel;
        private readonly Mock<ISourceDocumentTextReadService> sourceDocumentTextReadService;
        private readonly Mock<IBusinessEntitySourceDocumentType> businessEntitySourceDocumentType;
        private readonly ReadDataFromImageTextAddEditViewCommand sut;

        public ReadDataFromImageTextAddEditViewCommandTests()
        {
            sourceDocumentCollectionAddEditViewModelState = new Mock<ISourceDocumentCollectionAddEditViewModelState>();
            sourceDocumentViewModel = new Mock<ISourceDocumentViewModel>();
            businessEntitySourceDocumentType = new Mock<IBusinessEntitySourceDocumentType>();
            _ = businessEntitySourceDocumentType.Setup(a => a.Id)
                .Returns(It.IsAny<int>());
            image = new DocumentImage();
            imagecollection = new List<DocumentImage>
            {
                image
            };
            sourcedocument = new SourceDocument
            {
                Images = imagecollection
            };

            _ = sourceDocumentCollectionAddEditViewModelState.Setup(a => a.EntityViewModel)
                .Returns(sourceDocumentViewModel.Object);
            _ = sourceDocumentViewModel.Setup(a => a.Entity).Returns(sourcedocument);
            sourceDocumentTextReadService = new Mock<ISourceDocumentTextReadService>();

            image.SourceDocumentText = It.IsAny<string>();

            sut = new ReadDataFromImageTextAddEditViewCommand(
            sourceDocumentCollectionAddEditViewModelState.Object,
            sourceDocumentTextReadService.Object
            );
        }

        [Fact]
        public void ShouldImplementICommand()
        {
            _ = Assert.IsAssignableFrom<ICommand>(sut);
        }

        [Fact]
        public void ShouldNotRunIfTextIsEmpty()
        {
            _ = sourceDocumentCollectionAddEditViewModelState.Setup(a => a.SourceDocumentText)
                .Returns("");

            Assert.False(sut.CanExecute());
        }

        [Fact]
        public void ShouldNotRunIfTextIsNull()
        {
            _ = sourceDocumentCollectionAddEditViewModelState.Setup(a => a.SourceDocumentText)
                .Returns<string>(null);
            Assert.False(sut.CanExecute());
        }

    }
}
