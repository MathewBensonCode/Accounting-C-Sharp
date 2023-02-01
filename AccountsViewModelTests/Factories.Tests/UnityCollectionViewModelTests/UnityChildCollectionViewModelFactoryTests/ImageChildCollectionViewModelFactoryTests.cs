using System.Collections.Generic;
using AccountsModelCore.Classes.DocumentImages;
using AccountsModelCore.Interfaces.SourceDocuments;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CollectionViewModelFactories;
using AccountsViewModel.Factories.Unity.CollectionViewModelFactories;
using AccountsViewModel.Repositories.Interfaces;
using Moq;
using Xunit;

namespace AccountsViewModelTests.Factories.Tests.UnityCollectionViewModelTests.UnityChildCollectionViewModelFactoryTests
{
    public class ImageChildCollectionViewModelFactoryTests
    {
        private readonly Mock<IRepository<DocumentImage>> repository;
        private readonly Mock<ISourceDocument> sourcedocument;
        private readonly Mock<ICollection<DocumentImage>> imagecollection;
        private readonly Mock<IEntityCollectionViewModel<DocumentImage>> imagecollectionviewmodel;
        private readonly Mock<ICollectionViewModelFactory<DocumentImage>> collectionviewmodelfactory;
        private readonly ImageChildCollectionViewModelFactory sut;

        public ImageChildCollectionViewModelFactoryTests()
        {
            repository = new Mock<IRepository<DocumentImage>>();
            sourcedocument = new Mock<ISourceDocument>();
            imagecollection = new Mock<ICollection<DocumentImage>>();
            imagecollectionviewmodel = new Mock<IEntityCollectionViewModel<DocumentImage>>();
            collectionviewmodelfactory = new Mock<ICollectionViewModelFactory<DocumentImage>>();
            _ = repository.As<IImageRepository>().Setup(a => a.GetImagesForSourceDocument(sourcedocument.Object))
              .Returns(imagecollection.Object);
            _ = collectionviewmodelfactory.Setup(a => a.CreateNewCollectionViewModel(imagecollection.Object))
                .Returns(imagecollectionviewmodel.Object);

            sut = new ImageChildCollectionViewModelFactory(
                repository.Object,
                collectionviewmodelfactory.Object
                );

        }

        [Fact]
        public void ShouldImplementIImageCollectionViewModelFactory()
        {
            _ = Assert.IsAssignableFrom<IImageChildCollectionViewModelFactory>(sut);
        }

        [Fact]
        public void ShouldCreateImageCollectionviewModelForSourceDocument()
        {
            _ = sourcedocument.SetupProperty(a => a.Images);
            sourcedocument.Object.Images = null;
            _ = collectionviewmodelfactory.Setup(a => a.CreateNewCollectionViewModel(imagecollection.Object))
                .Returns(imagecollectionviewmodel.Object);
            Assert.Same(imagecollectionviewmodel.Object, sut.GetImageCollectionViewModelForSourceDocument(sourcedocument.Object));
        }

        [Fact]
        public void ShouldSetImagesCollectionOfSourceDocumentWithImageCollectionFromRepository()
        {
            _ = sut.GetImageCollectionViewModelForSourceDocument(sourcedocument.Object);
            sourcedocument.VerifySet(a => a.Images = imagecollection.Object);
        }
    }
}
