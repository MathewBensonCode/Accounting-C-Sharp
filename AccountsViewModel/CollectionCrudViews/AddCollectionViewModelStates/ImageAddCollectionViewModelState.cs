using System.Collections.Generic;
using AccountsModelCore.Classes;
using AccountsModelCore.Classes.DocumentImages;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CommandViewModelFactories;
using AccountsViewModel.Repositories.Interfaces;

namespace AccountsViewModel.CollectionCrudViews.AddCollectionViewModelStates
{
    public class ImageAddCollectionViewModelState
        : AddNewEntityToCollectionViewModelState<DocumentImage>, ICollectionAddViewModelState<DocumentImage>
    {
        public ImageAddCollectionViewModelState(
            ICollectionListViewModelState<DocumentImage> listViewModelState,
            IRepository<DocumentImage> repository,
            IEntityCollectionViewModel<DocumentImage> collectionViewModel,
            ICommandViewModelFactory<DocumentImage> commandfactory) :
            base(listViewModelState, repository, collectionViewModel, commandfactory)
        {
        }

        public IEnumerable<Country> CountryList { get; }
    }
}
