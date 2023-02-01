using System.Collections.Generic;
using AccountsViewModel.Factories.Interfaces.CollectionViewModelFactories;
using AccountsModelCore.Classes.Accounts;
using AccountsModelCore.Interfaces.Accounts;

namespace AccountsViewModel.EntityViewModels.Classes.Accounts
{
    public class LiabilityAccountViewModel
        : AccountViewModel
    {
        public LiabilityAccountViewModel(
            ILiabilityAccount entity,
            ITransactionChildCollectionViewModelFactory transactionfactory,
            IDictionary<string,
            List<string>> errors
            )
        : base(entity as LiabilityAccount, transactionfactory, errors)
        {
        }

    }
}
