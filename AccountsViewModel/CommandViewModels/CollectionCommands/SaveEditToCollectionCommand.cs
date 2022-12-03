using Accounts.Repositories;
using Prism.Commands;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Repositories.Interfaces;
using AccountsViewModel.Services.Interfaces;

namespace AccountsViewModel.CommandViewModels.CollectionCommands
{
    public class SaveEditedEntityCommand<T> :
        DelegateCommand
        where T : class
    {
        public SaveEditedEntityCommand(
            ICollectionEditViewModelState<T> editViewState,
            ICollectionListViewModelState<T> listViewState,
            IViewModelCopyService<T> copyService,
            IEntityCollectionViewModel<T> collectionViewModel,
            IRepository<T> repository
            ) 
            : base(
                  ()=>
                  {
                      copyService.CopyEntityViewModel(editViewState.EntityViewModel, listViewState.EntityViewModel);
                      var saverepository = repository as ISaveRepository;
                      if (saverepository!=null)
                          saverepository.SaveRepository();
                      collectionViewModel.CollectionViewState = listViewState;
                  }
                  )
        {
        }
    }
}
