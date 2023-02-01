using AccountsModelCore.Classes.Accounts;
using AccountsModelCore.Interfaces.Transactions;
using AccountsViewModel.EntityViewModels.Interfaces;

namespace AccountsViewModel.Factories.Interfaces.ViewModelFactories
{
    public interface IAccountViewModelFactory
        : IViewModelFactory<Account>
    {
        IAccountViewModel GetDebitAccountViewModelForTransaction(ITransaction transaction);
        IAccountViewModel GetCreditAccountViewModelForTransaction(ITransaction transaction);
    }
}
