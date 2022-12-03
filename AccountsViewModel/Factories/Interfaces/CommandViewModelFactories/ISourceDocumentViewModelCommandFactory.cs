using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CommandViewModels.CollectionCommands.Interfaces;

namespace AccountsViewModel.Factories.Interfaces.CommandViewModelFactories
{
    public interface ISourceDocumentCollectionAddEditViewModelStateCommandFactory
    {
        ICommandViewModel CreateReadFromImageTextCommand(ISourceDocumentCollectionAddEditViewModelState sourceDocumentCollectionAddEditViewModelState);
    }
}
