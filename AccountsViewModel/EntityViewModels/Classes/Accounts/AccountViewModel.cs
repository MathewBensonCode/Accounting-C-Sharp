using System.Collections.Generic;
using AccountLib.Interfaces.Accounts;
using AccountLib.Model.Accounts;
using AccountLib.Model.Transactions;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Entity.Interfaces;
using AccountsViewModel.Factories.Interfaces.CollectionViewModelFactories;

namespace AccountsViewModel.EntityViewModels.Classes.Accounts
{
    public class AccountViewModel
        : EntityViewModel<Account>, IAccountViewModel
    {
        private readonly ITransactionChildCollectionViewModelFactory transactionfactory;
        private readonly IAccount account;

        public AccountViewModel(
            IAccount entity,
            ITransactionChildCollectionViewModelFactory _transactionfactory,
            IDictionary<string, List<string>> errors)
        : base(entity as Account, errors)
        {
            account = entity;
            transactionfactory = _transactionfactory;
        }

        public string Name
        {
            get => account.Name;

            set
            {
                account.Name = value;
                RaisePropertyChanged();
            }
        }

        public IEntityCollectionViewModel<Transaction> DebitsViewModel => transactionfactory.GetDebitsCollectionViewModelForAccount(account);

        public IEntityCollectionViewModel<Transaction> CreditsViewModel => transactionfactory.GetCreditsCollectionViewModelForAccount(account);
    }

}
