using AccountsViewModel.EntityViewModels.Interfaces;

namespace AccountsViewModel.CollectionCrudViews.Interfaces
{
    public interface ICollectionViewModelState<T> where T : class
    {
        IEntityViewModel<T> EntityViewModel { get; set; }
    }
}
