﻿using AccountLib.Model.SourceDocuments;
using Accounts.Repositories;
using AccountLib.Interfaces.Transactions;
using AccountsViewModel.EntityViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.ViewModelFactories;
using Unity;
using AccountLib.Interfaces.Images;

namespace AccountsViewModel.Factories.Unity.ViewModelFactories
{
    public class SourceDocumentUnityViewModelFactory :
        UnityViewModelFactory<SourceDocument>, ISourceDocumentViewModelFactory
    {
        private readonly IRepository<SourceDocument> _sourceDocumentRepository;

        public SourceDocumentUnityViewModelFactory(
            IRepository<SourceDocument> sourceDocumentRepository,
            IUnityContainer container) : base(container)
        {
            _sourceDocumentRepository = sourceDocumentRepository;
        }

        public ISourceDocumentViewModel CreateSourceDocumentViewModelForImage(IDocumentImage image)
        {
            var sourceDocument = _sourceDocumentRepository.Find(image.SourceDocumentId);
            return CreateViewModelFromEntity(sourceDocument) as ISourceDocumentViewModel;
        }

        public ISourceDocumentViewModel CreateSourceDocumentViewModelForTransaction(ITransaction transaction)
        {
            var sourceDocument = _sourceDocumentRepository.Find(transaction.SourceDocumentId);
            return CreateViewModelFromEntity(sourceDocument) as ISourceDocumentViewModel;
        }
    }
}
