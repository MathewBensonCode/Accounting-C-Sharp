using System.Collections.Generic;
using AccountsModelCore.Classes.Accounts;
using AccountsModelCore.Classes.Transactions;
using AccountsViewModel.Repositories.Interfaces;

namespace AccountsViewModel.Factories.TransactionAccountSelectionListFactories
{
    public class CapitalDrawingTransactionAccountSelectionListFactory
        : TransactionAccountSelectionListFactory<CapitalDrawingTransaction>
    {
        private readonly IAccountRepository _repository;

        public CapitalDrawingTransactionAccountSelectionListFactory(IRepository<Account> repository)
        {
            _repository = repository as IAccountRepository;
        }

        public override ICollection<Account> DebitAccountSelectionList => _repository.GetCapitalAccounts() as ICollection<Account>;

        public override ICollection<Account> CreditAccountSelectionList => _repository.GetCurrencyAccounts() as ICollection<Account>;
    }
}
