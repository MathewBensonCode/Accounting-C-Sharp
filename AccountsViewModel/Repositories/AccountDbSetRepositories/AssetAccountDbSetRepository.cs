using System.Collections.Generic;
using System.Linq;
using AccountsEntityFrameworkCore;
using AccountsModelCore.Classes.Accounts;
using AccountsViewModel.Repositories.Interfaces;

namespace AccountsViewModel.Repositories.AccountDbSetRepositories
{
    public class AssetAccountDbSetRepository
        : AccountDbSetRepository, IRepository<AssetAccount>
    {
        public AssetAccountDbSetRepository(AccountsDbContext context, int pageSize = 10) : base(context, pageSize)
        {
        }

        IEnumerable<AssetAccount> IRepository<AssetAccount>.GetAll()
        {
            return GetAssetAccounts() as IEnumerable<AssetAccount>;
        }

        AssetAccount IRepository<AssetAccount>.Find(int Id)
        {
            return _dbSet.OfType<AssetAccount>().Where(a => a.Id == Id).FirstOrDefault();
        }

        IEnumerable<AssetAccount> IRepository<AssetAccount>.GetDefault()
        {
            return _dbSet.Take(GetPageSize()).ToList().OfType<AssetAccount>().ToList();
        }

        IEnumerable<AssetAccount> IRepository<AssetAccount>.GetPageCollection(int Id)
        {
            return _dbSet.Skip((Id - 1) * GetPageSize()).Take(GetPageSize()).ToList() as IEnumerable<AssetAccount>;
        }

        public void AddSingle(AssetAccount entity)
        {
            AddSingle(entity as Account);
        }

        public void AddRange(IEnumerable<AssetAccount> entities)
        {
            AddRange(entities as IEnumerable<Account>);
        }

        public void RemoveSingle(AssetAccount entity)
        {
            RemoveSingle(entity as Account);
        }

        public void RemoveRange(IEnumerable<AssetAccount> entities)
        {
            RemoveRange(entities as IEnumerable<Account>);
        }

        public bool Contains(AssetAccount entity)
        {
            return Contains(entity as Account);
        }
    }
}
