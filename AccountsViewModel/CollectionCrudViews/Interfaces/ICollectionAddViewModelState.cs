namespace AccountsViewModel.CollectionCrudViews.Interfaces
{
    public interface ICollectionAddViewModelState<T>
        : ICollectionAddEditViewModelState<T>
        where T : class
    {
    }
}
