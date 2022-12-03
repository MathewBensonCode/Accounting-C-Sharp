using AccountLib.Model.Source_Documents;
using AccountLib.Interfaces.SourceDocuments;
using AccountsViewModel.EntityViewModels.Interfaces;

namespace AccountsViewModel.Factories.Interfaces.ViewModelFactories
{
    public interface IBusinessEntitySourceDocumentTypeViewModelFactory :
        IViewModelFactory<BusinessEntitySourceDocumentType>
    {
        IBusinessEntitySourceDocumentTypeViewModel GetBusinessEntitySourceDocumentTypeViewModelForSourceDocument(ISourceDocument sourceDocument);
        void GetBusinessEntitySourceDocumentTypeViewModelForSourceDocumentFromText(string text, ISourceDocumentViewModel sourceDocumentViewModel);
    }
}
