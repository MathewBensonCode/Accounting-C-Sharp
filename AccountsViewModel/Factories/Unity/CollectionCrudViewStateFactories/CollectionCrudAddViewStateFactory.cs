using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CollectionCrudViewStateFactories;
using AccountsViewModel.Repositories.Interfaces;
using Unity;
using Unity.Resolution;

namespace AccountsViewModel.Factories.Unity.CollectionCrudViewStateFactories
{
    public class CollectionCrudAddViewStateFactory<T>
        : ICollectionCrudAddViewStateFactory<T>
        where T : class
    {
        private readonly IUnityContainer _container;

        public CollectionCrudAddViewStateFactory(IUnityContainer unityContainer)
        {
            _container = unityContainer;
        }

        public ICollectionAddViewModelState<T> CreateEntityAddViewState(ICollectionListViewModelState<T> liststate, IRepository<T> repository, IEntityCollectionViewModel<T> collectionviewmodel)
        {
            var addstate = _container.Resolve(typeof(ICollectionAddViewModelState<T>), null,
               new ResolverOverride[]
               {
                    new ParameterOverride("listViewModelState", liststate),
                    new ParameterOverride("collectionViewModel", collectionviewmodel),
                    new ParameterOverride("repository", repository)
               }

               ) as ICollectionAddViewModelState<T>;

            return addstate;
        }

    }
}
