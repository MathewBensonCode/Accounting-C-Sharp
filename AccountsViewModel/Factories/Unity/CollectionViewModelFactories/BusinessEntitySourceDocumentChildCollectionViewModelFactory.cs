using AccountsModelCore.Classes;
using AccountsModelCore.Interfaces.BusinessEntities;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CollectionViewModelFactories;
using AccountsViewModel.Repositories.Interfaces;

namespace AccountsViewModel.Factories.Unity.CollectionViewModelFactories
{
    public class BusinessEntitySourceDocumentTypeChildCollectionViewModelFactory :
        IBusinessEntitySourceDocumentTypeChildCollectionViewModelFactory
    {
        private readonly IBusinessEntitySourceDocumentTypeRepository _repository;
        private readonly ICollectionViewModelFactory<BusinessEntitySourceDocumentType> _businessEntitySourceDocumentTypeCollectionViewModelFactory;

        public BusinessEntitySourceDocumentTypeChildCollectionViewModelFactory(
            IRepository<BusinessEntitySourceDocumentType> repository,
            ICollectionViewModelFactory<BusinessEntitySourceDocumentType> businessEntitySourceDocumentTypeCollectionViewModelFactory
            )
        {
            _repository = repository as IBusinessEntitySourceDocumentTypeRepository;
            _businessEntitySourceDocumentTypeCollectionViewModelFactory = businessEntitySourceDocumentTypeCollectionViewModelFactory;
        }

        public IEntityCollectionViewModel<BusinessEntitySourceDocumentType> GetBusinessEntitySourceDocumentTypeCollectionViewModelForBusinessEntity(IBusinessEntity entity)
        {

            if (entity.BusinessEntitySourceDocumentTypes == null)
            {
                var collection = _repository.GetBusinessEntitySourceDocumentTypesForBusinessEntity(entity);
                entity.BusinessEntitySourceDocumentTypes = collection;
            }

            return _businessEntitySourceDocumentTypeCollectionViewModelFactory
                .CreateNewCollectionViewModel(entity.BusinessEntitySourceDocumentTypes);
        }
    }
}
