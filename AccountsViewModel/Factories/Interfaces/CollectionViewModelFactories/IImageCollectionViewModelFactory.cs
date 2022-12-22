using AccountsModelCore.Interfaces.SourceDocuments;
using AccountsViewModel.CollectionViewModels.Interfaces;

namespace AccountsViewModel.Factories.Interfaces.CollectionViewModelFactories
{
    public interface IImageCollectionViewModelFactory
    {
        IImageCollectionViewModel GetImageCollectionViewModelForSourceDocument(ISourceDocument sourceDocument);
    }
}
