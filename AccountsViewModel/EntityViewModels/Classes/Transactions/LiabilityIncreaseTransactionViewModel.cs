using System.Collections.Generic;
using AccountLib.Interfaces.Transactions;
using AccountsViewModel.Factories.Interfaces.ViewModelFactories;

namespace AccountsViewModel.EntityViewModels.Classes.Transactions
{
    public class LiabilityIncreaseTransactionViewModel
        : TransactionViewModel
    {
        public LiabilityIncreaseTransactionViewModel(
            ILiabilityIncreaseTransaction entity,
            IAccountViewModelFactory accountViewModelFactory,
            ISourceDocumentViewModelFactory sourceDocumentViewModelFactory,
            IDictionary<string, List<string>> errors
            )
            : base(entity, accountViewModelFactory, sourceDocumentViewModelFactory, errors)
        {
        }
    }
}
