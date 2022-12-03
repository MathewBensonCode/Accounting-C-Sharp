using Accounts.Repositories;
using AccountsModelCore.Classes.DocumentImages;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CommandViewModelFactories;

namespace AccountsViewModel.CollectionCrudViews
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
