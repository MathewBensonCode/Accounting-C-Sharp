using Accounts.Repositories;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;

namespace AccountsViewModel.Factories.Interfaces.CollectionCrudViewStateFactories
{
    public interface ICollectionCrudListViewStateFactory<T> where T:class
    {
       ICollectionListViewModelState<T> CreateEntityListView(IEntityCollectionViewModel<T> collectionvm, IRepository<T> repository);
    }
}
