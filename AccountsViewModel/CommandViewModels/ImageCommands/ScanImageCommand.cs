using AccountsViewModel.EntityViewModels.Interfaces;
using ImageServices.Services.Interfaces;
using Prism.Commands;

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
            imageViewModel.Path = pathservice.GetFullPath(imagefolder, imagepath);
        }
                )
        {
        }
    }
}
