using AccountLib.Model.Accounts;
using AccountLib.Interfaces.Transactions;
using AccountsViewModel.CollectionViewModels.Interfaces;

namespace AccountsViewModel.Factories.Interfaces.CollectionViewModelFactories
{
    public interface ITransactionAccountSelectionCollectionViewModelFactory
    {
        object GetDebitAccountCollectionViewModelForTransaction(ITransaction transaction);
        object GetCreditAccountCollectionViewModelForTransaction(ITransaction transaction);
    }
}
