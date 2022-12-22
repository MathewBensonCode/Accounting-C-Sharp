using AccountsViewModel.EntityViewModels.Interfaces;
using ImageServices.Services.Interfaces;
using Prism.Commands;

namespace AccountsViewModel.CommandViewModels.ImageCommands
{
    public class GetTextFromImageCommand :
        DelegateCommand
    {
        public GetTextFromImageCommand(
          IDocumentImageViewModel imageViewModel,
        IGetTextFromImageServices textFromImageService
            ) :
        base(
            () =>
            {
                imageViewModel.SourceDocumentText = textFromImageService.GetTextFromImageUsingTesseract(imageViewModel.Path);
            }
                )
        {
        }
    }
}
