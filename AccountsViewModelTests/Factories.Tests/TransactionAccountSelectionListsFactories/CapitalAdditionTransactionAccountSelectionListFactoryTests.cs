using AccountLib.Model.Accounts;
using AccountLib.Model.Transactions;
using Accounts.Repositories;
using Moq;
using System.Collections.Generic;
using AccountsViewModel.Factories.TransactionAccountSelectionListFactories;
using Xunit;

namespace AccountsViewModel.Xunit.Tests.Factories.Tests.TransactionAccountSelectionListsFactories
{
    public class CapitalAdditionTransactionAccountSelectionListFactoryTests
        : TransactionAccountSelectionListFactoryTests<CapitalAdditionTransaction>
    {
        Mock<IRepository<Account>> repository;
        Mock<ICollection<Account>> capitalaccounts;
        Mock<ICollection<Account>> currencyaccounts;
        CapitalAdditionTransactionAccountSelectionListFactory sut;
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
