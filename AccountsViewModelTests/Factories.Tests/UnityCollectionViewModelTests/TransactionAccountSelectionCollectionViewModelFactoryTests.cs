using System;
using AccountsModelCore.Classes.Accounts;
using AccountsModelCore.Interfaces.Transactions;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CollectionViewModelFactories;
using AccountsViewModel.Factories.Unity.CollectionViewModelFactories;
using Moq;
using Unity;
using Xunit;

namespace AccountsViewModelTests.Factories.Tests.UnityCollectionViewModelTests
{
    public class TransactionAccountSelectionCollectionViewModelFactoryTests
    {
        private readonly Mock<IUnityContainer> container;
        private readonly Mock<IEntityCollectionViewModel<Account>> assetaccountcollectionviewmodel;
        private readonly Mock<IEntityCollectionViewModel<Account>> capitalaccountcollectionviewmodel;
        private readonly Mock<IEntityCollectionViewModel<Account>> currencyaccountcollectionviewmodel;
        private readonly Mock<IEntityCollectionViewModel<Account>> expenseaccountcollectionviewmodel;
        private readonly Mock<IEntityCollectionViewModel<Account>> incomeaccountcollectionviewmodel;
        private readonly Mock<IEntityCollectionViewModel<Account>> liabilityaccountcollectionviewmodel;
        private readonly TransactionAccountSelectionCollectionViewModelFactory sut;

        public TransactionAccountSelectionCollectionViewModelFactoryTests()
        {
            container = new Mock<IUnityContainer>();
            assetaccountcollectionviewmodel = new Mock<IEntityCollectionViewModel<Account>>();
            capitalaccountcollectionviewmodel = new Mock<IEntityCollectionViewModel<Account>>();
            currencyaccountcollectionviewmodel = new Mock<IEntityCollectionViewModel<Account>>();
            expenseaccountcollectionviewmodel = new Mock<IEntityCollectionViewModel<Account>>();
            incomeaccountcollectionviewmodel = new Mock<IEntityCollectionViewModel<Account>>();
            liabilityaccountcollectionviewmodel = new Mock<IEntityCollectionViewModel<Account>>();

            container.Setup(a => a.Resolve(typeof(IEntityCollectionViewModel<AssetAccount>), null, null))
                .Returns(assetaccountcollectionviewmodel.Object);
            container.Setup(a => a.Resolve(typeof(IEntityCollectionViewModel<CapitalAccount>), null, null))
                .Returns(capitalaccountcollectionviewmodel.Object);
            container.Setup(a => a.Resolve(typeof(IEntityCollectionViewModel<CurrencyAccount>), null, null))
                .Returns(currencyaccountcollectionviewmodel.Object);
            container.Setup(a => a.Resolve(typeof(IEntityCollectionViewModel<ExpenseAccount>), null, null))
                .Returns(expenseaccountcollectionviewmodel.Object);
            container.Setup(a => a.Resolve(typeof(IEntityCollectionViewModel<IncomeAccount>), null, null))
                .Returns(incomeaccountcollectionviewmodel.Object);
            container.Setup(a => a.Resolve(typeof(IEntityCollectionViewModel<LiabilityAccount>), null, null))
                .Returns(liabilityaccountcollectionviewmodel.Object);

            sut = new TransactionAccountSelectionCollectionViewModelFactory(
                    container.Object
                    );
        }

        [Fact]
        public void ShouldImplementITransactionAccountSelectionViewModelFactory()
        {
            Assert.IsAssignableFrom<ITransactionAccountSelectionCollectionViewModelFactory>(sut);
        }

