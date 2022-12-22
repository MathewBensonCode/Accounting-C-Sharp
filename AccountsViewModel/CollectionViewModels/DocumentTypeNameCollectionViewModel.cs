using AccountsModelCore.Classes;
using AccountsViewModel.Factories.Interfaces.CollectionCrudViewStateFactories;
using AccountsViewModel.Repositories.Interfaces;

namespace AccountsViewModel.CollectionViewModels
{
    public class DocumentTypeNameCollectionViewModel :
        EntityCollectionViewModel<DocumentTypeName>
    {
        public DocumentTypeNameCollectionViewModel(
            IRepository<DocumentTypeName> repository,
            ICollectionCrudListViewStateFactory<DocumentTypeName> viewstatefactory
            ) : base(repository, viewstatefactory)
        {
        }
    }
}
