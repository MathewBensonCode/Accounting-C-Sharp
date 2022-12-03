using AccountLib.Model.SourceDocuments;
using AccountsModelCore.Interfaces.BusinessEntities;
using AccountsViewModel.CollectionViewModels.Interfaces;

namespace AccountsViewModel.EntityViewModels
{
    public interface ISourceDocumentCollectionViewModelFactory
    {
        IEntityCollectionViewModel<SourceDocument> CreateSourceDocumentCollectionViewModelForBusinessEntity(IBusinessEntity businessEntity);
    }
}
