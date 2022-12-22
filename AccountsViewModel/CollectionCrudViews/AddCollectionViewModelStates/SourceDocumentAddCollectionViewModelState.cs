using AccountLib.Model.BusinessEntities;
using AccountLib.Model.SourceDocuments;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionCrudViews.Interfaces.AddViewModelStateIInterfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CollectionViewModelFactories;
using AccountsViewModel.Factories.Interfaces.CommandViewModelFactories;
using AccountsViewModel.Repositories.Interfaces;

namespace AccountsViewModel.CollectionCrudViews.AddCollectionViewModelStates
{
    public class SourceDocumentAddCollectionViewModelState
        : SourceDocumentAddEditCollectionViewModelState, ISourceDocumentCollectionAddViewModelState
    {
        public SourceDocumentAddCollectionViewModelState(
              ICollectionListViewModelState<SourceDocument> listViewModelState,
              IRepository<SourceDocument> repository,
              IEntityCollectionViewModel<SourceDocument> collectionViewModel,
              ICollectionViewModelFactory<BusinessEntity> businessEntityCollectionViewModelSelectionList,
              ISourceDocumentCollectionAddEditViewModelStateCommandFactory sourceDocumentAddEditViewModelCommandFactory,
              ICommandViewModelFactory<SourceDocument> commandfactory) :
              base(listViewModelState, repository, collectionViewModel, businessEntityCollectionViewModelSelectionList, sourceDocumentAddEditViewModelCommandFactory, commandfactory)
        {
        }

        protected override void CreateSaveCommand()
        {
            SaveCommand = CommandFactory.CreateSaveNewCommand(this, ListViewModelState, Repository, CollectionViewModel);
        }
    }
}
