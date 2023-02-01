using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CollectionCrudViewStateFactories;
using AccountsViewModel.Repositories.Interfaces;
using Unity;
using Unity.Resolution;

namespace AccountsViewModel.Factories.Unity.CollectionCrudViewStateFactories
{
    public class CollectionCrudListViewStateFactory<T>
        : ICollectionCrudListViewStateFactory<T>
        where T : class
    {
        private readonly IUnityContainer _container;

        public CollectionCrudListViewStateFactory(IUnityContainer container)
        {
            _container = container;
        }

        public ICollectionListViewModelState<T> CreateEntityListView(IEntityCollectionViewModel<T> collectionvm, IRepository<T> repository)
        {
            return _container.Resolve(typeof(ICollectionListViewModelState<T>), null,
                new ResolverOverride[]
                {
                    new ParameterOverride("repository", repository),
                    new ParameterOverride("entityCollectionViewModel", collectionvm)
                }

                ) as ICollectionListViewModelState<T>;
        }
    }
}
