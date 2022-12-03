using AccountLib.Model.Accounts;
using AccountLib.Model.Transactions;
using Accounts.Repositories;
using Moq;
using System.Collections.Generic;
using AccountsViewModel.Factories.TransactionAccountSelectionListFactories;
using Xunit;

namespace AccountsViewModel.Xunit.Tests.Factories.Tests.TransactionAccountSelectionListsFactories
{
    public class IncomeTransactionAccountSelectionListFactoryTests
        : TransactionAccountSelectionListFactoryTests<IncomeTransaction>
    {
        Mock<IRepository<Account>> repository;
        Mock<ICollection<Account>> incomeaccounts;
        Mock<ICollection<Account>> currencyaccounts;
        IncomeTransactionAccountSelectionListFactory sut;
        public IncomeTransactionAccountSelectionListFactoryTests()
        {
            repository = new Mock<IRepository<Account>>();
            incomeaccounts = new Mock<ICollection<Account>>();
            currencyaccounts = new Mock<ICollection<Account>>();

            repository.As<IAccountRepository>().Setup(a => a.GetIncomeAccounts())
                .Returns(incomeaccounts.Object);
            repository.As<IAccountRepository>().Setup(r => r.GetCurrencyAccounts())
                .Returns(currencyaccounts.Object);

            sut = new IncomeTransactionAccountSelectionListFactory(
                repository.Object
                );

        }

        [Fact]
        public void DebitSelectionListShouldBeOfTypeCurrencyAccount()
        {
            Assert.Same(currencyaccounts.Object, sut.DebitAccountSelectionList);
        }

        [Fact]
        public void CreditSelectionListShouldBeOfTypeIncomeAccount()
        {
            Assert.Same(incomeaccounts.Object, sut.CreditAccountSelectionList);
        }
    }
}
