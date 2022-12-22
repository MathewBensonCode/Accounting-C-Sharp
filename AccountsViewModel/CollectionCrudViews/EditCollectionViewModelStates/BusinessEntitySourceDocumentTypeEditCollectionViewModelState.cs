using AccountsModelCore.Classes;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CommandViewModelFactories;
using AccountsViewModel.Repositories.Interfaces;

namespace AccountsViewModel.CollectionCrudViews.EditCollectionViewModelStates
{
    public class BusinessEntitySourceDocumentTypeEditCollectionViewModelState :
        EditEntityInCollectionViewModelState<BusinessEntitySourceDocumentType>, ICollectionEditViewModelState<BusinessEntitySourceDocumentType>
    {
        public BusinessEntitySourceDocumentTypeEditCollectionViewModelState(
            ICollectionListViewModelState<BusinessEntitySourceDocumentType> listViewModelState,
            IRepository<BusinessEntitySourceDocumentType> repository,
            IEntityCollectionViewModel<BusinessEntitySourceDocumentType> collectionViewModel,
            ICommandViewModelFactory<BusinessEntitySourceDocumentType> commandFactory
            ) : base(listViewModelState, repository, collectionViewModel, commandFactory)
        {
        }
    }
}
