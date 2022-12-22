using AccountsModelCore.Classes;
using AccountsModelCore.Interfaces;
using AccountsViewModel.EntityViewModels.Interfaces;

namespace AccountsViewModel.Factories.Interfaces.ViewModelFactories
{
    public interface IDocumentTypeNameViewModelFactory :
        IViewModelFactory<DocumentTypeName>
    {
        IEntityViewModel<DocumentTypeName> GetDocumentTypeNameViewModelForBusinessEntitySourceDocumentType(IBusinessEntitySourceDocumentType businessEntitySourceDocumentType);
    }
}
