using System.Collections.Generic;
using AccountLib.Model.Accounts;
using AccountLib.Model.Transactions;
using Accounts.Repositories;

namespace AccountsViewModel.Factories.TransactionAccountSelectionListFactories
{
    public class ExpenseTransactionAccountSelectionListFactory
        : TransactionAccountSelectionListFactory<ExpenseTransaction>
    {
        IAccountRepository _repository;

        public ExpenseTransactionAccountSelectionListFactory(IRepository<Account> repository)
        {
            _repository = repository as IAccountRepository;
        }

        public override ICollection<Account> DebitAccountSelectionList
        {
            get
            {
                return _repository.GetExpenseAccounts() as ICollection<Account>;
            }
        }

        public override ICollection<Account> CreditAccountSelectionList
        {
            get
            {
                return _repository.GetCurrencyAccounts() as ICollection<Account>;
            }
        }
    }
}
