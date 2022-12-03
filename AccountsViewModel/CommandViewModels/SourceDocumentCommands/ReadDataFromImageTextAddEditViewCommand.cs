using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.Services.Interfaces;
using Prism.Commands;

namespace AccountsViewModel.CommandViewModels.SourceDocumentCommands
{
    public class ReadDataFromImageTextAddEditViewCommand :
        DelegateCommand
    {
        public ReadDataFromImageTextAddEditViewCommand(
             ISourceDocumentCollectionAddEditViewModelState sourceDocumentCollectionAddEditViewModelState,
             ISourceDocumentTextReadService sourceDocumentTextReadService
             ) :
             base(
                 () =>
                 {
                     sourceDocumentTextReadService.GetDetailsFromText(sourceDocumentCollectionAddEditViewModelState);
                 }
                 ,
                     () =>
                     {
                         return !string.IsNullOrEmpty(sourceDocumentCollectionAddEditViewModelState.SourceDocumentText)
                 ;
                     }
                 )
        {
        }
    }
}
