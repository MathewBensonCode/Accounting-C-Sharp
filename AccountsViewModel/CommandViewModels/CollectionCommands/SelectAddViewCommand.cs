using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.ViewModelFactories;
using Prism.Commands;

namespace AccountsViewModel.CommandViewModels.CollectionCommands
{
    public class SelectAddViewCommand<T> : DelegateCommand<string> where T : class
    {

        public SelectAddViewCommand(
            IEntityCollectionViewModel<T> collectionViewModel,
            ICollectionAddViewModelState<T> addState,
            IViewModelFactory<T> viewModelFactory
            ) : base((string type) =>
            {
                collectionViewModel.CollectionViewState = addState;
                addState.EntityViewModel = viewModelFactory.CreateViewModelForNewEntity(type);
            })
        {

        }

    }
}
