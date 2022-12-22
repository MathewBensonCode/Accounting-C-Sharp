using System.Collections.Generic;
using System.Linq;
using AccountsEntityFrameworkCore;
using AccountsModelCore.Classes.Accounts;
using AccountsViewModel.Repositories.Interfaces;

namespace AccountsViewModel.Repositories.AccountDbSetRepositories
{
    public class CapitalAccountDbSetRepository
        : AccountDbSetRepository, IRepository<CapitalAccount>
    {
        public CapitalAccountDbSetRepository(AccountsDbContext context, int pageSize = 10) : base(context, pageSize)
        {
        }

        IEnumerable<CapitalAccount> IRepository<CapitalAccount>.GetAll()
        {
            return GetCapitalAccounts() as IEnumerable<CapitalAccount>;
        }

        CapitalAccount IRepository<CapitalAccount>.Find(int Id)
        {
            return _dbSet.OfType<CapitalAccount>().Where(a => a.Id == Id).FirstOrDefault();
        }

        IEnumerable<CapitalAccount> IRepository<CapitalAccount>.GetDefault()
        {
            return _dbSet.Take(GetPageSize()).ToList().OfType<CapitalAccount>().ToList();
        }

        IEnumerable<CapitalAccount> IRepository<CapitalAccount>.GetPageCollection(int Id)
        {
            return _dbSet.Skip((Id - 1) * GetPageSize()).Take(GetPageSize()).ToList() as IEnumerable<CapitalAccount>;
        }

        public void AddSingle(CapitalAccount entity)
        {
            AddSingle(entity as Account);
        }

        public void AddRange(IEnumerable<CapitalAccount> entities)
        {
            AddRange(entities as IEnumerable<Account>);
        }

        public void RemoveSingle(CapitalAccount entity)
        {
            RemoveSingle(entity as Account);
        }

        public void RemoveRange(IEnumerable<CapitalAccount> entities)
        {
            RemoveRange(entities as IEnumerable<Account>);
        }

        public bool Contains(CapitalAccount entity)
        {
            return Contains(entity as Account);
        }
    }
}
