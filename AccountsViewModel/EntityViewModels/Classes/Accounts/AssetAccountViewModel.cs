using System.Collections.Generic;
using AccountsViewModel.Factories.Interfaces.CollectionViewModelFactories;
using AccountsModelCore.Classes.Accounts;
using AccountsModelCore.Interfaces.Accounts;

namespace AccountsViewModel.EntityViewModels.Classes.Accounts
{
    public class AssetAccountViewModel
        : AccountViewModel
    {

        public AssetAccountViewModel(
            IAssetAccount entity,
            ITransactionChildCollectionViewModelFactory transactionfactory,
            IDictionary<string,
            List<string>> errors
            )
        : base(entity as AssetAccount, transactionfactory, errors)
        {
        }
    }
}
