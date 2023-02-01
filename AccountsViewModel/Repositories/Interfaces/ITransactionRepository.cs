using System.Collections.Generic;
using AccountsModelCore.Classes.Transactions;
using AccountsModelCore.Interfaces.Accounts;
using AccountsModelCore.Interfaces.SourceDocuments;

namespace AccountsViewModel.Repositories.Interfaces
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
