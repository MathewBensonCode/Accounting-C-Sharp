using Accounts.Repositories;
using AccountLib.Model;
using AccountsViewModel.Factories.Interfaces.CollectionCrudViewStateFactories;

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
