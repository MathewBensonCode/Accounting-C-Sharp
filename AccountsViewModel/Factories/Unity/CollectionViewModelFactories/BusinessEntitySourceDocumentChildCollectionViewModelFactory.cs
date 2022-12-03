using Accounts.Repositories;
using AccountLib.Model.Source_Documents;
using AccountsRepositoriesCore.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CollectionViewModelFactories;
using AccountsModelCore.Interfaces.BusinessEntities;

namespace AccountsViewModel.Factories.Unity.CollectionViewModelFactories
{
    public class BusinessEntitySourceDocumentTypeChildCollectionViewModelFactory :
        IBusinessEntitySourceDocumentTypeChildCollectionViewModelFactory
    {
        private IBusinessEntitySourceDocumentTypeRepository _repository;
        private ICollectionViewModelFactory<BusinessEntitySourceDocumentType> _businessEntitySourceDocumentTypeCollectionViewModelFactory;

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
