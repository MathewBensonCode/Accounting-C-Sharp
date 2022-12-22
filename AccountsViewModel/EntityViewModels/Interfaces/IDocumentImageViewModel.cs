using AccountsModelCore.Classes.DocumentImages;
using AccountsViewModel.CommandViewModels.Interfaces;

namespace AccountsViewModel.EntityViewModels.Interfaces
{
    public interface IDocumentImageViewModel
        : IEntityViewModel<DocumentImage>
    {
        string Path { get; set; }
        int SourceDocumentId { get; set; }
        ISourceDocumentViewModel SourceDocumentViewModel { get; }
        string SourceDocumentText { get; set; }
        ICommandViewModel ScanImageCommand { get; }
        ICommandViewModel GetImageFromFileCommand { get; }
        ICommandViewModel GetTextFromImageCommand { get; }
    }
}
