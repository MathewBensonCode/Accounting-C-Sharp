using System.Collections.Generic;
using AccountLib.Interfaces.Transactions;
using AccountsViewModel.Factories.Interfaces.ViewModelFactories;

namespace AccountsViewModel.EntityViewModels.Classes.Transactions
{
    public class ExpenseTransactionViewModel
        : TransactionViewModel
    {
        public ExpenseTransactionViewModel(
            IExpenseTransaction entity,
            IAccountViewModelFactory accountViewModelFactory,
            ISourceDocumentViewModelFactory sourceDocumentViewModelFactory,
            IDictionary<string, List<string>> errors
            )
            : base(entity, accountViewModelFactory, sourceDocumentViewModelFactory, errors)
        {
        }
    }
}
