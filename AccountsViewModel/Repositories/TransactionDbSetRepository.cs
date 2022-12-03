using AccountLib.Model.Accounts;
using AccountLib.Model.Transactions;
using Accounts.Repositories;
using AccountsEntityFrameworkCore;
using AccountLib.Interfaces;
using AccountLib.Interfaces.Accounts;
using AccountLib.Interfaces.SourceDocuments;
using System.Collections.Generic;
using System.Linq;

namespace AccountsViewModel.Repositories
{
    public class TransactionDbSetRepository
        : DbSetRepository<Transaction>, ITransactionRepository
    {
        public TransactionDbSetRepository(AccountsDbContext context, int pageSize = 10)
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

        public ICollection<Transaction> GetTransactionsForSourceDocument(ISourceDocument sourceDocument)
        {
            return AccountsDbContext.Transactions.Where(trans => trans.SourceDocumentId == (sourceDocument as IDbModel).Id).ToList();
        }

        public IEnumerable<Transaction> GetAssetPurchaseTransactions()
        {
            return AccountsDbContext.Transactions.OfType<AssetPurchaseTransaction>().ToList();
        }

        public IEnumerable<Transaction> GetAssetSaleTransactions()
        {
            return AccountsDbContext.Transactions.OfType<AssetSaleTransaction>().ToList();
        }

        public IEnumerable<Transaction> GetCapitalAdditionTransactions()
        {
            return AccountsDbContext.Transactions.OfType<CapitalAdditionTransaction>().ToList();
        }

        public IEnumerable<Transaction> GetCapitalDrawingTransactions()
        {
            return AccountsDbContext.Transactions.OfType<CapitalDrawingTransaction>().ToList();
        }

        public IEnumerable<Transaction> GetExpenseTransactions()
        {
            return AccountsDbContext.Transactions.OfType<ExpenseTransaction>().ToList();
        }

        public IEnumerable<Transaction> GetIncomeTransactions()
        {
            return AccountsDbContext.Transactions.OfType<IncomeTransaction>().ToList();
        }

        public IEnumerable<Transaction> GetLiabilityDecreaseTransactions()
        {
            return AccountsDbContext.Transactions.OfType<LiabilityDecreaseTransaction>().ToList();
        }

        public IEnumerable<Transaction> GetLiabilityIncreaseTransactions()
        {
            return AccountsDbContext.Transactions.OfType<LiabilityIncreaseTransaction>().ToList();
        }

        public ICollection<Transaction> GetDebitTransactionsForAccount(IAccount account)
        {
            return AccountsDbContext.Transactions.Where(t => t.DebitAccountId == (account as IDbModel).Id).ToList();
        }

        public ICollection<Transaction> GetCreditTransactionsForAccount(IAccount account)
        {
            return AccountsDbContext.Transactions.Where(t => t.CreditAccountId == (account as IDbModel).Id).ToList();
        }
    }
}


