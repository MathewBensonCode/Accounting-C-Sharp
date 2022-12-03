using AccountsViewModelsCore.Services.Interfaces;
using Prism.Commands;
using AccountsViewModel.EntityViewModels.Interfaces;

namespace AccountsViewModel.CommandViewModels.ImageCommands
{
    public class ScanImageCommand :
        DelegateCommand
    {
        public ScanImageCommand(
        IDocumentImageViewModel imageViewModel,
        ICreateImageService createimageservice,
        IImagePathService pathservice
        ) : base(
            () =>
        {
            var imagefolder = pathservice.GetFolderPathForNewImage();
            var imagepath = pathservice.GetFileNameForNewImage();
            createimageservice.CreateImageInFolderWithFilename(imagefolder, imagepath);
            (imageViewModel as IDocumentImageViewModel).Path = pathservice.GetFullPath(imagefolder, imagepath);
        }
                )
        {
        }
    }
}
