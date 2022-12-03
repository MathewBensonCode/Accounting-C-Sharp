using Accounts.Repositories;
using AccountLib.Interfaces.SourceDocuments;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CollectionViewModelFactories;
using AccountsModelCore.Classes.DocumentImages;

namespace AccountsViewModel.Factories.Unity.CollectionViewModelFactories
{
    public class ImageChildCollectionViewModelFactory
        : IImageChildCollectionViewModelFactory
    {
        private readonly IRepository<DocumentImage> _imageRepository;
        private readonly ICollectionViewModelFactory<DocumentImage> _collectionViewModelFactory;

        public ImageChildCollectionViewModelFactory(
            IRepository<DocumentImage> imageRepository,
            ICollectionViewModelFactory<DocumentImage> collectionViewModelFactory
            )
        {
            _imageRepository = imageRepository;
            _collectionViewModelFactory = collectionViewModelFactory;
        }

        public IEntityCollectionViewModel<DocumentImage> GetImageCollectionViewModelForSourceDocument(ISourceDocument sourceDocument)
        {
            if (sourceDocument.Images == null)
            {
                var imagecollection = (_imageRepository as IImageRepository).GetImagesForSourceDocument(sourceDocument);
                sourceDocument.Images = imagecollection;
            }

            return _collectionViewModelFactory.CreateNewCollectionViewModel(sourceDocument.Images);
        }
    }
}
