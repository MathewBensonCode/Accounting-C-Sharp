using Accounts.Repositories;
using AccountLib.Model.Source_Documents;
using AccountsViewModel.Factories.Interfaces.CollectionCrudViewStateFactories;

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
