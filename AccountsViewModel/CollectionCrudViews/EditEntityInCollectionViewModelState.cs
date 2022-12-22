using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CommandViewModelFactories;
using AccountsViewModel.Repositories.Interfaces;

namespace AccountsViewModel.CollectionCrudViews
{
    public class EditEntityInCollectionViewModelState<T> :
        AddEditEntityCollectionViewModelState<T>
        where T : class
    {
        public EditEntityInCollectionViewModelState
        (
         ICollectionListViewModelState<T> listViewModelState,
         IRepository<T> repository,
         IEntityCollectionViewModel<T> collectionViewModel,
         ICommandViewModelFactory<T> commandfactory
         )
        : base(listViewModelState, repository, collectionViewModel, commandfactory)
        {
        }

        protected override void CreateSaveCommand()
        {
            SaveCommand = CommandFactory.CreateSaveEditCommand(this as ICollectionEditViewModelState<T>, ListViewModelState, Repository, CollectionViewModel);
        }
    }
}
