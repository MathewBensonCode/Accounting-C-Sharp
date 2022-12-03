using AccountsViewModel.CommandViewModels.CollectionCommands.Interfaces;

namespace AccountsViewModel.CollectionCrudViews.Interfaces
{
    public interface ICollectionAddEditViewModelState<T>
        : ICollectionViewModelState<T> where T : class
    {
        ICommandViewModel SaveCommand { get; }
        ICommandViewModel CancelCommand { get; }
    }
}
