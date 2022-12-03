using AccountsViewModel.CollectionCrudViews.Interfaces;

namespace AccountsViewModel.Services.Interfaces
{
    public interface ISourceDocumentTextReadService
    {
        void GetDetailsFromText(ISourceDocumentCollectionAddEditViewModelState sourceDocumentCollectionAddEditViewModelState);
    }
}
