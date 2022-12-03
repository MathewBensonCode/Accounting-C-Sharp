using AccountLib.Interfaces.Accounts;
using AccountLib.Model.Accounts;
using AccountsViewModel.EntityViewModels.Classes;
using AccountsViewModel.EntityViewModels.Classes.Accounts;

namespace AccountsViewModelTests.EntityViewModel.Tests.Accounts
{
    public class CapitalAccountViewModelTests
        : AccountViewModelTests
    {
        protected override AccountViewModel AccountSut { get; set; }
        protected override Account Entity { get; set; }
        protected override EntityViewModel<Account> Sut { get; set; }

        public CapitalAccountViewModelTests()
        {
            Entity = new CapitalAccount();
            ICapitalAccount capitalaccount = (ICapitalAccount)Entity;
            AccountSut = new CapitalAccountViewModel(
                    capitalaccount,
                    Transactionfactory.Object,
                    ErrorCollection.Object
                    );
            Sut = AccountSut;
        }
    }
}
