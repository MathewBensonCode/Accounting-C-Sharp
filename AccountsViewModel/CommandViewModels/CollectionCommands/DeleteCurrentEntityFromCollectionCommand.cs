using Accounts.Repositories;
using Prism.Commands;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.EntityViewModels;

namespace AccountsViewModel.CommandViewModels.CollectionCommands
{
    public class DeleteCurrentEntityFromCollectionCommand<T> :
        DelegateCommand where T: class
    {
        public DeleteCurrentEntityFromCollectionCommand(
            IRepository<T> repository,
            ICollectionListViewModelState<T> listViewState
            ) : base(
                () =>
                {
                    if(repository.Contains(listViewState.EntityViewModel.Entity as T))
                        repository.RemoveSingle(listViewState.EntityViewModel.Entity as T);
                    
                    listViewState.EntityCollection.Remove(listViewState.EntityViewModel);
                    listViewState.EntityViewModel = null;
                }
                ,
                () =>
                {
                    return (listViewState.EntityViewModel != null);
                }
                )
        {
        }
    }
}
