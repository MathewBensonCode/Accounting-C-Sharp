using System.Collections.Generic;
using AccountsModelCore.Classes.Accounts;
using AccountsModelCore.Classes.Transactions;
using AccountsViewModel.Repositories.Interfaces;

namespace AccountsViewModel.Factories.TransactionAccountSelectionListFactories
{
    public class AssetPurchaseTransactionAccountSelectionListFactory
        : TransactionAccountSelectionListFactory<AssetPurchaseTransaction>
    {
        private readonly IAccountRepository _repository;

        public AssetPurchaseTransactionAccountSelectionListFactory(IRepository<Account> repository)
        {
            _repository = repository as IAccountRepository;
        }

        public override ICollection<Account> DebitAccountSelectionList => _repository.GetAssetAccounts() as ICollection<Account>;

        public override ICollection<Account> CreditAccountSelectionList => _repository.GetCurrencyAccounts() as ICollection<Account>;
    }
}
