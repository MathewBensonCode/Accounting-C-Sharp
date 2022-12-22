using System.Collections.Generic;
using AccountsModelCore.Classes.Accounts;
using AccountsModelCore.Classes.Transactions;
using AccountsViewModel.Repositories.Interfaces;

namespace AccountsViewModel.Factories.TransactionAccountSelectionListFactories
{
    public class IncomeTransactionAccountSelectionListFactory
        : TransactionAccountSelectionListFactory<IncomeTransaction>
    {
        private readonly IAccountRepository _repository;

        public IncomeTransactionAccountSelectionListFactory(IRepository<Account> repository)
        {
            _repository = repository as IAccountRepository;
        }

        public override ICollection<Account> DebitAccountSelectionList => _repository.GetCurrencyAccounts() as ICollection<Account>;

        public override ICollection<Account> CreditAccountSelectionList => _repository.GetIncomeAccounts() as ICollection<Account>;
    }
}
