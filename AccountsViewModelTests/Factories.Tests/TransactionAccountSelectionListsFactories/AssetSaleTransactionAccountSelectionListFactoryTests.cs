using System.Collections.Generic;
using AccountsModelCore.Classes.Accounts;
using AccountsModelCore.Classes.Transactions;
using AccountsViewModel.Factories.TransactionAccountSelectionListFactories;
using AccountsViewModel.Repositories.Interfaces;
using Moq;
using Xunit;

namespace AccountsViewModelTests.Factories.Tests.TransactionAccountSelectionListsFactories
{
    public class AssetSaleTransactionAccountSelectionListFactoryTests
        : TransactionAccountSelectionListFactoryTests<AssetPurchaseTransaction>
    {
        private readonly Mock<IRepository<Account>> repository;
        private readonly Mock<ICollection<Account>> assetaccounts;
        private readonly Mock<ICollection<Account>> currencyaccounts;
        private readonly AssetSaleTransactionAccountSelectionListFactory sut;

        public AssetSaleTransactionAccountSelectionListFactoryTests()
        {
            repository = new Mock<IRepository<Account>>();
            assetaccounts = new Mock<ICollection<Account>>();
            currencyaccounts = new Mock<ICollection<Account>>();

            repository.As<IAccountRepository>().Setup(a => a.GetAssetAccounts())
                .Returns(assetaccounts.Object);
            repository.As<IAccountRepository>().Setup(r => r.GetCurrencyAccounts())
                .Returns(currencyaccounts.Object);

            sut = new AssetSaleTransactionAccountSelectionListFactory(
                repository.Object
                );

        }

        [Fact]
        public void DebitSelectionListShouldBeOfTypeCurrencyAccount()
        {
            Assert.Same(currencyaccounts.Object, sut.DebitAccountSelectionList);
        }

        [Fact]
        public void CreditSelectionListShouldBeOfTypeAssetAccount()
        {
            Assert.Same(assetaccounts.Object, sut.CreditAccountSelectionList);
        }
    }
}
