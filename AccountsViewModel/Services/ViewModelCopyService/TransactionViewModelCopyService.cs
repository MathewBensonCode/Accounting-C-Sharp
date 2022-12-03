using AccountLib.Model.Transactions;
using AccountsViewModel.EntityViewModels;
using AccountsViewModel.EntityViewModels.Interfaces;
using AccountsViewModel.Services.Interfaces;

namespace AccountsViewModel.Services.ViewModelCopyService
{
    public class TransactionViewModelCopyService
        : IViewModelCopyService<Transaction>
    {
        public void CopyEntityViewModel(IEntityViewModel<Transaction> copyfrom, IEntityViewModel<Transaction> copyto)
        {
            var original = copyfrom as ITransactionViewModel;
            var copy = copyto as ITransactionViewModel;

            copy.DebitAccountId = original.DebitAccountId;
            copy.CreditAccountId = original.CreditAccountId;
            copy.SourceDocumentId = original.SourceDocumentId;
            copy.Amount = original.Amount;
        }
    }
}
