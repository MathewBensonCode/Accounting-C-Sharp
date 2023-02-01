using AccountsViewModel.EntityViewModels.Interfaces;
using ImageServices.Services.Interfaces;
using Prism.Commands;

namespace AccountsViewModel.CommandViewModels.ImageCommands
{
    public class GetImageFromFileCommand :
        DelegateCommand
    {
        public GetImageFromFileCommand(
            IDocumentImageViewModel imageViewModel,
            IGetImageFromFileService fileservice
            ) :
        base(
                () =>
                {
                    var path = fileservice.GetImagePathFromDialog();
                    imageViewModel.Path = path;
                }
                )
        {
        }
    }
}
