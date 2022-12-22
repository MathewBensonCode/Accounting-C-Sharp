using AccountsModelCore.Classes.DocumentImages;
using AccountsViewModel.EntityViewModels.Interfaces;
using AccountsViewModel.Services.Interfaces;

namespace AccountsViewModel.Services.ViewModelCopyService
{
    public class ImageViewModelCopyService
        : IViewModelCopyService<DocumentImage>
    {
        public void CopyEntityViewModel(IEntityViewModel<DocumentImage> copyfrom, IEntityViewModel<DocumentImage> copyto)
        {
            var original = copyfrom as IDocumentImageViewModel;
            var copy = copyto as IDocumentImageViewModel;

            copy.Path = original.Path;
            copy.SourceDocumentId = original.SourceDocumentId;
            copy.SourceDocumentText = original.SourceDocumentText;
        }
    }
}
