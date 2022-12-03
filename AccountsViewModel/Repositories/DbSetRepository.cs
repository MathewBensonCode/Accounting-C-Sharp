using System;
using System.Collections.Generic;
using System.Linq;
using Accounts.Repositories;
using AccountsEntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AccountsViewModel.Repositories.Interfaces;

namespace AccountsViewModel.Repositories
{
    public class DbSetRepository<T>
        : IRepository<T>, ISaveRepository
        where T : class
    {
        protected AccountsDbContext _context;
        protected DbSet<T> _dbSet;
        private readonly int _pageSize;

        public DbSetRepository(AccountsDbContext context, int pageSize = 10)
        {
            _context = context;
            _dbSet = context.Set<T>();
            _pageSize = pageSize;
        }

        public int Count => _dbSet.Count();

        public virtual void AddRange(IEnumerable<T> entities)
        {
            foreach (T t in entities)
            {
                _ = _dbSet.Add(t);
            }
        }

        public virtual void AddSingle(T entity)
        {
            _ = _dbSet.Add(entity);
        }

        public bool Contains(T entity)
        {
            return _dbSet.Contains(entity);
        }

        public virtual T Find(int Id)
        {
            return _dbSet.Find(Id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public virtual IEnumerable<T> GetDefault()
        {
            return GetPageCollection(1);
        }

        public virtual IEnumerable<T> GetPageCollection(int Id)
        {
            return _dbSet.Skip((Id - 1) * _pageSize).Take(_pageSize).ToList();
        }

        public int GetPageSize()
        {
            return _pageSize;
        }

        public virtual void RemoveRange(IEnumerable<T> entities)
        {
            foreach (T entity in entities)
            {
                _ = _dbSet.Contains(entity) ? _dbSet.Remove(entity) : throw new ArgumentOutOfRangeException();
            }
        }

        public virtual void RemoveSingle(T entity)
        {
            _ = !_dbSet.Contains(entity) ? throw new ArgumentOutOfRangeException() : _dbSet.Remove(entity);
        }

        public void SaveRepository()
        {
            _ = _context.SaveChanges();
        }
    }
}
