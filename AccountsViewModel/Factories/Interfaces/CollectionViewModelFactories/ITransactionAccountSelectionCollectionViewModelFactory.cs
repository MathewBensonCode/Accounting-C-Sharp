using AccountsModelCore.Interfaces.Transactions;

namespace AccountsViewModel.Factories.Interfaces.CollectionViewModelFactories
{
    public interface ITransactionAccountSelectionCollectionViewModelFactory
    {
        object GetDebitAccountCollectionViewModelForTransaction(ITransaction transaction);
        object GetCreditAccountCollectionViewModelForTransaction(ITransaction transaction);
    }
}
