using AccountLib.Model.BusinessEntities;
using AccountLib.Model.SourceDocuments;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CollectionViewModelFactories;
using AccountsViewModel.Repositories.Interfaces;

namespace AccountsViewModel.Factories.Unity.CollectionViewModelFactories
{
    public class SourceDocumentChildCollectionViewModelFactory
        : ISourceDocumentChildCollectionViewModelFactory
    {
        private readonly ISourceDocumentRepository _sourceDocumentRepository;
        private readonly ICollectionViewModelFactory<SourceDocument> _collectionViewModelFactory;

        public SourceDocumentChildCollectionViewModelFactory(
            IRepository<SourceDocument> sourceDocumentRepository,
            ICollectionViewModelFactory<SourceDocument> collectionViewModelFactory
            )
        {
            _sourceDocumentRepository = sourceDocumentRepository as ISourceDocumentRepository;
            _collectionViewModelFactory = collectionViewModelFactory;
        }
        public IEntityCollectionViewModel<SourceDocument> CreateSourceDocumentCollectionViewModelFromBusinessEntity(BusinessEntity businessEntity)
        {
            var sourcedocumentcollection = _sourceDocumentRepository.GetSourceDocumentsForBusinessEntity(businessEntity);
            //businessEntity.SourceDocuments = sourcedocumentcollection;
            return _collectionViewModelFactory.CreateNewCollectionViewModel(sourcedocumentcollection);
        }
    }
}
