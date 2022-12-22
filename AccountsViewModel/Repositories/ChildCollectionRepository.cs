using System;
using System.Collections.Generic;
using System.Linq;
using AccountsModelCore.Interfaces;
using AccountsViewModel.Repositories.Interfaces;

namespace AccountsViewModel.Repositories
{
    public class ChildCollectionRepository<T>
        : IRepository<T>
        where T : class, IDbModel
    {
        private readonly ICollection<T> _collection;
        private readonly int _pageSize = 10;

        public ChildCollectionRepository(
            ICollection<T> collection
            )
        {
            _collection = collection;
        }

        public int Count => _collection.Count;

        public void AddRange(IEnumerable<T> entities)
        {
            foreach (T t in entities)
            {
                _collection.Add(t);
            }
        }

        public void AddSingle(T entity)
        {
            _collection.Add(entity);
        }

        public bool Contains(T entity)
        {
            return _collection.Contains(entity);
        }

        public T Find(int Id)
        {
            foreach (T entity in _collection)
            {
                if (entity.Id == Id)
                {
                    return entity;
                }
            }

            return null;
        }

        public IEnumerable<T> GetAll()
        {
            return _collection;
        }

        public IEnumerable<T> GetDefault()
        {
            return GetPageCollection(1);
        }

        public IEnumerable<T> GetPageCollection(int Id)
        {
            return _collection.Skip((Id - 1) * _pageSize).Take(_pageSize).ToList();
        }

        public int GetPageSize()
        {
            return _pageSize;
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            foreach (T entity in entities)
            {
                _ = _collection.Contains(entity) ? _collection.Remove(entity) : throw new ArgumentOutOfRangeException();
            }
        }

        public void RemoveSingle(T entity)
        {
            if (_collection.Contains(entity))
            {
                _ = _collection.Remove(entity);
                return;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }
    }
}
