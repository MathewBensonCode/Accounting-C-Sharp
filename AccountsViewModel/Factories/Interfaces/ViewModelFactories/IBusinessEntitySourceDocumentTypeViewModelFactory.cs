using AccountsViewModel.EntityViewModels.Interfaces;
using AccountsModelCore.Classes;
using AccountsModelCore.Interfaces.SourceDocuments;

namespace AccountsViewModel.Factories.Interfaces.ViewModelFactories
{
    public interface IBusinessEntitySourceDocumentTypeViewModelFactory :
        IViewModelFactory<BusinessEntitySourceDocumentType>
    {
        IBusinessEntitySourceDocumentTypeViewModel GetBusinessEntitySourceDocumentTypeViewModelForSourceDocument(ISourceDocument sourceDocument);
        void GetBusinessEntitySourceDocumentTypeViewModelForSourceDocumentFromText(string text, ISourceDocumentViewModel sourceDocumentViewModel);
    }
}
