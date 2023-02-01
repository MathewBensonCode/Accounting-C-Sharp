using AccountsModelCore.Classes.Accounts;
using AccountsModelCore.Classes.Transactions;
using AccountsViewModel.CollectionViewModels.Interfaces;

namespace AccountsViewModel.EntityViewModels.Interfaces
{
    public interface IAccountViewModel
        : IEntityViewModel<Account>
    {
        string Name { get; set; }
        IEntityCollectionViewModel<Transaction> DebitsViewModel { get; }
        IEntityCollectionViewModel<Transaction> CreditsViewModel { get; }
    }
}
