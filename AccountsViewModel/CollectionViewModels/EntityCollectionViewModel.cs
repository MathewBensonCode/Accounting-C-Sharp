using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CollectionCrudViewStateFactories;
using AccountsViewModel.Repositories.Interfaces;
using Prism.Mvvm;

namespace AccountsViewModel.CollectionViewModels
{
    public class EntityCollectionViewModel<T> :
        BindableBase, IEntityCollectionViewModel<T> where T : class
    {
        private ICollectionViewModelState<T> _currentCollectionViewState;

        public EntityCollectionViewModel(
            IRepository<T> repository,
            ICollectionCrudListViewStateFactory<T> viewstatefactory
            )
        {
            CollectionViewState = viewstatefactory.CreateEntityListView(this, repository);
        }

        public ICollectionViewModelState<T> CollectionViewState
        {
            get => _currentCollectionViewState;

            set
            {
                _currentCollectionViewState = value;
                RaisePropertyChanged();
            }
        }
    }
}
