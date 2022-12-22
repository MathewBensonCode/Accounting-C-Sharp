using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.Repositories.Interfaces;
using Prism.Commands;

namespace AccountsViewModel.CommandViewModels.CollectionCommands
{
    public class DeleteCurrentEntityFromCollectionCommand<T> :
        DelegateCommand where T : class
    {
        public DeleteCurrentEntityFromCollectionCommand(
            IRepository<T> repository,
            ICollectionListViewModelState<T> listViewState
            ) : base(
                () =>
                {
                    if (repository.Contains(listViewState.EntityViewModel.Entity))
                    {
                        repository.RemoveSingle(listViewState.EntityViewModel.Entity);
                    }

                    _ = listViewState.EntityCollection.Remove(listViewState.EntityViewModel);
                    listViewState.EntityViewModel = null;
                }
                ,
                () =>
                {
                    return listViewState.EntityViewModel != null;
                }
                )
        {
        }
    }
}
