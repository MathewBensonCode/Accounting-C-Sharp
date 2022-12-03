using AccountLib.Model;
using AccountsViewModel.EntityViewModels;
using AccountsViewModel.EntityViewModels.Interfaces;
using AccountsViewModel.Services.Interfaces;

namespace AccountsViewModel.Services.ViewModelCopyService
{
    public class DocumentTypeNameViewModelCopyService :
        IViewModelCopyService<DocumentTypeName>
    {
        public void CopyEntityViewModel(IEntityViewModel<DocumentTypeName> copyfrom, IEntityViewModel<DocumentTypeName> copyto)
        {
            var original = copyfrom as IDocumentTypeNameViewModel;
            var copy = copyto as IDocumentTypeNameViewModel;

            copy.Name = original.Name;
        }
    }
}
