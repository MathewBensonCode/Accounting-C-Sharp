using System.Collections.Generic;
using AccountLib.Model.Accounts;
using AccountLib.Interfaces.Accounts;
using AccountsViewModel.Factories.Interfaces.CollectionViewModelFactories;

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
