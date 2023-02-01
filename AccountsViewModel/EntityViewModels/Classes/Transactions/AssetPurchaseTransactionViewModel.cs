using System.Collections.Generic;
using AccountsModelCore.Interfaces.Transactions;
using AccountsViewModel.Factories.Interfaces.ViewModelFactories;

namespace AccountsViewModel.EntityViewModels.Classes.Transactions
{
    public class AssetPurchaseTransactionViewModel :
        TransactionViewModel
    {
        public AssetPurchaseTransactionViewModel(
            IAssetPurchaseTransaction entity,
            IAccountViewModelFactory accountViewModelFactory,
            ISourceDocumentViewModelFactory sourceDocumentViewModelFactory,
            IDictionary<string, List<string>> errors
            )
             : base(entity, accountViewModelFactory, sourceDocumentViewModelFactory, errors)
        {
        }
    }
}
