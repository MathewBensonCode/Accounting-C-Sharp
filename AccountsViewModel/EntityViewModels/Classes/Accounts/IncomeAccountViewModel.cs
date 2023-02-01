using System.Collections.Generic;
using AccountsViewModel.Factories.Interfaces.CollectionViewModelFactories;
using AccountsModelCore.Interfaces.Accounts;
using AccountsModelCore.Classes.Accounts;

namespace AccountsViewModel.EntityViewModels.Classes.Accounts
{
    public class IncomeAccountViewModel
        : AccountViewModel
    {

        public IncomeAccountViewModel(
            IIncomeAccount entity,
            ITransactionChildCollectionViewModelFactory transactionfactory,
            IDictionary<string,
            List<string>> errors
            )
        : base(entity as IncomeAccount, transactionfactory, errors)
        {
        }

    }
}
