using Accounts.Repositories;
using AccountsModelCore.Classes.DocumentImages;
using AccountsViewModel.Factories.Interfaces.CollectionCrudViewStateFactories;

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
