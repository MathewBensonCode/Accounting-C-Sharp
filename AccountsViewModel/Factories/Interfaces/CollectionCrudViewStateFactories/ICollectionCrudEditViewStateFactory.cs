using Accounts.Repositories;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;

namespace AccountsViewModel.Factories.Interfaces.CollectionCrudViewStateFactories
{
    public interface ICollectionCrudEditViewStateFactory<T> where T:class
    {
        ICollectionEditViewModelState<T> CreateEntityEditView(
            IEntityCollectionViewModel<T> collectionViewModel,
            IRepository<T> repository,
            ICollectionListViewModelState<T> listViewModelState
            );
    }
}
