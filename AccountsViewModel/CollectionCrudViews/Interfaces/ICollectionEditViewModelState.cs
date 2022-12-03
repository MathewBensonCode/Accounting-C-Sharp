namespace AccountsViewModel.CollectionCrudViews.Interfaces
{
    public interface ICollectionEditViewModelState<T>
        : ICollectionAddEditViewModelState<T>
        where T : class
    {
    }
}
