using Accounts.Repositories;
using System.Collections.Generic;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CollectionCrudViewStateFactories;
using AccountsViewModel.Factories.Interfaces.CollectionViewModelFactories;
using AccountsViewModel.Factories.Repositories.Interfaces;
using Unity;
using Unity.Resolution;

namespace AccountsViewModel.Factories.Unity.CollectionViewModelFactories
{
    public class UnityCollectionViewModelFactory<T> :
        ICollectionViewModelFactory<T>
        where T : class
    {
        IUnityContainer _container;
        ICollectionCrudListViewStateFactory<T> _viewStateFactory;
        IRepositoryFactory<T> _repositoryFactory;

        public UnityCollectionViewModelFactory(
            IUnityContainer container,
            ICollectionCrudListViewStateFactory<T> viewstatefactory,
            IRepositoryFactory<T> repositoryFactory
            )
        {
            _container = container;
            _viewStateFactory = viewstatefactory;
            _repositoryFactory = repositoryFactory;
        }

        public IEntityCollectionViewModel<T> CreateNewCollectionViewModel(ICollection<T> collection = null)
        {
            IRepository<T> repository;
            IEntityCollectionViewModel<T> collectionViewModel;

            if (collection == null)
            {

                collectionViewModel = _container.Resolve(typeof(IEntityCollectionViewModel<T>), null) as IEntityCollectionViewModel<T>;
            }
            else
            {
                repository = _repositoryFactory.CreateRepositoryForCollection(collection);
                collectionViewModel = _container.Resolve(typeof(IEntityCollectionViewModel<T>), null, new ParameterOverride[]

                {

                    new ParameterOverride("repository", repository)

                }) as IEntityCollectionViewModel<T>;
            }

            return collectionViewModel;
        }
    }
}
