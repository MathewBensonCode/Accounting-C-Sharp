using System.Collections.Generic;
using System.Linq;
using AccountsEntityFrameworkCore;
using AccountsModelCore.Classes.Accounts;
using AccountsViewModel.Repositories.Interfaces;

namespace AccountsViewModel.Repositories.AccountDbSetRepositories
{
    public class ExpenseAccountDbSetRepository
        : AccountDbSetRepository, IRepository<ExpenseAccount>
    {
        public ExpenseAccountDbSetRepository(AccountsDbContext context, int pageSize = 10) : base(context, pageSize)
        {
        }

        IEnumerable<ExpenseAccount> IRepository<ExpenseAccount>.GetAll()
        {
            return GetExpenseAccounts() as IEnumerable<ExpenseAccount>;
        }

        ExpenseAccount IRepository<ExpenseAccount>.Find(int Id)
        {
            return _dbSet.OfType<ExpenseAccount>().Where(a => a.Id == Id).FirstOrDefault();
        }

        IEnumerable<ExpenseAccount> IRepository<ExpenseAccount>.GetDefault()
        {
            return _dbSet.Take(GetPageSize()).ToList().OfType<ExpenseAccount>().ToList();
        }

        IEnumerable<ExpenseAccount> IRepository<ExpenseAccount>.GetPageCollection(int Id)
        {
            return _dbSet.Skip((Id - 1) * GetPageSize()).Take(GetPageSize()).ToList() as IEnumerable<ExpenseAccount>;
        }

        public void AddSingle(ExpenseAccount entity)
        {
            AddSingle(entity as Account);
        }

        public void AddRange(IEnumerable<ExpenseAccount> entities)
        {
            AddRange(entities as IEnumerable<Account>);
        }

        public void RemoveSingle(ExpenseAccount entity)
        {
            RemoveSingle(entity as Account);
        }

        public void RemoveRange(IEnumerable<ExpenseAccount> entities)
        {
            RemoveRange(entities as IEnumerable<Account>);
        }

        public bool Contains(ExpenseAccount entity)
        {
            return Contains(entity as Account);
        }
    }
}
