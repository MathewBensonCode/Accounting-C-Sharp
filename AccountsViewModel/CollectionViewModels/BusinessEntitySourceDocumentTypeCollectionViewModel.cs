using AccountsModelCore.Classes;
using AccountsViewModel.Factories.Interfaces.CollectionCrudViewStateFactories;
using AccountsViewModel.Repositories.Interfaces;

namespace AccountsViewModel.CollectionViewModels
{
    public class BusinessEntitySourceDocumentTypeCollectionViewModel :
        EntityCollectionViewModel<BusinessEntitySourceDocumentType>
    {
        public BusinessEntitySourceDocumentTypeCollectionViewModel(
            IRepository<BusinessEntitySourceDocumentType> repository,
            ICollectionCrudListViewStateFactory<BusinessEntitySourceDocumentType> viewstatefactory
            ) : base(repository, viewstatefactory)
        {
        }
    }
}
