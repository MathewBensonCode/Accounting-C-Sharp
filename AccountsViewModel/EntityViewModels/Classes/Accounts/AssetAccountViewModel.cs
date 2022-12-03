using System.Collections.Generic;
using AccountLib.Model.Accounts;
using AccountLib.Interfaces.Accounts;
using AccountsViewModel.Factories.Interfaces.CollectionViewModelFactories;

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
