using AccountsModelCore.Classes;
using AccountsModelCore.Interfaces;
using AccountsViewModel.EntityViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.ViewModelFactories;
using AccountsViewModel.Repositories.Interfaces;
using Unity;

namespace AccountsViewModel.Factories.Unity.ViewModelFactories
{
    public class DocumentTypeNameUnityViewModelFactory :
        UnityViewModelFactory<DocumentTypeName>, IDocumentTypeNameViewModelFactory
    {
        private readonly IRepository<DocumentTypeName> _repository;

        public DocumentTypeNameUnityViewModelFactory(
            IRepository<DocumentTypeName> repository,
            IUnityContainer container
            ) : base(container)
        {
            _repository = repository;
        }

        public IEntityViewModel<DocumentTypeName> GetDocumentTypeNameViewModelForBusinessEntitySourceDocumentType(IBusinessEntitySourceDocumentType businessEntitySourceDocumentType)
        {
            var documentTypeName = _repository.Find(businessEntitySourceDocumentType.DocumentTypeNameId);
            return CreateViewModelFromEntity(documentTypeName);
        }
    }
}
