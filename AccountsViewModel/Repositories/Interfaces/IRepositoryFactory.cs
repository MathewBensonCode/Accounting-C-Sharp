using Accounts.Repositories;
using System.Collections.Generic;

namespace AccountsViewModel.Repositories.Interfaces
{
    public interface IRepositoryFactory<T> where T:class
    {
        IRepository<T> CreateDefaultRepository();
        IRepository<T> CreateRepositoryForCollection(ICollection<T> collection);
    }
}
