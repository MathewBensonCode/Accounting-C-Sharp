using AccountLib.Model.SourceDocuments;
using AccountsModelCore.Interfaces.BusinessEntities;
using AccountsViewModel.CollectionViewModels.Interfaces;

namespace AccountsViewModel.Factories.Interfaces.CollectionViewModels
{
    public interface ISourceDocumentCollectionViewModelFactory
    {
        IEntityCollectionViewModel<SourceDocument> CreateSourceDocumentCollectionViewModelForBusinessEntity(IBusinessEntity businessEntity);
    }
}
