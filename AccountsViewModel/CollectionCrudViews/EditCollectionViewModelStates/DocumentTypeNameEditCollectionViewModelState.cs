using Accounts.Repositories;
using AccountLib.Model;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CommandViewModelFactories;

namespace AccountsViewModel.CollectionCrudViews
{
    public class DocumentTypeNameEditCollectionViewModelState :
        EditEntityInCollectionViewModelState<DocumentTypeName>, ICollectionEditViewModelState<DocumentTypeName>
    {
        public DocumentTypeNameEditCollectionViewModelState(
            ICollectionListViewModelState<DocumentTypeName> listViewModelState,
            IRepository<DocumentTypeName> repository,
            IEntityCollectionViewModel<DocumentTypeName> collectionViewModel,
            ICommandViewModelFactory<DocumentTypeName> commandFactory
            ) : base(listViewModelState, repository, collectionViewModel, commandFactory)
        {
        }
    }
}
