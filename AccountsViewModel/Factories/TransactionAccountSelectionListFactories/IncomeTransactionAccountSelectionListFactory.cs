using System.Collections.Generic;
using AccountLib.Model.Accounts;
using AccountLib.Model.Transactions;
using Accounts.Repositories;

namespace AccountsViewModel.Factories.TransactionAccountSelectionListFactories
{
    public class IncomeTransactionAccountSelectionListFactory
        : TransactionAccountSelectionListFactory<IncomeTransaction>
    {
        IAccountRepository _repository;

        public IncomeTransactionAccountSelectionListFactory(IRepository<Account> repository)
        {
            _repository = repository as IAccountRepository;
        }

        public override ICollection<Account> DebitAccountSelectionList
        {
            get
            {
                return _repository.GetCurrencyAccounts() as ICollection<Account>;
            }
        }

        public override ICollection<Account> CreditAccountSelectionList
        {
            get
            {
                return _repository.GetIncomeAccounts() as ICollection<Account>;
            }
        }
    }
}
