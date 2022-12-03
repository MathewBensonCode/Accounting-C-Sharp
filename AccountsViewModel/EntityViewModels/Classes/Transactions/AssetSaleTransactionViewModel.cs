using System.Collections.Generic;
using AccountLib.Interfaces.Transactions;
using AccountsViewModel.Factories.Interfaces.ViewModelFactories;

namespace AccountsViewModel.EntityViewModels.Classes.Transactions
{
    public class AssetSaleTransactionViewModel
        : TransactionViewModel
    {
        public AssetSaleTransactionViewModel(
            IAssetSaleTransaction entity,
            IAccountViewModelFactory accountViewModelFactory,
            ISourceDocumentViewModelFactory sourceDocumentViewModelFactory,
            IDictionary<string, List<string>> errors
            )
            : base(entity, accountViewModelFactory, sourceDocumentViewModelFactory, errors)
        {
        }
    }
}
