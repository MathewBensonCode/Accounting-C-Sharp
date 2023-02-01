using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Repositories.Interfaces;

namespace AccountsViewModel.Factories.Interfaces.CollectionCrudViewStateFactories
{
    public interface ICollectionCrudAddViewStateFactory<T> where T : class
    {
        ICollectionAddViewModelState<T> CreateEntityAddViewState(ICollectionListViewModelState<T> liststate, IRepository<T> repository, IEntityCollectionViewModel<T> collectionViewModel);

    }
}
