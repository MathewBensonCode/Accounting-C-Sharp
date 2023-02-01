using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CommandViewModelFactories;
using AccountsViewModel.Repositories.Interfaces;

namespace AccountsViewModel.CollectionCrudViews
{
    public class AddNewEntityToCollectionViewModelState<T>
       : AddEditEntityCollectionViewModelState<T>
        where T : class
    {
        public AddNewEntityToCollectionViewModelState(
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
            SaveCommand = CommandFactory.CreateSaveNewCommand(this as ICollectionAddViewModelState<T>, ListViewModelState, Repository, CollectionViewModel);
        }
    }
}
