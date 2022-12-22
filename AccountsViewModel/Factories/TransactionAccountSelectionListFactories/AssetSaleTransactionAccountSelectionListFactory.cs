using System.Collections.Generic;
using AccountsModelCore.Classes.Accounts;
using AccountsModelCore.Classes.Transactions;
using AccountsViewModel.Repositories.Interfaces;

namespace AccountsViewModel.Factories.TransactionAccountSelectionListFactories
{
    public class AssetSaleTransactionAccountSelectionListFactory
        : TransactionAccountSelectionListFactory<AssetSaleTransaction>
    {
        private readonly IAccountRepository _repository;

        public AssetSaleTransactionAccountSelectionListFactory(IRepository<Account> repository)
        {
            _repository = repository as IAccountRepository;
        }

        public override ICollection<Account> DebitAccountSelectionList => _repository.GetCurrencyAccounts() as ICollection<Account>;

        public override ICollection<Account> CreditAccountSelectionList => _repository.GetAssetAccounts() as ICollection<Account>;
    }
}
