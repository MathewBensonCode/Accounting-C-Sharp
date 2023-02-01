using System.Collections.Generic;
using AccountsModelCore.Classes.Accounts;
using AccountsModelCore.Classes.Transactions;
using AccountsViewModel.Factories.TransactionAccountSelectionListFactories;
using AccountsViewModel.Repositories.Interfaces;
using Moq;
using Xunit;

namespace AccountsViewModelTests.Factories.Tests.TransactionAccountSelectionListsFactories
{
    public class IncomeTransactionAccountSelectionListFactoryTests
        : TransactionAccountSelectionListFactoryTests<IncomeTransaction>
    {
        private readonly Mock<IRepository<Account>> repository;
        private readonly Mock<ICollection<Account>> incomeaccounts;
        private readonly Mock<ICollection<Account>> currencyaccounts;
        private readonly IncomeTransactionAccountSelectionListFactory sut;

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
