using Accounts.Repositories;
using Prism.Commands;
using AccountsViewModel.CollectionCrudViews.Interfaces;

namespace AccountsViewModel.CommandViewModels.NavigationCommands
{
    public class NextPageCollectionCommand<T> :
        DelegateCommand where T : class
    {
        public NextPageCollectionCommand(
            IRepository<T> repository,
            ICollectionListViewModelState<T> listViewState
            ) :
            base(
                () =>
                {
                    listViewState.CurrentPage++;
                }
                ,
                () =>

                {
                    var lastpossiblepage = repository.Count / repository.GetPageSize();
                    return lastpossiblepage > listViewState.CurrentPage;
                }
                )
        {

        }
    }
}
