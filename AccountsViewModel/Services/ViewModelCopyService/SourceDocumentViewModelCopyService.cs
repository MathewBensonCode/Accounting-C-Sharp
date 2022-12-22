using AccountLib.Model.SourceDocuments;
using AccountsModelCore.Classes.DocumentImages;
using AccountsModelCore.Classes.Transactions;
using AccountsViewModel.EntityViewModels.Interfaces;
using AccountsViewModel.Services.Interfaces;

namespace AccountsViewModel.Services.ViewModelCopyService
{
    public class SourceDocumentViewModelCopyService
        : IViewModelCopyService<SourceDocument>
    {
        private readonly IViewModelCollectionCopyService<Transaction> _transactioncollectioncopyservice;
        private readonly IViewModelCollectionCopyService<DocumentImage> _imageCollectionCopyService;

        public SourceDocumentViewModelCopyService(
            IViewModelCollectionCopyService<Transaction> transactioncollectioncopyservice,
            IViewModelCollectionCopyService<DocumentImage> imageCollectionCopyService
            )
        {
            _transactioncollectioncopyservice = transactioncollectioncopyservice;
            _imageCollectionCopyService = imageCollectionCopyService;
        }
        public void CopyEntityViewModel(
            IEntityViewModel<SourceDocument> copyfrom,
            IEntityViewModel<SourceDocument> copyto)
        {
            var original = copyfrom as ISourceDocumentViewModel;
            var copy = copyto as ISourceDocumentViewModel;
            copy.DocumentDate = original.DocumentDate;
            copy.BusinessEntitySourceDocumentTypeId = original.BusinessEntitySourceDocumentTypeId;

            _transactioncollectioncopyservice.CopyCollection(original.TransactionCollectionViewModel, copy.TransactionCollectionViewModel);
            _imageCollectionCopyService.CopyCollection(original.ImageCollectionViewModel, copy.ImageCollectionViewModel);
        }
    }
}
