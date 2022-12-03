using Accounts.Repositories;
using Prism.Mvvm;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CollectionCrudViewStateFactories;

namespace AccountsViewModel.CollectionViewModels
{
    public class EntityCollectionViewModel<T>:
        BindableBase, IEntityCollectionViewModel<T> where T: class
    {
        ICollectionViewModelState<T> _currentCollectionViewState;

        public EntityCollectionViewModel(
            IRepository<T> repository,
            ICollectionCrudListViewStateFactory<T> viewstatefactory
            )
        {
            CollectionViewState = viewstatefactory.CreateEntityListView(this, repository);
        }

        public ICollectionViewModelState<T> CollectionViewState
        {
            get
            {
                return _currentCollectionViewState;
            }

            set
            {
                _currentCollectionViewState = value;
                RaisePropertyChanged();
            }
        }   
    }
}
