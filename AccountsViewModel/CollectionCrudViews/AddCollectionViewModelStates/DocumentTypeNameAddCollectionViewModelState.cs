using AccountsModelCore.Classes;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CommandViewModelFactories;
using AccountsViewModel.Repositories.Interfaces;

namespace AccountsViewModel.CollectionCrudViews.AddCollectionViewModelStates
{
    public class DocumentTypeNameAddCollectionViewModelState :
        AddNewEntityToCollectionViewModelState<DocumentTypeName>, ICollectionAddViewModelState<DocumentTypeName>
    {
        public DocumentTypeNameAddCollectionViewModelState(
            ICollectionListViewModelState<DocumentTypeName> listViewModelState,
            IRepository<DocumentTypeName> repository,
            IEntityCollectionViewModel<DocumentTypeName> collectionViewModel,
            ICommandViewModelFactory<DocumentTypeName> commandfactory
            ) : base(listViewModelState, repository, collectionViewModel, commandfactory)
        {
        }
    }
}
