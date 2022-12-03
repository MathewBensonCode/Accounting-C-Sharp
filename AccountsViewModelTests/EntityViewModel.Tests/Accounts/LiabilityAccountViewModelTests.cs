using AccountLib.Interfaces.Accounts;
using AccountLib.Model.Accounts;
using AccountsViewModel.EntityViewModels.Classes;
using AccountsViewModel.EntityViewModels.Classes.Accounts;

namespace AccountsViewModelTests.EntityViewModel.Tests.Accounts
{
    public class LiabilityAccountViewModelTests
        : AccountViewModelTests
    {
        protected override AccountViewModel AccountSut { get; set; }
        protected override Account Entity { get; set; }
        protected override EntityViewModel<Account> Sut { get; set; }

        public LiabilityAccountViewModelTests()
        {
            Entity = new LiabilityAccount();
            var liabilityaccount = (ILiabilityAccount)Entity;

            AccountSut = new LiabilityAccountViewModel(
                    liabilityaccount,
                    Transactionfactory.Object,
                    ErrorCollection.Object
                    );

            Sut = AccountSut;
        }
    }
}
