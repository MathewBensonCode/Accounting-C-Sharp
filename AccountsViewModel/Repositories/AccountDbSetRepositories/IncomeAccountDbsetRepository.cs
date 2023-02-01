using System.Collections.Generic;
using System.Linq;
using AccountsEntityFrameworkCore;
using AccountsModelCore.Classes.Accounts;
using AccountsViewModel.Repositories.Interfaces;

namespace AccountsViewModel.Repositories.AccountDbSetRepositories
{
    public class IncomeAccountDbSetRepository
        : AccountDbSetRepository, IRepository<IncomeAccount>
    {
        public IncomeAccountDbSetRepository(AccountsDbContext context, int pageSize = 10) : base(context, pageSize)
        {
        }

        IEnumerable<IncomeAccount> IRepository<IncomeAccount>.GetAll()
        {
            return GetIncomeAccounts() as IEnumerable<IncomeAccount>;
        }

        IncomeAccount IRepository<IncomeAccount>.Find(int Id)
        {
            return _dbSet.OfType<IncomeAccount>().Where(a => a.Id == Id).FirstOrDefault();
        }

        IEnumerable<IncomeAccount> IRepository<IncomeAccount>.GetDefault()
        {
            return _dbSet.Take(GetPageSize()).ToList().OfType<IncomeAccount>().ToList();
        }

        IEnumerable<IncomeAccount> IRepository<IncomeAccount>.GetPageCollection(int Id)
        {
            return _dbSet.Skip((Id - 1) * GetPageSize()).Take(GetPageSize()).ToList() as IEnumerable<IncomeAccount>;
        }

        public void AddSingle(IncomeAccount entity)
        {
            AddSingle(entity as Account);
        }

        public void AddRange(IEnumerable<IncomeAccount> entities)
        {
            AddRange(entities as IEnumerable<Account>);
        }

        public void RemoveSingle(IncomeAccount entity)
        {
            RemoveSingle(entity as Account);
        }

        public void RemoveRange(IEnumerable<IncomeAccount> entities)
        {
            RemoveRange(entities as IEnumerable<Account>);
        }

        public bool Contains(IncomeAccount entity)
        {
            return Contains(entity as Account);
        }
    }
}
