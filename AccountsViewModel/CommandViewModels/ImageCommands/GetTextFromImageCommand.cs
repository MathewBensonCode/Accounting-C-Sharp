using AccountsViewModelsCore.Services.Interfaces;
using Prism.Commands;
using AccountsViewModel.EntityViewModels.Interfaces;

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
