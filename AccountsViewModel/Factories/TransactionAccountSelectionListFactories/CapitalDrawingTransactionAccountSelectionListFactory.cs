using System.Collections.Generic;
using AccountLib.Model.Accounts;
using AccountLib.Model.Transactions;
using Accounts.Repositories;

namespace AccountsViewModel.Factories.TransactionAccountSelectionListFactories
{
    public class CapitalDrawingTransactionAccountSelectionListFactory
        : TransactionAccountSelectionListFactory<CapitalDrawingTransaction>
    {
        IAccountRepository _repository;

        public CapitalDrawingTransactionAccountSelectionListFactory(IRepository<Account> repository)
        {
            _repository = repository as IAccountRepository;
        }

        public override ICollection<Account> DebitAccountSelectionList
        {
            get
            {
                return _repository.GetCapitalAccounts() as ICollection<Account>; 
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
