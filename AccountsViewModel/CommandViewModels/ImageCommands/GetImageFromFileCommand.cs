using AccountsViewModelsCore.Services.Interfaces;
using Prism.Commands;
using AccountsViewModel.EntityViewModels.Interfaces;

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
