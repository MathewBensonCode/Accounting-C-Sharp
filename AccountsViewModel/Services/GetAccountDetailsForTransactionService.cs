using AccountsViewModel.EntityViewModels.Interfaces;
using AccountsViewModel.Services.Interfaces;

namespace AccountsViewModel.Services
{
    public class GetAccountDetailsForTransactionService
        : IGetAccountDetailsForTransactionService
    {
        public GetAccountDetailsForTransactionService()
        {
        }

        public void GetCreditAccountForTransactionFromText(string text, ITransactionViewModel transactionvm)
        {
            throw new System.NotImplementedException();
        }

        public void GetDebitAccountForTransactionFromText(string text, ITransactionViewModel transactionvm)
        {
            throw new System.NotImplementedException();
        }
    }
}
