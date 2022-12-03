﻿using System.Collections.Generic;
using Accounts.Repositories;
using AccountsViewModel.Factories.Repositories.Interfaces;
using Unity;
using Unity.Resolution;

namespace AccountsViewModel.Factories.Unity.RepositoryFactories
{
    public class RepositoryFactory<T> :
        IRepositoryFactory<T> where T : class
    {
        IUnityContainer _container;

        public RepositoryFactory(IUnityContainer container)
        {
            _container = container;
        }
        public IRepository<T> CreateDefaultRepository()
        {
            return _container.Resolve(typeof(IRepository<T>), null, null) as IRepository<T>;
        }

        public IRepository<T> CreateRepositoryForCollection(ICollection<T> collection)
        {
            return _container.Resolve(typeof(IRepository<T>), "childcollection",
                new ResolverOverride[]
                {
                    new ParameterOverride("collection", collection),
                }) as IRepository<T>;
        }
    }
}
