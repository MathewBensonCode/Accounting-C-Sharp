using Prism.Commands;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;

namespace AccountsViewModel.CommandViewModels.CollectionCommands
{
    public class CancelAddNewAndEditCommand<T> :
        DelegateCommand
        where T : class
    {
        public CancelAddNewAndEditCommand(
             IEntityCollectionViewModel<T> collectionViewModel,
             ICollectionListViewModelState<T> listViewState
            ) :
            base(
                () =>
                {
                    collectionViewModel.CollectionViewState = listViewState;
                }
                )
        {
        }
    }
}
