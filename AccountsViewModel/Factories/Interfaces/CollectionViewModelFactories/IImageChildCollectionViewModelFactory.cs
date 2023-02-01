using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsModelCore.Classes.DocumentImages;
using AccountsModelCore.Interfaces.SourceDocuments;

namespace AccountsViewModel.Factories.Interfaces.CollectionViewModelFactories
{
    public interface IImageChildCollectionViewModelFactory
    {
        IEntityCollectionViewModel<DocumentImage> GetImageCollectionViewModelForSourceDocument(ISourceDocument sourceDocument);
    }
}
