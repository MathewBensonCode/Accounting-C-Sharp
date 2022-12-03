using AccountLib.Model.SourceDocuments;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsModelCore.Interfaces.BusinessEntities;

namespace AccountsViewModel.Factories.Interfaces.CollectionViewModelFactories
{
    public interface ISourceDocumentCollectionViewModelFactory :
        ICollectionViewModelFactory<SourceDocument>
    {
        ISourceDocumentCollectionViewModel CreateSourceDocumentCollectionViewModelFromBusinessEntity(IBusinessEntity businessEntity);
    }
}
