using AccountLib.Model.Accounts;
using AccountLib.Model.Transactions;
using Accounts.Repositories;
using Moq;
using System.Collections.Generic;
using AccountsViewModel.Factories.TransactionAccountSelectionListFactories;
using Xunit;

namespace AccountsViewModel.Xunit.Tests.Factories.Tests.TransactionAccountSelectionListsFactories
{
    public class ExpenseTransactionAccountSelectionListFactoryTests
        : TransactionAccountSelectionListFactoryTests<ExpenseTransaction>
    {
        Mock<IRepository<Account>> repository;
        Mock<ICollection<Account>> expenseaccounts;
        Mock<ICollection<Account>> currencyaccounts;
        ExpenseTransactionAccountSelectionListFactory sut;
        public ExpenseTransactionAccountSelectionListFactoryTests()
        {
            repository = new Mock<IRepository<Account>>();
            expenseaccounts = new Mock<ICollection<Account>>();
            currencyaccounts = new Mock<ICollection<Account>>();

            repository.As<IAccountRepository>().Setup(a => a.GetExpenseAccounts())
                .Returns(expenseaccounts.Object);
            repository.As<IAccountRepository>().Setup(r => r.GetCurrencyAccounts())
                .Returns(currencyaccounts.Object);

            sut = new ExpenseTransactionAccountSelectionListFactory(
                repository.Object
                );

        }

        [Fact]
        public void DebitSelectionListShouldBeOfTypeExpenseAccount()
        {
            Assert.Same(expenseaccounts.Object, sut.DebitAccountSelectionList);
        }

        [Fact]
        public void CreditSelectionListShouldBeOfTypeCurrencyAccount()
        {
            Assert.Same(currencyaccounts.Object, sut.CreditAccountSelectionList);
        }
    }
}
