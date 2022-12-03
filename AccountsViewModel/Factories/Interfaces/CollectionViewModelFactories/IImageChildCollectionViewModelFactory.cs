using AccountLib.Interfaces.SourceDocuments;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsModelCore.Classes.DocumentImages;

namespace AccountsViewModel.Factories.Interfaces.CollectionViewModelFactories
{
    public interface IImageChildCollectionViewModelFactory
    {
        IEntityCollectionViewModel<DocumentImage> GetImageCollectionViewModelForSourceDocument(ISourceDocument sourceDocument);
    }
}
