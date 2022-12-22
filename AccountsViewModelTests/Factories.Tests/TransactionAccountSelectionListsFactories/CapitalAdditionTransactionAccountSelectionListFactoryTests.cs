using System.Collections.Generic;
using AccountsModelCore.Classes.Accounts;
using AccountsModelCore.Classes.Transactions;
using AccountsViewModel.Factories.TransactionAccountSelectionListFactories;
using AccountsViewModel.Repositories.Interfaces;
using Moq;
using Xunit;

namespace AccountsViewModelTests.Factories.Tests.TransactionAccountSelectionListsFactories
{
    public class CapitalAdditionTransactionAccountSelectionListFactoryTests
        : TransactionAccountSelectionListFactoryTests<CapitalAdditionTransaction>
    {
        private readonly Mock<IRepository<Account>> repository;
        private readonly Mock<ICollection<Account>> capitalaccounts;
        private readonly Mock<ICollection<Account>> currencyaccounts;
        private readonly CapitalAdditionTransactionAccountSelectionListFactory sut;

        public CapitalAdditionTransactionAccountSelectionListFactoryTests()
        {
            repository = new Mock<IRepository<Account>>();
            capitalaccounts = new Mock<ICollection<Account>>();
            currencyaccounts = new Mock<ICollection<Account>>();

            repository.As<IAccountRepository>().Setup(a => a.GetCapitalAccounts())
                .Returns(capitalaccounts.Object);
            repository.As<IAccountRepository>().Setup(r => r.GetCurrencyAccounts())
                .Returns(currencyaccounts.Object);

            sut = new CapitalAdditionTransactionAccountSelectionListFactory(
                repository.Object
                );

        }

        [Fact]
        public void DebitSelectionListShouldBeOfTypeCurrencyAccount()
        {
            Assert.Same(currencyaccounts.Object, sut.DebitAccountSelectionList);
        }

        [Fact]
        public void CreditSelectionListShouldBeOfTypeCapitalAccount()
        {
            Assert.Same(capitalaccounts.Object, sut.CreditAccountSelectionList);
        }
    }
}
