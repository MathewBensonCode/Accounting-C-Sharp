using AccountLib.Model.Accounts;
using AccountLib.Model.Transactions;
using Accounts.Repositories;
using Moq;
using System.Collections.Generic;
using AccountsViewModel.Factories.TransactionAccountSelectionListFactories;
using Xunit;

namespace AccountsViewModel.Xunit.Tests.Factories.Tests.TransactionAccountSelectionListsFactories
{
    public class CapitalDrawingTransactionAccountSelectionListFactoryTests
        : TransactionAccountSelectionListFactoryTests<CapitalDrawingTransaction>
    {
        Mock<IRepository<Account>> repository;
        Mock<ICollection<Account>> capitalaccounts;
        Mock<ICollection<Account>> currencyaccounts;
        CapitalDrawingTransactionAccountSelectionListFactory sut;
        public CapitalDrawingTransactionAccountSelectionListFactoryTests()
        {
            repository = new Mock<IRepository<Account>>();
            capitalaccounts = new Mock<ICollection<Account>>();
            currencyaccounts = new Mock<ICollection<Account>>();

            repository.As<IAccountRepository>().Setup(a => a.GetCapitalAccounts())
                .Returns(capitalaccounts.Object);
            repository.As<IAccountRepository>().Setup(r => r.GetCurrencyAccounts())
                .Returns(currencyaccounts.Object);

            sut = new CapitalDrawingTransactionAccountSelectionListFactory(
                repository.Object
                );

        }

        [Fact]
        public void DebitSelectionListShouldBeOfTypeCapitalAccount()
        {
            Assert.Same(capitalaccounts.Object, sut.DebitAccountSelectionList);
        }

        [Fact]
        public void CreditSelectionListShouldBeOfTypeCurrencyAccount()
        {
            Assert.Same(currencyaccounts.Object, sut.CreditAccountSelectionList);
        }
    }
}
