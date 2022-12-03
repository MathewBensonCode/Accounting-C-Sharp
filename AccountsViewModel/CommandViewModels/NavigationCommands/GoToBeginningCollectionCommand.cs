using Accounts.Repositories;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using Prism.Commands;

namespace AccountsViewModel.CommandViewModels.NavigationCommands
{
    public class GoToBeginningCollectionCommand<T> :
        DelegateCommand where T : class
    {

        public GoToBeginningCollectionCommand(
            IRepository<T> repository,
            ICollectionListViewModelState<T> listViewState
            ) :
            base(
                () =>
                {
                    listViewState.CurrentPage = 1;
                },
                () =>
                {
                    return (repository.GetPageSize() < repository.Count) && (listViewState.CurrentPage != 1);

                }
                )
        {
        }

    }
}
