using AccountLib.Model.Accounts;
using AccountLib.Model.Transactions;
using Accounts.Repositories;
using Moq;
using System.Collections.Generic;
using AccountsViewModel.Factories.TransactionAccountSelectionListFactories;
using Xunit;

namespace AccountsViewModel.Xunit.Tests.Factories.Tests.TransactionAccountSelectionListsFactories
{
    public class AssetSaleTransactionAccountSelectionListFactoryTests
        : TransactionAccountSelectionListFactoryTests<AssetPurchaseTransaction>
    {
        Mock<IRepository<Account>> repository;
        Mock<ICollection<Account>> assetaccounts;
        Mock<ICollection<Account>> currencyaccounts;
        AssetSaleTransactionAccountSelectionListFactory sut;
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
