using AccountsViewModel.Repositories.Interfaces;
using System.Collections.Generic;

namespace AccountsViewModel.Factories.Interfaces.RepositoryFactories
{
    public interface IRepositoryFactory<T> where T : class
    {
        IRepository<T> CreateDefaultRepository();
        IRepository<T> CreateRepositoryForCollection(ICollection<T> collection);
    }
}
