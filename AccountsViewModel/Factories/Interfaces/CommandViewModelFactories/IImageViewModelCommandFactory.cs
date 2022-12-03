using AccountsViewModel.CommandViewModels.CollectionCommands.Interfaces;
using AccountsViewModel.EntityViewModels.Interfaces;

namespace AccountsViewModel.Factories.Interfaces.CommandViewModelFactories
{
    public interface IImageViewModelCommandFactory
    {
        ICommandViewModel CreateScanImageCommand(IDocumentImageViewModel imageViewModel);
        ICommandViewModel CreateGetImageFromFileCommand(IDocumentImageViewModel imageviewmodel);
        ICommandViewModel CreateGetTextFromImageCommand(IDocumentImageViewModel imageviewmodel);
    }
}
