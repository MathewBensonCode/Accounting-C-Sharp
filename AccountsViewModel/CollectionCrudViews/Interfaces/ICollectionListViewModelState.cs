using System.Collections.Generic;
using System.ComponentModel;
using AccountsViewModel.CommandViewModels.Interfaces;
using AccountsViewModel.EntityViewModels.Interfaces;

namespace AccountsViewModel.CollectionCrudViews.Interfaces
{
    public interface ICollectionListViewModelState<T>
        : ICollectionViewModelState<T>, INotifyPropertyChanged
        where T : class
    {
        ICollection<IEntityViewModel<T>> EntityCollection { get; }

        ICommandViewModel AddNewCommand { get; }
        ICommandViewModel EditCurrentCommand { get; }
        ICommandViewModel DeleteCurrentCommand { get; }

        ICommandViewModel NextPageCommand { get; }
        ICommandViewModel PreviousPageCommand { get; }
        ICommandViewModel GoToBeginningCommand { get; }
        ICommandViewModel GoToEndCommand { get; }

        int Count { get; }

        int CurrentPage { get; set; }
    }
}
