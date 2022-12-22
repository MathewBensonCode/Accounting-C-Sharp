using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CollectionCrudViewStateFactories;
using AccountsViewModel.Repositories.Interfaces;
using Unity;
using Unity.Resolution;

namespace AccountsViewModel.Factories.Unity.CollectionCrudViewStateFactories
{
    public class CollectionCrudEditViewStateFactory<T>
        : ICollectionCrudEditViewStateFactory<T> where T : class
    {
        private readonly IUnityContainer _container;

        public CollectionCrudEditViewStateFactory(IUnityContainer container)
        {
            _container = container;
        }
        public ICollectionEditViewModelState<T> CreateEntityEditView(
            IEntityCollectionViewModel<T> collectionViewModel,
            IRepository<T> repository,
            ICollectionListViewModelState<T> listViewState
            )
        {
            return _container.Resolve(typeof(ICollectionEditViewModelState<T>), null,
               new ResolverOverride[]
               {
                    new ParameterOverride("collectionViewModel", collectionViewModel),
                    new ParameterOverride("repository", repository),
                    new ParameterOverride("listViewModelState", listViewState)
               }

               ) as ICollectionEditViewModelState<T>;
        }
    }
}
