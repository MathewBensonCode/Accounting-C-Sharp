using AccountLib.Model.Accounts;
using AccountLib.Model.Transactions;
using Accounts.Repositories;
using Moq;
using System.Collections.Generic;
using AccountsViewModel.Factories.TransactionAccountSelectionListFactories;
using Xunit;

namespace AccountsViewModel.Xunit.Tests.Factories.Tests.TransactionAccountSelectionListsFactories
{
    public class LiabilityIncreaseTransactionAccountSelectionListFactoryTests
        : TransactionAccountSelectionListFactoryTests<LiabilityIncreaseTransaction>
    {
        Mock<IRepository<Account>> repository;
        Mock<ICollection<Account>> liabilityaccounts;
        Mock<ICollection<Account>> currencyaccounts;
        LiabilityIncreaseTransactionAccountSelectionListFactory sut;
        public LiabilityIncreaseTransactionAccountSelectionListFactoryTests()
        {
            repository = new Mock<IRepository<Account>>();
            liabilityaccounts = new Mock<ICollection<Account>>();
            currencyaccounts = new Mock<ICollection<Account>>();

            repository.As<IAccountRepository>().Setup(a => a.GetLiabilityAccounts())
                .Returns(liabilityaccounts.Object);
            repository.As<IAccountRepository>().Setup(r => r.GetCurrencyAccounts())
                .Returns(currencyaccounts.Object);

            sut = new LiabilityIncreaseTransactionAccountSelectionListFactory(
                repository.Object
                );

        }

        [Fact]
        public void DebitSelectionListShouldBeOfTypeCurrencyAccount()
        {
            Assert.Same(currencyaccounts.Object, sut.DebitAccountSelectionList);
        }

        [Fact]
        public void CreditSelectionListShouldBeOfTypeLiabilityAccount()
        {
            Assert.Same(liabilityaccounts.Object, sut.CreditAccountSelectionList);
        }
    }
}
