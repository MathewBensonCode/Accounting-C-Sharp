using AccountLib.Model.SourceDocuments;
using Accounts.Repositories;
using AccountsViewModel.Factories.Interfaces.CollectionCrudViewStateFactories;

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
