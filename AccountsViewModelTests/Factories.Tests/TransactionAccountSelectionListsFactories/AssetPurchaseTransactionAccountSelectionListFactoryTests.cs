using AccountLib.Model.Accounts;
using AccountLib.Model.Transactions;
using Accounts.Repositories;
using Moq;
using System.Collections.Generic;
using AccountsViewModel.Factories.TransactionAccountSelectionListFactories;
using Xunit;

namespace AccountsViewModel.Xunit.Tests.Factories.Tests.TransactionAccountSelectionListsFactories
{
    public class AssetPurchaseTransactionAccountSelectionListFactoryTests
        :TransactionAccountSelectionListFactoryTests<AssetPurchaseTransaction>
    {
        Mock<IRepository<Account>> repository;
        Mock<ICollection<Account>> assetaccounts;
        Mock<ICollection<Account>> currencyaccounts;
        AssetPurchaseTransactionAccountSelectionListFactory sut;
        public AssetPurchaseTransactionAccountSelectionListFactoryTests()
        {
            repository = new Mock<IRepository<Account>>();
            assetaccounts = new Mock<ICollection<Account>>();
            currencyaccounts = new Mock<ICollection<Account>>();

            repository.As<IAccountRepository>().Setup(a => a.GetAssetAccounts())
                .Returns(assetaccounts.Object);
            repository.As<IAccountRepository>().Setup(r => r.GetCurrencyAccounts())
                .Returns(currencyaccounts.Object);



            sut = new AssetPurchaseTransactionAccountSelectionListFactory(
                repository.Object
                );

        }

        [Fact]
        public void DebitSelectionListShouldBeOfTypeAssetAccount()
        {
            Assert.Same(assetaccounts.Object, sut.DebitAccountSelectionList);
        }

        [Fact]
        public void CreditSelectionListShouldBeOfTypeCurrencyAccount()
        {
            Assert.Same(currencyaccounts.Object, sut.CreditAccountSelectionList);
        }
    }
}
