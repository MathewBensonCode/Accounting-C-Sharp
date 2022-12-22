using AccountsModelCore.Classes;
using AccountsModelCore.Interfaces.SourceDocuments;
using AccountsViewModel.EntityViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.ViewModelFactories;
using AccountsViewModel.Repositories.Interfaces;
using Unity;
using Unity.Resolution;

namespace AccountsViewModel.Factories.Unity.ViewModelFactories
{
    public class BusinessEntitySourceDocumentTypeUnityViewModelFactory :
        UnityViewModelFactory<BusinessEntitySourceDocumentType>, IBusinessEntitySourceDocumentTypeViewModelFactory
    {
        private readonly IRepository<BusinessEntitySourceDocumentType> _repository;

        public BusinessEntitySourceDocumentTypeUnityViewModelFactory(
            IRepository<BusinessEntitySourceDocumentType> repository,
            IUnityContainer container) :
            base(container)
        {
            _repository = repository;
        }

        public IBusinessEntitySourceDocumentTypeViewModel GetBusinessEntitySourceDocumentTypeViewModelForSourceDocument(ISourceDocument sourceDocument)
        {
            var businessEntitySourceDocumentType = _repository.Find(sourceDocument.BusinessEntitySourceDocumentTypeId);
            return _unityContainer.Resolve(typeof(IEntityViewModel<BusinessEntitySourceDocumentType>), null,
                new ResolverOverride[] {
                    new ParameterOverride("entity", businessEntitySourceDocumentType)
                }) as IBusinessEntitySourceDocumentTypeViewModel;
        }

        public void GetBusinessEntitySourceDocumentTypeViewModelForSourceDocumentFromText(string text, ISourceDocumentViewModel sourceDocumentViewModel)
        {
            throw new System.NotImplementedException();
        }
    }
}
