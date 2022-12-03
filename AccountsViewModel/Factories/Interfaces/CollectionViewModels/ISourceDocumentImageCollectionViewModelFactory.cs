using AccountLib.Interfaces.SourceDocuments;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsModelCore.Classes.DocumentImages;

namespace AccountsViewModel.Factories.Interfaces.CollectionViewModels
{
    public interface IImageCollectionViewModelFactory
    {
        IEntityCollectionViewModel<DocumentImage> CreateImageCollectionViewModelForSourceDocument(ISourceDocument sourceDocument);
    }
}
