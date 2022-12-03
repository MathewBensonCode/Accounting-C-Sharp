using Accounts.Repositories;
using Prism.Commands;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Repositories.Interfaces;

namespace AccountsViewModel.CommandViewModels.CollectionCommands
{
    public class SaveNewToRepositoryCommand<T>
        : DelegateCommand where T : class
    {
        public SaveNewToRepositoryCommand(
            IEntityCollectionViewModel<T> collectionViewModel,
            ICollectionAddViewModelState<T> addViewState,
            ICollectionListViewModelState<T> listViewState,
            IRepository<T> repository
            )
            : base(
                  () =>
                  {
                      var entityvm = addViewState.EntityViewModel;
                      repository.AddSingle(entityvm.Entity as T);
                      var saverepository = repository as ISaveRepository;
                      if (saverepository != null)
                          saverepository.SaveRepository();
                      listViewState.EntityCollection.Add(entityvm);
                      collectionViewModel.CollectionViewState = listViewState;
                  },
                  () =>
                  {
                      return (!addViewState.EntityViewModel.HasErrors) && (addViewState.EntityViewModel.HasChanged);
                  }
                  )
        {

        }
    }
}
