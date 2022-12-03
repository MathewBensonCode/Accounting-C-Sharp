using AccountLib.Interfaces.Accounts;
using AccountLib.Model.Accounts;
using AccountsViewModel.EntityViewModels.Classes;
using AccountsViewModel.EntityViewModels.Classes.Accounts;

namespace AccountsViewModelTests.EntityViewModel.Tests.Accounts
{
    public class ExpenseAccountViewModelTests
        : AccountViewModelTests
    {
        protected override AccountViewModel AccountSut { get; set; }
        protected override Account Entity { get; set; }
        protected override EntityViewModel<Account> Sut { get; set; }

        public ExpenseAccountViewModelTests()
        {
            Entity = new ExpenseAccount();
            IExpenseAccount expenseaccount = (IExpenseAccount)Entity;
            AccountSut = new ExpenseAccountViewModel(
                    expenseaccount,
                    Transactionfactory.Object,
                    ErrorCollection.Object
                    );
            Sut = AccountSut;
        }
    }
}
