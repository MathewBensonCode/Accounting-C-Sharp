using Accounts.Repositories;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CollectionCrudViewStateFactories;
using Unity;
using Unity.Resolution;

namespace AccountsViewModel.Factories.Unity.CollectionCrudViewStateFactories
{
    public class CollectionCrudViewStateFactory<T> :
        ICollectionCrudViewStateFactory<T>
        where T : class
    {
        IUnityContainer _container;

        public CollectionCrudViewStateFactory(IUnityContainer container)
        {
            _container = container;
        }

        public ICollectionAddViewModelState<T> CreateEntityAddView(ICollectionListViewModelState<T> listViewState)
        {
            throw new System.NotImplementedException();
        }

        public ICollectionEditViewModelState<T> CreateEntityEditView()
        {
            throw new System.NotImplementedException();
        }

        public ICollectionListViewModelState<T> CreateEntityListView(IEntityCollectionViewModel<T> collectionvm, IRepository<T> repository)
        {
            return _container.Resolve(typeof(ICollectionListViewModelState<T>), null,
                new ResolverOverride[]
                {
                    new ParameterOverride("repository", repository),
                    new ParameterOverride("collection", collectionvm)
                }
                
                ) as ICollectionListViewModelState<T>;
        }
    }
}
