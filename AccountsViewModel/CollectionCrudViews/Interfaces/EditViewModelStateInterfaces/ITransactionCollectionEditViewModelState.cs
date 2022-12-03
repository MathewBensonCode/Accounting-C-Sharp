using AccountLib.Model.Accounts;
using AccountLib.Model.Transactions;
using AccountsViewModel.CollectionViewModels.Interfaces;

namespace AccountsViewModel.CollectionCrudViews.Interfaces.AddViewModelStateIInterfaces
{
    public interface ITransactionCollectionEditViewModelState
	    :ICollectionEditViewModelState<Transaction>
    {
    }
}
