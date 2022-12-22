using System;
using AccountLib.Model.SourceDocuments;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.EntityViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CollectionViewModelFactories;
using AccountsViewModel.Factories.Interfaces.ViewModelFactories;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AccountsModelCore.Classes.DocumentImages;
using AccountsModelCore.Classes.Transactions;
using AccountsModelCore.Interfaces.SourceDocuments;

namespace AccountsViewModel.EntityViewModels.Classes.SourceDocuments
{
    public class SourceDocumentViewModel
        : EntityViewModel<SourceDocument>, ISourceDocumentViewModel
    {
        private readonly IBusinessEntitySourceDocumentTypeViewModelFactory _BusinessEntitySourceDocumentTypeViewModelFactory;

        public SourceDocumentViewModel(
            ISourceDocument entity,
            ITransactionChildCollectionViewModelFactory transactionCollectionViewModelFactory,
            IBusinessEntitySourceDocumentTypeViewModelFactory BusinessEntitySourceDocumentTypeViewModelFactory,
            IImageChildCollectionViewModelFactory imageCollectionViewModelFactory,
            IDictionary<string, List<string>> errors
            )
        : base(entity as SourceDocument, errors)
        {
            TransactionCollectionViewModel = transactionCollectionViewModelFactory.GetTransactionCollectionViewModelForSourceDocument(entity);
            _BusinessEntitySourceDocumentTypeViewModelFactory = BusinessEntitySourceDocumentTypeViewModelFactory;
            ImageCollectionViewModel = imageCollectionViewModelFactory.GetImageCollectionViewModelForSourceDocument(entity);
        }

        private ISourceDocument SourceDocument => Entity;

        [Required]
        public DateTime? DocumentDate
        {
            get => SourceDocument.DocumentDate;
            set
            {
                SourceDocument.DocumentDate = value;
                RaisePropertyChanged();
            }
        }

        public int BusinessEntitySourceDocumentTypeId
        {
            get => SourceDocument.BusinessEntitySourceDocumentTypeId;
            set
            {
                SourceDocument.BusinessEntitySourceDocumentTypeId = value;
                RaisePropertyChanged();
                RaisePropertyChanged("BusinessEntitySourceDocumentTypeViewModel");
            }

        }

        public IEntityCollectionViewModel<Transaction> TransactionCollectionViewModel
        {
            get; private set;
        }

        public IEntityCollectionViewModel<DocumentImage> ImageCollectionViewModel
        {
            get; private set;
        }

        public IBusinessEntitySourceDocumentTypeViewModel BusinessEntitySourceDocumentTypeViewModel => _BusinessEntitySourceDocumentTypeViewModelFactory.GetBusinessEntitySourceDocumentTypeViewModelForSourceDocument(SourceDocument);
    }
}
