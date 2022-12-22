using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.Repositories.Interfaces;
using Prism.Commands;

namespace AccountsViewModel.CommandViewModels.NavigationCommands
{
    public class GoToEndCollectionCommand<T> :
         DelegateCommand where T : class
    {
        public GoToEndCollectionCommand(
            IRepository<T> repository,
            ICollectionListViewModelState<T> listViewState
            ) :
            base(
                () =>
                {
                    var lastpossiblepage = repository.Count / repository.GetPageSize();
                    listViewState.CurrentPage = lastpossiblepage;
                }
                ,
                () =>
                {
                    var lastpossiblepage = repository.Count / repository.GetPageSize();
                    return lastpossiblepage > 1 && listViewState.CurrentPage < lastpossiblepage;
                }
                )
        {

        }
    }
}
