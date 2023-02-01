using AccountLib.Model.SourceDocuments;
using AccountsViewModel.Factories.Interfaces.CollectionCrudViewStateFactories;
using AccountsViewModel.Repositories.Interfaces;

namespace AccountsViewModel.CollectionViewModels
{
    public class SourceDocumentCollectionViewModel
        : EntityCollectionViewModel<SourceDocument>
    {
        public SourceDocumentCollectionViewModel(
            IRepository<SourceDocument> repository,
            ICollectionCrudListViewStateFactory<SourceDocument> viewstatefactory
            ) : base(repository, viewstatefactory)
        {
        }
    }
}
