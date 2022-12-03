using AccountLib.Model.Accounts;
using System.Collections.Generic;

namespace Accounts.Repositories
{
    public interface IAccountRepository : IRepository<Account>
    {
        IEnumerable<Account> GetDefaultAccountsWithTransactions();
        Account GetAccountWithTransactions(int id);
        IEnumerable<Account> GetAssetAccounts();
        IEnumerable<Account> GetCurrencyAccounts();
        IEnumerable<Account> GetCapitalAccounts();
        IEnumerable<Account> GetExpenseAccounts();
        IEnumerable<Account> GetIncomeAccounts();
        IEnumerable<Account> GetLiabilityAccounts();
        IEnumerable<Account> GetTradeItemAssetAccounts();

    }
}
