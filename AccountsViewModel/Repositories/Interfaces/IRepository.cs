using System.Collections.Generic;

namespace Accounts.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        int Count { get; }

        IEnumerable<TEntity> GetAll();
        TEntity Find(int Id);

        IEnumerable<TEntity> GetDefault();
        int GetPageSize();
        IEnumerable<TEntity> GetPageCollection(int Id);

        void AddSingle(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        void RemoveSingle(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);

        bool Contains(TEntity entity);

    }
}
