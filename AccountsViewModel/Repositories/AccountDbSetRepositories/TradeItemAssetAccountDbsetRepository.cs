using System.Collections.Generic;
using System.Linq;
using AccountLib.Model.Accounts;
using Accounts.Repositories;
using AccountsEntityFrameworkCore;

namespace AccountsViewModel.Repositories.DbSetRepositories
{
	public class TradeItemAssetAccountDbSetRepository
		: AccountDbSetRepository, IRepository<TradeItemAssetAccount>
	{
		public TradeItemAssetAccountDbSetRepository(AccountsDbContext context, int pageSize = 10) : base(context, pageSize)
		{
		}



		IEnumerable<TradeItemAssetAccount> IRepository<TradeItemAssetAccount>.GetAll()
		{
			return GetTradeItemAssetAccounts() as IEnumerable<TradeItemAssetAccount>;
		}

		TradeItemAssetAccount IRepository<TradeItemAssetAccount>.Find(int Id)
		{
			return _dbSet.OfType<TradeItemAssetAccount>().Where(a => a.Id == Id).FirstOrDefault();
		}

		IEnumerable<TradeItemAssetAccount> IRepository<TradeItemAssetAccount>.GetDefault()
		{
			return _dbSet.Take(GetPageSize()).ToList().OfType<TradeItemAssetAccount>().ToList();
		}

		IEnumerable<TradeItemAssetAccount> IRepository<TradeItemAssetAccount>.GetPageCollection(int Id)
		{
			return _dbSet.Skip((Id - 1) * GetPageSize()).Take(GetPageSize()).ToList() as IEnumerable<TradeItemAssetAccount>;
		}

		public void AddSingle(TradeItemAssetAccount entity)
		{
			AddSingle(entity as Account);
		}

		public void AddRange(IEnumerable<TradeItemAssetAccount> entities)
		{
			AddRange(entities as IEnumerable<Account>);
		}

		public void RemoveSingle(TradeItemAssetAccount entity)
		{
			RemoveSingle(entity as Account);
		}

		public void RemoveRange(IEnumerable<TradeItemAssetAccount> entities)
		{
			RemoveRange(entities as IEnumerable<Account>);
		}

		public bool Contains(TradeItemAssetAccount entity)
		{
			return Contains(entity as Account);
		}
	}
}
