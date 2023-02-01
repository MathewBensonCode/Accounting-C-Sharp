using System.Collections.Generic;
using AccountsViewModel.Factories.Interfaces.CollectionViewModelFactories;
using AccountsModelCore.Classes.Accounts;
using AccountsModelCore.Interfaces.Accounts;

namespace AccountsViewModel.EntityViewModels.Classes.Accounts
{
    public class ExpenseAccountViewModel
        : AccountViewModel
    {

        public ExpenseAccountViewModel(
            IExpenseAccount entity,
            ITransactionChildCollectionViewModelFactory transactionfactory,
            IDictionary<string,
            List<string>> errors
            )
        : base(entity as ExpenseAccount, transactionfactory, errors)
        {
        }

    }
}