        //null exception check
        [Fact]
        public void ShouldThrowArgumentNullExceptionWhenGettingDebitsAndTransactionIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => { sut.GetDebitAccountCollectionViewModelForTransaction(null); });
        }

        [Fact]
        public void ShouldThrowArgumentNullExceptionWhenGettingCreditsAndTransactionIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => { sut.GetCreditAccountCollectionViewModelForTransaction(null); });
        }

        //Asset Purchase Transaction
        [Fact]
        public void ShouldCreateAssetDebitAccountCollectionViewModelForAssetPurchaseTransaction()
        {
            var transaction = new Mock<IAssetPurchaseTransaction>();
            Assert.Same(assetaccountcollectionviewmodel.Object, sut.GetDebitAccountCollectionViewModelForTransaction(transaction.Object));
        }

        [Fact]
        public void ShouldCreateCurrencyCreditAccountCollectionViewModelForAssetPurchaseTransaction()
        {
            var transaction = new Mock<IAssetPurchaseTransaction>();
            Assert.Same(currencyaccountcollectionviewmodel.Object, sut.GetCreditAccountCollectionViewModelForTransaction(transaction.Object));
        }

        //Asset Sale Transaction

        [Fact]
        public void ShouldCreateCurrencyDebitAccountCollectionViewModelForAssetSaleTransaction()
        {
            var transaction = new Mock<IAssetSaleTransaction>();
            Assert.Same(currencyaccountcollectionviewmodel.Object, sut.GetDebitAccountCollectionViewModelForTransaction(transaction.Object));
        }

        [Fact]
        public void ShouldCreateAssetCreditAccountCollectionViewModelForAssetSaleTransaction()
        {
            var transaction = new Mock<IAssetSaleTransaction>();
            Assert.Same(assetaccountcollectionviewmodel.Object, sut.GetCreditAccountCollectionViewModelForTransaction(transaction.Object));
        }

        //Capital Addition Transaction

        [Fact]
        public void ShouldCreateCurrencyDebitAccountCollectionViewModelForCapitalAdditionTransaction()
        {
            var transaction = new Mock<ICapitalAdditionTransaction>();
            Assert.Same(currencyaccountcollectionviewmodel.Object, sut.GetDebitAccountCollectionViewModelForTransaction(transaction.Object));
        }

        [Fact]
        public void ShouldCreateCapitalCreditAccountCollectionViewModelForCapitalAdditionTransaction()
        {
            var transaction = new Mock<ICapitalAdditionTransaction>();
            Assert.Same(capitalaccountcollectionviewmodel.Object, sut.GetCreditAccountCollectionViewModelForTransaction(transaction.Object));
        }

        //Capital Drawing Transaction

        [Fact]
        public void ShouldCreateCapitalDebitAccountCollectionViewModelForCapitalDrawingTransaction()
        {
            var transaction = new Mock<ICapitalDrawingTransaction>();
            Assert.Same(capitalaccountcollectionviewmodel.Object, sut.GetDebitAccountCollectionViewModelForTransaction(transaction.Object));
        }

        [Fact]
        public void ShouldCreateCurrencyCreditAccountCollectionViewModelForCapitalDrawingTransaction()
        {
            var transaction = new Mock<ICapitalDrawingTransaction>();
            Assert.Same(currencyaccountcollectionviewmodel.Object, sut.GetCreditAccountCollectionViewModelForTransaction(transaction.Object));
        }

        //Expense Transaction

        [Fact]
        public void ShouldCreateExpenseDebitAccountCollectionViewModelForExpenseTransaction()
        {
            var transaction = new Mock<IExpenseTransaction>();
            Assert.Same(expenseaccountcollectionviewmodel.Object, sut.GetDebitAccountCollectionViewModelForTransaction(transaction.Object));
        }

        [Fact]
        public void ShouldCreateCurrencyCreditAccountCollectionViewModelForExpenseTransaction()
        {
            var transaction = new Mock<IExpenseTransaction>();
            Assert.Same(currencyaccountcollectionviewmodel.Object, sut.GetCreditAccountCollectionViewModelForTransaction(transaction.Object));
        }

        //Income Transaction

        [Fact]
        public void ShouldCreateCurrencyDebitAccountCollectionViewModelForIncomeTransaction()
        {
            var transaction = new Mock<IIncomeTransaction>();
            Assert.Same(currencyaccountcollectionviewmodel.Object, sut.GetDebitAccountCollectionViewModelForTransaction(transaction.Object));
        }

        [Fact]
        public void ShouldCreateIncomeCreditAccountCollectionViewModelForIncomeTransaction()
        {
            var transaction = new Mock<IIncomeTransaction>();
            Assert.Same(incomeaccountcollectionviewmodel.Object, sut.GetCreditAccountCollectionViewModelForTransaction(transaction.Object));
        }

        //LiabilityDecrease Transaction

        [Fact]
        public void ShouldCreateLiabilityDebitAccountCollectionViewModelForLiabilityDecreaseTransaction()
        {
            var transaction = new Mock<ILiabilityDecreaseTransaction>();
            Assert.Same(liabilityaccountcollectionviewmodel.Object, sut.GetDebitAccountCollectionViewModelForTransaction(transaction.Object));
        }

        [Fact]
        public void ShouldCreateCurrencyCreditAccountCollectionViewModelForLiabilityDecreaseTransaction()
        {
            var transaction = new Mock<ILiabilityDecreaseTransaction>();
            Assert.Same(currencyaccountcollectionviewmodel.Object, sut.GetCreditAccountCollectionViewModelForTransaction(transaction.Object));
        }

        //LiabilityIncrease Transaction

        [Fact]
        public void ShouldCreateCurrencyDebitAccountCollectionViewModelForLiabilityIncreaseTransaction()
        {
            var transaction = new Mock<ILiabilityIncreaseTransaction>();
            Assert.Same(currencyaccountcollectionviewmodel.Object, sut.GetDebitAccountCollectionViewModelForTransaction(transaction.Object));
        }

        [Fact]
        public void ShouldCreateLiabilityCreditAccountCollectionViewModelForLiabilityIncreaseTransaction()
        {
            var transaction = new Mock<ILiabilityIncreaseTransaction>();
            Assert.Same(liabilityaccountcollectionviewmodel.Object, sut.GetCreditAccountCollectionViewModelForTransaction(transaction.Object));
        }

    }
}
