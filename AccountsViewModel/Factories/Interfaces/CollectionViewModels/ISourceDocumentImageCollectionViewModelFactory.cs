using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsModelCore.Classes.DocumentImages;
using AccountsModelCore.Interfaces.SourceDocuments;

namespace AccountsViewModel.Factories.Interfaces.CollectionViewModels
{
    public interface IImageCollectionViewModelFactory
    {
        IEntityCollectionViewModel<DocumentImage> CreateImageCollectionViewModelForSourceDocument(ISourceDocument sourceDocument);
    }
}
