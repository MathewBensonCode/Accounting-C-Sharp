using AccountLib.Model.BusinessEntities;
using AccountLib.Model.SourceDocuments;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.CommandViewModels.CollectionCommands.Interfaces;

namespace AccountsViewModel.CollectionCrudViews.Interfaces
{
    public interface ISourceDocumentCollectionAddEditViewModelState
        : ICollectionAddEditViewModelState<SourceDocument>
    {
        IEntityCollectionViewModel<BusinessEntity> BusinessEntityCollectionViewModel { get; }
        ICommandViewModel ReadTextFromImageCommand { get; }
        string SourceDocumentText { get; }
        bool ImagePanelVisible { get; }
        bool BusinessEntityPanelVisible { get; }
        bool SourceDocumentTextPanelVisible { get; }
        bool DateAndTransactionsPanelVisible { get; }
    }
}
