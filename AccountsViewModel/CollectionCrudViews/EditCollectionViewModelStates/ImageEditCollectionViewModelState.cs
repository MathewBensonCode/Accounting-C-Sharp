using AccountsModelCore.Classes.DocumentImages;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CommandViewModelFactories;
using AccountsViewModel.Repositories.Interfaces;

namespace AccountsViewModel.CollectionCrudViews.EditCollectionViewModelStates
{
    public class ImageEditCollectionViewModelState
        : EditEntityInCollectionViewModelState<DocumentImage>, ICollectionEditViewModelState<DocumentImage>
    {
        public ImageEditCollectionViewModelState(
            ICollectionListViewModelState<DocumentImage> listViewModelState,
            IRepository<DocumentImage> repository,
            IEntityCollectionViewModel<DocumentImage> collectionViewModel,
            ICommandViewModelFactory<DocumentImage> commandFactory) : base(listViewModelState, repository, collectionViewModel, commandFactory)
        {
        }
    }
}
