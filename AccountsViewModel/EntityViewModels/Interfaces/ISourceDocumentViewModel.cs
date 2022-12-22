using System;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsModelCore.Classes.DocumentImages;
using AccountLib.Model.SourceDocuments;
using AccountsModelCore.Classes.Transactions;

namespace AccountsViewModel.EntityViewModels.Interfaces
{
    public interface ISourceDocumentViewModel
        : IEntityViewModel<SourceDocument>
    {
        DateTime? DocumentDate { get; set; }
        int BusinessEntitySourceDocumentTypeId { get; set; }
        IBusinessEntitySourceDocumentTypeViewModel BusinessEntitySourceDocumentTypeViewModel { get; }
        IEntityCollectionViewModel<Transaction> TransactionCollectionViewModel { get; }
        IEntityCollectionViewModel<DocumentImage> ImageCollectionViewModel { get; }

    }
}
