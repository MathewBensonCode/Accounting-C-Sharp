using AccountsModelCore.Classes.Accounts;
using AccountsModelCore.Interfaces.Accounts;
using AccountsViewModel.EntityViewModels.Classes;
using AccountsViewModel.EntityViewModels.Classes.Accounts;

namespace AccountsViewModelTests.EntityViewModel.Tests.Accounts
{
    public class IncomeAccountViewModelTests
        : AccountViewModelTests
    {
        protected override AccountViewModel AccountSut { get; set; }
        protected override Account Entity { get; set; }
        protected override EntityViewModel<Account> Sut { get; set; }

        public IncomeAccountViewModelTests()
        {
            Entity = new IncomeAccount();
            var incomeaccount = (IIncomeAccount)Entity;
            AccountSut = new IncomeAccountViewModel(
                    incomeaccount,
                    Transactionfactory.Object,
                    ErrorCollection.Object
                    );
            Sut = AccountSut;
        }
    }
}
