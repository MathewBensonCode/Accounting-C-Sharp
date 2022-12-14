using AccountsModelCore.Classes.Transactions;

namespace AccountsViewModel.CollectionCrudViews.Interfaces
{
    public interface ITransactionCollectionAddEditViewModelState
        : ICollectionAddEditViewModelState<Transaction>
    {
        object DebitAccountCollectionViewModel { get; }
        object CreditAccountCollectionViewModel { get; }
    }
}
