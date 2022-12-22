using AccountsModelCore.Classes.Accounts;
using AccountsViewModel.EntityViewModels.Classes;
using AccountsViewModel.EntityViewModels.Classes.Accounts;

namespace AccountsViewModelTests.EntityViewModel.Tests.Accounts
{
    public class AssetAccountViewModelTests
        : AccountViewModelTests
    {
        protected override AccountViewModel AccountSut { get; set; }
        protected override Account Entity { get; set; }
        protected override EntityViewModel<Account> Sut { get; set; }

        public AssetAccountViewModelTests()
        {
            var assetaccount = new AssetAccount();
            Entity = assetaccount;

            var assetAccountViewModel = new AssetAccountViewModel(
                                assetaccount,
                                Transactionfactory.Object,
                                ErrorCollection.Object
                                );

            AccountSut = assetAccountViewModel;

            Sut = AccountSut;
        }
    }
}
