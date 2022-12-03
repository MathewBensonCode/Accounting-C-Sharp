using AccountsViewModel.EntityViewModels.Interfaces;

namespace AccountsViewModel.Services.Interfaces
{
    public interface IGetAccountDetailsForTransactionService
    {
        void GetDebitAccountForTransactionFromText(string text, ITransactionViewModel transactionvm);
        void GetCreditAccountForTransactionFromText(string text, ITransactionViewModel transactionvm);
    }
}

