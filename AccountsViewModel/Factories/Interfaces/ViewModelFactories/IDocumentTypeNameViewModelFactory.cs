using AccountLib.Model;
using AccountLib.Interfaces;
using AccountsViewModel.EntityViewModels;

namespace AccountsViewModel.Factories.Interfaces.ViewModelFactories
{
    public interface IDocumentTypeNameViewModelFactory:
        IViewModelFactory<DocumentTypeName>
    {
        IEntityViewModel<DocumentTypeName> GetDocumentTypeNameViewModelForBusinessEntitySourceDocumentType(IBusinessEntitySourceDocumentType businessEntitySourceDocumentType);
    }
}
