using AccountLib.Model.Transactions;
using AccountLib.Interfaces.Accounts;
using AccountLib.Interfaces.SourceDocuments;
using System.Collections.Generic;

namespace Accounts.Repositories
{
    public interface ITransactionRepository : IRepository<Transaction>
    {
        ICollection<Transaction> GetTransactionsForSourceDocument(ISourceDocument sourceDocument);
        ICollection<Transaction> GetDebitTransactionsForAccount(IAccount account);
        ICollection<Transaction> GetCreditTransactionsForAccount(IAccount account);
        IEnumerable<Transaction> GetAssetPurchaseTransactions();
        IEnumerable<Transaction> GetAssetSaleTransactions();
        IEnumerable<Transaction> GetCapitalAdditionTransactions();
        IEnumerable<Transaction> GetCapitalDrawingTransactions();
        IEnumerable<Transaction> GetExpenseTransactions();
        IEnumerable<Transaction> GetIncomeTransactions();
        IEnumerable<Transaction> GetLiabilityDecreaseTransactions();
        IEnumerable<Transaction> GetLiabilityIncreaseTransactions();
        


    }
}
