using AccountsViewModel.EntityViewModels;

namespace AccountsViewModel.CollectionCrudViews.Interfaces
{
    public interface ICollectionViewModelState<T> where T : class
    {
        IEntityViewModel<T> EntityViewModel { get; set; }
    }
}
