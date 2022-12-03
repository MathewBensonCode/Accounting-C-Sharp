using Accounts.Repositories;
using AccountLib.Model.Source_Documents;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CommandViewModelFactories;

namespace AccountsViewModel.CollectionCrudViews
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
