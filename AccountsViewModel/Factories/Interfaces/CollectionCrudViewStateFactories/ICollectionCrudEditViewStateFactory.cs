using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Repositories.Interfaces;

namespace AccountsViewModel.Factories.Interfaces.CollectionCrudViewStateFactories
{
    public interface ICollectionCrudEditViewStateFactory<T> where T : class
    {
        ICollectionEditViewModelState<T> CreateEntityEditView(
            IEntityCollectionViewModel<T> collectionViewModel,
            IRepository<T> repository,
            ICollectionListViewModelState<T> listViewModelState
            );
    }
}
