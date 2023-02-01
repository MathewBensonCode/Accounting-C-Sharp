﻿using System.Collections.Generic;
using AccountsModelCore.Classes.Accounts;
using AccountsModelCore.Classes.Transactions;
using AccountsViewModel.Factories.TransactionAccountSelectionListFactories;
using AccountsViewModel.Repositories.Interfaces;
using Moq;
using Xunit;

namespace AccountsViewModelTests.Factories.Tests.TransactionAccountSelectionListsFactories
{
    public class LiabilityDecreaseTransactionAccountSelectionListFactoryTests
        : TransactionAccountSelectionListFactoryTests<LiabilityDecreaseTransaction>
    {
        private readonly Mock<IRepository<Account>> repository;
        private readonly Mock<ICollection<Account>> liabilityaccounts;
        private readonly Mock<ICollection<Account>> currencyaccounts;
        private readonly LiabilityDecreaseTransactionAccountSelectionListFactory sut;

        public LiabilityDecreaseTransactionAccountSelectionListFactoryTests()
        {
            repository = new Mock<IRepository<Account>>();
            liabilityaccounts = new Mock<ICollection<Account>>();
            currencyaccounts = new Mock<ICollection<Account>>();

            repository.As<IAccountRepository>().Setup(a => a.GetLiabilityAccounts())
                .Returns(liabilityaccounts.Object);
            repository.As<IAccountRepository>().Setup(r => r.GetCurrencyAccounts())
                .Returns(currencyaccounts.Object);

            sut = new LiabilityDecreaseTransactionAccountSelectionListFactory(
                repository.Object
                );

        }

        [Fact]
        public void DebitSelectionListShouldBeOfTypeLiabilityAccount()
        {
            Assert.Same(liabilityaccounts.Object, sut.DebitAccountSelectionList);
        }

        [Fact]
        public void CreditSelectionListShouldBeOfTypeCurrencyAccount()
        {
            Assert.Same(currencyaccounts.Object, sut.CreditAccountSelectionList);
        }
    }
}
