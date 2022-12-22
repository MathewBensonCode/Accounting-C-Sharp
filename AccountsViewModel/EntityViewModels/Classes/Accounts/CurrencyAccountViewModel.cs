using System.Collections.Generic;
using AccountsViewModel.Factories.Interfaces.CollectionViewModelFactories;
using AccountsModelCore.Interfaces.Accounts;
using AccountsModelCore.Classes.Accounts;

namespace AccountsViewModel.EntityViewModels.Classes.Accounts
{
    public class CurrencyAccountViewModel
        : AccountViewModel
    {

        public CurrencyAccountViewModel(
            ICurrencyAccount entity,
            ITransactionChildCollectionViewModelFactory transactionfactory,
            IDictionary<string,
            List<string>> errors
            )
        : base(entity as CurrencyAccount, transactionfactory, errors)
        {
        }

    }
}
