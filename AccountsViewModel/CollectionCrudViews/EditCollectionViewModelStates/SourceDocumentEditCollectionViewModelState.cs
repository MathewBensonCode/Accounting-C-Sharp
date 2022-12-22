using AccountLib.Model.BusinessEntities;
using AccountLib.Model.SourceDocuments;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionCrudViews.Interfaces.EditViewModelStateInterfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CollectionViewModelFactories;
using AccountsViewModel.Factories.Interfaces.CommandViewModelFactories;
using AccountsViewModel.Repositories.Interfaces;

namespace AccountsViewModel.CollectionCrudViews.EditCollectionViewModelStates
{
    public class SourceDocumentEditCollectionViewModelState
        : SourceDocumentAddEditCollectionViewModelState, ISourceDocumentCollectionEditViewModelState
    {

        public SourceDocumentEditCollectionViewModelState(
            ICollectionListViewModelState<SourceDocument> listViewModelState,
            IRepository<SourceDocument> repository,
            IEntityCollectionViewModel<SourceDocument> collectionViewModel,
            ICommandViewModelFactory<SourceDocument> commandFactory,
            ICollectionViewModelFactory<BusinessEntity> businessEntityCollectionViewModelFactory,
            ISourceDocumentCollectionAddEditViewModelStateCommandFactory sourceDocumentCollectionAddEditViewModelStateCommandFactory
            )
            : base(listViewModelState, repository, collectionViewModel, businessEntityCollectionViewModelFactory, sourceDocumentCollectionAddEditViewModelStateCommandFactory, commandFactory)
        {
        }

        protected override void CreateSaveCommand()
        {
            SaveCommand = CommandFactory.CreateSaveEditCommand(this, ListViewModelState, Repository, CollectionViewModel);
        }
    }
}
