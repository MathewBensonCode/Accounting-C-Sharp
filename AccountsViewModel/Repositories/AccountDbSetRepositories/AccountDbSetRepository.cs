using AccountLib.Model.Accounts;
using Accounts.Repositories;
using AccountsEntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AccountsViewModel.Repositories
{
    public class AccountDbSetRepository
        : DbSetRepository<Account>, IAccountRepository
    {
        public AccountDbSetRepository(AccountsDbContext context, int pageSize = 10)
        : base(context, pageSize)
        {
           
        }

        public AccountsDbContext AccountsDbContext
        {
            get
            {
                return _context as AccountsDbContext;
            }
        }

        public Account GetAccountWithTransactions(int id)
        {
            return AccountsDbContext.Accounts.Include(a => a.Debits).Include(a => a.Credits).FirstOrDefault(a => a.Id == id);
        }

        public IEnumerable<Account> GetDefaultAccountsWithTransactions()
        {
            return AccountsDbContext.Accounts.Include(a => a.Debits).Include(a => a.Credits).Take(GetPageSize()).ToList();
        }

        public IEnumerable<Account> GetAssetAccounts()
        {
            return AccountsDbContext.Accounts.OfType<AssetAccount>().ToList();
        }

        public IEnumerable<Account> GetCurrencyAccounts()
        {
            return AccountsDbContext.Accounts.OfType<CurrencyAccount>().ToList();
        }

        public IEnumerable<Account> GetCapitalAccounts()
        {
            return AccountsDbContext.Accounts.OfType<CapitalAccount>().ToList();
        }

        public IEnumerable<Account> GetExpenseAccounts()
        {
            return AccountsDbContext.Accounts.OfType<ExpenseAccount>().ToList();
        }

        public IEnumerable<Account> GetIncomeAccounts()
        {
            return AccountsDbContext.Accounts.OfType<IncomeAccount>().ToList();
        }

        public IEnumerable<Account> GetLiabilityAccounts()
        {
            return AccountsDbContext.Accounts.OfType<LiabilityAccount>().ToList();
        }

        public IEnumerable<Account> GetTradeItemAssetAccounts()
        {
            return AccountsDbContext.Accounts.OfType<TradeItemAssetAccount>().ToList();
        }


        
    }

}
