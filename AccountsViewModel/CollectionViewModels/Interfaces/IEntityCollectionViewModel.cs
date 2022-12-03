using System.ComponentModel;
using AccountsViewModel.CollectionCrudViews.Interfaces;

namespace AccountsViewModel.CollectionViewModels.Interfaces
{
    public interface IEntityCollectionViewModel<T>:
        INotifyPropertyChanged where T:class
    {
        ICollectionViewModelState<T> CollectionViewState { get; set; }
    }
}
