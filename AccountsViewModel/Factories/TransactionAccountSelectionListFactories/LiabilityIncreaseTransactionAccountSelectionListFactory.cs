using System.Collections.Generic;
using AccountLib.Model.Accounts;
using AccountLib.Model.Transactions;
using Accounts.Repositories;

namespace AccountsViewModel.Factories.TransactionAccountSelectionListFactories
{
    public class LiabilityIncreaseTransactionAccountSelectionListFactory
        : TransactionAccountSelectionListFactory<LiabilityIncreaseTransaction>
    {
        IAccountRepository _repository;

        public LiabilityIncreaseTransactionAccountSelectionListFactory(IRepository<Account> repository)
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
                return _repository.GetLiabilityAccounts() as ICollection<Account>;
            }
        }
    }
}
