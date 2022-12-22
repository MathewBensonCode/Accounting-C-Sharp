using System.Collections.Generic;
using System.Linq;
using AccountsEntityFrameworkCore;
using AccountsModelCore.Classes.Accounts;
using AccountsViewModel.Repositories.Interfaces;

namespace AccountsViewModel.Repositories.AccountDbSetRepositories
{
    public class LiabilityAccountDbSetRepository
        : AccountDbSetRepository, IRepository<LiabilityAccount>
    {
        public LiabilityAccountDbSetRepository(AccountsDbContext context, int pageSize = 10) : base(context, pageSize)
        {
        }

        IEnumerable<LiabilityAccount> IRepository<LiabilityAccount>.GetAll()
        {
            return GetLiabilityAccounts() as IEnumerable<LiabilityAccount>;
        }

        LiabilityAccount IRepository<LiabilityAccount>.Find(int Id)
        {
            return _dbSet.OfType<LiabilityAccount>().Where(a => a.Id == Id).FirstOrDefault();
        }

        IEnumerable<LiabilityAccount> IRepository<LiabilityAccount>.GetDefault()
        {
            return _dbSet.Take(GetPageSize()).ToList().OfType<LiabilityAccount>().ToList();
        }

        IEnumerable<LiabilityAccount> IRepository<LiabilityAccount>.GetPageCollection(int Id)
        {
            return _dbSet.Skip((Id - 1) * GetPageSize()).Take(GetPageSize()).ToList() as IEnumerable<LiabilityAccount>;
        }

        public void AddSingle(LiabilityAccount entity)
        {
            AddSingle(entity as Account);
        }

        public void AddRange(IEnumerable<LiabilityAccount> entities)
        {
            AddRange(entities as IEnumerable<Account>);
        }

        public void RemoveSingle(LiabilityAccount entity)
        {
            RemoveSingle(entity as Account);
        }

        public void RemoveRange(IEnumerable<LiabilityAccount> entities)
        {
            RemoveRange(entities as IEnumerable<Account>);
        }

        public bool Contains(LiabilityAccount entity)
        {
            return Contains(entity as Account);
        }
    }
}
