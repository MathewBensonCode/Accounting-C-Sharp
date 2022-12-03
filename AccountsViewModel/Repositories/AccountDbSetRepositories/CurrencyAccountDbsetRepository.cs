using System.Collections.Generic;
using System.Linq;
using AccountLib.Model.Accounts;
using Accounts.Repositories;
using AccountsEntityFrameworkCore;

namespace AccountsViewModel.Repositories.DbSetRepositories
{
	public class CurrencyAccountDbSetRepository
		: AccountDbSetRepository, IRepository<CurrencyAccount>
	{
		public CurrencyAccountDbSetRepository(AccountsDbContext context, int pageSize = 10) : base(context, pageSize)
		{
		}



		IEnumerable<CurrencyAccount> IRepository<CurrencyAccount>.GetAll()
		{
			return GetCurrencyAccounts() as IEnumerable<CurrencyAccount>;
		}

		CurrencyAccount IRepository<CurrencyAccount>.Find(int Id)
		{
			return _dbSet.OfType<CurrencyAccount>().Where(a => a.Id == Id).FirstOrDefault();
		}

		IEnumerable<CurrencyAccount> IRepository<CurrencyAccount>.GetDefault()
		{
			return _dbSet.Take(GetPageSize()).ToList().OfType<CurrencyAccount>().ToList();
		}

		IEnumerable<CurrencyAccount> IRepository<CurrencyAccount>.GetPageCollection(int Id)
		{
			return _dbSet.Skip((Id - 1) * GetPageSize()).Take(GetPageSize()).ToList() as IEnumerable<CurrencyAccount>;
		}

		public void AddSingle(CurrencyAccount entity)
		{
			AddSingle(entity as Account);
		}

		public void AddRange(IEnumerable<CurrencyAccount> entities)
		{
			AddRange(entities as IEnumerable<Account>);
		}

		public void RemoveSingle(CurrencyAccount entity)
		{
			RemoveSingle(entity as Account);
		}

		public void RemoveRange(IEnumerable<CurrencyAccount> entities)
		{
			RemoveRange(entities as IEnumerable<Account>);
		}

		public bool Contains(CurrencyAccount entity)
		{
			return Contains(entity as Account);
		}
	}
}
