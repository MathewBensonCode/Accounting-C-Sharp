using AccountLib.Model.Accounts;
using AccountLib.Model.Transactions;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.EntityViewModels;

namespace AccountsViewModel.Entity.Interfaces
{
    public interface IAccountViewModel
        : IEntityViewModel<Account>
    {
        string Name { get; set; }
        IEntityCollectionViewModel<Transaction> DebitsViewModel { get; }
        IEntityCollectionViewModel<Transaction> CreditsViewModel { get; }
    }
}
