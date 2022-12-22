using AccountsModelCore.Classes.DocumentImages;
using AccountsViewModel.Factories.Interfaces.CollectionCrudViewStateFactories;
using AccountsViewModel.Repositories.Interfaces;

namespace AccountsViewModel.CollectionViewModels
{
    public class ImageCollectionViewModel
        : EntityCollectionViewModel<DocumentImage>
    {
        public ImageCollectionViewModel(
            IRepository<DocumentImage> repository,
            ICollectionCrudListViewStateFactory<DocumentImage> viewstatefactory
            ) : base(repository, viewstatefactory)
        {
        }
    }
}
