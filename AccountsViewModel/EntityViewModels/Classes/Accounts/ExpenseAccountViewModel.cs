using System.Collections.Generic;
using AccountLib.Model.Accounts;
using AccountLib.Interfaces.Accounts;
using AccountsViewModel.Factories.Interfaces.CollectionViewModelFactories;

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