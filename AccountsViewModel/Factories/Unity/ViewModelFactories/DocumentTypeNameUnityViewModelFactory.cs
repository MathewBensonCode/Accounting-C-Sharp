using Accounts.Repositories;
using AccountLib.Model;
using AccountLib.Interfaces;
using AccountsViewModel.EntityViewModels;
using AccountsViewModel.Factories.Interfaces.ViewModelFactories;
using Unity;

namespace AccountsViewModel.Factories.Unity.ViewModelFactories
{
    public class DocumentTypeNameUnityViewModelFactory:
        UnityViewModelFactory<DocumentTypeName>, IDocumentTypeNameViewModelFactory
    {
        IRepository<DocumentTypeName> _repository;

        public DocumentTypeNameUnityViewModelFactory(
            IRepository<DocumentTypeName> repository,
            IUnityContainer container
            ):base(container)
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
