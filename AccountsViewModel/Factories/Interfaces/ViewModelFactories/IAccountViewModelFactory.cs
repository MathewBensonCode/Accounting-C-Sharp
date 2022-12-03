using AccountLib.Model.Accounts;
using AccountLib.Interfaces.Transactions;
using AccountsViewModel.Entity.Interfaces;

namespace AccountsViewModel.Factories.Interfaces.ViewModelFactories
{
    public interface IAccountViewModelFactory
        :IViewModelFactory<Account>
    {
        IAccountViewModel GetDebitAccountViewModelForTransaction(ITransaction transaction);
        IAccountViewModel GetCreditAccountViewModelForTransaction(ITransaction transaction);
    }
}
