using AccountsModelCore.Classes.Transactions;

namespace AccountsViewModel.EntityViewModels.Interfaces
{
    public interface ITransactionViewModel
        : IEntityViewModel<Transaction>
    {
        int DebitAccountId { get; set; }
        int CreditAccountId { get; set; }
        int SourceDocumentId { get; set; }
        decimal Amount { get; set; }
        ISourceDocumentViewModel SourceDocumentViewModel { get; }
        IAccountViewModel DebitAccountViewModel { get; }
        IAccountViewModel CreditAccountViewModel { get; }
    }
}
